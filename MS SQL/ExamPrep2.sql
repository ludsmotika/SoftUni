--Problem 1

CREATE TABLE [Sizes]
(
Id INT PRIMARY KEY IDENTITY,
[Length] INT NOT NULL CHECK ([Length] >=10 AND [Length] <=25),
RingRange DECIMAL(20,2) NOT NULL CHECK (RingRange >=1.5 AND RingRange <=7.5)
)

CREATE TABLE [Tastes]
(
Id INT PRIMARY KEY IDENTITY,
TasteType VARCHAR(20) NOT NULL,
TasteStrength VARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE [Brands]
(
Id INT PRIMARY KEY IDENTITY,
BrandName VARCHAR(30) UNIQUE NOT NULL,
BrandDescription VARCHAR(MAX)
)

CREATE TABLE [Cigars]
(
Id INT PRIMARY KEY IDENTITY,
CigarName VARCHAR(80) NOT NULL,
BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
PriceForSingleCigar MONEY NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE [Addresses]
(
Id INT PRIMARY KEY IDENTITY,
Town VARCHAR(30) NOT NULL,
Country NVARCHAR(30) NOT NULL,
Streat NVARCHAR(100) NOT NULL,
ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE [Clients]
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(50) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE [ClientsCigars]
(
ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
CigarId INT FOREIGN KEY REFERENCES Cigars(Id) NOT NULL,
PRIMARY KEY (ClientId ,CigarId)
)

--Problem 2

INSERT INTO Cigars
VALUES
('COHIBA ROBUSTO',	9,	1,	5,	15.50,	'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',	9,	1,	10,	410.00,	'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',	14,	5,	11,	7.50,	'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',	14,	4,	15,	32.00,	'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',	2,	3,	8,	85.21,	'trinidad-coloniales-stick_30.jpg')


INSERT INTO Addresses
VALUES
('Sofia',	'Bulgaria',	'18 Bul. Vasil levski',	1000),
('Athens',	'Greece',	'4342 McDonald Avenue',	10435),
('Zagreb',	'Croatia', '4333 Lauren Drive',	10000)

--Problem 3

UPDATE Cigars 
SET PriceForSingleCigar =PriceForSingleCigar *1.20
WHERE TastId = (SELECT Id FROM Tastes WHERE  TasteType='Spicy')

UPDATE Brands
SET BrandDescription ='New description' 
WHERE BrandDescription IS NULL

--Problem 4

DELETE FROM Clients
WHERE AddressId IN (SELECT Id FROM [Addresses] WHERE LEFT(Country,1)='C')

DELETE FROM Addresses 
WHERE LEFT(Country,1)='C'

--Problem 5

SELECT CigarName, PriceForSingleCigar,ImageURL   FROM [Cigars]
ORDER BY PriceForSingleCigar,CigarName DESC

--Problem 6

SELECT c.[Id], [CigarName] ,[PriceForSingleCigar] ,t.[TasteType] ,t.[TasteStrength]  FROM [Cigars] AS [c]
JOIN Tastes AS [t] ON c.TastId =t.Id 
WHERE TastId IN (SELECT Id FROM Tastes WHERE TasteType IN ('Earthy','Woody'))
ORDER BY PriceForSingleCigar DESC

--Problem 7

SELECT [Id],CONCAT(FirstName,' ', LastName) AS [ClientName], [Email] FROM [Clients] AS [c]
WHERE Id NOT IN (SELECT ClientId FROM ClientsCigars)
ORDER BY ClientName 

--Problem 8

SELECT TOP(5) [CigarName],[PriceForSingleCigar],[ImageURL] FROM Cigars AS [c]
JOIN Sizes AS [s] ON c.SizeId =s.Id 
WHERE s.[Length]>=12 AND (CigarName LIKE '%ci%' OR PriceForSingleCigar >50) AND s.RingRange >2.55
ORDER BY c.[CigarName],c.[PriceForSingleCigar] DESC

--Problem 9

SELECT 
CONCAT(c.FirstName ,' ', c.LastName) AS [FullName],
a.Country,
a.ZIP,
CONCAT('$',MAX(ci.PriceForSingleCigar)) AS [CigarPrice]
FROM Clients AS [c]
JOIN Addresses AS [a] ON c.AddressId =a.Id
JOIN ClientsCigars AS [cc] ON c.Id =cc.ClientId
JOIN Cigars AS [ci] ON cc.CigarId=ci.Id 
GROUP BY CONCAT(c.FirstName ,' ', c.LastName), a.Country,a.Zip
HAVING ISNUMERIC(a.ZIP)=1
ORDER BY FullName
--MAX(ci.PriceForSingleCigar)
--Problem 10
--Problem 11
--Problem 12