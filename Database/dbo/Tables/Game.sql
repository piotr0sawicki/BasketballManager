CREATE TABLE [dbo].[Game]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[HomeTeamId] INT NOT NULL,
	[GuestTeamId] INT NOT NULL, 
	[HomeScore] INT NOT NULL,
	[GuestScore] INT NOT NULL,
	[LocalizationId] INT NOT NULL,
	[Tipoff] DATETIME NOT NULL, 
    CONSTRAINT [FK_Game_ToHomeTeam] FOREIGN KEY ([HomeTeamId]) REFERENCES [Team]([Id]), 
    CONSTRAINT [FK_Game_ToGuestTeam] FOREIGN KEY ([GuestTeamId]) REFERENCES [Team]([Id])
)
