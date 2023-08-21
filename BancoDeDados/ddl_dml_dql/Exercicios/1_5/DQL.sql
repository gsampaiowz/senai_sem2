-- listar todos os pedidos de um cliente (nome), mostrando quais produtos foram solicitados (titulo) neste pedido e de qual subcategoria (nome) e categoria (nome) pertencem

SELECT
	PedidoProduto.IdPedido AS Pedido,
	PedidoProduto.IdProduto AS Produto,
	Produto.Nome AS Produto,
	Cliente.Nome AS Cliente,
	Categoria.Nome AS Categoria,
	Subcategoria.Nome AS Subcategoria
FROM
	Pedido join Cliente on Pedido.IdCliente = Cliente.IdCliente, 
	Produto,
	PedidoProduto,
	Subcategoria join Categoria on Subcategoria.IdCategoria = Categoria.IdCategoria
WHERE
	Produto.IdSubcategoria = Subcategoria.IdSubcategoria AND
	PedidoProduto.IdProduto = Produto.IdProduto AND
	PedidoProduto.IdPedido = Pedido.IdPedido AND
	Cliente.Nome = 'Gusta'