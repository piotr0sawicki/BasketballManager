CREATE PROCEDURE [dbo].[spGame_GetDetailsById]
	@id int 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT d.PlayerId, d.[3PA] as Details3PA, d.[3PM] as Details3PM, d.Assists, d.FGA as DetailsFGA, d.FGM as DetailsFGM, u.FirstName, u.LastName, u.Id, t.[Name] as TeamName 
	FROM [dbo].GameDetails d
	JOIN  [dbo].Game g on g.Id = d.GameId
	JOIN [dbo].[User] u on u.Id = d.PlayerId
	JOIN [dbo].[User_Team] ut on d.PlayerId = ut.UserId
	JOIN [dbo].[Team] t on t.Id = ut.TeamId
	WHERE g.Id = @id;
END