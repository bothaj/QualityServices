
IF OBJECT_ID('[dbo].[sp_Service_Delete]') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_Service_Delete];
GO

CREATE PROCEDURE [dbo].[sp_Service_Delete]
	@Id uniqueidentifier,	
	@UserId	UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON

	DELETE
	FROM [Service]
	WHERE [Id] = @Id

	SET NOCOUNT OFF

END
GO

--EXECUTE [dbo].[T_DescribeProcedure] '[dbo].[sp_Service_Delete]', 'Deletes a [dbo].[Service] record.', null;
--EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Service_Delete]', '@Id', 'The Id of Service';
GO
PRINT 'Created stored procedure [dbo].[sp_Service_Delete]'
GO
