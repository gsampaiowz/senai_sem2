import React, { useContext, useEffect, useState } from "react";
import { Link, NavLink } from "react-router-dom";
import "./Nav.css";

import logoMobile from "../../assets/images/logo-white.svg";
import logoDesktop from "../../assets/images/logo-pink.svg";
import { userContext } from "../../context/AuthContext";

const Nav = ({ setExibeNavBar, exibeNavBar }) => {
  const { userData } = useContext(userContext);

  const [windowWidth, setWindowWidth] = useState(window.innerWidth);

  useEffect(() => {
    const handleResize = () => setWindowWidth(window.innerWidth);
    window.onresize = handleResize;
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  return (
    <nav className={`navbar ${exibeNavBar ? "exibeNavbar" : ""}`}>
      <span onClick={() => setExibeNavBar(false)} className="navbar__close">
        x
      </span>

      <Link to="/">
        <img
          className="eventlogo__logo-image"
          src={windowWidth > 992 ? logoDesktop : logoMobile}
          alt="Event Plus Logo"
        />
      </Link>

      <div className="navbar__items-box">
        <NavLink to="/" className="navbar__item">
          Home
        </NavLink>
        {userData.role === "administrador" ? (
          <>
            <NavLink to="/eventos" className="navbar__item">
              Eventos
            </NavLink>

            <NavLink to="/tipos-de-eventos" className="navbar__item">
              Tipos de eventos
            </NavLink>
          </>
        ) : userData.role === "aluno" ? (
          <NavLink to="/eventos-aluno" className="navbar__item">
            Eventos Aluno
          </NavLink>
        ) : null}
      </div>
    </nav>
  );
};

export default Nav;
