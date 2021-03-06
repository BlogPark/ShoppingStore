/*
   2014年10月19日11:23:20
   用户: sa
   服务器: .
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
CREATE TABLE dbo.bsp_advertpositions
	(
	adposid int NOT NULL IDENTITY (1, 1),
	title nvarchar(50) NULL,
	description nvarchar(50) NULL,
	IsEnable int NULL,
	posidIDname nvarchar(50) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_advertpositions', N'COLUMN', N'adposid'
GO
DECLARE @v sql_variant 
SET @v = N'位置标题'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_advertpositions', N'COLUMN', N'title'
GO
DECLARE @v sql_variant 
SET @v = N'位置描述'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_advertpositions', N'COLUMN', N'description'
GO
DECLARE @v sql_variant 
SET @v = N'是否启用'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_advertpositions', N'COLUMN', N'IsEnable'
GO
DECLARE @v sql_variant 
SET @v = N'页面ID属性值'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_advertpositions', N'COLUMN', N'posidIDname'
GO
ALTER TABLE dbo.bsp_advertpositions ADD CONSTRAINT
	PK_bsp_advertpositions PRIMARY KEY CLUSTERED 
	(
	adposid
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.bsp_advertpositions SET (LOCK_ESCALATION = TABLE)
GO
COMMIT