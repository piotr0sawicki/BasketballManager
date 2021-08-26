CREATE TABLE [dbo].[Workout]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[TeamId] INT NOT NULL,
	[LocalizationId] INT NOT NULL, 
    CONSTRAINT [FK_Workout_ToTeam] FOREIGN KEY ([TeamId]) REFERENCES [Team]([Id])
)
