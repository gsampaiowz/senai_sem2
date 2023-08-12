-- DQL - DATA QUERY LANGUAGE

-- CONSULTAR DADOS

-- Criar script para consulta exibindo os seguintes dados

/*Usar JOIN

Nome do usuário
Tipo do usuário
Data do evento
Local do evento (Instituição)
Tipo do evento
Nome do evento
Descrição do evento
Situação do evento
Comentário do evento
*/

SELECT 
	Us.Nome AS NomeUsuario,
	TU.NomeTipoDeUsuario AS TipoUsuario,
	Ev.DataEvento AS DataEvento,
	Ins.NomeFantasia AS LocalEvento,
	Ins.Endereco AS LocalEvento,
	TE.NomeTipoDeEvento AS TipoEvento,
	Ev.Nome AS NomeEvento,
	Ev.Descricao AS DescricaoEvento,
	PE.Situacao AS Situacao,
	CE.Descricao AS Comentario
FROM
	Usuario AS Us
	JOIN TiposDeUsuario AS TU ON Us.IdTipoDeUsuario = TU.IdTipoDeUsuario
	JOIN PresencasEvento AS PE ON Us.IdUsuario = PE.IdUsuario
	LEFT JOIN ComentarioEvento AS CE ON Us.IdUsuario = CE.IdUsuario,
	Evento AS Ev
	JOIN Instituicao AS Ins ON Ev.IdInstituicao = Ins.IdInstituicao
	JOIN TiposDeEvento AS TE ON Ev.IdTipoDeEvento = TE.IdTipoDeEvento
WHERE
	Ev.IdEvento = PE.IdEvento

SELECT 
	Us.Nome AS NomeUsuario,
	TU.NomeTipoDeUsuario AS TipoUsuario,
	Ev.DataEvento AS DataEvento,
	--CONCAT (Ins.NomeFantasia, ' - ', Ins.Endereco) AS LocalEvento,
	'Escola ' + Ins.NomeFantasia + ' - ' + Ins.Endereco AS LocalEvento,
	TE.NomeTipoDeEvento AS TipoEvento,
	Ev.Nome AS NomeEvento,
	Ev.Descricao AS DescricaoEvento,
	CASE WHEN PE.Situacao = 1 THEN 'Confirmado' ELSE 'Não confirmado' END AS Situacao,
	CE.Descricao AS Comentario
FROM Evento as Ev
	JOIN TiposDeEvento AS TE ON Ev.IdTipoDeEvento = TE.IdTipoDeEvento
	JOIN Instituicao AS Ins ON Ev.IdInstituicao = Ins.IdInstituicao
	JOIN PresencasEvento AS PE ON Ev.IdEvento = PE.IdEvento
	JOIN Usuario AS Us ON Us.IdUsuario = PE.IdUsuario AND PE.IdUsuario = Us.IdUsuario
	JOIN TiposDeUsuario AS TU ON Us.IdTipoDeUsuario = TU.IdTipoDeUsuario
	LEFT JOIN ComentarioEvento AS CE ON Us.IdUsuario = CE.IdUsuario AND Ev.IdEvento = CE.IdEvento
