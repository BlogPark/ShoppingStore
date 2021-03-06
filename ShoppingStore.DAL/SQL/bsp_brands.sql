/*
   2014年10月16日15:42:12
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
CREATE TABLE dbo.bsp_brands
	(
	brandid int NOT NULL IDENTITY (1, 1),
	isshow int NULL,
	displayorder int NULL,
	name nvarchar(50) NULL,
	logo nchar(100) NULL,
	BelongsCategoryID int NULL,
	IsRecommend int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'品牌ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_brands', N'COLUMN', N'brandid'
GO
DECLARE @v sql_variant 
SET @v = N'是否显示'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_brands', N'COLUMN', N'isshow'
GO
DECLARE @v sql_variant 
SET @v = N'排序'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_brands', N'COLUMN', N'displayorder'
GO
DECLARE @v sql_variant 
SET @v = N'名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_brands', N'COLUMN', N'name'
GO
DECLARE @v sql_variant 
SET @v = N'标志'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_brands', N'COLUMN', N'logo'
GO
DECLARE @v sql_variant 
SET @v = N'所属分类'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_brands', N'COLUMN', N'BelongsCategoryID'
GO
DECLARE @v sql_variant 
SET @v = N'是否推荐'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_brands', N'COLUMN', N'IsRecommend'
GO
ALTER TABLE dbo.bsp_brands ADD CONSTRAINT
	PK_bsp_brands PRIMARY KEY CLUSTERED 
	(
	brandid
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.bsp_brands SET (LOCK_ESCALATION = TABLE)
GO
COMMIT