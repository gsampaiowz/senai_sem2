--DML - DATA MANIPULATION LANGUAGE

INSERT INTO Funcionarios(Nome)
VALUES('RENATO')

UPDATE Funcionarios
SET Nome = 'Yuri' WHERE Nome = 'ROGER'

DELETE FROM Funcionarios WHERE IdFuncionario = 15

INSERT INTO Empresas(IdFuncionario,Nome) 
VALUES (16, 'Ford')