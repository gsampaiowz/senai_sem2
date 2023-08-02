--ATIVIDADE DQL 

 -- listar as pessoas em ordem alfabética reversa, mostrando seus telefones, seus emails e suas CNHs

 --SCRIPT SEM USAR JOIN

 USE Exercicio_1_1;

 SELECT	
	 P.Nome AS Nome,
	 T.Numero AS Telefone,
	 E.Endereco AS Email,
	 P.CNH AS CNH
 FROM 
	 Pessoa AS P,
	 Email AS E,
	 Telefone AS T
 WHERE 
	P.IdPessoa = E.IdPessoa
	AND P.IdPessoa = T.IdPessoa
 ORDER BY 
	Nome DESC;

 DELETE Pessoa WHERE IdPessoa = 12;

 INSERT INTO Pessoa 
	(Nome, Cnh)
 VALUES
	('Matheus','402839542'),
	('Fabio','948239432'),
	('Keller','920839524'),
	('Yuri','897494338');
 
 INSERT INTO Pessoa VALUES('Possarle', '123122333');
 INSERT INTO Email VALUES(13,'possarle@email.com');
 INSERT INTO Telefone VALUES(13, '11943978122');
 
SELECT * FROM Pessoa; 
SELECT * FROM Email; 
SELECT * FROM Telefone;

 SELECT	
	 *
 FROM 
	 Pessoa AS P,
	 Email AS E,
	 Telefone AS T
 WHERE 
	P.IdPessoa = E.IdPessoa
	AND P.IdPessoa = T.IdPessoa

SELECT 
	*
FROM
	Pessoa inner join Telefone on pessoa.IdPessoa = telefone.IdPessoa

	
SELECT 
	*
FROM
	Pessoa left join Telefone on pessoa.IdPessoa = telefone.IdPessoa

SELECT IdPessoa, numero 