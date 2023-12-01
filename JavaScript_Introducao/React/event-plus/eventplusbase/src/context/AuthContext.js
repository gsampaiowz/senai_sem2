import { createContext } from "react";
import { jwtDecode } from "jwt-decode";

export const userContext = createContext(null);

export const userDecodeToken = (theToken) => {
  const decoded = jwtDecode(theToken); //aqui retorna o payload do token

  return {
    role: decoded.role,
    name: decoded.name,
    userId: decoded.jti,
    token: theToken,
  };
};
