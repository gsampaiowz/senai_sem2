import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "../pages/HomePage/HomePage";
import LoginPage from "../pages/LoginPage/LoginPage";
import EventosPage from "../pages/EventosPage/EventosPage";
import TipoEventosPage from "../pages/TipoEventosPage/TipoEventosPage";
import EventosAlunoPage from "../pages/EventosAlunoPage/EventosAlunoPage";
import Header from "../components/Header/Header";
import Footer from "../components/Footer/Footer";
import TestePage from "../pages/TestePage/TestePage";
import { PrivateRoute } from "./PrivateRoute";

const AppRoutes = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} exact path="/" />
        <Route element={<LoginPage />} path="/login" />
        <Route
          element={
            <PrivateRoute redirectTo="/">
              <EventosAlunoPage />
            </PrivateRoute>
          }
          path="/eventos-aluno"
        />
        <Route
          element={
            <PrivateRoute redirectTo="/">
              <EventosPage />
            </PrivateRoute>
          }
          path="/eventos"
        />
        <Route
          element={
            <PrivateRoute redirectTo="/">
              <TipoEventosPage />
            </PrivateRoute>
          }
          path="/tipos-de-eventos"
        />
        <Route element={<TestePage />} path="/teste" />
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default AppRoutes;
