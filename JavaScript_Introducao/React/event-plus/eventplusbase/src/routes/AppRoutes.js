import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "../pages/HomePage/HomePage";
import LoginPage from "../pages/LoginPage/LoginPage";
import EventosPage from "../pages/EventosPage/EventosPage";
import TipoEventosPage from "../pages/TipoEventosPage/TipoEventosPage";
import Header from "../components/Header/Header";
import Footer from "../components/Footer/Footer";

const AppRoutes = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} exact path="/" />
        <Route element={<LoginPage />} path="/login" />
        <Route element={<EventosPage />} path="/eventos" />
        <Route element={<TipoEventosPage />} path="/tipos-de-eventos" />
      </Routes>
      <Footer/>
    </BrowserRouter>
  );
};

export default AppRoutes;
