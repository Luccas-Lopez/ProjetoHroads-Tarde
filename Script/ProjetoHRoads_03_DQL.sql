USE SENAI_HROADS_TARDE;
GO
------------------------------------------------------------DQL----------------------------------------------------------------

--Selecionar todos as classes;
SELECT * FROM CLASSE
--Selecionar todos os tipos de habilidades;
SELECT * FROM TIPO_HABILIDADE
--Selecionar todas as habilidades;
SELECT * FROM HABILIDADE
SELECT * FROM CLASSE_HABILIDADE
--Selecionar todos os personagens;
SELECT * FROM PERSONAGEM


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
SELECT nomeHabilidade AS 'Habilidade', nomeTipoHabilidade AS 'Tipo da habilidade' FROM HABILIDADE
INNER JOIN TIPO_HABILIDADE
ON TIPO_HABILIDADE.idTipoHabilidade = HABILIDADE.idTipoHabilidade

--Selecionar todos os personagens e suas respectivas classes;
SELECT nomePersonagem AS 'Personagem',nomeClasse as 'Classe' FROM PERSONAGEM
INNER JOIN CLASSE
ON CLASSE.idClasse = PERSONAGEM.idClasse

--Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);
SELECT nomePersonagem AS 'Personagem',nomeClasse AS 'Classe' FROM PERSONAGEM
RIGHT JOIN CLASSE
ON CLASSE.idClasse = PERSONAGEM.idClasse

--Selecionar todas as classes e suas respectivas habilidades;
SELECT nomeClasse AS Classe, nomeHabilidade AS Habilidade FROM CLASSE
INNER JOIN CLASSE_HABILIDADE
ON CLASSE.idClasse  = CLASSE_HABILIDADE.idClasse
INNER JOIN HABILIDADE
ON HABILIDADE.idHabilidade = CLASSE_HABILIDADE.idHabilidade;
GO

--Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
SELECT nomeClasse AS Classe, nomeHabilidade AS Habilidade FROM CLASSE
RIGHT JOIN CLASSE_HABILIDADE
ON classe.idClasse  = CLASSE_HABILIDADE.idClasse
RIGHT JOIN HABILIDADE
ON HABILIDADE.idHabilidade = CLASSE_HABILIDADE.idHabilidade;
GO

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT nomeClasse AS Classe, nomeHabilidade AS Habilidade FROM CLASSE_HABILIDADE
LEFT JOIN CLASSE
ON CLASSE.idClasse  = CLASSE_HABILIDADE.idClasse
LEFT JOIN HABILIDADE
ON HABILIDADE.idHabilidade = CLASSE_HABILIDADE.idHabilidade;
GO