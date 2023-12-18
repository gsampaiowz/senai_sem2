import React, { useContext, useEffect, useState } from "react";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import logo from "../../assets/images/logo-pink.svg";
import { Input, Button } from "../../components/FormComponents/FormComponents";
import imageLogin from "../../assets/images/login.svg";
import imageCadastro from "../../assets/images/cadastro-image.svg";
import api from "../../Services/Service";
import Notification from "../../components/Notification/Notification";
import { userContext, userDecodeToken } from "../../context/AuthContext";
import { useNavigate } from "react-router-dom";
import "./LoginPage.css";
import { motion } from 'framer-motion';

const LoginPage = () => {
  const [user, setUser] = useState({ email: "", senha: "" });
  const [senha, setSenha] = useState("");
  const [nome, setNome] = useState("");

  const [notifyUser, setNotifyUser] = useState({});

  const [cadastro, setCadastro] = useState(false);

  const { userData, setUserData } = useContext(userContext);

  const navigate = useNavigate();

  const idAluno = "64d8b0e8-9ae2-46cc-8415-fbf22fc90353";

  useEffect(() => {
    if (userData.name) {
      navigate("/");
    }
  }, [userData, navigate]);

  async function handleSubmit(e) {
    e.preventDefault();

    if (user.email.length >= 3 && user.senha.length >= 3) {
      try {
        const promise = await api.post("/Login", {
          email: user.email,
          senha: user.senha,
        });

        const userFullToken = userDecodeToken(promise.data.token);
        setUserData(userFullToken); //guarda os dados decodificados (payload)
        localStorage.setItem("token", JSON.stringify(userFullToken));
        navigate("/"); //manda o usuário para a página inicial

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
          imgAlt: "Erro no login",
          showMessage: true,
        });
      }
    } else {
      setNotifyUser({
        titleNote: "Falha",
        textNote: `Dados inválidos!`,
        imgIcon: "warning",
        imgAlt: "Aviso de dados inválidos",
        showMessage: true,
      });
    }
  }

  async function handleRegister(e) {
    e.preventDefault();

    try {
      if (
        user.email.length < 3 &&
        user.senha.length < 3 &&
        senha.length < 3 &&
        nome.length < 3
      )
        return setNotifyUser({
          titleNote: "Falha",
          textNote: `Preencha os campos corretamente!`,
          imgIcon: "warning",
          imgAlt: "Aviso de dados inválidos",
          showMessage: true,
        });

      if (user.senha !== senha)
        return setNotifyUser({
          titleNote: "Erro",
          textNote: `Senhas não conferem!`,
          imgIcon: "danger",
          imgAlt:
            "Imagem de ilustração de erro. Moça segurando um balão com símbolo de erro.",
          showMessage: true,
        });

      await api.post("/Usuario", {
        nome: nome,
        email: user.email,
        senha: user.senha,
        idTipoUsuario: idAluno,
      });
      setCadastro(false);
      setUser({ email: "", senha: "" });
      setSenha("");
      setNome("");
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    } catch (error) {
      console.error("Erro no cadastro: " + error);
      setNotifyUser({
        titleNote: "Falha",
        textNote: `Falha ao cadastrar!`,
        imgIcon: "danger",
        imgAlt: "Erro no cadastro",
        showMessage: true,
      });
    }
  }

  return (
    <div className="layout-grid-login">
      <motion.div
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.5 }}
      >
        <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
        <div className="login">
          <div className="login__illustration">
            <div className="login__illustration-rotate"></div>
            <button
              className="botao-setcadastro"
              onClick={() => setCadastro(!cadastro)}
            >
              {!cadastro ? "Criar conta" : "Fazer login"}
            </button>
            <ImageIllustrator
              imageRender={cadastro ? imageCadastro : imageLogin}
              alterText="Imagem de um homem em frente de uma porta de entrada"
              additionalClass="login-illustrator "
            />
          </div>

          <div className="frm-login">
            <img src={logo} className="frm-login__logo" alt="Logo event+" />

            <form
              className="frm-login__formbox"
              onSubmit={cadastro ? handleRegister : handleSubmit}
            >
              {cadastro && (
                <Input
                  additionalClass="frm-login__entry"
                  type="text"
                  id="nome"
                  name="nome"
                  required={true}
                  value={nome}
                  manipulationFunction={(e) => {
                    setNome(e.target.value.trim());
                  }}
                  placeholder="Nome"
                />
              )}
              <Input
                additionalClass="frm-login__entry"
                type="email"
                id="login"
                name="login"
                required={true}
                value={user.email}
                manipulationFunction={(e) => {
                  setUser({ ...user, email: e.target.value.trim() });
                }}
                placeholder="Email"
              />
              <Input
                additionalClass="frm-login__entry"
                type="password"
                id="senha"
                name="senha"
                required={true}
                value={user.senha}
                manipulationFunction={(e) => {
                  setUser({ ...user, senha: e.target.value.trim() });
                }}
                placeholder="*****"
              />
              {cadastro && (
                <Input
                  additionalClass="frm-login__entry"
                  type="password"
                  id="confirmar-senha"
                  name="confirmar-senha"
                  required={true}
                  value={senha}
                  manipulationFunction={(e) => {
                    setSenha(e.target.value.trim());
                  }}
                  placeholder="*****"
                />
              )}

              <a href="/" className="frm-login__link">
                Esqueceu a senha?
              </a>

              <Button
                textButton={cadastro ? "Cadastrar" : "Entrar"}
                id="btn-login"
                name="btn-login"
                type="submit"
                className="frm-login__button"
              />
            </form>
          </div>
        </div>
      </motion.div>
    </div>
  );
};

export default LoginPage;
