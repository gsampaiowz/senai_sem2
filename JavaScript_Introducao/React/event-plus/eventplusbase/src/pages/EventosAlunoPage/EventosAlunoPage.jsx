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
  const [meusEventos, setMeusEventos] = useState([]);
  // select mocado
  const quaisEventos = [
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData } = useContext(userContext);

  //METODO PARA LISTAR EVENTOS
  async function getEventos() {
    setShowSpinner(true);
    try {
      const promise = await api.get("/Evento");
      setEventos(promise.data);
    } catch (error) {
      console.error("Erro ao carregar eventos: " + error);
    }
    setShowSpinner(false);
  }

  async function getMeusEventos() {
    setShowSpinner(true);
    try {
      const promise = await api.get(
        `/PresencasEvento/ListarMinhas/${userData.userId}`
      );

      let novosEventos = [];
      promise.data.forEach((e) => {
        novosEventos.push({...e.evento, situacao: e.situacao});
      });
      setMeusEventos(novosEventos);

      const dadosMarcados = verificaPresenca(eventos, promise.data);
      console.clear();
      console.log(dadosMarcados);

    } catch (error) {
      console.error("Erro ao carregar eventos: " + error);
    }
    setShowSpinner(false);
  }

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {
      //para cada evento (todos)
      //verifica se o aluno está participando do evento atual (x)
      for (let i = 0; i < eventsUser.length; i++) {
        if (arrAllEvents[x].idEvento === eventsUser[i].idEvento) {
          arrAllEvents[x].situacao = true;
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
    getMeusEventos();
  }, [userData]);

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  function handleConnect() {
    alert("Desenvolver a função conectar evento");
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
            dados={tipoEvento === "1" ? eventos : meusEventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
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
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
