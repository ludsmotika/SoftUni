--Problem 1

CREATE TABLE [Passports]
(
[PassportID] INT  PRIMARY KEY IDENTITY(101,1),
[PassportNumber] NVARCHAR(50) 
)

CREATE TABLE [Persons]
(
 [PersinID] INT PRIMARY KEY IDENTITY(1,1),
[FirstName] NVARCHAR(50) ,
[Salary] DECIMAL ,
[PassportID] INT  FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO [Passports]
VALUES
('N34FG21B'),('K65LO4R7'),('ZE657QP2')


INSERT INTO [Persons]
VALUES
('Roberto',43300,102),('Tom',56100,103),('Yana',60200,101)

--Problem 2

CREATE TABLE [Manufacturers]
(
[ManufacturerID] INT  PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50),
[EstablishedOn] DATE
)

CREATE TABLE [Models]
(
 [ModelID] INT PRIMARY KEY IDENTITY(101,1),
[Name] NVARCHAR(50) ,
[ManufacturerID] INT  FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO [Manufacturers]
VALUES
('BMW','1916-03-07'),('Tesla','2003-01-01'),('Lada','1966-05-01')


INSERT INTO [Models]
VALUES
('X1',1),('i6',1),('Model S',2),('Model X',2),('Model 3',2),('Nova',3)

--Problem 3


CREATE TABLE [Students]
(
[StudentID] INT  PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50)
)

CREATE TABLE [Exams]
(
 [ExamID] INT PRIMARY KEY IDENTITY(101,1),
 [Name] NVARCHAR(50)
)

CREATE TABLE [StudentsExams]
(
[StudentID] INT FOREIGN KEY REFERENCES [Students](StudentID),
[ExamID] INT FOREIGN KEY REFERENCES [Exams](ExamID),
CONSTRAINT pk_this PRIMARY KEY([StudentID],[ExamID])
)

INSERT INTO [Students]
VALUES
('Mila'),('Toni'),('Ron')


INSERT INTO [Exams]
VALUES
('SpringMVC'),('Neo4j'),('Oracle 11g')

INSERT INTO [StudentsExams] 
VALUES (1,101),(1,102),(2,101),(3,103),(2,102),(2,103)

--Problem 4

CREATE TABLE [Teachers]
(
 [TeacherID] INT PRIMARY KEY IDENTITY(101,1),
[Name] NVARCHAR(50) ,
[ManagerID] INT FOREIGN KEY REFERENCES [Teachers](TeacherID)
)

INSERT INTO [Teachers]
VALUES
('John',NULL),('Maya',106),('Silvia',106),('Ted',105),('Mark',101),('Greta',101)

--Problem 5

CREATE DATABASE [OnlineStore]

CREATE TABLE [Cities]
(
[CityID] INT PRIMARY KEY,
[Name] VARCHAR(50)
)

CREATE TABLE [Customers]
(
[CustomerID] INT PRIMARY KEY,
[Name] VARCHAR(50),
[Birthdate] DATE,
[CityID] INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE [ItemTypes]
(
[ItemTypeID] INT PRIMARY KEY,
[Name] VARCHAR(50)
)

CREATE TABLE [Items]
(
[ItemID] INT PRIMARY KEY,
[Name] VARCHAR(50),
[ItemTypeID] INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE [Orders]
(
[OrderID] INT PRIMARY KEY,
[CustomerID] INT FOREIGN KEY REFERENCES Customers(CustomerID)
) 

CREATE TABLE [OrderItems]
(
[OrderID] INT FOREIGN KEY REFERENCES Orders(OrderID),
[ItemID] INT FOREIGN KEY REFERENCES Items(ItemID),
CONSTRAINT cs_cons PRIMARY KEY(OrderID,ItemID)
)

--Problem 6

CREATE DATABASE [University]
USE [University]

CREATE TABLE [Majors] 
(
[MajorID] INT PRIMARY KEY,
[Name] VARCHAR(50)
)

CREATE TABLE [Subjects] 
(
[SubjectID] INT PRIMARY KEY,
[SubjectName] VARCHAR(50)
)


CREATE TABLE [Students] 
(
[StudentID] INT PRIMARY KEY,
[StudentNumber] INT,
[StudentName] VARCHAR(50),
[MajorID] INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE [Agenda] 
(
[StudentID] INT FOREIGN KEY REFERENCES Students(StudentID),
[SubjectID] INT FOREIGN KEY REFERENCES Subjects(SubjectID),
CONSTRAINT cs_pkkey PRIMARY KEY(StudentID,SubjectID)
)

CREATE TABLE [Payments] 
(
[PaymentID] INT PRIMARY KEY ,
[PaymentDate] DATE,
[PaymentAmount] DECIMAL,s
[StudentID] INT FOREIGN KEY REFERENCES Students(StudentID)
)

--Problem 9
 USE [Geography] 
 SELECT mn.MountainRange,pk.PeakName,pk.Elevation FROM Peaks AS pk, Mountains AS mn
 WHERE mn.id=pk.MountainId AND mn.MountainRange ='Rila'
 ORDER BY pk.Elevation DESC