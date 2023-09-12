CREATE DATABASE FilmesTarde;
USE FilmesTarde;

CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50) UNIQUE,
);

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(50) UNIQUE,
);

INSERT INTO Genero VALUES('Comedia'),('Terror');

INSERT INTO Filme VALUES(1,'Gente Grande'),(2,'A Freira');

SELECT * FROM Filme INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero;
SELECT * FROM Genero;