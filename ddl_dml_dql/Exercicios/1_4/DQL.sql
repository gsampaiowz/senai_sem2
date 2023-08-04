-- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
-- listar todas as raças que começam com a letra S
-- listar todos os tipos de pet que terminam com a letra O
-- listar todos os pets mostrando os nomes dos seus donos
-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, o nome, a raça e o tipo do pet que foi atendido, o nome do dono do pet e o nome da clínica onde o pet foi atendido

SELECT
	V.Nome
FROM
	Veterinario AS V
WHERE
	V.IdClinica = 2

--SELECT NOS REGISTROS
SELECT
	R.Descricao
FROM
	Raca AS R
WHERE
	RIGHT(R.Descricao,1) = 'o'

SELECT
	D.Nome,
	P.Nome
FROM
	Dono AS D,
	Pet AS P
WHERE
	P.IdDono = D.IdDono


SELECT
	A.IdAtendimento,
	V.Nome AS NomeVet,
	P.Nome AS NomePet,
	R.Descricao AS Raca,
	T.Descricao AS Tipo,
	D.Nome AS NomeDono,
	C.Endereco
FROM
	Atendimento AS A,
	Veterinario AS V,
	Pet AS P,
	Raca AS R,
	TipoPet AS T,
	Dono AS D,
	Clinica AS C
WHERE
	P.IdTipoPet = T.IdTipoPet
	AND P.IdRaca = R.IdRaca
	AND P.IdDono = D.IdDono
	AND R.IdTipoPet = T.IdTipoPet
	AND V.IdClinica = C.IdClinica
	AND A.IdVeterinario = V.IdVeterinario
	AND P.IdPet = A.IdPet