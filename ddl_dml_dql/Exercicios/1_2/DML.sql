USE Exercicio_1_2;

INSERT INTO Cliente VALUES('Sampaio', '42342434'),('Gustavo', '123523425');

INSERT INTO Empresa VALUES('HiperCars'),('UltraCars');

INSERT INTO Marca VALUES('Ford'), ('Chevrolet'),( 'Wolksvagen'), ('Nissan'),( 'Honda'),( 'Toyota');

INSERT INTO Modelo VALUES(1,'Ka'), (2,'Celta'),(3, 'Gol'), (4,'Kicks'),(5, 'Fit'),( 6,'Corolla');

INSERT INTO Veiculo VALUES(1,4,4,'ABC1234'),(2,2,2,'FGH1234');

INSERT INTO Aluguel 
VALUES
	(1,1,'20/08/2023','20/09/2023'),
	(2,2,'13/08/2023','13/10/2023');

SELECT * FROM Marca;
SELECT * FROM Modelo;
SELECT * FROM Veiculo;
SELECT * FROM Cliente;
SELECT * FROM Empresa;
SELECT * FROM Aluguel;