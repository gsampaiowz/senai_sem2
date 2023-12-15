import React, { useContext } from "react";
import "./NextEvent.css";
import dateFormatDbToView from "../../Utils/stringFunction";

import { Tooltip } from "react-tooltip";
import { userContext } from "../../context/AuthContext";
import { Link } from "react-router-dom";

const NextEvent = ({
  conectar,
  idSituacao,
  title,
  description,
  eventDate,
  idEvento,
}) => {
  const { userData } = useContext(userContext);
  return (
    <article className="event-card">
      <h2 className="event-card__title">{title}</h2>

      <Tooltip id={idEvento} className="tooltip" />
      <p
        className="event-card__description"
        data-tooltip-id={idEvento}
        data-tooltip-content={description}
        data-tooltip-place="top"
      >
        {description}
      </p>
      <p className="event-card__description">{dateFormatDbToView(eventDate)}</p>

      {new Date().toJSON() > new Date(eventDate).toJSON() ? null : (
        <a href="/" className="event-card__connect-link" onClick={conectar}>
          {!userData.userId ? "Login" : idSituacao ? "Desconectar" : "Conectar"}
        </a>
      )}
      <Link
        style={{ marginBottom: 0, fontSize: 16 }}
        to={`/detalhes-evento/${idEvento}`}
        className="event-card__connect-link"
      >
        Visualizar
      </Link>
    </article>
  );
};

export default NextEvent;
