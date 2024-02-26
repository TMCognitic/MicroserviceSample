CREATE LOGIN Thierry
WITH Password = N'Test1234=';
GO

CREATE LOGIN AppUser
WITH Password = N'Test1234=';
GO

CREATE DATABASE Demo;
GO

USE DEMO;
GO

CREATE TABLE Todo
(
    Id INT NOT NULL IDENTITY,
    Title NVARCHAR(255) NOT NULL,
    CONSTRAINT PK_Todo PRIMARY KEY (Id),
    CONSTRAINT UK_Todo_Title UNIQUE (Title)
);

INSERT INTO Todo (Title) VALUES (N'Test1'), (N'Test2'), (N'Test3'), (N'Test4');

EXEC master..sp_addsrvrolemember @loginame = N'Thierry', @rolename = N'sysadmin'
GO

ALTER LOGIN sa DISABLE;
GO