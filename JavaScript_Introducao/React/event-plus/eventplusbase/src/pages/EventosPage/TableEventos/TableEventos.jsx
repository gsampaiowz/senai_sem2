import React from "react";
import "./TableEventos.css";
import iconeLixo from "../../../assets/images/trash-delete.svg";
import iconeEditar from "../../../assets/images/edit-pen.svg";
import { FaEye } from 'react-icons/fa';
import { useNavigate } from "react-router-dom";

const TableEventos = ({ dados, fnUpdate, fnDelete }) => {
  const navigate = useNavigate();
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
            Tipo Evento
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Instituição
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Data Evento
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Visualizar
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
        {dados.map((evento) => (
          <tr key={evento.idEvento} className="table-data__head-row">
            <td className="table-data__data table-data__data--little">
              {evento.nomeEvento}
            </td>

            <td className="table-data__data table-data__data--little">
              {evento.descricao}
            </td>

            <td className="table-data__data table-data__data--little">
              {evento.tiposEvento.titulo}
            </td>

            <td className="table-data__data table-data__data--little">
              {evento.instituicao.nomeFantasia}
            </td>

            <td className="table-data__data table-data__data--little">
              {new Date(evento.dataEvento).toLocaleDateString()}
            </td>
            <td className="table-data__data table-data__data--little">
<FaEye style={{cursor: "pointer"}} onClick={() => navigate(`/detalhes-evento/${evento.idEvento}`)} size={20} color="var(--color-white)"/>
            </td>

            <td className="table-data__data table-data__data--little">
              <img
                className="table-data__icon"
                src={iconeEditar}
                alt="Ícone de lixeira para deletar"
                onClick={() => fnUpdate(evento)}
              />
            </td>

            <td className="table-data__data table-data__data--little">
              <img
                className="table-data__icon"
                src={iconeLixo}
                alt="Ícone de caneta para editar"
                onClick={() => fnDelete(evento.idEvento)}
              />
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default TableEventos;
