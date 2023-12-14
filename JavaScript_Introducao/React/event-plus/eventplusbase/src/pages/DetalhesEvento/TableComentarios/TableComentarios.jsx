import React from "react";
import "./TableComentarios.css";
import iconeLixo from "../../../assets/images/trash-delete.svg";
import ToggleSwitch from "../../../components/Toggle/Toggle";

const TableComentarios = ({ dados, fnDelete, fnExibe }) => {
  return (
    <table className="table-data">
      <thead className="table-data__head">
        <tr className="table-data__head-row">
          <th className="table-data__head-title table-data__head-title--little">
            Nome
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Descrição
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Exibe
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Deletar
          </th>
        </tr>
      </thead>

      <tbody>
        {dados.map((comentario) => (
          <tr
            key={comentario.idComentarioEvento}
            className="table-data__head-row"
          >
            <td className="table-data__data table-data__data--little">
              {comentario.usuario.nome}
            </td>

            <td className="table-data__data table-data__data--little">
              {comentario.descricao}
            </td>

            <td style={{display: "flex", justifyContent: "center"}} className="table-data__data table-data__data--little toogle-comentarios">
            <ToggleSwitch
                    toggleActive={comentario.exibe}
                    manipulationFunction={() => {
                      fnExibe(
                        comentario.idComentarioEvento,
                        comentario.descricao,
                        comentario.exibe ? false : true
                      );
                    }}
                  />
            </td>

            <td className="table-data__data table-data__data--little">
              <img
                className="table-data__icon"
                src={iconeLixo}
                alt="Ícone de caneta para editar"
                onClick={() => fnDelete(comentario.idComentarioEvento)}
              />
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default TableComentarios;
