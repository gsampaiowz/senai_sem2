-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

SELECT 
	A.Inicio,
	A.Fim,
	C.Nome,
	M.Nome
FROM
	Cliente AS C,
	Aluguel AS A,
	Modelo AS M,
	Veiculo AS V
WHERE 
	C.IdCliente = A.IdCliente 
	AND M.IdModelo = V.IdModelo 
	AND V.IdVeiculo = A.IdVeiculo;

SELECT 
	A.Inicio,
	A.Fim,
	C.Nome,
	M.Nome
FROM
	Cliente AS C,
	Aluguel AS A,
	Modelo AS M,
	Veiculo AS V
WHERE 
	C.IdCliente = 2
	AND C.IdCliente = A.IdCliente 
	AND M.IdModelo = V.IdModelo 
	AND V.IdVeiculo = A.IdVeiculo
	