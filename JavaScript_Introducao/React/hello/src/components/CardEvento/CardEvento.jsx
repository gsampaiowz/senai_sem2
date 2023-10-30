import React from "react";

import "../../App.css";
import "./CardEvento.css";

const CardEvento = ({ tituloTexto, descricaoTexto, disabled = false, botaoTexto}) => {
  return (
    <div className="card-evento">
      <h2 className="card-evento__titulo">{tituloTexto}</h2>
      <p className="card-evento__descricao">{descricaoTexto}</p>
      <button className={`card-evento__conectar ${disabled ? 'card-evento__conectar--disabled' : ''}`}>
        {botaoTexto}
      </button>
    </div>
  );
};

export default CardEvento;
