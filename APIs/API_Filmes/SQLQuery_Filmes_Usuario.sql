--CRIANDO TABELA Usuario

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(255) NOT NULL UNIQUE,
	Senha VARCHAR(128) NOT NULL,
	Permissao BIT NOT NULL,
);

--INSERIR DADOS

INSERT INTO Usuario(Email,Senha,Permissao) 
VALUES
('gabriel@email.com','123',0),
('gustavo@email.com','321',1);

SELECT * FROM Usuario;