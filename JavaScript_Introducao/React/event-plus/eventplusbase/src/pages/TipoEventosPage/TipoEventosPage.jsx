import React, { useState } from "react";
import Title from "./../../components/Title/Title";
import MainContent from "./../../components/MainContent/MainContent";
import "./TipoEventosPage.css";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";

import Container from "../../components/Container/Container";
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
      console.log(retorno.data)
    } catch (error) {
      console.error(error + "Erro ao cadastrar tipo de evento")
    }

    //limpar o formulário
    setTitulo("");
  }

  function handleUpdate() {
    setFrmEdit(!frmEdit);
  }

  const [titulo, setTitulo] = useState("");

  return (
    <MainContent>
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
    </MainContent>
  );
};

export default TipoEventosPage;
