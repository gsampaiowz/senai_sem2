import React from "react";
import MainContent from "../../components/MainContent/MainContent";
import Banner from "../../components/Banner/Banner";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "./../../components/ContactSection/ContactSection";
import NextEvent from "../../components/NextEvent/NextEvent";
import Title from "../../components/Title/Title";
import Container from "../../components/Container/Container";
import "./HomePage.css";

const HomePage = () => {
  return (
    <MainContent>
      <Banner />
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Próximos Eventos"} />

          <div className="events-box">
            <NextEvent
              title={"Baile do Código"}
              description={"Comemoração"}
              eventDate={"14/11/2023"}
              idEvento={1}
            />
            <NextEvent
              title={"Baile do Código"}
              description={"Comemoração"}
              eventDate={"14/11/2023"}
              idEvento={2}
              />
          </div>
              </Container>
          <VisionSection />
          <ContactSection />
      </section>
    </MainContent>
  );
};

export default HomePage;
