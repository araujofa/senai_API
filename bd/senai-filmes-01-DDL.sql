CREATE DATABASE Filmes_tarde;

USE Filmes_tarde;

CREATE TABLE Generos(
	IdGenero	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR (255) NOT NULL UNIQUE
);

CREATE TABLE Filmes(
	IdFilme		INT PRIMARY KEY IDENTITY
	,Titulo		VARCHAR (255) NOT NULL UNIQUE
	,IdGenero	INT FOREIGN KEY REFERENCES Generos (IdGenero)
);