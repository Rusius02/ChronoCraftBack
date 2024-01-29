IF EXISTS (SELECT * FROM sysobjects WHERE name='users' and xtype='U')
DROP TABLE sessions;

IF EXISTS (SELECT * FROM sysobjects WHERE name='plans' and xtype='U')
DROP TABLE personnes;

IF EXISTS (SELECT * FROM sysobjects WHERE name='chronos' and xtype='U')
DROP TABLE parcours;

CREATE TABLE users(
id INT IDENTITY PRIMARY KEY,
nom VARCHAR(200) NOT NULL,
prenom VARCHAR(200) NOT NULL,
);

CREATE TABLE plans(
id INT IDENTITY PRIMARY KEY,
nom VARCHAR(200) NOT NULL,
temps_marche_minutes INT NOT NULL,
temps_course_minutes INT NOT NULL
);

CREATE TABLE chronos(
id INT IDENTITY PRIMARY KEY,
id_utilisateur INT FOREIGN KEY REFERENCES personnes(id),
id_parcours INT FOREIGN KEY REFERENCES parcours(id),
type VARCHAR (50) NOT NULL,
temps_minutes INT NOT NULL
);

INSERT INTO Users(nom, prenom)
VALUES('Stievenart', 'Adrien'),
      ('Stievenart', 'Marie'),
      ('Thienponds', 'Cyril'),
      ('Ferrez', 'Jeanne');

INSERT INTO Plans(nom, temps_marche_minutes,temps_course_minutes)
VALUES('Trail des Joncquilles', 150, 90),
      ('Jogging du coeur', 75, 30);

INSERT INTO Chronos(id_utilisateur, id_parcours, type, temps_minutes)
VALUES(1, 1,'course', 83),
      (1, 2, 'course', 27),
      (2, 2, 'marche', 72);