-- sqllocaldb c demo01ado
-- sqllocaldb s demo01ado

CREATE DATABASE contactDB;
GO

-- on se positionne sur la base de données
USE contactDB;
GO

-- Création de la table personne
CREATE TABLE personne (
	id INT IDENTITY(1,1) PRIMARY KEY,
	prenom VARCHAR(50) NOT NULL,
	nom VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL
);
GO

-- ajout d'un enregistrement dans la table personne
INSERT INTO 
	personne 
	(prenom, nom, email)
VALUES 
	('toto', 'titi', 'toto@titi.fr');
GO

SELECT * FROM personne;
GO