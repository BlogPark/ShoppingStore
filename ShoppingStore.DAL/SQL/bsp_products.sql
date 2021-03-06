/*
   2014-10-2417:33:31
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
CREATE TABLE dbo.bsp_products
	(
	pid int NOT NULL IDENTITY (1, 1),
	InternalCode nvarchar(50) NULL,
	MainCategoryid int NULL,
	Cateid int NULL,
	Brandid int NULL,
	ProductName nvarchar(50) NULL,
	Shopprice decimal(10, 2) NULL,
	Marketprice decimal(10, 2) NULL,
	Costprice decimal(10, 2) NULL,
	ProductState int NULL,
	Isbest int NULL,
	Ishot int NULL,
	Isnew int NULL,
	Displayorder int NULL,
	Weight decimal(10, 2) NULL,
	ShowimgPath nvarchar(500) NULL,
	Salecount int NULL,
	Visitcount int NULL,
	Reviewcount int NULL,
	Star1 int NULL,
	Star2 int NULL,
	Star3 int NULL,
	Star4 int NULL,
	Star5 int NULL,
	Description ntext NULL,
	CreateTime datetime NULL,
	SimpleDescription nvarchar(100) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.bsp_products SET (LOCK_ESCALATION = TABLE)
GO
DECLARE @v sql_variant 
SET @v = N'商品款号'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'InternalCode'
GO
DECLARE @v sql_variant 
SET @v = N'一级分类ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'MainCategoryid'
GO
DECLARE @v sql_variant 
SET @v = N'末级分类ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Cateid'
GO
DECLARE @v sql_variant 
SET @v = N'品牌ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Brandid'
GO
DECLARE @v sql_variant 
SET @v = N'商品名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'ProductName'
GO
DECLARE @v sql_variant 
SET @v = N'商城价'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Shopprice'
GO
DECLARE @v sql_variant 
SET @v = N'市场价'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Marketprice'
GO
DECLARE @v sql_variant 
SET @v = N'成本价'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Costprice'
GO
DECLARE @v sql_variant 
SET @v = N'状态(0代表上架，1代表下架，2代表回收站，3代表隐藏品牌，4代表隐藏分类)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'ProductState'
GO
DECLARE @v sql_variant 
SET @v = N'是否推荐'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Isbest'
GO
DECLARE @v sql_variant 
SET @v = N'是否热卖'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Ishot'
GO
DECLARE @v sql_variant 
SET @v = N'是否新品'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Isnew'
GO
DECLARE @v sql_variant 
SET @v = N'排序'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Displayorder'
GO
DECLARE @v sql_variant 
SET @v = N'重量'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Weight'
GO
DECLARE @v sql_variant 
SET @v = N'首页图片路径'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'ShowimgPath'
GO
DECLARE @v sql_variant 
SET @v = N'售卖数量'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Salecount'
GO
DECLARE @v sql_variant 
SET @v = N'访问数量'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Visitcount'
GO
DECLARE @v sql_variant 
SET @v = N'评论数量'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Reviewcount'
GO
DECLARE @v sql_variant 
SET @v = N'一星'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Star1'
GO
DECLARE @v sql_variant 
SET @v = N'两星'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Star2'
GO
DECLARE @v sql_variant 
SET @v = N'三星'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Star3'
GO
DECLARE @v sql_variant 
SET @v = N'四星'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Star4'
GO
DECLARE @v sql_variant 
SET @v = N'五星'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Star5'
GO
DECLARE @v sql_variant 
SET @v = N'商品详情'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'Description'
GO
DECLARE @v sql_variant 
SET @v = N'创建时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'CreateTime'
GO
DECLARE @v sql_variant 
SET @v = N'简单描述'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'bsp_products', N'COLUMN', N'SimpleDescription'
GO
SET IDENTITY_INSERT dbo.bsp_products ON
GO

ALTER TABLE dbo.bsp_products ADD CONSTRAINT
	PK_bsp_products PRIMARY KEY CLUSTERED 
	(
	pid
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT