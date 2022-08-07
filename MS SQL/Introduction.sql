Go
CREATE DATABASE [Minions]

USE [Minions]
Go
CREATE TABLE [Minions]([ID] INT  PRIMARY KEY NOT NULL,[Name] NVARCHAR(50),[Age] INT)

CREATE TABLE [Towns]([ID] INT PRIMARY KEY NOT NULL, [TownName] NVARCHAR(50))
 
 DROP TABLE Minions

ALTER TABLE [Minions] 
ADD [TownID] INT FOREIGN KEY REFERENCES [Towns]([ID]) NOT NULL


INSERT INTO Towns ([ID],[TownName])
VALUES 
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO [Minions] ([ID],[Name],[Age],[TownID])
VALUES 
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

CREATE TABLE [People]
(
[Id] INT IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY,
CHECK (DATALENGTH(Picture) <=2000000),
[Height] DECIMAL(3,2),
[Weight] DECIMAL(3,2),
[Gender] CHAR(1) NOT NULL,
CHECK( [Gender]='m' OR [Gender]='f'),
[Birthdate] DATE NOT NULL,
[Biography] NVARCHAR(MAX)
)
INSERT INTO [People] ([Name],[Gender],[Birthdate])
VALUES 
('Pesho','m','1993-12-12'),
('Mimi','f','1343-09-11'),
('Viki','m','1293-10-10'),
('Pesha','f','1793-12-12'),
('Mesho','f','1973-02-05')


CREATE TABLE [Users] 
(
[Id] BIGINT IDENTITY(1,1) PRIMARY KEY,
[Username] VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARBINARY,
CHECK ( DATALENGTH(ProfilePicture)<900000 ),
[LastLoginTime] DATETIME2,
[IsDeleted] BIT
) 
INSERT INTO [Users] ([Username],[Password])
VALUES 
('Pesho','dfasmas'),
('Mimi','ffasd'),
('Viki','masdf'),
('Pesha','fasdf'),
('Mesho','sffasdf')

DROP TABLE [Users]
ALTER TABLE [Users]
ADD CONSTRAINT Df_Value DEFAULT GETDATE() FOR [LastLoginTime]

INSERT INTO [Users] ([Username],[Password])
VALUES 
('Daniel','udrisirenie')
SELECT * FROM [Users]
WHERE [Username]='Daniel'


-- Problem 13
GO
CREATE DATABASE [Movies]
USE [Movies]
GO


CREATE TABLE [Directors]
(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[DirectorName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Genres]
(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[GenreName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Categories]
(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[CategoryName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Movies]
(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Title] NVARCHAR(50) NOT NULL,
[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
[CopyrightYear] DATE,
[Length] INT NOT NULL,
[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
[Rating] DECIMAL(3,2),
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors] ([DirectorName] ,[Notes])
VALUES 
('Pesho',NULL),
('Mimi','Check amount'),
('Viki','verify'),
('Pesha','qjaaa'),
('Mesho',NULL)
INSERT INTO [Genres] ([GenreName] ,[Notes])
VALUES 
('Action',NULL),
('Comedy','LOL'),
('Documetary','learn something new'),
('Horror','a lot scared'),
('Thriller',NULL)
INSERT INTO [Categories] ([CategoryName] ,[Notes])
VALUES 
('Actionable',NULL),
('Funny','LOL'),
('Documetal','learn something new'),
('Scare','a lot scared'),
('Strange',NULL)
INSERT INTO [Movies]  ([Title] ,[DirectorId],[Length] ,[GenreId],[CategoryId])
VALUES 
('Annabel',1,60,4,4),
('Fast And Furious',3,90,1,1),
('yeazzy',2,15,2,2),
('Alabama',5,60,3,5),
('Hobit',4,120,1,2)


