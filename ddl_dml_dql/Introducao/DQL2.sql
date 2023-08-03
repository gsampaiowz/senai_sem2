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
 
 INSERT INTO Email VALUES(2,'fabio@email.com');
 INSERT INTO Telefone VALUES(2, '11943214321');
 
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
	AND P.IdPessoa = T.IdPessoa;

--
SELECT 
	*
FROM
	Pessoa join Telefone on pessoa.IdPessoa = telefone.IdPessoa;

--
SELECT 
	*
FROM
	Pessoa left join Telefone on pessoa.IdPessoa = telefone.IdPessoa;

--
SELECT 
	*
FROM
	pessoa join email on pessoa.IdPessoa = email.IdPessoa;