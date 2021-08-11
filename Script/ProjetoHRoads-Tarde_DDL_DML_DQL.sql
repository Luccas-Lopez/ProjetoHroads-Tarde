CREATE DATABASE SENAI_HROADS_TARDE;
GO

USE SENAI_HROADS_TARDE;
GO

------------------------------------------------------------DDL----------------------------------------------------------------

CREATE TABLE CLASSE(
idClasse TINYINT PRIMARY KEY IDENTITY (1,1),
nomeClasse VARCHAR (20)NOT NULL UNIQUE
);
GO

CREATE TABLE TIPO_HABILIDADE(
idTipoHabilidade TINYINT PRIMARY KEY IDENTITY (1,1),
nomeTipoHabilidade VARCHAR (25) UNIQUE
);
GO

CREATE TABLE HABILIDADE (
idHabilidade TINYINT PRIMARY KEY IDENTITY (1,1),
nomeHabilidade VARCHAR (50) NOT NULL UNIQUE
);
GO
 
ALTER TABLE HABILIDADE
ADD idTipoHabilidade TINYINT FOREIGN KEY REFERENCES TIPO_HABILIDADE (idTipoHabilidade);
GO

CREATE TABLE CLASSE_HABILIDADE(
idHabilidade TINYINT FOREIGN KEY REFERENCES HABILIDADE (idHabilidade),
idClasse TINYINT FOREIGN KEY REFERENCES CLASSE (idClasse)
);
GO

CREATE TABLE PERSONAGEM(
nomePersonagem VARCHAR (6) UNIQUE NOT NULL,
idPersonagem  TINYINT PRIMARY KEY IDENTITY (1,1),
idClasse TINYINT FOREIGN KEY REFERENCES CLASSE (idClasse),
capacidadeVida INT,
capacidadeMana INT,
dataAtualizacao DATE,
dataCriacao DATE
);
GO

------------------------------------------------------------DML----------------------------------------------------------------

INSERT CLASSE (nomeClasse)
VALUES ('BÁRBARO'),('CRUZADO'),('CAÇADORA DE DEMÔNIOS'),('MONGE'),('NECROMANTE'),('FEITICEIRO'),('ARCANISTA');
GO

INSERT TIPO_HABILIDADE (nomeTipoHabilidade)
VALUES ('ATAQUE'), ('DEFESA'), ('CURA'), ('MAGIA');
GO


 INSERT HABILIDADE (nomeHabilidade, idTipoHabilidade)
 VALUES ('Lança Mortal',1), ('Escudo Supremo',2),('Recuperar Vida',3);
 GO

INSERT CLASSE_HABILIDADE(idClasse, idHabilidade)
VALUES (1,1),(2,2),(3,1),(4,3),(5,NULL),(6,3),(7,NULL),(1,2),(4,2);
GO


INSERT PERSONAGEM (idClasse, nomePersonagem,capacidadeVida,capacidadeMana,dataAtualizacao,dataCriacao)
VALUES (1,'DeuBug','100','80',GETDATE(),'18/01/2019'), (4,'BitBug','70','100',GETDATE(),'17/03/2016'), (7,'Fer8','75','60',GETDATE(),'18/03/2018');
GO

--Atualizar o nome do personagem Fer8 para Fer7;
UPDATE PERSONAGEM SET nomePersonagem = 'Fer7' WHERE idPersonagem = 3
--Atualizar o nome da classe de Necromante para Necromancer;
UPDATE CLASSE SET nomeClasse = 'NECROMANCER' WHERE idClasse = 5

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



