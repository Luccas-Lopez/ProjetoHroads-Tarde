CREATE DATABASE SENAI_HROADS_TARDE;
GO

USE SENAI_HROADS_TARDE;
GO

------------------------------------------------------------DDL----------------------------------------------------------------

CREATE TABLE classe(
idClasse TINYINT PRIMARY KEY IDENTITY (1,1),
nomeClasse VARCHAR (20)NOT NULL UNIQUE
);
GO

CREATE TABLE tipoUsuario(
idTipoUsuario SMALLINT PRIMARY KEY IDENTITY (1,1),
nomeTipoUsuario VARCHAR (20) NOT NULL
); 
GO


CREATE TABLE usuario(
idUsuario SMALLINT PRIMARY KEY IDENTITY (1,1),
nomeUsuario VARCHAR (50),
email VARCHAR (200),
senha VARCHAR (100),
idTipoUsuario SMALLINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario)
);
GO

CREATE TABLE tipoHabilidade(
idTipoHabilidade TINYINT PRIMARY KEY IDENTITY (1,1),
nomeTipoHabilidade VARCHAR (25) UNIQUE
);
GO

CREATE TABLE habilidade (
idHabilidade TINYINT PRIMARY KEY IDENTITY (1,1),
nomeHabilidade VARCHAR (50) NOT NULL UNIQUE,
idTipoHabilidade TINYINT FOREIGN KEY REFERENCES tipoHabilidade (idTipoHabilidade)
);
GO
 
CREATE TABLE classeHabilidade(
idClasseHabilidade TINYINT PRIMARY KEY IDENTITY (1,1),
idHabilidade TINYINT FOREIGN KEY REFERENCES habilidade (idHabilidade),
idClasse TINYINT FOREIGN KEY REFERENCES classe (idClasse)
);
GO

drop table classeHabilidade
drop table personagem

CREATE TABLE personagem(
nomePersonagem VARCHAR (256) UNIQUE NOT NULL,
idPersonagem  TINYINT PRIMARY KEY IDENTITY (1,1),
idClasse TINYINT FOREIGN KEY REFERENCES classe (idClasse),
capacidadeVida INT,
capacidadeMana INT,
dataAtualizacao DATE,
dataCriacao DATE
);
GO

------------------------------------------------------------DML----------------------------------------------------------------

INSERT classe (nomeClasse)
VALUES ('BÁRBARO'),('CRUZADO'),('CAÇADORA DE DEMÔNIOS'),('MONGE'),('NECROMANTE'),('FEITICEIRO'),('ARCANISTA');
GO

INSERT tipoHabilidade(nomeTipoHabilidade)
VALUES ('ATAQUE'), ('DEFESA'), ('CURA'), ('MAGIA');
GO


 INSERT habilidade (nomeHabilidade, idTipoHabilidade)
 VALUES ('Lança Mortal',1), ('Escudo Supremo',2),('Recuperar Vida',3);
 GO

INSERT classeHabilidade (idClasse, idHabilidade)
VALUES (1,1),(2,2),(3,1),(4,3),(5,NULL),(6,3),(7,NULL),(1,2),(4,2);
GO


INSERT personagem (idClasse, nomePersonagem,capacidadeVida,capacidadeMana,dataAtualizacao,dataCriacao)
VALUES (1,'DeuBug','100','80',GETDATE(),'18/01/2019'), (4,'BitBug','70','100',GETDATE(),'17/03/2016'), (7,'Fer8','75','60',GETDATE(),'18/03/2018');
GO

INSERT tipoUsuario (nomeTipoUsuario)
VALUES ('ADM'),('JOGADOR');
GO

INSERT usuario(nomeUsuario, email, senha, idTipoUsuario)
VALUES ('Saulove', 'saulo@email.com','saulo123',1), ('nay_ara777', 'nay777@email.com', 'nayara123',2),('lucas_nepomusceninho','lucas@email.com', 'lucas123',2)
--Atualizar o nome do personagem Fer8 para Fer7;
UPDATE personagem SET nomePersonagem = 'Fer7' WHERE idPersonagem = 3
--Atualizar o nome da classe de Necromante para Necromancer;
UPDATE classe SET nomeClasse = 'NECROMANCER' WHERE idClasse = 5

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



