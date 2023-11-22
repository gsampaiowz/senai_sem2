import React from "react";
import "./TableTp.css";
import iconeLixo from "../../../assets/images/trash-delete.svg";
import iconeEditar from "../../../assets/images/edit-pen.svg";

const TableTp = ({ dados, fnUpdate, fnDelete }) => {
  return (
    <table className="table-data">
      <thead className="table-data__head">
        <tr className="table-data__head-row">
          <th className="table-data__head-title table-data__head-title--big">
            Título
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Editar
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Deletar
          </th>
        </tr>
      </thead>

      <tbody>
        {dados.map((tipoEvento) => (
          <tr key={tipoEvento.idTipoEvento} className="table-data__head-row">
            <td className="table-data__data table-data__data--big">
              {tipoEvento.titulo}
            </td>

            <td className="table-data__data table-data__data--little">
              <img
                className="table-data__icon"
                src={iconeEditar}
                alt="Ícone de lixeira para deletar"
                onClick={() => fnUpdate(tipoEvento)}
              />
            </td>

            <td className="table-data__data table-data__data--little">
              <img
                className="table-data__icon"
                src={iconeLixo}
                alt="Ícone de caneta para editar"
                onClick={() => fnDelete(tipoEvento.idTipoEvento)}
              />
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default TableTp;
