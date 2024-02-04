CREATE DATABASE MedifyDB;

USE MedifyDB;

CREATE TABLE Doctors (
    [Id] INT PRIMARY KEY,
    [FIN] NVARCHAR(50) NOT NULL,
    [Phone] NVARCHAR(20),
    [Mail] NVARCHAR(100),
    [Name] NVARCHAR(50) NOT NULL,
    [Surname] NVARCHAR(50) NOT NULL,
    [Birth] DATE NOT NULL,
    [Speciality] INT NOT NULL,
    [Hospitals] NVARCHAR(MAX),
    [isPaid] BIT NOT NULL,
    [Subscription] INT NOT NULL,
    [SubscriptionStartDate] DATE NOT NULL
);