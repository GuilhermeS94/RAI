CREATE DATABASE TesteEntrevista
GO
USE TesteEntrevista
GO

CREATE TABLE Pessoas(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Login] VARCHAR(50) NOT NULL,
	Senha VARCHAR (35) NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	Nivel SMALLINT NOT NULL
);