-- DML - DATA MANIPULATION LANGUAGE - LINGUAGEM DE MANIPULACAO DE DADOS

USE Health_Clinic_Tarde;

-- RESETAR ID
DBCC CHECKIDENT('Consultas', RESEED, 0);

-- INSERIR DADOS NAS TABELAS

INSERT INTO TiposDeUsuarios VALUES('Administrador'),('Medico'),('Paciente');

INSERT INTO Usuarios 
VALUES
	(1,'gabriel','gabriel@email.com','123'),
	(2,'gustavo','gustavo@email.com','123'),
	(3,'guilherme','gui@email.com','123'),
	(2,'eduardo','edu@email.com','123'),
	(3,'pedro','pedro@email.com','123');

INSERT INTO Pacientes
VALUES
	(3,'2000-01-01','00000000000','000000000','00000000000','00000000','Rua Ciclano, 0'),
	(5,'2000-11-11','11111111111','111111111','11111111111','11111111','Rua Ciclano, 1');

INSERT INTO Especialidades VALUES('Neurologista'),('Oftalmologista');

INSERT INTO Clinicas
VALUES
	('Rua Fulano, 1','Osasco','11111111111111','11:11:11','22:22:22'),
	('Rua Fulano, 0','Suzano','00000000000000','00:00:00','11:11:11');

INSERT INTO Medicos 
VALUES
	(2,1,1,'123123'),
	(4,2,2,'321321');

INSERT INTO Situacoes VALUES('Confirmada'),('Cancelada');

INSERT INTO Consultas 
VALUES
	(1,1,1,1,'Tomografia computadorizada','2000-01-01','00:00:00'),
	(2,2,2,2,'Exame de vista','1111-11-11','11:11:11');

INSERT INTO Comentarios VALUES(1,1,'Médico muito atencioso, consulta nota 10!');