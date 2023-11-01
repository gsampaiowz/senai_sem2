import React from "react";
import "./Button.css";

const Button = (props) => {
  return (
    <>
      <button type={props.tipo}>{props.textoBotao}</button>
      
    </>
  );
};

export default Button;
