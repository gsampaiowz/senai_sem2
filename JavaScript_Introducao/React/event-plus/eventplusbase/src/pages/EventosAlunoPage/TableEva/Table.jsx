import React from "react";
import comentaryIcon from "../../../assets/images/comentary-icon.svg";
import ToggleSwitch from "../../../components/Toggle/Toggle";
// importa a biblioteca de tootips ()
import "react-tooltip/dist/react-tooltip.css";
import { FaEye } from "react-icons/fa";

// import trashDelete from "../../../assets/images/trash-delete.svg";
import "./Table.css";
import { useNavigate } from "react-router-dom";

const Table = ({ dados, fnConnect = null, fnShowModal = null }) => {
  const navigate = useNavigate();
  return (
    <table className="tbal-data">
      <thead className="tbal-data__head">
        <tr className="tbal-data__head-row tbal-data__head-row--red-color">
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Evento
          </th>
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Data
          </th>
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Ações
          </th>
        </tr>
      </thead>
      <tbody>
        {dados.length === 0 ? (
          <tr className="tbal-data__head-row" key={Math.random()}>
            <td className="tbal-data__data tbal-data__data--big"></td>
            <td className="tbal-data__data tbal-data__data--big">
              Não há nenhum evento aqui.
            </td>
            <td className="tbal-data__data tbal-data__data--big"></td>
          </tr>
        ) : (
          dados.sort((a, b) => (a.dataEvento < b.dataEvento ? 1 : a.dataEvento > b.dataEvento ? -1 : 0)).map((e) => (
            <tr className="tbal-data__head-row" key={Math.random()}>
              <td className="tbal-data__data tbal-data__data--big">
                {e.nomeEvento}
              </td>

              <td className="tbal-data__data tbal-data__data--big tbal-data__btn-actions">
                {/* {e.dataEvento} */}
                {new Date(e.dataEvento).toLocaleDateString("pt-BR")}
              </td>

              <td className="tbal-data__data tbal-data__data--big tbal-data__btn-actions">
                {new Date(e.dataEvento) < new Date() ? (
                  <img
                    className="tbal-data__icon"
                    src={comentaryIcon}
                    alt=""
                    onClick={() => fnShowModal(e.idEvento)}
                  />
                ) : null}
                {new Date(e.dataEvento) > new Date() ? (
                  <ToggleSwitch
                    toggleActive={e.situacao}
                    manipulationFunction={() => {
                      fnConnect(
                        e.idEvento,
                        e.idPresencaEvento,
                        e.situacao ? false : true
                      );
                    }}
                  />
                ) : null}
                <FaEye color="#201849" onClick={() => navigate(`/detalhes-evento/${e.idEvento}`)} style={{cursor: "pointer"}} size={20}/>
              </td>
            </tr>
          ))
        )}
      </tbody>
    </table>
  );
};

export default Table;
