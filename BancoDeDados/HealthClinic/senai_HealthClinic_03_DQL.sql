-- DQL - DATA QUERY LANGUAGE - LINGUAGEM DE CONSULTA DE DADOS

-- CONSULTAR DADOS

SELECT * FROM TipoDeUsuario;
SELECT * FROM Situacao;
SELECT * FROM Usuarios;
SELECT * FROM Especialidades;
SELECT * FROM Clinicas;
SELECT * FROM Medicos;
SELECT * FROM Pacientes;
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

SELECT
	C.IdConsulta,
	C.[Data] AS DataConsulta,
	C.Horario AS HorarioConsulta,
	Cli.Unidade AS ClinicaUnidade,
	Us.NomeUsuario AS NomePaciente,
	Us.NomeUsuario AS NomeMedico,
	Esp.NomeEspecialidade AS MedicoEspecialidade,
	Med.CRM AS MedicoCRM,
	CASE WHEN Com.Descricao IS NULL THEN 'FeedBack não registrado' ELSE Com.Descricao END AS FeedBackConsulta
FROM Consultas AS C
	JOIN Clinicas AS Cli ON C.IdClinica = Cli.IdClinica
	JOIN Medicos AS Med ON Med.IdClinica = Cli.IdClinica
	JOIN Usuarios AS Us ON Us.IdUsuario = Med.IdUsuario
	JOIN TiposDeUsuarios AS TU ON TU.IdTipoDeUsuario = Us.IdTipoDeUsuario
	JOIN Especialidades AS Esp ON Esp.IdEspecialidade = Med.IdEspecialidade
	FULL JOIN Comentarios AS Com ON Com.IdConsulta = C.IdConsulta;
	
-- Criar funcao para retornar os medicos de uma determinada especialidade
CREATE FUNCTION FiltrarMedicos(@especialidade INT)
RETURNS TABLE
AS RETURN (SELECT *
		   FROM Medicos
		   WHERE IdEspecialidade = @especialidade);

SELECT * FROM FiltrarMedicos(1);

-- Criar procedure para retornar a idade de um determinado paciente
CREATE PROCEDURE IdadeDeterminado
@paciente INT
AS
DECLARE @AnoAtual INT
SET @AnoAtual = CONVERT(INT, YEAR(GETDATE()))
SELECT 
	@AnoAtual - CONVERT(INT, YEAR(DataNascimento)) AS Idade,
	Usuarios.NomeUsuario AS NomePaciente
FROM Pacientes 
	JOIN Usuarios ON Usuarios.IdUsuario = Pacientes.IdUsuario
WHERE 
	Pacientes.IdUsuario = @paciente;

EXEC IdadeDeterminado 3

-- Mostrar todos pacientes e suas idades
CREATE PROCEDURE Idade
AS
DECLARE @AnoAtual INT
SET @AnoAtual = CONVERT(INT, YEAR(GETDATE()))
SELECT 
	@AnoAtual - CONVERT(INT, YEAR(DataNascimento)) AS Idade,
	Usuarios.NomeUsuario AS NomePaciente
FROM Pacientes
	JOIN Usuarios ON Usuarios.IdUsuario = Pacientes.IdUsuario

EXEC Idade;