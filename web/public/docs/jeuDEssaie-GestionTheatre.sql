-- Insertion dans Client
INSERT INTO Client (cli_nom, cli_prenom, cli_email, cli_tel) 
VALUES 
    ('Juino', 'Milan', 'milanjuino@gmail.com', '0651282551'),
    ('Rogue', 'Emmanuel', 'emmanuelrogue@gmail.com', '0710397693'),
    ('Bonaventure', 'Noah', 'noahbonaventure@gmail.com', '0627843779'),
    ('Morel', 'Emma', 'emmamorel@gmail.com', '0712345678'),
    ('Leclere', 'Adrien', 'adrienleclere@gmail.com', '0692019372');


-- Insertion dans Tarif
INSERT INTO Tarif (tar_lib, tar_var) 
VALUES 
    ('Standard', 0.0), 
    ('Semaine de nuit', 5), 
    ('Semaine de jour', -5), 
    ('Week end de jour', 10),
    ('Week end de nuit', 15);

-- Insertion dans Compagnies
INSERT INTO Compagnies (comp_nom, comp_ville, comp_directeur) 
VALUES 
    ('Les Dramaturges', 'Paris', 'Paul Mirabel'),
    ('Hell Takers', 'Lyon', 'Claire Renaud'),
    ('Th��tre � Vie', 'Marseille', 'Julien Sorel'),
    ('Les Troubadours', 'Toulouse', 'Rom�o Juliet');

-- Insertion dans Theme
INSERT INTO Theme (the_nom) 
VALUES 
    ('Com�die'), 
    ('Drame'), 
    ('Thriller'), 
    ('Musical');

-- Insertion dans Auteur
INSERT INTO Auteur (aut_nom, aut_prenom) 
VALUES 
    ('Moli�re', 'Jean-Baptiste'), 
    ('Hugo', 'Victor'), 
    ('Camus', 'Albert'), 
    ('Rabelai', 'Pierre');

-- Insertion dans Publics
INSERT INTO Publics (pub_categ) 
VALUES 
    ('Tout public'), 
    ('Enfants'), 
    ('Adolescents'), 
    ('Adultes uniquement');

-- Insertion dans Pieces
INSERT INTO Pieces (pie_nom, pie_prix, pie_descrip, pie_duree, pie_comp, pie_pub, pie_the, pie_aut) 
VALUES 
    ('Le Malade Imaginaire', 30.00, 'Com�die c�l�bre de Moli�re.', 120, 1, 1, 1, 1),
    ('Les Mis�rables', 45.00, 'Adaptation du roman de Victor Hugo.', 180, 2, 1, 2, 2),
    ('La Peste', 35.00, 'Drame philosophique par Camus.', 150, 3, 4, 2, 3),
    ('Gargantua', 25.00, 'Th��tre de l humour par Rabelai.', 90, 4, 1, 3, 4);

-- Insertion dans Representation
INSERT INTO Representation (rep_heure, rep_date, rep_lieu, rep_nb_place_max, rep_pie, rep_tar) 
VALUES 
    ('10:30', '2024-01-12', 'Th��tre de Paris', 300, 1, 2),
    ('19:30', '2024-01-12', 'Th��tre de Paris', 300, 1, 3),
    ('10:00', '2024-05-12', 'Op�ra de Lyon', 500, 2, 2),
    ('20:00', '2024-05-12', 'Op�ra de Lyon', 500, 2, 3),
    ('10:00', '2024-11-11', 'Th��tre National de Marseille', 200, 3, 4),
    ('18:00', '2024-11-11', 'Th��tre National de Marseille', 200, 3, 4),
    ('11:00', '2024-09-10', 'Sc�ne de Toulouse', 150, 4, 5),
    ('21:00', '2024-09-10', 'Sc�ne de Toulouse', 150, 4, 5);

-- Insertion dans Comediens
INSERT INTO Comediens (come_nom, come_prenom, come_nationalite, come_age, come_comp) 
VALUES 
    ('Lemoine', 'Antoine', 'Fran�ais', 35, 1),
    ('Dupuis', 'Marie', 'Fran�ais', 28, 2),
    ('Smith', 'John', 'Anglais', 40, 3),
    ('Cotte', 'Djimmy', 'Fran�ais', 19, 3),
    ('Carton', 'Sasha', 'Fran�ais', 20, 3),
    ('Salgueiro', 'Helder', 'Portugais', 19, 3),
    ('Robin', 'Margot', 'Anglais', 30, 4),
    ('Losse', 'Margaux', 'Fran�ais', 24, 1),
    ('Plichta', 'Juliette', 'Portugais', 23, 1),
    ('Charmant', 'Rom�o', 'Allemand', 60, 2),
    ('Garcia', 'Pedro', 'Espagnol', 30, 4);

INSERT INTO Utilisateur (uti_login, uti_mdp) 
VALUES ('admin', 'admin');

-- Insertion dans Reservation
INSERT INTO Reservation (res_cli, res_rep, res_nb_place) 
VALUES 
    (1, 1, 2), 
    (2, 1, 3),
    (3, 2, 4), 
    (4, 3, 1), 
    (2, 4, 2), 
    (1, 2, 5);
GO
