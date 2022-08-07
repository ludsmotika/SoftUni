--Problem 1

SELECT COUNT(* ) FROM [WizzardDeposits] 

--Problem 2

SELECT MAX(wd.MagicWandSize) AS [Count] FROM [WizzardDeposits] AS [wd] 

--Problem 3

SELECT
wd.DepositGroup,
MAX(wd.MagicWandSize) AS [Count] 
FROM [WizzardDeposits] AS [wd] 
GROUP BY wd.DepositGroup 

--Problem 5

SELECT
wd.DepositGroup,
SUM(wd.DepositAmount) AS [TotalSum] 
FROM [WizzardDeposits] AS [wd] 
GROUP BY wd.DepositGroup 

--Problem 6

SELECT
wd.DepositGroup,
SUM(wd.DepositAmount) AS [TotalSum] 
FROM [WizzardDeposits] AS [wd] 
WHERE wd.MagicWandCreator ='Ollivander family'
GROUP BY wd.DepositGroup 

--Problem 7

SELECT
wd.DepositGroup,
SUM(wd.DepositAmount) AS [TotalSum] 
FROM [WizzardDeposits] AS [wd] 
WHERE wd.MagicWandCreator ='Ollivander family' 
GROUP BY wd.DepositGroup 
HAVING SUM(wd.DepositAmount) < 150000
ORDER BY SUM(wd.DepositAmount) DESC

--Problem 8

SELECT
wd.DepositGroup,
wd.MagicWandCreator,
MIN(wd.DepositCharge) AS MinDepositCharge 
FROM [WizzardDeposits] AS [wd] 
GROUP BY wd.DepositGroup, wd.MagicWandCreator
ORDER BY  wd.MagicWandCreator, wd.DepositGroup 

--Problem 9

SELECT ag.AgeGroup, COUNT(*) AS [WizardCount] FROM (
SELECT wd.Age ,
CASE 
      WHEN wd.Age BETWEEN 0 AND 10 THEN '[0-10]'
      WHEN wd.Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN wd.Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN wd.Age BETWEEN 31 AND 40 THEN '[31-40]'
      WHEN wd.Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN wd.Age BETWEEN 51 AND 60 THEN '[51-60]'
	  WHEN wd.Age >= 61 THEN '[61+]'
	  END AS [AgeGroup]
 FROM [WizzardDeposits] AS [wd]
 ) AS [ag]
 GROUP BY [AgeGroup] 

--Problem 10

SELECT LEFT(wd.FirstName ,1) FROM [WizzardDeposits] AS [wd]
WHERE wd.DepositGroup ='Troll Chest' 
GROUP BY LEFT(wd.FirstName ,1)

--Problem 11

SELECT wd.DepositGroup, wd.IsDepositExpired, AVG(wd.DepositInterest) AS [AverageInterest]  FROM [WizzardDeposits] AS [wd]
WHERE wd.DepositStartDate > '1985-01-01'
GROUP BY wd.DepositGroup, wd.IsDepositExpired
ORDER BY wd.DepositGroup DESC, wd.IsDepositExpired

--Problem 13

SELECT DepartmentID, SUM(Salary) AS [TotalSalary] FROM [Employees] 
GROUP BY DepartmentID 
ORDER BY DepartmentID 

--Problem 14

SELECT DepartmentID, MIN(Salary) AS [MinimumSalary] FROM [Employees] 
WHERE DepartmentID IN (2,5,7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID 
ORDER BY DepartmentID 

--Problem 15



--Problem 16

SELECT e.DepartmentID ,MAX(e.Salary) AS [MaxSalary] FROM [Employees] AS [e]
GROUP BY e.DepartmentID 
HAVING MAX(e.Salary) NOT BETWEEN 30000 AND 70000

--Problem 17

SELECT COUNT(*) AS [Count] FROM [Employees] AS [e] WHERE e.ManagerID IS NULL 
