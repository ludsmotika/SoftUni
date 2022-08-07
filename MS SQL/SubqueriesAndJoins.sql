USE [SoftUni] 

--Problem 1

SELECT TOP(5)
Employees.EmployeeID,
Employees.JobTitle,
Addresses.AddressID,
Addresses.AddressText
FROM [Employees] 
JOIN [Addresses] ON Employees.AddressID = Addresses.AddressID
ORDER BY [AddressID]

--Problem 2

SELECT TOP(50)
e.FirstName,
e.LastName,
t.[Name],
a.AddressText
FROM [Employees] AS [e]
JOIN [Addresses] AS [a] ON e.AddressID = a.AddressID
JOIN [Towns] AS [t] ON a.TownID = t.TownID
ORDER BY e.FirstName , e.LastName

--Problem 3

SELECT
e.EmployeeID,
e.FirstName,
e.LastName,
d.[Name] AS [DepartmentName]
FROM [Employees] AS [e]
JOIN [Departments] AS [d] ON e.DepartmentID = d.DepartmentID AND d.[Name]='Sales'
ORDER BY e.EmployeeID

--Problem 4

SELECT TOP(5)
e.EmployeeID,
e.FirstName,
e.Salary,
d.[Name] AS [DepartmentName]
FROM [Employees] AS [e]
JOIN [Departments] AS [d] ON e.DepartmentID = d.DepartmentID 
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

--Problem 5

SELECT TOP(3)
e.EmployeeID,
e.FirstName
FROM [Employees] AS [e] 
LEFT JOIN [EmployeesProjects] AS [ep] ON ep.EmployeeID = e.EmployeeID 
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--Problem 6

SELECT 
e.FirstName,
e.LastName,
e.HireDate ,
d.[Name] AS [DeptName]
FROM [Employees] AS [e]
JOIN [Departments] AS [d] ON e.DepartmentID = d.DepartmentID AND d.[Name] IN ('Sales','Finance') 
WHERE YEAR(e.HireDate)>1998
ORDER BY e.HireDate

--Problem 7

SELECT TOP(5)
e.EmployeeID,
e.FirstName,
p.[Name]
FROM [Employees] AS [e]
JOIN [EmployeesProjects] AS [ep] ON  ep.EmployeeID= e.EmployeeID
JOIN [Projects] AS [p] ON ep.ProjectID =p.ProjectID
WHERE p.StartDate> '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--Problem 8

SELECT 
e.EmployeeID,
e.FirstName,
p.[Name] AS [ProjectName]
FROM [Employees] AS [e]
JOIN [EmployeesProjects] AS [ep] ON  e.EmployeeID = 24 AND e.EmployeeID =ep.EmployeeID 
LEFT JOIN [Projects] AS [p] ON ep.ProjectID = p.ProjectID AND YEAR(p.StartDate)< 2005

--Problem 9

SELECT 
e.EmployeeID,
e.FirstName,
em.EmployeeID,
em.FirstName AS [ManagerName]
FROM [Employees] AS [e]
JOIN [Employees] AS [em] ON e.ManagerID = em.EmployeeID AND em.EmployeeID IN (3,7)
ORDER BY e.EmployeeID

--Problem 10

SELECT TOP(50)
e.EmployeeID,
CONCAT(e.FirstName, ' ', e.LastName ) AS [EmployeeName],
CONCAT(em.FirstName, ' ', em.LastName ) AS [ManagerName],
d.[Name] 
FROM [Employees] AS [e]
JOIN [Employees] AS [em] ON e.ManagerID = em.EmployeeID 
JOIN [Departments] AS [d] ON e.DepartmentID=d.DepartmentID
ORDER BY e.EmployeeID

--Problem 11

SELECT TOP 1 AVG(e.Salary) AS [MinAverageSalary] FROM [Departments] AS [d]
JOIN [Employees] AS [e] ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY AVG(e.Salary)

--Problem 12

USE [Geography]

SELECT 
mc.CountryCode ,
m.MountainRange,
p.PeakName,
p.Elevation
FROM [MountainsCountries] AS [mc]
JOIN [Mountains] AS [m] ON  mc.MountainId =m.Id 
JOIN [Peaks] AS [p] ON m.Id =p.MountainId 
WHERE mc.CountryCode ='BG' AND p.Elevation> 2835
ORDER BY p.Elevation DESC

--Problem 13

SELECT
mc.CountryCode ,
COUNT(m.MountainRange ) AS [MountainRanges]
FROM [MountainsCountries] AS [mc]
JOIN [Mountains] AS [m] ON mc.MountainId =m.Id 
WHERE mc.CountryCode IN ('US','BG','RU')
GROUP BY mc.CountryCode 

--Problem 14

SELECT TOP 5
c.CountryName ,
r.RiverName
FROM [Countries] AS [c]
LEFT JOIN [CountriesRivers] AS [cr] ON c.CountryCode =cr.CountryCode 
LEFT JOIN [Rivers] AS [r] ON cr.RiverId =r.Id 
WHERE c.ContinentCode='AF'
ORDER BY c.CountryName

--Problem 16

SELECT
COUNT(*)
FROM Countries AS [c]
LEFT JOIN [MountainsCountries] AS [mc] ON c.CountryCode =mc.CountryCode 
WHERE mc.MountainId IS NULL

--Problem 17

SELECT TOP 5
c.CountryName,
MAX(p.Elevation) AS [HighestPeakElevation],
MAX (r.Length) AS [LongestRiverLength]
FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc] ON c.CountryCode =mc.CountryCode 
LEFT JOIN [Mountains] AS [m] ON mc.MountainId =m.Id 
LEFT JOIN [Peaks] AS [p] ON m.Id =p.MountainId 
LEFT JOIN [CountriesRivers] AS [cr] ON c.CountryCode =cr.CountryCode 
LEFT JOIN [Rivers] AS [r] ON cr.RiverId =r.Id 
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC , MAX(r.Length) DESC, c.CountryName 