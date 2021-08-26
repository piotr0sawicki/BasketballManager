CREATE TABLE [dbo].[User_Team]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UserId] INT NOT NULL,
	[TeamId] INT NOT NULL, 
    CONSTRAINT [FK_User_Team_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_User_Team_ToTeam] FOREIGN KEY ([TeamId]) REFERENCES [Team]([Id])
)
