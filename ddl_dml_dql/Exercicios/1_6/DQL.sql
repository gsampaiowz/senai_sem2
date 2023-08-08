-- listar todos os pedidos dos clientes
-- listar todos os pedidos de um determinado cliente, mostrando quais foram os colaboradores que executaram o serviço, 
-- qual foi o tipo de conserto, qual item foi consertado e o nome deste cliente

SELECT 
	Clientes.Nome AS Cliente,
	Pedidos.IdPedido AS Pedido
FROM
	Pedidos join Clientes on Pedidos.IdCliente = Clientes.IdCliente
ORDER BY
	Cliente ASC

SELECT 
	C.Nome AS Cliente,
	P.IdPedido AS Pedido,
	CB.Nome AS Colaborador,
	TC.Descricao AS Tipo,
	I.Descricao AS Item
FROM Pedidos AS P
	inner join Clientes AS C on P.IdCliente = C.IdCliente
	inner join TiposConsertos AS TC on P.IdTipoConserto = TC.IdTipoConserto
	inner join Itens AS I on P.IdItem = I.IdItem,
	PedidosColaboradores AS PC,
	Colaboradores AS CB
WHERE
	PC.IdColaborador = CB.IdColaborador AND
	PC.IdPedido = P.IdPedido AND
	C.IdCliente = 1
	