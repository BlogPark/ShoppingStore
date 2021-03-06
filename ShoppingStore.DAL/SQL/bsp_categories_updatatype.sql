/*
   2014-11-2415:14:57
   用户: sa
   服务器: localhost
   数据库: ShoppingStore
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
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
ALTER TABLE dbo.bsp_categories
	DROP CONSTRAINT DF_bsp_categories_isshow
GO
ALTER TABLE dbo.bsp_categories
	DROP CONSTRAINT DF_bsp_categories_dispalyorder
GO
ALTER TABLE dbo.bsp_categories
	DROP CONSTRAINT DF_bsp_categories_name
GO
ALTER TABLE dbo.bsp_categories
	DROP CONSTRAINT DF_bsp_categories_pricerange
GO
ALTER TABLE dbo.bsp_categories
	DROP CONSTRAINT DF_bsp_categories_parentid
GO
ALTER TABLE dbo.bsp_categories
	DROP CONSTRAINT DF_bsp_categories_layer
GO
ALTER TABLE dbo.bsp_categories
	DROP CONSTRAINT DF_bsp_categories_haschild
GO
ALTER TABLE dbo.bsp_categories
	DROP CONSTRAINT DF_bsp_categories_path
GO
CREATE TABLE dbo.Tmp_bsp_categories
	(
	cateid int NOT NULL IDENTITY (1, 1),
	isshow int NOT NULL,
	displayorder int NOT NULL,
	name nvarchar(60) NOT NULL,
	pricerange nvarchar(200) NOT NULL,
	parentid int NOT NULL,
	layer int NOT NULL,
	haschild int NOT NULL,
	path nvarchar(100) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_bsp_categories SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_bsp_categories ADD CONSTRAINT
	DF_bsp_categories_isshow DEFAULT ((0)) FOR isshow
GO
ALTER TABLE dbo.Tmp_bsp_categories ADD CONSTRAINT
	DF_bsp_categories_dispalyorder DEFAULT ((0)) FOR displayorder
GO
ALTER TABLE dbo.Tmp_bsp_categories ADD CONSTRAINT
	DF_bsp_categories_name DEFAULT ('') FOR name
GO
ALTER TABLE dbo.Tmp_bsp_categories ADD CONSTRAINT
	DF_bsp_categories_pricerange DEFAULT ('') FOR pricerange
GO
ALTER TABLE dbo.Tmp_bsp_categories ADD CONSTRAINT
	DF_bsp_categories_parentid DEFAULT ((0)) FOR parentid
GO
ALTER TABLE dbo.Tmp_bsp_categories ADD CONSTRAINT
	DF_bsp_categories_layer DEFAULT ((0)) FOR layer
GO
ALTER TABLE dbo.Tmp_bsp_categories ADD CONSTRAINT
	DF_bsp_categories_haschild DEFAULT ((0)) FOR haschild
GO
ALTER TABLE dbo.Tmp_bsp_categories ADD CONSTRAINT
	DF_bsp_categories_path DEFAULT ('') FOR path
GO
SET IDENTITY_INSERT dbo.Tmp_bsp_categories ON
GO
IF EXISTS(SELECT * FROM dbo.bsp_categories)
	 EXEC('INSERT INTO dbo.Tmp_bsp_categories (cateid, isshow, displayorder, name, pricerange, parentid, layer, haschild, path)
		SELECT CONVERT(int, cateid), CONVERT(int, isshow), displayorder, CONVERT(nvarchar(60), name), CONVERT(nvarchar(200), pricerange), CONVERT(int, parentid), CONVERT(int, layer), CONVERT(int, haschild), CONVERT(nvarchar(100), path) FROM dbo.bsp_categories WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_bsp_categories OFF
GO
DROP TABLE dbo.bsp_categories
GO
EXECUTE sp_rename N'dbo.Tmp_bsp_categories', N'bsp_categories', 'OBJECT' 
GO
ALTER TABLE dbo.bsp_categories ADD CONSTRAINT
	PK_bsp_categories PRIMARY KEY CLUSTERED 
	(
	cateid
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.bsp_categories', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.bsp_categories', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.bsp_categories', 'Object', 'CONTROL') as Contr_Per 