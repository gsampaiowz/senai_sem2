INSERT INTO Estudio VALUES (NEWID(), 'Blizzard') 
SELECT * FROM Estudio

INSERT INTO Jogo VALUES (NEWID(), 'Diablo 3', 'Ótimo jogo', '2013-05-01', 199, 'E325F389-7054-47E2-883C-39260CDA397D')
SELECT * FROM Jogo

INSERT INTO TipoUsuario VALUES (NEWID(), 'Comum'), (NEWID(),'Administrador')
SELECT * FROM TipoUsuario

INSERT INTO Usuario VALUES (NEWID(), 'comum@comum.com', 'comum123', '09DB9941-19A3-4921-B074-F43747988FF9'), (NEWID(), 'admin@admin.com', 'admin123', '5A6C8130-ACBA-4643-8CA4-F23894A790D9') 
SELECT * FROM Usuario