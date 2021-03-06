/*
   2014年10月16日14:57:03
   用户: sa
   服务器: localhost
   数据库: ShoppingStore
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
use ShoppingStore
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
CREATE TABLE dbo.bsp_subcategories
	(
	id int NOT NULL IDENTITY (1, 1),
	SubCategoryName nvarchar(50) NULL,
	Isshow int NULL,
	ParentID int NULL,
	MainCategory int NULL,
	DisplayOrder int NULL,
	Path nvarchar(100) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'标识列'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_subcategories', N'COLUMN', N'id'
GO
DECLARE @v sql_variant 
SET @v = N'明细类别名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_subcategories', N'COLUMN', N'SubCategoryName'
GO
DECLARE @v sql_variant 
SET @v = N'是否显示'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_subcategories', N'COLUMN', N'Isshow'
GO
DECLARE @v sql_variant 
SET @v = N'父级ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_subcategories', N'COLUMN', N'ParentID'
GO
DECLARE @v sql_variant 
SET @v = N'大类别'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_subcategories', N'COLUMN', N'MainCategory'
GO
DECLARE @v sql_variant 
SET @v = N'排序'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_subcategories', N'COLUMN', N'DisplayOrder'
GO
DECLARE @v sql_variant 
SET @v = N'路径'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_subcategories', N'COLUMN', N'Path'
GO
ALTER TABLE dbo.bsp_subcategories ADD CONSTRAINT
	PK_bsp_subcategories PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.bsp_subcategories SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
