import React, { useEffect, useState } from "react";
import Title from "./../../components/Title/Title";
import MainContent from "./../../components/MainContent/MainContent";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import Notification from "../../components/Notification/Notification";
import Container from "../../components/Container/Container";
import TableEventos from "./TableEventos/TableEventos";
import eventImage from "../../assets/images/evento.svg";
import Spinner from "../../components/Spinner/Spinner";
import {
  Input,
  Button,
  Select,
} from "../../components/FormComponents/FormComponents";
import api from "../../Services/Service";

import "./EventosPage.css";
const EventosPage = () => {
  //
  const [frmEdit, setFrmEdit] = useState(false);

  const [nomeEvento, setNomeEvento] = useState("");
  const [descricao, setDescricao] = useState("");
  const [idTipoEvento, setIdTipoEvento] = useState("");
  const [dataEvento, setDataEvento] = useState("");
  const [idInstituicao, setIdInstituicao] = useState("");

  const [eventos, setEventos] = useState([]);
  const [tiposEvento, setTiposEvento] = useState([]);
  const [instituicoes, setInstituicoes] = useState([]);

  const [idEvento, setIdEvento] = useState("");

  const [notifyUser, setNotifyUser] = useState({});

  const [showSpinner, setShowSpinner] = useState(true);

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

  async function getTiposEvento() {
    setShowSpinner(true);
    try {
      const promise = await api.get("/TiposEvento");
      setTiposEvento(promise.data);
    } catch (error) {
      console.error("Erro ao carregar tipos de eventos: " + error);
    }
    setShowSpinner(false);
  }

  async function getInstituicoes() {
    setShowSpinner(true);
    try {
      const promise = await api.get("/Instituicao");
      setInstituicoes(promise.data);
    } catch (error) {
      console.error("Erro ao carregar instituições: " + error);
    }
    setShowSpinner(false);
  }

  //LISTAGEM DE EVENTOS
  useEffect(() => {
    //chamar a api
    getEventos();
    getTiposEvento();
    getInstituicoes();
  }, []);

  //CADASTRAR EVENTO

  async function handleSubmit(e) {
    e.preventDefault();
    setShowSpinner(true);
    // parar o submit do formulário
    // validar pelo menos 3 caracteres
    //chamar a api

    if (nomeEvento.trim().length < 3) {
      setNotifyUser({
        titleNote: "Nome inválido",
        textNote: `digite pelo menos 3 caracteres!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de aviso. Moça pisando em um símbolo de exclamação.",
        showMessage: true,
      });
      return;
    }
    //chamar a api
    try {
      const promise = await api.post("/Evento", {
        nomeEvento,
        descricao,
        idTipoEvento,
        dataEvento,
        idInstituicao,
      });
      console.log(promise.data);
      getEventos();
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      setNomeEvento("");
      setDescricao("");
      setIdTipoEvento("");
      setIdInstituicao("");
      setDataEvento("");
    } catch (error) {
      console.error("Erro ao cadastrar evento: " + error);
    }

    //limpar o formulário
    setShowSpinner(false);
  }

  //MOSTRAR FORMULÁRIO DE EDIÇÃO

  function showUpdateForm(e) {
    setFrmEdit(true);
    setNomeEvento(e.nomeEvento);
    setDescricao(e.descricao);
    setIdTipoEvento(e.idTipoEvento);
    setIdInstituicao(e.idInstituicao);
    setDataEvento(e.dataEvento.slice(0, 10));
    window.scrollTo({ top: 0, behavior: "smooth" });
    setIdEvento(e.idEvento);
  }

  //ATUALIZAR EVENTO
  async function handleUpdate(e) {
    e.preventDefault();
    setShowSpinner(true);

    if (nomeEvento.trim().length < 3) {
      setNotifyUser({
        titleNote: "Nome inválido",
        textNote: `Digite pelo menos 3 caracteres!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de aviso. Moça pisando em um símbolo de exclamação.",
        showMessage: true,
      });
      return;
    }

    try {
      const promise = await api.put(`/Evento/${idEvento}`, {
        nomeEvento,
        descricao,
        idTipoEvento,
        dataEvento,
        idInstituicao,
      });
      console.log(promise.datas);
      getEventos();
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      setNomeEvento("");
      setFrmEdit(false);
    } catch (error) {
      console.error("Erro ao atualizar evento: " + error);
    }

    setShowSpinner(false);
  }

  //CANCELA EDIÇÃO
  function cancelUpdate() {
    setFrmEdit(false);
    setNomeEvento("");
    setDescricao("");
    setIdTipoEvento("");
    setIdInstituicao("");
    setDataEvento("");
  }

  //DELETAR EVENTO
  async function handleDelete(id) {
    setShowSpinner(true);
    try {
      eventos.filter((tipoEvento) => tipoEvento.idTipoEvento === id);
      const promise = await api.delete(`/Evento/${id}`);
      console.log(promise.data);
      getEventos();
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Deletado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    } catch (error) {
      console.error("Erro ao deletar tipo de evento: " + error);
    }
    setShowSpinner(false);
  }

  return (
    <MainContent>
      {/* Cadastro de eventos */}
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title
              titleText={"Página de Eventos"}
              additionalClass="margem-acima"
            />

            <ImageIllustrator
              alterText="Homem interagindo com uma plataforma"
              imageRender={eventImage}
            />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
              action=""
            >
              {!frmEdit ? (
                <>
                  <p>Tela de Cadastro</p>
                  <Input
                    id="nome-evento"
                    placeholder="Nome"
                    type="text"
                    name="nome-evento"
                    value={nomeEvento}
                    required
                    manipulationFunction={(e) => {
                      setNomeEvento(e.target.value);
                    }}
                  />
                  <Input
                    id="descricao"
                    placeholder="Descrição"
                    type="text"
                    name="descricao"
                    value={descricao}
                    required
                    manipulationFunction={(e) => {
                      setDescricao(e.target.value);
                    }}
                  />
                  <Select
                    id="tipo-evento"
                    name="tipo-evento"
                    object={tiposEvento}
                    required
                    value={idTipoEvento}
                    mapOption={(option) => (
                      <option
                        value={option.idTipoEvento}
                        key={option.idTipoEvento}
                      >
                        {option.titulo}
                      </option>
                    )}
                    manipulationFunction={(e) => {
                      setIdTipoEvento(e.target.value);
                    }}
                  />
                  <Select
                    value={idInstituicao}
                    id="instituicao"
                    name="instituicao"
                    required
                    mapOption={(option) => (
                      <option
                        value={option.idInstituicao}
                        key={option.idInstituicao}
                      >
                        {option.nomeFantasia}
                      </option>
                    )}
                    object={instituicoes}
                    manipulationFunction={(e) => {
                      setIdInstituicao(e.target.value);
                    }}
                  />
                  <Input
                    id="data-evento"
                    placeholder="Data"
                    type="date"
                    name="data-evento"
                    value={dataEvento}
                    required
                    manipulationFunction={(e) => {
                      setDataEvento(e.target.value);
                    }}
                  />
                  <Button
                    id="cadastrar"
                    type="submit"
                    name="cadastrar"
                    textButton="Cadastrar"
                  />
                </>
              ) : (
                <>
                  <p>Tela de Edição</p>
                  <Input
                    id="nome-evento"
                    placeholder="Nome"
                    type="text"
                    name="nome-evento"
                    value={nomeEvento}
                    required
                    manipulationFunction={(e) => {
                      setNomeEvento(e.target.value);
                    }}
                  />
                  <Input
                    id="descricao"
                    placeholder="Descrição"
                    type="text"
                    name="descricao"
                    value={descricao}
                    required
                    manipulationFunction={(e) => {
                      setDescricao(e.target.value);
                    }}
                  />
                  <Select
                    id="tipo-evento"
                    name="tipo-evento"
                    object={tiposEvento}
                    required
                    value={idTipoEvento}
                    mapOption={(option) => (
                      <option
                        value={option.idTipoEvento}
                        key={option.idTipoEvento}
                      >
                        {option.titulo}
                      </option>
                    )}
                    manipulationFunction={(e) => {
                      setIdTipoEvento(e.target.value);
                    }}
                  />
                  <Select
                    value={idInstituicao}
                    id="instituicao"
                    name="instituicao"
                    required
                    mapOption={(option) => (
                      <option
                        value={option.idInstituicao}
                        key={option.idInstituicao}
                      >
                        {option.nomeFantasia}
                      </option>
                    )}
                    object={instituicoes}
                    manipulationFunction={(e) => {
                      setIdInstituicao(e.target.value);
                    }}
                  />
                  <Input
                    id="data-evento"
                    placeholder="Data"
                    type="date"
                    name="data-evento"
                    value={dataEvento}
                    required
                    manipulationFunction={(e) => {
                      setDataEvento(e.target.value);
                    }}
                  />
                  <div className="buttons-editbox">
                    <Button
                      id="editar"
                      type="submit"
                      name="editar"
                      textButton="Editar"
                    />
                    <Button
                      id="cancelar"
                      type="reset"
                      manipulationFunction={cancelUpdate}
                      additionalClass="button-component--middle"
                      name="cancelar"
                      textButton="Cancelar"
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      {/* Listagem de tipo de eventos */}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de Eventos"} color="white" />

          <TableEventos
            dados={eventos}
            fnDelete={handleDelete}
            fnUpdate={showUpdateForm}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventosPage;
