import React from "react";
import "./HomePage.css";
import Titulo from "../../components/Titulo/Titulo";
import CardEvento from "../../components/CardEvento/CardEvento";
import Contador from "../../components/Contador/Contador";

const HomePage = () => {
  return (
    <div className="App">
      <h1>My App</h1>
      <Titulo />
      <Titulo texto="React" />
      <div className="cards">
        <CardEvento
          tituloTexto="React"
          descricaoTexto="O react é uma biblioteca do javascript que nos ajuda a criar interfaces UI de forma mais performática."
          botaoTexto="Conectar"
        />
        <CardEvento
          disabled
          tituloTexto="React"
          descricaoTexto="O react é uma biblioteca do javascript que nos ajuda a criar interfaces UI de forma mais performática."
          botaoTexto="Conectar"
        />
      </div>
      <Contador />
    </div>
  );
};

export default HomePage;
