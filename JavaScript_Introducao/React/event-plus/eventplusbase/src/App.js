import "./App.css";
import AppRoutes from "./routes/AppRoutes";
import { userContext } from "./context/AuthContext";
import { useEffect, useState } from "react";

function App() {
  const [userData, setUserData] = useState({});

  useEffect(() => {
    const token = localStorage.getItem("token");

    setUserData(token === null ? {} : JSON.parse(token));
  }, []);
  return (
    <userContext.Provider value={{ userData, setUserData }}>
      <AppRoutes />
    </userContext.Provider>
  );
}

export default App;
