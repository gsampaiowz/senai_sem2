import React, { useCallback, useContext, useEffect, useState } from "react";
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
import { useNavigate } from "react-router-dom";
import { motion } from "framer-motion";

const HomePage = () => {
  const { userData } = useContext(userContext);

  // array de objetos - proximos eventos
  const [events, setEvents] = useState([]);

  const navigate = useNavigate();

  const getEventos = useCallback(async () => {
    try {
      const promise = await api.get("/Evento");
      if (userData.userId) {
        const promiseEventos = await api.get(
          `/PresencasEvento/ListarMinhas/${userData.userId}`
        );
        verificaPresenca(promise.data, promiseEventos.data);
      }

      setEvents(promise.data);
    } catch (error) {
      console.error("Erro ao carregar os eventos: " + error);
    }
  }, [userData]);

  useEffect(() => {
    //chamar a api
    getEventos();
  }, [userData, getEventos]);

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
    <MainContent>
      <motion.div
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.5 }}
      >
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
                {events
                  .filter((e) => e.dataEvento >= new Date().toJSON())
                  .map((event, index) => (
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

                          return userData.userId
                            ? handleConnect(
                                event.idEvento,
                                event.idPresencaEvento,
                                event.situacao ? false : true
                              )
                            : navigate("/login");
                        }}
                      />
                    </SwiperSlide>
                  ))}
              </Swiper>
            </div>

            <Title
              titleText={"Eventos passados"}
              additionalClass="margem-acima"
            />

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
                {events
                  .filter((e) => e.dataEvento < new Date().toJSON())
                  .map((event, index) => (
                    <SwiperSlide key={index}>
                      <NextEvent
                        style={{ flex: 1 }}
                        key={event.idEvento}
                        title={event.nomeEvento}
                        description={event.descricao}
                        eventDate={event.dataEvento}
                        idEvento={event.idEvento}
                        idSituacao={event.situacao}
                      />
                    </SwiperSlide>
                  ))}
              </Swiper>
            </div>
          </Container>
          <VisionSection />
          <ContactSection />
        </section>
      </motion.div>
    </MainContent>
  );
};

export default HomePage;
