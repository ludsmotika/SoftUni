USE [SoftUni] 

--Problem 1

SELECT [FirstName],[LastName]
FROM [Employees]
WHERE LEFT([FirstName],2)='Sa'

--Problem 2

SELECT [FirstName],[LastName]
FROM [Employees]
WHERE [LastName] LIKE '%ei%'

--Problem 3

SELECT [FirstName] FROM [Employees]
WHERE ([DepartmentID]=3 OR [DepartmentID] =10) AND YEAR([HireDate]) BETWEEN 1995 AND 2005

--Problem 4

SELECT [FirstName],[LastName] FROM [Employees]
WHERE [JobTitle] not like '%engineer%'

--Problem 5

SELECT [Name] FROM [Towns]
WHERE LEN([Name])=5 OR LEN([Name])=6
ORDER BY [Name]

--Problem 6

SELECT [TownId] ,[Name] FROM [Towns]
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

--Problem 7

SELECT [TownId] ,[Name] FROM [Towns]
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

--Problem 8

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName] ,[LastName] FROM [Employees] 
WHERE YEAR([HireDate]) >2000

--Problem 9

SELECT [FirstName] ,[LastName] FROM [Employees] 
WHERE LEN([LastName])=5

--Problem 10

SELECT [EmployeeID],[FirstName] ,[LastName],[Salary],
DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees] 
WHERE ([Salary] BETWEEN 10000 AND 50000) 
ORDER BY [Salary] DESC

--Problem 11

SELECT * FROM
(
SELECT [EmployeeID],[FirstName] ,[LastName],[Salary],
DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees] 
WHERE ([Salary] BETWEEN 10000 AND 50000) 
) AS [Ranking]
WHERE [Rank] =2
ORDER BY [Salary] DESC

--Problem 12

USE [Geography] 

SELECT [CountryName],[IsoCode]  FROM [Countries]
WHERE LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [IsoCode]

--Problem 13

SELECT p.PeakName ,r.RiverName, LOWER(CONCAT(LEFT(p.PeakName,LEN(p.Peakname)-1),r.RiverName)) AS [Mix]  FROM [Rivers] AS r,[Peaks] AS p
WHERE RIGHT(p.PeakName,1)=LEFT(r.RiverName ,1)
ORDER BY [Mix]

--Problem 14

USE [Diablo]
 
SELECT TOP(50) [Name], FORMAT([Start],'yyyy-MM-dd','bg-BG') AS [Start] FROM [Games]
WHERE YEAR([Start]) IN (2011,2012)
ORDER BY [Start] , [Name]

--Problem 15

SELECT 
[Username],
SUBSTRING([Users].Email,CHARINDEX('@',[Users].Email)+1,LEN([Users].Email)) AS [Email Provider]
FROM [Users]
ORDER BY [Email Provider],[Username]

--Problem 16

SELECT [Username] ,[IpAddress] FROM [Users]
WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

--Problem 17

SELECT [Name] AS [Game],
CASE  
WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
ELSE 'Evening'
END AS [Part of the Day],
CASE  
WHEN [Duration] BETWEEN 0 AND 3 THEN 'Extra Short'
WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
WHEN [Duration] > 6 THEN 'Long'
ELSE 'Extra Long'
END AS [Duration]
FROM [Games]
ORDER BY [Name], [Duration], [Part of the Day]
