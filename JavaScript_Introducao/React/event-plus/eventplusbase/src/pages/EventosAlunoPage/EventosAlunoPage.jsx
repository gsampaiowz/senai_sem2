import React, { useContext, useEffect, useState } from "react";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Title/Title";
import Table from "./TableEva/Table";
import Container from "../../components/Container/Container";
import { Select } from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal";
import api from "../../Services/Service";

import "./EventosAlunoPage.css";
import { userContext } from "../../context/AuthContext";

const EventosAlunoPage = () => {
  const [eventos, setEventos] = useState([]);
  // select mocado
  const quaisEventos = [
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ];

  const [idEventoComentario, setIdEventoComentario] = useState("")
  const [comentario, setComentario] = useState("")

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData } = useContext(userContext);

  async function getEventos() {
    setShowSpinner(true);
    try {
      const promise = await api.get("/Evento");
      const promiseEventos = await api.get(
        `/PresencasEvento/ListarMinhas/${userData.userId}`
      );
      if (tipoEvento === "1") {
        verificaPresenca(promise.data, promiseEventos.data);
        setEventos(promise.data);
      } else {
        let novosEventos = [];

        promiseEventos.data.forEach((e) => {
          novosEventos.push({
            ...e.evento,
            idPresencaEvento: e.idPresencaEvento,
            situacao: e.situacao,
          });
        });
        setEventos(novosEventos);
      }
    } catch (error) {
      console.error("Erro ao carregar eventos: " + error);
    }
    setShowSpinner(false);
  }

  //verificar presença
  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {
      //para cada evento (todos)
      //verifica se o aluno está participando do evento atual (x)
      for (let i = 0; i < eventsUser.length; i++) {
        if (arrAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;
          break;
        }
      }
    }

    return arrAllEvents;
  };

  //LISTAGEM DE EVENTOS
  useEffect(() => {
    //chamar a api
    getEventos();
  }, [userData, tipoEvento]);

  const showHideModal = (idEvento) => {
    setShowModal(showModal ? false : true);
    setIdEventoComentario(idEvento)
  };

  async function loadMyComentary() {
    const promiseComentario = await api.get(
      `/ComentariosEvento/BuscarPorIdUsuario?idUsuario=${userData.userId}&idEvento=${idEventoComentario}`
    );
    setComentario(promiseComentario.data.descricao)
  }

  const commentaryRemove = async () => {
    alert("Remover o comentário");
  };

  const commentaryAdd = async (commentary) => {
    await api.post(`/ComentariosEvento/`, {descricao: commentary, exibe: true, idUsuario: userData.userId, idEvento: idEventoComentario})
  };

  const commentaryEdit = async (commentary) => {
    alert("Edit comentário");
  };

  async function handleConnect(idEvent, idPresent, connect = false) {
    if (connect === true) {
      try {
        await api.post("/PresencasEvento", {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent,
        });
        getEventos();
      } catch (error) {
        console.log("Erro ao conectar" + error);
      }
      return;
    }
    //unconnect
    try {
      await api.delete(`/PresencasEvento/${idPresent}`);
      getEventos();
    } catch (error) {
      console.log("Erro ao desconectar" + error);
    }
  }

  return (
    <>
      <MainContent>
        <Container>
          <Title titleText={"Eventos"} additionalClass="margem-acima" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            object={quaisEventos}
            mapOption={(option) => (
              <option value={option.value} key={option.value}>
                {option.text}
              </option>
            )}
            manipulationFunction={(e) => {
              setTipoEvento(e.target.value);
            }} // aqui só a variável state
            value={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={showHideModal}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
          fnPost={commentaryAdd}
          fnPut={commentaryEdit}
          fnGet={loadMyComentary}
          comentaryText={comentario}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
