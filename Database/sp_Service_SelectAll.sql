
IF OBJECT_ID('[dbo].[sp_Service_SelectAll]') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_Service_SelectAll];
GO

CREATE PROCEDURE [dbo].[sp_Service_SelectAll] 
	@ServiceCategory uniqueidentifier = NULL,
	@ServiceName VARCHAR(200) = NULL,
	@StatusId int = NULL
AS

BEGIN

	SET NOCOUNT ON

	SELECT S.[Id],
		S.[ServiceCategory],
		S.[ServiceName],
		C.CategoryName
	FROM [dbo].[Service] S
	INNER JOIN ServiceCategory C
	ON S.ServiceCategory = C.Id
	WHERE	(
				(@ServiceCategory IS NULL OR S.[ServiceCategory] = @ServiceCategory) AND
				(@ServiceName IS NULL OR S.[ServiceName] = @ServiceName) AND
				(@StatusId IS NULL OR S.[StatusId] = @StatusId)
				
			)
	ORDER BY	[ServiceName] ASC
	
	SET NOCOUNT OFF

END
GO

--EXECUTE [dbo].[T_DescribeProcedure] '[dbo].[sp_Service_SelectAll]', 'Retrieves all the records from [dbo].[Service].', 'dataset';
--EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Service_SelectAll]', '@ServiceCategory', 'The Barcode of ServiceGroup';
--EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Service_SelectAll]', '@ServiceName', 'The ServiceNumber of ServiceGroup';
--EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Service_SelectAll]', '@StatusId', 'The StatusId of Service';
GO
PRINT 'Created stored procedure [dbo].[sp_Service_SelectAll]'
GO

