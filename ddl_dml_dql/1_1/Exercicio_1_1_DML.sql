--DML - INSERIR DADOS NAS TABELAS

-- USAR O BANCO CRIADO
USE Exercicio_1_1;

--INSERIR DADOS NA TABELA
INSERT INTO Pessoa(Nome, Cnh)
VALUES('Gustavo', '1234567890');

INSERT INTO Pessoa VALUES('Sampaio', '1231231232'), ('Guilherme', '929310390');

INSERT INTO Email VALUES(2, 'sampaio@email.com'), (4, 'gustavo@email.com');

INSERT INTO Telefone Values(3, '32423431');

SELECT * FROM Pessoa;
SELECT * FROM Email;
SELECT * FROM Telefone;