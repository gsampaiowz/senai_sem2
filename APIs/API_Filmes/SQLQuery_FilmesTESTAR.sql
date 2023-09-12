--DBCC CHECKIDENT('[Genero]', RESEED, 0);
--DBCC CHECKIDENT('[Filme]', RESEED, 0);

--DELETE FROM Filme;
--DELETE FROM Genero;

--SELECT F.IdFilme, F.IdGenero, F.Titulo, G.Nome FROM Filme AS F INNER JOIN Genero AS G ON F.IdGenero = G.IdGenero