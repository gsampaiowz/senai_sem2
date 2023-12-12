import React, { useEffect, useState } from "react";
import "./DetalhesEvento.css";
import Container from "../../components/Container/Container";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Title/Title";
import api from "../../Services/Service";
import { useCallback } from "react";

const DetalhesEvento = () => {
  const idEvento = window.location.href
    .split("/")
    .at(window.location.href.split("/").length - 1);

  const [evento, setEvento] = useState({});

  const getEvento = useCallback(async () => {
    const promise = await api.get(`/Evento/${idEvento}`);
    setEvento(promise.data);
  }, [idEvento]);

  useEffect(() => {
    getEvento();
  }, [idEvento, getEvento]);

  return (
    <MainContent>
      <Container>
        <Title additionalClass="margem-acima" titleText={`Evento: ${evento.nomeEvento}`} />
        <p>Data: {new Date(evento.dataEvento).toLocaleDateString()}</p>
        <p>Descrição: {evento.descricao}</p>
        <p>Tipo evento: {evento.tipoEvento}</p>
      </Container>
    </MainContent>
  );
};

export default DetalhesEvento;
