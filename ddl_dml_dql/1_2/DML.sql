USE Exercicio_1_2;

INSERT INTO Cliente VALUES('Sampaio', '42342434'),('Gustavo', '123523425');

INSERT INTO Empresa VALUES('HiperCars'),('UltraCars');

INSERT INTO Marca VALUES('Ford'), ('Chevrolet'),( 'Wolksvagen'), ('Nissan'),( 'Honda'),( 'Toyota');

INSERT INTO Veiculo VALUES(1,4,'ABC1234'),(2,2,'FGH1234');

INSERT INTO Aluguel VALUES(3,1,'Devolver dia 28/08'),(4,2,'Devolver dia 25/08');

SELECT * FROM Marca;
SELECT * FROM Veiculo;
SELECT * FROM Cliente;
SELECT * FROM Empresa;
SELECT * FROM Aluguel;