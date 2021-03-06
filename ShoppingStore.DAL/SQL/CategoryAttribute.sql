/*
   2014-10-2413:29:32
   用户: sa
   服务器: localhost
   数据库: ShoppingStore
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
USE ShoppingStore
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.bsp_CategoryAttribute
	(
	ID int NOT NULL IDENTITY (1, 1),
	CategoryID int NULL,
	AttributeID int NULL,
	IsEnable int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_CategoryAttribute', N'COLUMN', N'ID'
GO
DECLARE @v sql_variant 
SET @v = N'分类ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_CategoryAttribute', N'COLUMN', N'CategoryID'
GO
DECLARE @v sql_variant 
SET @v = N'属性ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_CategoryAttribute', N'COLUMN', N'AttributeID'
GO
DECLARE @v sql_variant 
SET @v = N'是否启用'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_CategoryAttribute', N'COLUMN', N'IsEnable'
GO
ALTER TABLE dbo.bsp_CategoryAttribute ADD CONSTRAINT
	PK_CategoryAttribute PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.bsp_CategoryAttribute SET (LOCK_ESCALATION = TABLE)
GO
COMMIT