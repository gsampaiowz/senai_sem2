--DDL - DATA DEFINITION LANGUAGE

--CRIA BANCO DE DADOS
CREATE DATABASE BancoTarde;

USE BancoTarde;

--CRIA A TABELA
CREATE TABLE Funcionarios
(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(10),
);

CREATE TABLE Empresas
(
 IdEmpresa INT PRIMARY KEY IDENTITY,
 IdFuncionario INT FOREIGN KEY REFERENCES Funcionarios(IdFuncionario),
 Nome VARCHAR(10),
);

------------------------

--ALTER TABLE
ALTER TABLE Funcionarios
ADD Cpf VARCHAR(11)

ALTER TABLE Funcionarios
DROP COLUMN Cpf 

DROP TABLE Empresas

USE Teste

DROP DATABASE BancoTarde