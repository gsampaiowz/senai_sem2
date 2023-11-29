import "./App.css";
import AppRoutes from "./routes/AppRoutes";
import { userContext } from "./context/AuthContext";
import { useState } from "react";

function App() {
  const [userData, setUserData] = useState({});
  return (
    <userContext.Provider value={{userData, setUserData}}>
      <AppRoutes />
    </userContext.Provider>
  );
}

export default App;
