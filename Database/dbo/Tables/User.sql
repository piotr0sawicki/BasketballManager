﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[AuthUserId] NVARCHAR(128) NOT NULL,
	[Email] NVARCHAR(200) NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Number] INT,
	[Height] INT,
	[Weight] INT
)