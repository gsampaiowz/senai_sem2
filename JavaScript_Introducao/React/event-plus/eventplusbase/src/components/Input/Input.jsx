import React from "react";
import "./Input.css";

const Input = ({ tipo, id, nome, valor, dicaCampo, fnAltera }) => {
  return (
    <input
      className="numero"
      type={tipo}
      id={id}
      name={nome}
      value={valor}
      placeholder={dicaCampo}
      onChange={(e) => {
        fnAltera(e.target.value);
      }} //
    />
  );
};

export default Input;
