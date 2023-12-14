import React, { useCallback, useEffect, useState } from "react";
import "./DetalhesEvento.css";
import Container from "../../components/Container/Container";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Title/Title";
import api from "../../Services/Service";
import { useParams } from "react-router-dom";
import TableComentarios from "./TableComentarios/TableComentarios";

const DetalhesEvento = () => {
  const { idEvento } = useParams();

  const [evento, setEvento] = useState({});
  const [tipoEvento, setTipoEvento] = useState("");
  const [instituicao, setInstituicao] = useState("");

  const [comentarios, setComentarios] = useState([]);

  const getEvento = useCallback(async () => {
    try {
      const promise = await api.get(`/Evento/${idEvento}`);
      setEvento(promise.data);
      setTipoEvento(promise.data.tiposEvento.titulo);
      setInstituicao(promise.data.instituicao.nomeFantasia);
    } catch (error) {
      console.log("Erro ao buscar evento", error);
    }
  }, [idEvento]);

  const getComentario = useCallback(async () => {
    try {
      const promise = await api.get(`/ComentariosEvento/ListarSomenteExibe?id=${idEvento}`);
      setComentarios(promise.data);
    } catch (error) {
      console.log("Erro ao buscar comentario", error);
    }
  }, [idEvento]);

  const deleteComentario = async (idComentario) => {
    try {
      await api.delete(`/ComentariosEvento/${idComentario}`);
    } catch (error) {
      console.log("Erro ao deletar comentario", error);
    }
  };

  const exibeComentario = async (idComentario, descricao, exibe = false) => {
    try {
      await api.put(`/ComentariosEvento?id=${idComentario}`,{descricao, exibe});
      getComentario()
    } catch (error) {
      console.log("Erro ao deletar comentario", error);
    }
  };

  useEffect(() => {
    getEvento();
    getComentario();
  }, [idEvento, getEvento, getComentario]);

  return (
    <MainContent>
      <section className="detalhes-evento-main">
        <Container>
          <div className="detalhes-evento-page">
            <Title
              additionalClass="margem-acima"
              titleText={`Evento: ${evento.nomeEvento}`}
            />
            <div className="detalhes-evento-flex">
              <p className="detalhe-evento-propriedade">
                <b>Data:</b> {new Date(evento.dataEvento).toLocaleDateString()}
              </p>
              <p className="detalhe-evento-propriedade">
                <b>Tipo evento:</b> {tipoEvento}
              </p>
              <p className="detalhe-evento-propriedade">
                <b>Instituição:</b> {instituicao}
              </p>
            </div>
            <p className="detalhe-evento-propriedade">
              <b>Descrição:</b> <br /> {evento.descricao}
            </p>
          </div>
        </Container>
      </section>
      <section className="lista-comentarios-section">
        <Container>
          <Title
            additionalClass="margem-acima"
            titleText={"Lista de comentários"}
            color="white"
          ></Title>

          <TableComentarios fnExibe={exibeComentario} dados={comentarios} fnDelete={deleteComentario} />
        </Container>
      </section>
    </MainContent>
  );
};

export default DetalhesEvento;
