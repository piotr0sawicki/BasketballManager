CREATE TABLE [dbo].[GameDetails]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[GameId] INT NOT NULL,
	[PlayerId] INT NOT NULL,
	[Points] INT NOT NULL,
	[Assists] INT,
	[Rebounds] INT,
	[FGM] INT,
	[FGA] INT,
	[3PM] INT,
	[3PA] INT, 
    CONSTRAINT [FK_GameDetails_ToGame] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id]), 
    CONSTRAINT [FK_GameDetails_ToPlayer] FOREIGN KEY ([PlayerId]) REFERENCES [User]([Id])
)
