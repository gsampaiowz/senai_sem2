-- DQL - DATA QUERY LANGUAGE - LINGUAGEM DE CONSULTA DE DADOS

-- CONSULTAR DADOS

SELECT * FROM TiposDeUsuarios;
SELECT * FROM Usuarios;
SELECT * FROM Especialidades;
SELECT * FROM Clinicas;
SELECT * FROM Medicos;
SELECT * FROM Pacientes;
SELECT * FROM Situacoes;
SELECT * FROM Consultas;
SELECT * FROM Comentarios;

-- CRIAR UM SCRIPT QUE EXIBA OS SEGUINTES DADOS
/*
- Id Consulta
- Data Consulta
- Horario da Consulta
- Nome da Clinica
- Nome do Paciente
- Nome do Medico
- Especialidade do Medico
- CRM
- FeedBack(Comentario da consulta)
*/

-- MAIS EXEMPLOS DE JOINS

SELECT 
	
-- Criar funcao para retornar os medicos de uma determinada especialidade
-- Criar procedure para retornar a idade de um determinado usuario