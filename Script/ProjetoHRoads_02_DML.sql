USE SENAI_HROADS_TARDE;
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