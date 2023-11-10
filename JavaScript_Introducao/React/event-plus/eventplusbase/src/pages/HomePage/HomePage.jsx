import React, { useEffect, useState } from "react";
import MainContent from "../../components/MainContent/MainContent";
import Banner from "../../components/Banner/Banner";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "./../../components/ContactSection/ContactSection";
import NextEvent from "../../components/NextEvent/NextEvent";
import Title from "../../components/Title/Title";
import Container from "../../components/Container/Container";
import api from "../../Services/Service";

// Import Swiper React components
import { Swiper, SwiperSlide } from "swiper/react";
import { Pagination } from "swiper/modules";
// Import styles
import "swiper/css";
import "swiper/css/pagination";
import "./HomePage.css";

const HomePage = () => {
  useEffect(() => {
    //chamar a api
    async function getProximosEventos() {
      try {
        const promise = await api.get("/Evento/ListarProximos");
        console.log(promise.data);
        setNextEvents(promise.data);
      } catch (error) {
        console.error("Erro : " + error);
        alert("Erro ao carregar os eventos");
      }
    }

    getProximosEventos();
    console.log("A HOME FOI MONTADA!");
  }, []);

  // fake mock - api mocada
  const [nextEvents, setNextEvents] = useState([]);

  return (
    <MainContent>
      <Banner />
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Próximos Eventos"} />

          <div className="events-box">
            <Swiper
              slidesPerView={3}
              pagination={{
                dynamicBullets: true,
              }}
              modules={[Pagination]}
              className="mySwiper"
            >
              {nextEvents.map((event) => (
                <>
                  <SwiperSlide>
                    <NextEvent
                      key={event.idEvento}
                      title={event.nomeEvento}
                      description={event.descricao}
                      eventDate={event.dataEvento}
                      idEvento={event.idEvento}
                    />
                  </SwiperSlide>
                </>
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
