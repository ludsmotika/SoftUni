--Problem 1

CREATE DATABASE [Bitbucket]

USE [Bitbucket]

CREATE TABLE [Users] 
(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
Email VARCHAR(50) NOT NULL,
)

CREATE TABLE Repositories 
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
PRIMARY KEY (RepositoryId,ContributorId)
)

CREATE TABLE Issues
(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(255) NOT NULL,
IssueStatus VARCHAR(6) NOT NULL,
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Commits
(
Id INT PRIMARY KEY IDENTITY,
[Message] VARCHAR(255) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Files
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL(20,2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)


--Problem 2

INSERT INTO Files 
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues 
VALUES
('Critical Problem with HomeController.cs file', 'open',1, 4),
('Typo fix in Judge.html',	'open',	4,	3),
('Implement documentation for UsersService.cs',	'closed',	8,	2),
('Unreachable code in Index.cs'	,'open'	,9,	8)

--Problem 3

UPDATE Issues
SET IssueStatus ='closed'
WHERE AssigneeId =6

--Problem 4

DELETE Issues 
WHERE RepositoryId =(
						SELECT Id FROM Repositories 
						WHERE [Name]= 'Softuni-Teamwork'
				     )

DELETE RepositoriesContributors 
WHERE RepositoryId =(
						SELECT Id FROM Repositories 
						WHERE [Name]= 'Softuni-Teamwork'
				     )

--Problem 5

SELECT Id,[Message], RepositoryId , ContributorId  FROM [Commits] 
ORDER BY Id,[Message], RepositoryId , ContributorId 

--Problem 6

SELECT [Id], [Name], [Size] FROM [Files]
WHERE [Size] >1000 AND [Name] LIKE '%html%'
ORDER BY [Size] DESC, [Id], [Name]

--Problem 7

SELECT i.Id,CONCAT(u.Username,' : ',i.Title ) AS [IssueAssignee] FROM [Issues] AS [i]
JOIN [Users] AS [u] ON i.AssigneeId = u.Id 
ORDER BY i.Id DESC, i.AssigneeId

--Problem 8 
SELECT [Id],[Name],CONCAT([Size],'KB') AS [Size]  FROM [Files] AS [f]
WHERE f.Id NOT IN (SELECT fi.[ParentId] FROM [Files] AS [fi]) 
ORDER BY Id,[Name],[Size] DESC

SELECT * FROM [Files]

--Problem 9

SELECT TOP(5) r.[Id],[Name],COUNT(c.RepositoryId)  FROM [Repositories] AS [r]
JOIN Commits AS [c] ON c.RepositoryId=r.Id
JOIN [RepositoriesContributors]  AS [rc] ON rc.RepositoryId =r.Id
GROUP BY r.Id ,r.[Name] 
ORDER BY COUNT(c.RepositoryId) DESC, r.Id ,r.[Name]

--Problem 10

SELECT u.[Username] , AVG(f.Size) AS [Size] FROM [Users] AS [u]
JOIN [Commits] AS [c] ON u.Id =c.ContributorId 
JOIN [Files] AS [f] ON c.Id =f.CommitId 
GROUP BY u.[Username]
ORDER BY AVG(f.Size) DESC, u.Username 


--Problem 11

CREATE FUNCTION udf_AllUserCommits (@username VARCHAR(50))
RETURNS INT 
BEGIN
DECLARE @userId INT 
SET @userId= (SELECT Id FROM [Users] AS [u] WHERE u.Username =@username) 
DECLARE @count INT
SET @count = (SELECT COUNT(Id) FROM [Commits] WHERE ContributorId =@userId )
RETURN @count
END

--Problem 12

CREATE OR ALTER PROC usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
BEGIN
SELECT [Id],[Name],CONCAT([Size],'KB') AS [Size] FROM [Files] AS [f]
WHERE f.[Name] LIKE CONCAT('%[.]',@fileExtension)
ORDER BY [Id],[Name],[Size] DESC
END


EXEC  dbo.usp_SearchForFiles 'txt'