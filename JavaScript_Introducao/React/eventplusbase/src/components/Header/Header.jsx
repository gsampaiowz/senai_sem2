import React from "react";
import { Link } from "react-router-dom";
import "./Header.css";

const Header = () => {
  return (
    <header>
      <nav>
        <Link to="/">HomePage</Link>
        <Link to="/login">LoginPage</Link>
        <Link to="/eventos">EventosPage</Link>
        <Link to="/tipoeventos">TipoEventosPage</Link>
        <Link to="/teste">TestePage</Link>
      </nav>
    </header>
  );
};

export default Header;
