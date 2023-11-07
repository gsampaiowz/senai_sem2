import React from "react";
import Title from "../../components/Title/Title";
import MainContent from "../../components/MainContent/MainContent";
import Banner from "../../components/Banner/Banner";
import VisionSection from "../../components/VisionSection/VisionSection";

const HomePage = () => {
  return (
    <MainContent>
      <Banner />
      <Title titleText={"HomePage"} additionalClass="margem-acima" />
      <VisionSection/>
    </MainContent>
  );
};

export default HomePage;
