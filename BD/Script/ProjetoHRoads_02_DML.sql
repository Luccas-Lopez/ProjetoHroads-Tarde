USE SENAI_HROADS_TARDE;
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
