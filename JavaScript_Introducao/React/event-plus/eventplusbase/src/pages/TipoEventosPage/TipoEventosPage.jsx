import React, { useEffect, useState } from "react";
import Title from "./../../components/Title/Title";
import MainContent from "./../../components/MainContent/MainContent";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import Notification from "../../components/Notification/Notification";

import Container from "../../components/Container/Container";
import TableTp from "./TableTp/TableTp";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Spinner from "../../components/Spinner/Spinner";

import { Input, Button } from "../../components/FormComponents/FormComponents";

import api from "../../Services/Service";
import "./TipoEventosPage.css";

const TipoEventosPage = () => {
  //
  const [frmEdit, setFrmEdit] = useState(false);

  const [titulo, setTitulo] = useState("");

  const [tiposEvento, setTiposEvento] = useState([]);

  const [idTipoEvento, setIdTipoEvento] = useState("");

  const [notifyUser, setNotifyUser] = useState({});

  const [showSpinner, setShowSpinner] = useState(true);

  //METODO PARA LISTAR EVENTOS
  async function getTiposEventos() {
    setShowSpinner(true);
    try {
      const promise = await api.get("/TiposEvento");
      setTiposEvento(promise.data);
    } catch (error) {
      console.error("Erro ao carregar tipos de evento: " + error);
    }
    setShowSpinner(false);
  }

  //LISTAGEM DE TIPOS DE EVENTOS
  useEffect(() => {
    //chamar a api
    getTiposEventos();
  }, []);

  //CADASTRAR TIPO DE EVENTO

  async function handleSubmit(e) {
    e.preventDefault();
    setShowSpinner(true);
    // parar o submit do formulário
    // validar pelo menos 3 caracteres
    //chamar a api

    if (titulo.trim().length < 3) {
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
      const promise = await api.post("/TiposEvento", { titulo });
      console.log(promise.data);
      getTiposEventos();
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    } catch (error) {
      console.error(error + "Erro ao cadastrar tipo de evento");
    }

    //limpar o formulário
    setTitulo("");
    setShowSpinner(false);
  }

  //MOSTRAR FORMULÁRIO DE EDIÇÃO

  function showUpdateForm(tipoEvento) {
    setFrmEdit(true);
    setTitulo(tipoEvento.titulo);
    window.scrollTo({ top: 0, behavior: "smooth" });
    setIdTipoEvento(tipoEvento.idTipoEvento);
  }
  //ATUALIZAR TIPO DE EVENTO
  async function handleUpdate(e) {
    e.preventDefault();
    setShowSpinner(true);

    if (titulo.trim().length < 3) {
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
      const promise = await api.put(`/TiposEvento/${idTipoEvento}`, {
        titulo,
      });
      console.log(promise.data);
      getTiposEventos();
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      setTitulo("");
      setFrmEdit(false);
    } catch (error) {
      console.error("Erro ao atualizar tipo de evento: " + error);
    }

    setShowSpinner(false);
  }

  function cancelUpdate() {
    setFrmEdit(false);
    setTitulo("");
  }

  async function handleDelete(id) {
    setShowSpinner(true);
    try {
      tiposEvento.filter((tipoEvento) => tipoEvento.idTipoEvento === id);
      const promise = await api.delete(`/TiposEvento/${id}`);
      console.log(promise.data);
      getTiposEventos();
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
      {/* Cadastro de tipo de eventos */}
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title
              titleText={"Página Tipos de Eventos"}
              additionalClass="margem-acima"
            />

            <ImageIllustrator
              alterText="Homem e mulher interagindo com a tela de um computador"
              imageRender={eventTypeImage}
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
                    id="titulo"
                    placeholder="Título"
                    type="text"
                    name="titulo"
                    value={titulo}
                    required
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
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
                    id="titulo"
                    placeholder="Título"
                    type="text"
                    name="titulo"
                    value={titulo}
                    required
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
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
          <Title titleText={"Lista Tipo de Eventos"} color="white" />

          <TableTp
            dados={tiposEvento}
            fnDelete={handleDelete}
            fnUpdate={showUpdateForm}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;
