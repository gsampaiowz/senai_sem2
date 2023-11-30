import React, { useContext } from "react";
import "./PerfilUsuario.css";
import iconeLogout from "../../assets/images/icone-logout.svg";
import { userContext } from "../../context/AuthContext";
import { Link, useNavigate } from "react-router-dom";

const PerfilUsuario = () => {
  const { userData, setUserData } = useContext(userContext);

  const navigate = useNavigate();

  const logout = () => {
    localStorage.clear();
    setUserData({});
    navigate("/login");
  };

  return (
    <div className="perfil-usuario">
      {userData.name ? (
        <>
          <span className="perfil-usuario__menuitem">{userData.name}</span>

          <img
            onClick={logout}
            title="Deslogar"
            className="perfil-usuario__icon"
            src={iconeLogout}
            alt="imagem ilustrativa de uma porta de saída do usuário "
          />
        </>
      ) : (
        <Link className="perfil-usuario__menuitem" to="/login">
          Login
        </Link>
      )}
    </div>
  );
};

export default PerfilUsuario;
