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