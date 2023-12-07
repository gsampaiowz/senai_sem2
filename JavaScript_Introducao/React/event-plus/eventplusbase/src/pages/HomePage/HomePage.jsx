import React, { useContext, useEffect, useState } from "react";
import MainContent from "../../components/MainContent/MainContent";
import Banner from "../../components/Banner/Banner";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "./../../components/ContactSection/ContactSection";
import NextEvent from "../../components/NextEvent/NextEvent";
import Title from "../../components/Title/Title";
import Container from "../../components/Container/Container";
import api from "../../Services/Service";

// Importando Swiper React components
import { Swiper, SwiperSlide } from "swiper/react";
import { Pagination } from "swiper/modules";
// Estilização
import "swiper/css";
import "swiper/css/pagination";
import "./HomePage.css";
import { userContext } from "../../context/AuthContext";

const HomePage = () => {
  const { userData } = useContext(userContext);

  useEffect(() => {
    //chamar a api
    getProximosEventos();
  }, [userData]);

  async function getProximosEventos() {
    try {
      const promise = await api.get("/Evento/ListarProximos");
      const promiseEventos = await api.get(
        `/PresencasEvento/ListarMinhas/${userData.userId}`
      );
      verificaPresenca(promise.data, promiseEventos.data);

      // let novosEventos = [];
      // promiseEventos.data.forEach((e) => {
      //   novosEventos.push({
      //     ...e.evento,
      //     idPresencaEvento: e.idPresencaEvento,
      //     situacao: e.situacao,
      //   });
      // });

      setNextEvents(promise.data);
    } catch (error) {
      console.error("Erro ao carregar os eventos: " + error);
    }
  }
  // array de objetos - proximos eventos
  const [nextEvents, setNextEvents] = useState([]);

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

  async function handleConnect(idEvent, idPresent, connect = false) {
    if (connect === true) {
      try {
        await api.post("/PresencasEvento", {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent,
        });
        getProximosEventos();
      } catch (error) {
        console.log("Erro ao conectar" + error);
      }
      return;
    }
    //unconnect
    try {
      await api.delete(`/PresencasEvento/${idPresent}`);
      getProximosEventos();
    } catch (error) {
      console.log("Erro ao desconectar" + error);
    }
  }

  return (
    <MainContent>
      <Banner />
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Próximos Eventos"} />

          <div className="events-box">
            <Swiper
              breakpoints={{
                320: {
                  slidesPerView: 1,
                },
                992: {
                  slidesPerView: 3,
                },
              }}
              spaceBetween={20}
              pagination={{
                dynamicBullets: true,
                clickable: true,
              }}
              modules={[Pagination]}
              className="mySwiper"
            >
              {nextEvents.map((event, index) => (
                <SwiperSlide key={index}>
                  <NextEvent
                    style={{ flex: 1 }}
                    key={event.idEvento}
                    title={event.nomeEvento}
                    description={event.descricao}
                    eventDate={event.dataEvento}
                    idEvento={event.idEvento}
                    idSituacao={event.situacao}
                    conectar={(e) => {
                      e.preventDefault();
                      
                      return(handleConnect(
                        event.idEvento,
                        event.idPresencaEvento,
                        event.situacao ? false : true
                      ))
                      
                    }}
                  />
                </SwiperSlide>
              ))}
            </Swiper>
          </div>
        </Container>
        <VisionSection />
        <ContactSection />
      </section>
    </MainContent>
  );
};

export default HomePage;
