/*
   2014-10-2415:19:39
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
CREATE TABLE dbo.bsp_attributes
	(
	attrid int NOT NULL IDENTITY (1, 1),
	name nvarchar(50) NULL,
	attributecode nvarchar(50) NULL,
	IsEnable int NULL,
	showtype int NULL,
	isfilter int NULL,
	displayorder int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'属性名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributes', N'COLUMN', N'name'
GO
DECLARE @v sql_variant 
SET @v = N'属性编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributes', N'COLUMN', N'attributecode'
GO
DECLARE @v sql_variant 
SET @v = N'是否启用'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributes', N'COLUMN', N'IsEnable'
GO
DECLARE @v sql_variant 
SET @v = N'展示类型(0代表文字,1代表图片)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributes', N'COLUMN', N'showtype'
GO
DECLARE @v sql_variant 
SET @v = N'是否为筛选属性'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributes', N'COLUMN', N'isfilter'
GO
DECLARE @v sql_variant 
SET @v = N'排序'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributes', N'COLUMN', N'displayorder'
GO
ALTER TABLE dbo.bsp_attributes ADD CONSTRAINT
	PK_bsp_attributes PRIMARY KEY CLUSTERED 
	(
	attrid
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.bsp_attributes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
