import React from "react";
import "./VisionSection.css";
import Title from "../Title/Title";

const VisionSection = () => {
  return (
    <section className="vision">
      <div className="vision__box">
        <Title
          color="white"
          titleText={"Visão"}
          additionalClass="vision__title"
        />

        <p className="vision__text">
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Corporis
          accusamus necessitatibus nemo alias quam numquam fugiat molestias est
          eum! At illum odit, natus inventore quibusdam esse nobis molestiae
          tempore modi. Asperiores beatae quas expedita in enim, repudiandae
          nulla voluptatum iusto accusantium harum. Omnis fuga dolorum
          perspiciatis magnam rerum delectus voluptas dolores eveniet expedita
          reprehenderit quidem, quibusdam tempore quaerat veniam eligendi.
        </p>
      </div>
    </section>
  );
};

export default VisionSection;
