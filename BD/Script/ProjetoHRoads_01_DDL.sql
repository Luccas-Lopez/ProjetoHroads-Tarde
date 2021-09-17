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

CREATE TABLE tipoHabilidade(
idTipoHabilidade TINYINT PRIMARY KEY IDENTITY (1,1),
nomeTipoHabilidade VARCHAR (25) UNIQUE
);
GO

CREATE TABLE HABILIDADE (
idTipoHabilidade TINYINT FOREIGN KEY REFERENCES tipoHabilidade (idTipoHabilidade),
idHabilidade TINYINT PRIMARY KEY IDENTITY (1,1),
nomeHabilidade VARCHAR (50) NOT NULL UNIQUE
);
GO

CREATE TABLE classeHabilidade(
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

CREATE TABLE tipoUsuario (
idTipoUsuario TINYINT PRIMARY KEY IDENTITY (1,1),
nomeTipoUsuario VARCHAR (25) NOT NULL UNIQUE
);
go

CREATE TABLE USUARIO (
idUsuario TINYINT PRIMARY KEY IDENTITY (1,1),
idTipoUsuario TINYINT FOREIGN KEY REFERENCES tipoUsuario (idTipoUsuario),
nomeUsuario VARCHAR (100) UNIQUE NOT NULL,
email VARCHAR (100) UNIQUE NOT NULL,
senha VARCHAR (30) UNIQUE NOT NULL
);
GO


GO