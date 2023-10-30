import React, { useState } from "react";
import "./Contador.css";

const Contador = () => {
  const [contador, setContador] = useState(0);
  const handleIncrementar = () => {
    setContador(contador + 1);
  };
  const handleDecrementar = () => {
    setContador(contador === 0 ? 0 : contador - 1);
  };
  return (
    <div className="contador">
      <button onClick={handleIncrementar} className="contador__botao">
        +
      </button>
      <span className="contador__valor">{contador}</span>
      <button onClick={handleDecrementar} className="contador__botao">
        -
      </button>
    </div>
  );
};

export default Contador;
