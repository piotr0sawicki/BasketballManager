CREATE TABLE [dbo].[Post]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(200) NOT NULL,
	[GameId] INT,
	[WorkoutId] INT,
	[Description] VARCHAR(MAX),
)
