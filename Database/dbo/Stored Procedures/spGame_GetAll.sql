CREATE PROCEDURE [dbo].[spGame_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT game.[Id], [HomeTeamId], [GuestTeamId], [HomeScore], [GuestScore], [LocalizationId], [Tipoff], [guestTeam].[Name] AS GuestTeam, [homeTeam].[Name] AS HomeTeam, [localization].City AS Localization
	FROM dbo.Game AS game
		JOIN dbo.Team AS homeTeam ON homeTeam.Id = game.HomeTeamId
		JOIN dbo.Team AS guestTeam ON guestTeam.Id = game.GuestTeamId
		JOIN dbo.[Localization] AS localization ON localization.Id = game.LocalizationId;
END
