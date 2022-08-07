--Problem 1

CREATE PROC usp_GetEmployeesSalaryAboveNumber  
AS 
BEGIN

SELECT [FirstName], [LastName] FROM [Employees] 
WHERE Salary >35000

END

--Problem 2

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18,4)) 
AS 
BEGIN

SELECT [FirstName], [LastName] FROM [Employees] 
WHERE Salary >= @Number

END 

--Problem 3

CREATE PROC usp_GetTownsStartingWith (@Start VARCHAR(50))
AS 
BEGIN

SELECT [Name] FROM Towns 
WHERE LEFT([Name],LEN(@Start))=@Start 

END

--Problem 4

CREATE PROC usp_GetEmployeesFromTown (@City VARCHAR(50))
AS 
BEGIN

SELECT [FirstName], [LastName]  FROM Employees AS [e]
JOIN [Addresses] AS [a] ON e.AddressID =a.AddressID 
JOIN [Towns] AS [t] ON a.TownID =t.TownID 
WHERE t.Name =@City

END

--Problem 5


CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR (10)
BEGIN 

DECLARE @Result VARCHAR(10) 
IF(@salary<30000)
BEGIN 
SET @Result = 'Low'
END
ELSE IF(@salary BETWEEN 30000 AND 50000)
BEGIN 
SET @Result = 'Average'
END
ELSE
BEGIN 
SET @Result = 'High'
END
RETURN @Result

END


--Problem 6

CREATE PROC usp_EmployeesBySalaryLevel(@Level VARCHAR(10))
AS
BEGIN
SELECT [FirstName], [LastName] FROM [Employees] AS [e]
WHERE dbo.ufn_GetSalaryLevel([Salary]) = @Level
END

--Problem 7
GO
CREATE OR ALTER FUNCTION ufn_IsWordComprised 
(
@setOfLetters VARCHAR(50)
, @word VARCHAR(50)
)
RETURNS BIT
   BEGIN 
       DECLARE @Index INT
       SET @Index =1
       WHILE(@Index<=Len(@word))
         BEGIN 
           DECLARE @Current CHAR
           SET @Current = RIGHT(LEFT (@word,@Index),1)
           DECLARE @Check INT
           SET @Check =1
           DECLARE @IsIn BIT 
           SET @IsIn=0
              WHILE(@Check<=Len(@setOfLetters))
                BEGIN 
                  IF @Current = RIGHT(LEFT (@setOfLetters ,@Check),1)
                      BEGIN 
                         SET @IsIn=1
                      END
                  SET @Check = @Check +1
                END 

           IF @IsIn =0
             BEGIN 
               RETURN 0
             END
           SET @Index =@Index +1
         END 
      RETURN 1
   END
GO

--Problem 9

CREATE PROC usp_GetHoldersFullName 
AS 
BEGIN
SELECT CONCAT(FirstName,' ', LastName ) AS [Full Name] FROM AccountHolders

END

--Problem 10
GO
CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan (@Number DECIMAL(18,4))
AS 
BEGIN 
SELECT ah.FirstName ,ah.LastName  FROM (
		SELECT ah.Id  FROM AccountHolders AS[ah]
		JOIN Accounts AS [a] ON ah.Id =a.AccountHolderId 
		GROUP BY ah.Id 
		HAVING SUM(a.Balance)> @Number) AS [acc]
JOIN [AccountHolders] AS [ah] ON acc.Id =ah.Id 
END
GO
SELECT dbo.

