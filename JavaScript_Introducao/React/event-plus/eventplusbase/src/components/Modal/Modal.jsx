import React, { useEffect, useState } from "react";
import trashDelete from "../../assets/images/trash-delete-red.png";

import { Button, Input } from "../FormComponents/FormComponents";
import "./Modal.css";

const Modal = ({
  modalTitle = "Feedback",
  comentaryText = "Não informado.",
  showHideModal = false,
  fnGet = null,
  fnDelete = null,
  fnPost = null,
  fnPut = null,
}) => {
  const [commentaryInput, setCommentaryInput] = useState("");

  useEffect(() => {
    fnGet();
  }, []);

  return (
    <div className="modal">
      <article className="modal__box">
        <h3 className="modal__title">
          {modalTitle}
          <span className="modal__close" onClick={() => showHideModal(true)}>
            x
          </span>
        </h3>

        <div className="comentary">
          <h4 className="comentary__title">Comentário</h4>
          <img
            src={trashDelete}
            className="comentary__icon-delete"
            alt="Ícone de uma lixeira"
            onClick={fnDelete}
          />

          <p className="comentary__text">{comentaryText}</p>

          <hr className="comentary__separator" />
        </div>

        <Input
          placeholder="Escreva seu comentário..."
          additionalClass="comentary__entry"
          value={commentaryInput}
          manipulationFunction={(e) => setCommentaryInput(e.target.value)}
        />

        <Button
          textButton={
            comentaryText !== "Não informado." ? "Editar" : "Comentar"
          }
          additionalClass="comentary__button"
          manipulationFunction={
            comentaryText !== "Não informado."
              ? () => fnPut(commentaryInput)
              : () => fnPost(commentaryInput)
          }
        />
      </article>
    </div>
  );
};

export default Modal;
