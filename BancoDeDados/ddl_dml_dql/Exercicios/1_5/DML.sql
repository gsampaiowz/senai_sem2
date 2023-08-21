USE Exercicio_1_5;

INSERT INTO
	Loja
VALUES
	('Shop1'),
	('Shop2'),
	('Shop3'),
	('Shop4');

INSERT INTO
	Cliente
VALUES
	('Sampas'),
	('Gusta'),
	('Isaque'),
	('Duds');

INSERT INTO
	Categoria
VALUES
	(1,'Bolachas'),
	(1,'Bebidas'),
	(2,'Roupas masculinas'),
	(2,'Esportes');

INSERT INTO
	Pedido
VALUES
	(1,1),
	(2,2),
	(2,3),
	(3,4);

INSERT INTO
	Subcategoria
VALUES
	(1,'Doces'),
	(2,'Alcólicas'),
	(3,'Calças'),
	(4,'Futebol');

INSERT INTO
	Produto
VALUES
	(1,'Bauducco recheada'),
	(2,'Jack Daniels'),
	(3,'Calça Cargo 42'),
	(4,'Bola de futebol');

INSERT INTO
	PedidoProduto
VALUES
	(1,1),
	(2,3),
	(3,4),
	(4,2);

SELECT * FROM Loja;
SELECT * FROM Categoria;
SELECT * FROM Subcategoria
SELECT * FROM Produto;
SELECT * FROM PedidoProduto;
SELECT * FROM Pedido;
SELECT * FROM Cliente;
