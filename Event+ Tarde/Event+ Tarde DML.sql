-- DML - DATA MANIPULATION LANGUAGE

-- INSERIR DADOS NAS TABELAS

INSERT INTO TiposDeUsuario (NomeTipoDeUsuario) 
VALUES ('Administrador'), ('Comum');

INSERT INTO TiposDeEvento (NomeTipoDeEvento) 
VALUES ('SQL Server');

INSERT INTO Instituicao (CNPJ, Endereco, NomeFantasia)
VALUES ('55434321000196','Rua Nitéroi, 180 São Caetano do Sul ','DevSchool');

INSERT INTO Usuario (IdTipoDeUsuario,Nome,Email,Senha)
VALUES (1,'Gabriel','gabriel@email.com','123'), (2,'Eduardo','eduardo@email.com','123');

INSERT INTO Evento (IdTipoDeEvento, IdInstituicao, Nome, Descricao, DataEvento, HoraEvento)
VALUES (1,1,'INTENSIVÃO DE SQL','Estudos intensos de SQL','2023-08-15','20:30:30');

INSERT INTO PresencasEvento (IdUsuario,IdEvento,Situacao)
VALUES (2,1,1);

INSERT INTO ComentarioEvento (IdUsuario, IdEvento, DataComentario, Descricao, Exibe)
VALUES (2,1,'2023-08-10','Evento muito bom!',1);

SELECT * FROM TiposDeUsuario
SELECT * FROM TiposDeEvento
SELECT * FROM Instituicao
SELECT * FROM Usuario
SELECT * FROM Evento
SELECT * FROM PresencasEvento
SELECT * FROM ComentarioEvento