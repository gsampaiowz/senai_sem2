import React, { useContext } from "react";
import { Link } from "react-router-dom";
import "./Nav.css";

import logoMobile from "../../assets/images/logo-white.svg";
import logoDesktop from "../../assets/images/logo-pink.svg";
import { userContext } from "../../context/AuthContext";

const Nav = ({ setExibeNavBar, exibeNavBar }) => {
  const { userData } = useContext(userContext);

  return (
    <nav className={`navbar ${exibeNavBar ? "exibeNavbar" : ""}`}>
      <span onClick={() => setExibeNavBar(false)} className="navbar__close">
        x
      </span>

      <Link to="/">
        <img
          className="eventlogo__logo-image"
          src={window.innerWidth > 992 ? logoDesktop : logoMobile}
          alt="Event Plus Logo"
        />
      </Link>

      <div className="navbar__items-box">
        <Link to="/" className="navbar__item">
          Home
        </Link>
        {userData.role === "administrador" ? (
          <>
            <Link to="/eventos" className="navbar__item">
              Eventos
            </Link>

            <Link to="/tipos-de-eventos" className="navbar__item">
              Tipos de eventos
            </Link>
          </>
        ) : userData.role === "aluno" ? (
          <Link to="/eventos-aluno" className="navbar__item">
            Eventos Aluno
          </Link>
        ) : null}

        <Link to="/login" className="navbar__item">
          Login
        </Link>
      </div>
    </nav>
  );
};

export default Nav;
