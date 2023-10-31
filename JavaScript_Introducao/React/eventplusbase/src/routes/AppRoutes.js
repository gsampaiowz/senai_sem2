import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "../pages/HomePage/HomePage";
import LoginPage from "../pages/LoginPage/LoginPage";
import EventosPage from "../pages/EventosPage/EventosPage";
import TipoEventosPage from "../pages/TipoEventosPage/TipoEventosPage";
import TestePage from "../pages/TestePage/TestePage";

const AppRoutes = () => {
  return (
    <BrowserRouter>
        <Routes>
            <Route element={<HomePage/>} exact path="/"/>
            <Route element={<LoginPage/>} path="/login"/>
            <Route element={<EventosPage/>} path="/eventos"/>
            <Route element={<TipoEventosPage/>} path="/tipoeventos"/>
            <Route element={<TestePage/>} path="/teste"/>
        </Routes>
    </BrowserRouter>
  );
};

export default AppRoutes;
