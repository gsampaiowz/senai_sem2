import React from "react";
import "./FormComponents.css";

export const Input = ({
  type,
  id,
  value,
  required,
  additionalClass = "",
  name,
  placeholder,
  manipulationFunction,
}) => {
  return (
    <input
      type={type}
      id={id}
      value={value}
      required={required}
      className={`input-component ${additionalClass}`}
      name={name}
      placeholder={placeholder}
      onChange={manipulationFunction}
      autoComplete="off"
    />
  );
};

export const Button = ({
  type,
  id,
  name,
  additionalClass = "",
  textButton,
  manipulationFunction,
}) => {
  return (
    <button
      onClick={manipulationFunction}
      type={type}
      name={name}
      id={id}
      className={`button-component ${additionalClass}`}
    >
      {textButton}
    </button>
  );
};

// export const Select = ({
//   id,
//   required,
//   additionalClass = "",
//   name,
//   object = [],
// }) => {
//   return (
//     <select
//       id={id}
//       required={required}
//       className={`input-component ${additionalClass}`}
//       name={name}
//     >
//       <option value="select">Selecione</option>
//       {object.titulo == null
//         ? object.map((option) => (
//             <option value={option.idInstituicao} key={option.idInstituicao}>
//               {option.nomeFantasia}
//             </option>
//           ))
//         : object.nomeFantasia == null ? object.map((option) => (
//             <option value={option.idTipoEvento} key={option.idTipoEvento}>
//               {option.titulo}
//             </option>
//           )) : null}
//     </select>
//   );
// };

export const SelectInst = ({
  id,
  required,
  additionalClass = "",
  name,
  value,
  manipulationFunction,
  object = [],
}) => {
  return (
    <select
      id={id}
      required={required}
      className={`input-component ${additionalClass}`}
      name={name}
      value={value}
      onChange={manipulationFunction}
    >
      <option value="select">Selecione</option>
      {object.map((option) => (
        <option value={option.idInstituicao} key={option.idInstituicao}>
          {option.nomeFantasia}
        </option>
      ))}
    </select>
  );
};

export const SelectTipo = ({
  id,
  required,
  additionalClass = "",
  name,
  value,
  manipulationFunction,
  object = [],
}) => {
  return (
    <select
      id={id}
      required={required}
      className={`input-component ${additionalClass}`}
      name={name}
      value={value}
      onChange={manipulationFunction}
    >
      <option value="select">Selecione</option>
      {object.map((option) => (
        <option value={option.idTipoEvento} key={option.idTipoEvento}>
          {option.titulo}
        </option>
      ))}
    </select>
  );
};
