USE EscolaDeIdiomas
GO

INSERT INTO Alunos (idAluno, nomeCompleto, cpf, email)
VALUES('a4ec4f4e-2867-4b78-9029-e7d47aa2fb01','Mateus Rodrigues', '68098450031','mateus@email.com'),
	('b609db2e-1958-4114-98cf-82371b43e40f','Carlos Augusto','12345678999','carlos@email.com'),
	('a2b5de86-5d73-466f-9a76-3ee221f5ee0f','Vinicius Figueiroa','49278288080','vinicius@email.com'),
	('e8df7d7b-e1fe-48bd-80a1-09e7c18edd7e','Paulo Brandão','69025933025','paulo@email.com'),
	('80bc4b81-7fe5-47cd-bd14-dcd5c6317a88', 'Saulo Santos', '24197333048','saulo@email.com'),
	('2d6734fb-3971-43bd-96ce-cb0f65bf769a', 'Carlos Tsukamoto','80106940023', 'carlostsuka@email.com'),
	('197d2787-fec6-e830-e6ed-f6740137b5df', 'João Soares','26536869028', 'joao@email.com'),
	('c2ebed27-6196-596c-4b19-607239873f0c','Maria Silva','49996230058','maria@email.com' ),
	('0e2619ea-5742-f5d5-4237-953960134115','Leonardo Costa', '55020770043', 'leonardo@email.com'),
	('7a92ed4b-28db-8d17-b9d7-e13f7484f5f8', 'Miguel Melo','79042131098','miguel@email.com'),
	('319d7165-c5ce-be50-4171-674c26c2f0d6','Murilo Silva','57591643045', 'murilo@email.com')
GO


INSERT INTO Turmas(idTurma, numeroTurma, anoLetivo, descricaoTurma)
VALUES('a6ffea61-862d-428e-b56f-9ddf8923bc6c',1,'2022','Inglês'),
	('ce4cee97-bf73-432a-a50c-b69a23cf147a',2,'2023','Alemão'),
	('1fb577b1-0aba-43b3-800c-7c6839a333b7',3,'2024','Espanhol')
GO

INSERT INTO Matriculas(idMatricula, idAluno, idTurma)
VALUES('c7f40b10-97e6-43d3-1301-260b07efe4ad','b609db2e-1958-4114-98cf-82371b43e40f','a6ffea61-862d-428e-b56f-9ddf8923bc6c'),
	('dec107b4-6318-46f0-c94a-71ca5dc93e8f','a2b5de86-5d73-466f-9a76-3ee221f5ee0f','a6ffea61-862d-428e-b56f-9ddf8923bc6c'),
	('86f59797-1e3a-b243-17fd-2f1c1d2e08d5','a4ec4f4e-2867-4b78-9029-e7d47aa2fb01','a6ffea61-862d-428e-b56f-9ddf8923bc6c'),
	('6bf3c714-8a7a-82e1-240c-42621450e735','e8df7d7b-e1fe-48bd-80a1-09e7c18edd7e','a6ffea61-862d-428e-b56f-9ddf8923bc6c'),
	('c80ad692-a67a-a9f0-9c85-a6927583962e','80bc4b81-7fe5-47cd-bd14-dcd5c6317a88','a6ffea61-862d-428e-b56f-9ddf8923bc6c'),
	('eb9c984c-af29-7c7a-f7dc-a8b482a204b2','2d6734fb-3971-43bd-96ce-cb0f65bf769a','ce4cee97-bf73-432a-a50c-b69a23cf147a'),
	('283fa435-97cd-b843-3570-9f0540c41036','197d2787-fec6-e830-e6ed-f6740137b5df','ce4cee97-bf73-432a-a50c-b69a23cf147a'),
	('59240eb2-45a8-9638-4f24-e80e94da84d5','c2ebed27-6196-596c-4b19-607239873f0c','ce4cee97-bf73-432a-a50c-b69a23cf147a'),
	('b6ae0d0a-2645-e71b-a567-b1c6a6a35b40','0e2619ea-5742-f5d5-4237-953960134115','ce4cee97-bf73-432a-a50c-b69a23cf147a'),
	('73fbd9d6-4154-1639-e4de-23c5fad93484','7a92ed4b-28db-8d17-b9d7-e13f7484f5f8','ce4cee97-bf73-432a-a50c-b69a23cf147a'),
	('ba0aef92-71f9-73ab-13a5-64d9dbf76df4','319d7165-c5ce-be50-4171-674c26c2f0d6','1fb577b1-0aba-43b3-800c-7c6839a333b7')
GO

