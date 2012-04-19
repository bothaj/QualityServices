
IF OBJECT_ID('[dbo].[sp_Asset_Update]') IS NOT NULL 
    DROP PROCEDURE [dbo].[sp_Asset_Update];
GO

CREATE PROCEDURE [dbo].[sp_Asset_Update]
	@Id uniqueidentifier,
	@Description nvarchar(255) = NULL,
	@Barcode varchar(50),
	@AssetNumber varchar(50) = NULL,
	@InventoryNumber varchar(50) = NULL,
	@VendorId varchar(50) = NULL,
	@RoomId uniqueidentifier = NULL,
	@LocationId int = NULL,
	@AssetTypeId int,
	@AssetTypeDescriptionId nvarchar (255) = NULL,
	@SAPDescription varchar(255) = NULL,
	@StocktakeId uniqueidentifier = NULL,
	@StatusId int,
	@ModifiedUserId uniqueidentifier = NULL,
	@UtcModifiedDate datetime = NULL,	
	@UserId	UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON

	UPDATE [Asset]
	SET [Description] = @Description,
		[Barcode] = @Barcode,
		[AssetNumber] = @AssetNumber,
		[InventoryNumber] = @InventoryNumber,
		[VendorId] = @VendorId,
		[LocationId] = @LocationId,
		[RoomId] = @RoomId,
		[AssetTypeId] = @AssetTypeId,
		[SAPDescription] = @SAPDescription,
		[StatusId] = @StatusId,
		[ModifiedUserId] = @ModifiedUserId,
		[UtcModifiedDate] = @UtcModifiedDate
	WHERE [Id] = @Id
	
	SET NOCOUNT OFF
	
END
GO

EXECUTE [dbo].[T_DescribeProcedure] '[dbo].[sp_Asset_Update]', 'Updates a [dbo].[Asset] record.', null;
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@Id', '';
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@Description', '';
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@Barcode', '';
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@VendorId', '';
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@RoomId', '';
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@AssetTypeId', '';
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@SAPDescription', '';
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@StatusId', '';
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@ModifiedUserId', '';
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@UtcModifiedDate', '';
EXECUTE [dbo].[T_DescribeParameter] '[dbo].[sp_Asset_Update]', '@UserId', 'The User Owner of Asset';
GO
PRINT 'Created stored procedure [dbo].[sp_Asset_Update]'
GO

