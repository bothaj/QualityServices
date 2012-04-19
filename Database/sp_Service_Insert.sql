
IF OBJECT_ID('[dbo].[sp_Service_Insert]') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_Service_Insert];
GO

CREATE PROCEDURE [dbo].[sp_Service_Insert]
	@Id uniqueidentifier,
	@ServiceCategory uniqueidentifier,
	@ServiceName varchar(200),
	@StatusId int,
	@CreatedUserId uniqueidentifier,	
	@UtcCreatedDate datetime
AS
BEGIN

	SET NOCOUNT ON
	
	IF @Id IS NULL
		 SET @Id = NEWID()

	INSERT INTO [Service]
		([Id],
		[ServiceCategory],
		[ServiceName],
		[StatusId],
		[CreatedUserId],
		[UtcCreatedDate])
	VALUES (@Id,
		@ServiceCategory,
		@ServiceName,
		@StatusId,
		@CreatedUserId,
		@UtcCreatedDate)

	SET NOCOUNT OFF
END
GO

--EXECUTE [dbo].[T_DescribeProcedure] '[dbo].[sp_Service_Insert]', 'Inserts a [dbo].[Service] record.', null;
--EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Service_Insert]', '@Id', 'The Id of Service';
--EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Service_Insert]', '@Description', 'The Description of Service';
--EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Service_Insert]', '@StatusId', 'The StatusId of Service';
--EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Service_Insert]', '@CreatedUserId', 'The CreatedUserId of Service';
--EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Service_Insert]', '@UserId', 'The User Owner of Service';
GO
PRINT 'Created stored procedure [dbo].[sp_Service_Insert]'
GO