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