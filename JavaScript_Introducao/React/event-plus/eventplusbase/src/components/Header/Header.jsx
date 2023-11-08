import React, { useState } from "react";
import "./Header.css";
import Container from "../Container/Container";
import Nav from "../Nav/Nav";
import PerfilUsuario from "./../PerfilUsuario/PerfilUsuario";
import menubar from "../../assets/images/menubar.png";

const Header = () => {
  const [exibeNavBar, setExibeNavBar] = useState(false);
  return (
    <header className="headerpage">
      <Container>
        <div className="header-flex">
          <img
            src={menubar}
            className="headerpage__menubar"
            alt="Imagem menu de barras. Serve para exibir ou ocultar o menu no smartphone"
            onClick={() => {
              setExibeNavBar(true);
            }}
          />

          <Nav setExibeNavBar={setExibeNavBar} exibeNavBar={exibeNavBar} />

          <PerfilUsuario />
        </div>
      </Container>
    </header>
  );
};

export default Header;
