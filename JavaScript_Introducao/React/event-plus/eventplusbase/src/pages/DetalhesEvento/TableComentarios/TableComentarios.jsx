import React, { useContext } from "react";
import "./TableComentarios.css";
import iconeLixo from "../../../assets/images/trash-delete.svg";
import ToggleSwitch from "../../../components/Toggle/Toggle";
import { userContext } from "../../../context/AuthContext";

const TableComentarios = ({ dados, fnDelete, fnExibe }) => {
  const { userData } = useContext(userContext);
  return (
    <table className="table-data">
      <thead className="table-data__head">
        <tr
          style={{
            justifyContent: userData.role === "aluno" ? "space-around" : null,
          }}
          className="table-data__head-row"
        >
          <th className="table-data__head-title table-data__head-title--little">
            Nome
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Descrição
          </th>
          {userData.role === "administrador" && (
            <>
              <th className="table-data__head-title table-data__head-title--little">
                Exibe
              </th>
              <th className="table-data__head-title table-data__head-title--little">
                Deletar
              </th>
            </>
          )}
        </tr>
      </thead>

      <tbody>
        {dados.map((comentario) => (
          <tr
            style={{
              justifyContent: userData.role === "aluno" ? "space-around" : null,
            }}
            key={comentario.idComentarioEvento}
            className="table-data__head-row"
          >
            <td className="table-data__data table-data__data--little">
              {comentario.usuario.nome}
            </td>

            <td className="table-data__data table-data__data--little">
              {comentario.descricao}
            </td>

            {userData.role === "administrador" ? (
              <>
                <td
                  style={{ display: "flex", justifyContent: "center" }}
                  className="table-data__data table-data__data--little toogle-comentarios"
                >
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
              </>
            ) : null}
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default TableComentarios;
