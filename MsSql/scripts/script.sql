CREATE LOGIN Thierry
WITH Password = N'Test1234=';
GO

CREATE LOGIN AppUser
WITH Password = N'Test1234=';
GO

EXEC master..sp_addsrvrolemember @loginame = N'Thierry', @rolename = N'sysadmin'
GO

ALTER LOGIN sa DISABLE;
GO