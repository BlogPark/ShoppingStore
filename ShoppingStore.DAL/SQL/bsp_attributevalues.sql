/*
   2014-10-2415:30:03
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
CREATE TABLE dbo.bsp_attributevalues
	(
	attrvalueid int NOT NULL,
	attrid int NULL,
	attrnameCode nvarchar(50) NULL,
	attrvaluename nvarchar(50) NULL,
	isinput int NULL,
	attrvalueCode nvarchar(50) NULL,
	attrvaluedisplayorder int NULL,
	attrshowtype int NULL,
	IsEnable int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'属性ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributevalues', N'COLUMN', N'attrid'
GO
DECLARE @v sql_variant 
SET @v = N'属性编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributevalues', N'COLUMN', N'attrnameCode'
GO
DECLARE @v sql_variant 
SET @v = N'属性值名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributevalues', N'COLUMN', N'attrvaluename'
GO
DECLARE @v sql_variant 
SET @v = N'是否为输入属性值(0代表是输入属性值,1代表选择属性值)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributevalues', N'COLUMN', N'isinput'
GO
DECLARE @v sql_variant 
SET @v = N'属性值编号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributevalues', N'COLUMN', N'attrvalueCode'
GO
DECLARE @v sql_variant 
SET @v = N'排序'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributevalues', N'COLUMN', N'attrvaluedisplayorder'
GO
DECLARE @v sql_variant 
SET @v = N'属性展示类型(0代表文字,1代表图片)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributevalues', N'COLUMN', N'attrshowtype'
GO
DECLARE @v sql_variant 
SET @v = N'是否启用'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_attributevalues', N'COLUMN', N'IsEnable'
GO
ALTER TABLE dbo.bsp_attributevalues ADD CONSTRAINT
	PK_bsp_attributevalues PRIMARY KEY CLUSTERED 
	(
	attrvalueid
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.bsp_attributevalues SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
