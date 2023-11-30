import React, { useContext, useEffect, useState } from "react";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import logo from "../../assets/images/logo-pink.svg";
import { Input, Button } from "../../components/FormComponents/FormComponents";
import imageLogin from "../../assets/images/login.svg"

import api from "../../Services/Service";
import Notification from "../../components/Notification/Notification";
import { userContext, userDecodeToken } from "../../context/AuthContext";
import { useNavigate } from "react-router-dom";
import "./LoginPage.css";

const LoginPage = () => {
  const [user, setUser] = useState({ email: "adm@email.com", senha: "123123" });

  const [notifyUser, setNotifyUser] = useState({});

  const {userData, setUserData} = useContext(userContext)

  const navigate = useNavigate();

  useEffect(() => {
    if(userData.name){
      navigate("/")
    }
  }, [userData, navigate]);

  async function handleSubmit(e){
    e.preventDefault();
    
    if(user.email.length >= 3 && user.senha.length >= 3){
      try {
        const promise = await api.post("/Login", {
          email: user.email,
          senha: user.senha,
        });

        const userFullToken = userDecodeToken(promise.data.token);
        setUserData(userFullToken); //guarda os dados decodificados (payload)
        localStorage.setItem("token", JSON.stringify(userFullToken));
        navigate("/") //manda o usuário para a página inicial

        setNotifyUser({
          titleNote: "Sucesso",
          textNote: `Logado com sucesso!`,
          imgIcon: "success",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
      } catch (error) {
        console.error("Erro no login: " + error);
        setNotifyUser({
          titleNote: "Falha",
          textNote: `Falha ao logar!`,
          imgIcon: "danger",
          imgAlt:
            "Erro no login",
          showMessage: true,
        });
      }
    }else{
      setNotifyUser({
        titleNote: "Falha",
        textNote: `Dados inválidos!`,
        imgIcon: "warning",
        imgAlt:
          "Aviso de dados inválidos",
        showMessage: true,
      });
    }
  }

  return (
    <div className="layout-grid-login">
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      <div className="login">
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIllustrator
            imageRender={imageLogin}
            alterText="Imagem de um homem em frente de uma porta de entrada"
            additionalClass="login-illustrator "
          />
        </div>

        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="Logo event+" />

          <form className="frm-login__formbox" onSubmit={handleSubmit}>
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => {setUser({...user, email: e.target.value.trim()})}}
              placeholder="Username"
            />
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              manipulationFunction={(e) => {setUser({...user, senha: e.target.value.trim()})}}
              placeholder="****"
            />

            <a href="/" className="frm-login__link">
              Esqueceu a senha?
            </a>

            <Button
              textButton="Login"
              id="btn-login"
              name="btn-login"
              type="submit"
              className="frm-login__button"
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
