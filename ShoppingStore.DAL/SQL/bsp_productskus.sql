/*
   2014-10-2417:27:44
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
CREATE TABLE dbo.bsp_productskus
	(
	SKU bigint NOT NULL IDENTITY (1, 1),
	ProductID int NULL,
	AtributeValueid1 int NULL,
	AtributeValueid2 int NULL,
	AtributeValueid3 int NULL,
	Atributeid1 int NULL,
	Atributeid2 int NULL,
	Atributeid3 int NULL,
	BarCode nvarchar(50) NULL,
	ShopPrice decimal(10, 2) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'SKU'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_productskus', N'COLUMN', N'SKU'
GO
DECLARE @v sql_variant 
SET @v = N'商品ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_productskus', N'COLUMN', N'ProductID'
GO
DECLARE @v sql_variant 
SET @v = N'属性值1'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_productskus', N'COLUMN', N'AtributeValueid1'
GO
DECLARE @v sql_variant 
SET @v = N'属性值2'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_productskus', N'COLUMN', N'AtributeValueid2'
GO
DECLARE @v sql_variant 
SET @v = N'属性值3'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_productskus', N'COLUMN', N'AtributeValueid3'
GO
DECLARE @v sql_variant 
SET @v = N'属性1'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_productskus', N'COLUMN', N'Atributeid1'
GO
DECLARE @v sql_variant 
SET @v = N'属性2'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_productskus', N'COLUMN', N'Atributeid2'
GO
DECLARE @v sql_variant 
SET @v = N'属性3'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_productskus', N'COLUMN', N'Atributeid3'
GO
DECLARE @v sql_variant 
SET @v = N'条码'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_productskus', N'COLUMN', N'BarCode'
GO
DECLARE @v sql_variant 
SET @v = N'商城价'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_productskus', N'COLUMN', N'ShopPrice'
GO
ALTER TABLE dbo.bsp_productskus ADD CONSTRAINT
	PK_bsp_productskus PRIMARY KEY CLUSTERED 
	(
	SKU
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.bsp_productskus SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
