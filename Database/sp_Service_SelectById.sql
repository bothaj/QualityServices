IF OBJECT_ID('[dbo].[sp_Service_SelectById]') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_Service_SelectById];
GO

CREATE PROCEDURE [dbo].[sp_Service_SelectById]
	@Id uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON

	SELECT S.[Id],
		S.[ServiceCategory],
		S.[ServiceName]
	FROM [dbo].[Service] S
	WHERE ([Id] = @Id)

	SET NOCOUNT OFF

END
GO
