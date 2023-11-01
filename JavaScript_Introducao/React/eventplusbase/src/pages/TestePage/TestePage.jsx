import React, { useState } from "react";
import Input from "../../components/Input/Input";
import Button from "../../components/Button/Button";
import "./TestePage.css";

const TestePage = () => {
  const [total, setTotal] = useState('');
  const [n1, setN1] = useState('');
  const [n2, setN2] = useState('');

  const handleCalcular = (e) => {
    e.preventDefault();
    setTotal(parseFloat(n1) + parseFloat(n2));
  };

  return (
    <div className="teste-page">
      <h1>Teste</h1>
      <h2>Calculadora</h2>
      <form onSubmit={handleCalcular}>
        <Input
          dicaCampo="Primeiro número"
          id="numero1"
          name="numero1"
          tipo="number"
          valor={n1}
          fnAltera={setN1}
        />
        <Input
          dicaCampo="Segundo número"
          id="numero2"
          name="numero2"
          tipo="number"
          valor={n2}
          fnAltera={setN2}
        />

        <Button tipo="submit" textoBotao="Somar" />
        <p>
          Resultado: <strong>{total}</strong>
        </p>
      </form>
    </div>
  );
};

export default TestePage;
