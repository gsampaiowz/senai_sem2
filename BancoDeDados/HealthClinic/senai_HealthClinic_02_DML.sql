-- DML - DATA MANIPULATION LANGUAGE - LINGUAGEM DE MANIPULACAO DE DADOS

USE HealthClinic_Tarde;

-- RESETAR ID
DBCC CHECKIDENT('Consultas', RESEED, 0);

-- INSERIR DADOS NAS TABELAS

INSERT INTO TipoDeUsuario VALUES(NEWID(),'Administrador'),(NEWID(),'Medico'),(NEWID(),'Paciente');

INSERT INTO Paciente
VALUES
	(3,'2000-01-01','00000000000','000000000','00000000000','00000000','Rua Ciclano, 0'),
	(5,'2000-11-11','11111111111','111111111','11111111111','11111111','Rua Ciclano, 1');

INSERT INTO Especialidades VALUES('Neurologista'),('Oftalmologista');

INSERT INTO Clinicas
VALUES
	('Rua Fulano, 1','Osasco','11111111111111','11:11:11','22:22:22'),
	('Rua Fulano, 0','Suzano','00000000000000','00:00:00','11:11:11');

INSERT INTO Medico
VALUES
	(2,1,1,'123123'),
	(4,2,2,'321321');

INSERT INTO Situacao VALUES(NEWID(),'Confirmada'),(NEWID(),'Cancelada');

INSERT INTO Consulta
VALUES
	(1,1,1,1,'Tomografia computadorizada','2000-01-01','00:00:00'),
	(2,2,2,2,'Exame de vista','1111-11-11','11:11:11');

INSERT INTO Comentario VALUES(1,1,'Médico muito atencioso, consulta nota 10!');