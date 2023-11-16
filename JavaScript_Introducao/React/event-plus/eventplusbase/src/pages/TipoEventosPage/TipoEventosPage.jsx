import React, { useEffect, useState } from "react";
import Title from "./../../components/Title/Title";
import MainContent from "./../../components/MainContent/MainContent";
import "./TipoEventosPage.css";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";

import Container from "../../components/Container/Container";
import TableTp from "./TableTp/TableTp";
import eventTypeImage from "../../assets/images/tipo-evento.svg";

import { Input, Button } from "../../components/FormComponents/FormComponents";

import api from "../../Services/Service";

const TipoEventosPage = () => {
  const [frmEdit, setFrmEdit] = useState(false);

  async function handleSubmit(e) {
    e.preventDefault();
    // parar o submit do formulário
    // validar pelo menos 3 caracteres
    //chamar a api

    if (titulo.trim().length < 3) {
      alert("Digite pelo menos 3 caracteres");
    }
    //chamar a api
    try {
      const retorno = await api.post("/TiposEvento", { titulo });
      console.log(retorno.data);
    } catch (error) {
      console.error(error + "Erro ao cadastrar tipo de evento");
    }

    //limpar o formulário
    setTitulo("");
  }

  function showUpdateForm() {
    setFrmEdit(true);
  }

  function handleUpdate() {
    setFrmEdit(!frmEdit);
  }

  function cancelUpdate() {
    setFrmEdit(false);
  }

  const [titulo, setTitulo] = useState("");

  const [tiposEvento, setTiposEvento] = useState([]);

  useEffect(() => {
    //chamar a api
    async function getTitulos() {
      try {
        const promise = await api.get("/TiposEvento");
        setTiposEvento(promise.data);
      } catch (error) {
        console.error("Erro ao carregar tipos de evento: " + error);
      }
    }

    getTitulos();
  }, [tiposEvento]);

  async function handleDelete(id) {
    try {
      const promise = await api.delete(`/TiposEvento/${id}`);
      console.log(promise.data);
    } catch (error) {
      console.error("Erro ao deletar tipo de evento: " + error);
    }
  }

  return (
    <MainContent>
      {/* Cadastro de tipo de eventos */}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title
              titleText={"Página Tipos de Eventos"}
              additionalClass="margem-acima"
            />

            <ImageIllustrator alterText="??????" imageRender={eventTypeImage} />

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
                <p>Tela de Edição</p>
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
