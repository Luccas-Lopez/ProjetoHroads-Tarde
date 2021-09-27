USE SENAI_HROADS_TARDE;
GO
------------------------------------------------------------DQL----------------------------------------------------------------

--Selecionar todos as classes;
SELECT * FROM classe
--Selecionar todos os tipos de habilidades;
SELECT * FROM tipoHabilidade
--Selecionar todas as habilidades;
SELECT * FROM habilidade
SELECT * FROM classeHabilidade
--Selecionar todos os personagens;
SELECT * FROM personagem
--Selecionar todos os tipos de usuários;
SELECT * FROM tipoUsuario
--Selecionar todos os usuários;
SELECT * FROM usuario
WHERE email = 'saulo@email.com' AND senha = 'saulo123'

--Selecionar somente o nome das classes;
SELECT nomeClasse AS Classe FROM CLASSE;
GO

--Realizar a contagem de quantas habilidades estão cadastradas;
SELECT COUNT (*) AS Habilidades FROM HABILIDADE;
GO

--Selecionar somente os id’s das habilidades classificando-os por ordem crescente;
SELECT idHabilidade AS 'ID das habilidades em ordem crescente'
FROM  HABILIDADE
ORDER BY  idHabilidade ASC

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;
SELECT nomeHabilidade AS 'Habilidade', nomeTipoHabilidade AS 'Tipo da habilidade' FROM habilidade
INNER JOIN tipoHabilidade
ON tipoHabilidade.idTipoHabilidade = habilidade.idTipoHabilidade

--Selecionar todos os personagens e suas respectivas classes;
SELECT nomePersonagem AS 'Personagem',nomeClasse as 'Classe' FROM personagem
INNER JOIN CLASSE
ON classe.idClasse = personagem.idClasse

--Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);
SELECT nomePersonagem AS 'Personagem',nomeClasse AS 'Classe' FROM PERSONAGEM
RIGHT JOIN CLASSE
ON CLASSE.idClasse = PERSONAGEM.idClasse

--Selecionar todas as classes e suas respectivas habilidades;
SELECT nomeClasse AS Classe, nomeHabilidade AS Habilidade FROM CLASSE
INNER JOIN classeHabilidade
ON CLASSE.idClasse  = classeHabilidade.idClasse
INNER JOIN HABILIDADE
ON HABILIDADE.idHabilidade = classeHabilidade.idHabilidade;
GO

--Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
SELECT nomeClasse AS Classe, nomeHabilidade AS Habilidade FROM CLASSE
RIGHT JOIN classeHabilidade
ON classe.idClasse  = classeHabilidade.idClasse
RIGHT JOIN HABILIDADE
ON HABILIDADE.idHabilidade = classeHabilidade.idHabilidade;
GO

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT nomeClasse AS Classe, nomeHabilidade AS Habilidade FROM classeHabilidade
LEFT JOIN CLASSE
ON CLASSE.idClasse  = classeHabilidade.idClasse
LEFT JOIN HABILIDADE
ON HABILIDADE.idHabilidade = classeHabilidade.idHabilidade;
GO


