CREATE TABLE [dbo].[PlayerStatistics]
(
	[PlayerId] INT NOT NULL PRIMARY KEY,
	[PPG] DECIMAL NOT NULL,
	[APG] DECIMAL NOT NULL,
	[RPG] DECIMAL NOT NULL,
	[Games] INT NOT NULL, 
    CONSTRAINT [FK_PlayerStatistics_ToPlayer] FOREIGN KEY ([PlayerId]) REFERENCES [User]([Id])
)
