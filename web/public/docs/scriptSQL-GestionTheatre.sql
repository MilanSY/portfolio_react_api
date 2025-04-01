-- Cr�ation de la base de donn�es
CREATE DATABASE Gestion_Theatre;
GO

-- Utilisation de la base de donn�es
USE Gestion_Theatre;
GO

-- Cr�ation des tables
CREATE TABLE Utilisateur (
    uti_login VARCHAR(50) PRIMARY KEY,
    uti_mdp NVARCHAR(255) NOT NULL
);

CREATE TABLE Client (
    cli_id INT PRIMARY KEY IDENTITY(1,1),
    cli_nom NVARCHAR(50) NOT NULL,
    cli_prenom NVARCHAR(50) NOT NULL,
    cli_email NVARCHAR(100) UNIQUE NOT NULL,
    cli_tel NVARCHAR(20)
);

CREATE TABLE Tarif (
    tar_id INT PRIMARY KEY IDENTITY(1,1),
    tar_lib NVARCHAR(50) NOT NULL,
    tar_var FLOAT NOT NULL
);

CREATE TABLE Compagnies (
    comp_id INT PRIMARY KEY IDENTITY(1,1),
    comp_nom NVARCHAR(100) NOT NULL,
    comp_ville NVARCHAR(100),
    comp_directeur NVARCHAR(100)
);

CREATE TABLE Theme (
    the_id INT PRIMARY KEY IDENTITY(1,1),
    the_nom NVARCHAR(50) NOT NULL
);

CREATE TABLE Auteur (
    aut_id INT PRIMARY KEY IDENTITY(1,1),
    aut_nom NVARCHAR(50) NOT NULL,
    aut_prenom NVARCHAR(50) NOT NULL
);

CREATE TABLE Publics (
    pub_id INT PRIMARY KEY IDENTITY(1,1),
    pub_categ NVARCHAR(50) NOT NULL
);

CREATE TABLE Pieces (
    pie_id INT PRIMARY KEY IDENTITY(1,1),
    pie_nom NVARCHAR(100) NOT NULL,
    pie_prix FLOAT NOT NULL,
    pie_descrip NVARCHAR(MAX),
    pie_duree INT,
    pie_comp INT,
    pie_pub INT,
    pie_the INT,
    pie_aut INT,
    FOREIGN KEY (pie_comp) REFERENCES Compagnies(comp_id),
    FOREIGN KEY (pie_pub) REFERENCES Publics(pub_id),
    FOREIGN KEY (pie_the) REFERENCES Theme(the_id),
    FOREIGN KEY (pie_aut) REFERENCES Auteur(aut_id)
);

CREATE TABLE Representation (
    rep_id INT PRIMARY KEY IDENTITY(1,1),
    rep_heure TIME NOT NULL,
    rep_date DATE NOT NULL,
    rep_lieu NVARCHAR(100) NOT NULL,
    rep_nb_place_max INT NOT NULL,
    rep_pie INT NOT NULL,
    rep_tar INT NOT NULL,
    FOREIGN KEY (rep_pie) REFERENCES Pieces(pie_id),
    FOREIGN KEY (rep_tar) REFERENCES Tarif(tar_id)
);

CREATE TABLE Comediens (
    come_id INT PRIMARY KEY IDENTITY(1,1),
    come_nom NVARCHAR(50) NOT NULL,
    come_prenom NVARCHAR(50) NOT NULL,
    come_nationalite NVARCHAR(50),
    come_age INT,
    come_comp INT,
    FOREIGN KEY (come_comp) REFERENCES Compagnies(comp_id)
);

CREATE TABLE Reservation (
    res_cli INT,
    res_rep INT,
    res_nb_place INT NOT NULL,
    PRIMARY KEY (res_cli, res_rep),
    FOREIGN KEY (res_cli) REFERENCES Client(cli_id),
    FOREIGN KEY (res_rep) REFERENCES Representation(rep_id)
);
GO
