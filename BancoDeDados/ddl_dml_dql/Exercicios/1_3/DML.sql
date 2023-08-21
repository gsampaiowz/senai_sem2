USE Exercicio_1_3;

INSERT INTO Clinica VALUES('Rua Corinthians, 123'),('Rua Palmeiras, 10');

INSERT INTO TipoPet VALUES('Cachorro'),('Gato');

INSERT INTO Raca VALUES(1,'Caramelo'),(2 ,'Preto'),(1,'ShihTzu');

INSERT INTO Dono VALUES('Jonas'),('Goku');

INSERT INTO Veterinario VALUES('1', 'Robert'),('2', 'Vegeta');

INSERT INTO Pet VALUES(1, 1, 1, 'Bob', '15/09/2019'),(2,2,2,'Fred', '24/06/2022');

INSERT INTO Atendimento VALUES(1,1,'Tratamento de pugas','20/08/2023'),(2,2,'Outro', '09/09/2023');

SELECT * FROM Clinica;
SELECT * FROM TipoPet;
SELECT * FROM Raca;
SELECT * FROM Dono;
SELECT * FROM Veterinario;
SELECT * FROM Pet;
SELECT * FROM Atendimento;