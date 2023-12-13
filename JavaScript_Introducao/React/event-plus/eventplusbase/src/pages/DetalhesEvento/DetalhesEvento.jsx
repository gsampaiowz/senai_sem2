import React, { useCallback, useEffect, useState } from "react";
import "./DetalhesEvento.css";
import Container from "../../components/Container/Container";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Title/Title";
import api from "../../Services/Service";
import { useParams } from "react-router-dom";

const DetalhesEvento = () => {
  const { idEvento } = useParams();

  const [evento, setEvento] = useState({});
  const [tipoEvento, setTipoEvento] = useState("");

  const getEvento = useCallback(async () => {
    try {
      const promise = await api.get(`/Evento/${idEvento}`);
      setEvento(promise.data);
      setTipoEvento(promise.data.tiposEvento.titulo);
    } catch (error) {
      console.log("Erro ao buscar evento", error);
    }
  },[idEvento]);
  useEffect(() => {
    getEvento();
  }, [idEvento, getEvento]);

  return (
    <MainContent>
      <Container>
        <Title
          additionalClass="margem-acima"
          titleText={`Evento: ${evento.nomeEvento}`}
        />
        <p>Data: {new Date(evento.dataEvento).toLocaleDateString()}</p>
        <p>Descrição: {evento.descricao}</p>
        <p>Tipo evento: {tipoEvento}</p>
      </Container>
    </MainContent>
  );
};

export default DetalhesEvento;
