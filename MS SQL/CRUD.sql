USE [SoftUni] 
--Problem 2
SELECT * FROM [Departments]

--Problem 3
SELECT [Name] FROM [Departments]

--Problem 4
SELECT [FirstName], [LastName], [Salary]  FROM [Employees] 

--Problem 5
SELECT [FirstName], [MiddleName], [LastName]  FROM [Employees] 

--Problem 6

SELECT 
[FirstName]+'.'+[LastName]+ '@softuni.bg' 
AS 
     [Full Email Address] 
FROM 
	 [Employees]

--Problem 7

SELECT DISTINCT [Salary] AS [Salary] FROM [Employees] 

--Problem 8

SELECT * FROM [Employees] 
WHERE [JobTitle] ='Sales Representative'

--Problem 9

SELECT [FirstName], [LastName], [JobTitle]  FROM [Employees] 
WHERE [Salary]  BETWEEN 20000 AND 30000

--Problem 10

SELECT [FirstName]+' '+[MiddleName]+' '+[LastName] AS [Full Name]
FROM [Employees]
WHERE [Salary]=12500 OR [Salary]=14000 OR [Salary]=23600 OR[Salary]=25000

--Problem 11

SELECT [FirstName], [LastName] 
FROM [Employees]
WHERE [ManagerID] IS NULL

--Problem 12

SELECT [FirstName], [LastName], [Salary]
FROM [Employees]
WHERE [Salary]>50000
ORDER BY [Salary] DESC

--Problem 13

SELECT TOP(5) [FirstName], [LastName]
FROM [Employees]
ORDER BY [Salary] DESC

--Problem 14

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [DepartmentID] != 4

--Problem 15

SELECT * FROM [Employees]
ORDER BY [Salary] DESC, [FirstName] ,[LastName] DESC,[MiddleName]

--Problem 16

CREATE VIEW [V_EmployeesSalaries] AS
SELECT [FirstName], [LastName], [Salary]
FROM Employees

--Problem 17

CREATE VIEW [V_EmployeeNameJobTitle] AS
SELECT CONCAT([FirstName],' ', [MiddleName],' ', [LastName]) AS [Full Name], [JobTitle] AS [Job Title]
FROM Employees

SELECT * FROM [V_EmployeeNameJobTitle]

DROP VIEW[V_EmployeeNameJobTitle]

--Problem 18

SELECT DISTINCT [JobTitle]  FROM [Employees]
 
--Problem 19

 SELECT TOP(10) * FROM [Projects] 
 ORDER BY [StartDate] ,[Name]

--Problem 20

 SELECT TOP(7) [FirstName], [LastName], [HireDate]  FROM [Employees]  
 ORDER BY [HireDate] DESC

--Problem 21

 SELECT [Salary] FROM [Employees] 
 
 UPDATE [Employees] 
 SET [Salary] += [Salary]*0.12
 WHERE [DepartmentID] IN (1,2,4,11)

--Problem 22
 USE [Geography]
 SELECT [PeakName] FROM [Peaks]
 ORDER BY [PeakName]
 
--Problem 23
 
 SELECT TOP(30) [CountryName],[Population] FROM [Countries]
 WHERE [ContinentCode]='EU'
 ORDER BY [Population] DESC, [CountryName]
  
--Problem 24
 
 SELECT [CountryName], [CountryCode],
 Case 
 When [CurrencyCode]='EUR' THEN 'Euro'
 ELSE 'Not Euro' 
 END AS[Currency]
 FROM [Countries] 
 ORDER BY [CountryName]

--Problem 25
USE [Diablo] 
SELECT [Name] FROM [Characters]
ORDER BY [Name]