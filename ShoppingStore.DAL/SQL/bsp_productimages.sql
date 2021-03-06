/*
   2014-10-2911:42:47
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
ALTER TABLE dbo.bsp_productimages
	DROP CONSTRAINT DF_bsp_productimages_pid
GO
ALTER TABLE dbo.bsp_productimages
	DROP CONSTRAINT DF_bsp_productimages_showimg
GO
ALTER TABLE dbo.bsp_productimages
	DROP CONSTRAINT DF_bsp_productimages_ismain
GO
ALTER TABLE dbo.bsp_productimages
	DROP CONSTRAINT DF_bsp_productimages_displayorder
GO
CREATE TABLE dbo.Tmp_bsp_productimages
	(
	pimgid int NOT NULL IDENTITY (1, 1),
	pid int NOT NULL,
	showimg nvarchar(1000) NOT NULL,
	ismain int NOT NULL,
	displayorder int NOT NULL,
	SKU int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_bsp_productimages SET (LOCK_ESCALATION = TABLE)
GO
DECLARE @v sql_variant 
SET @v = N'productid'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_bsp_productimages', N'COLUMN', N'pid'
GO
DECLARE @v sql_variant 
SET @v = N'图片地址'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_bsp_productimages', N'COLUMN', N'showimg'
GO
DECLARE @v sql_variant 
SET @v = N'是否主图'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_bsp_productimages', N'COLUMN', N'ismain'
GO
DECLARE @v sql_variant 
SET @v = N'排序'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_bsp_productimages', N'COLUMN', N'displayorder'
GO
DECLARE @v sql_variant 
SET @v = N'skuID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_bsp_productimages', N'COLUMN', N'SKU'
GO
ALTER TABLE dbo.Tmp_bsp_productimages ADD CONSTRAINT
	DF_bsp_productimages_pid DEFAULT ((0)) FOR pid
GO
ALTER TABLE dbo.Tmp_bsp_productimages ADD CONSTRAINT
	DF_bsp_productimages_showimg DEFAULT ('') FOR showimg
GO
ALTER TABLE dbo.Tmp_bsp_productimages ADD CONSTRAINT
	DF_bsp_productimages_ismain DEFAULT ((0)) FOR ismain
GO
ALTER TABLE dbo.Tmp_bsp_productimages ADD CONSTRAINT
	DF_bsp_productimages_displayorder DEFAULT ((0)) FOR displayorder
GO
SET IDENTITY_INSERT dbo.Tmp_bsp_productimages ON
GO
IF EXISTS(SELECT * FROM dbo.bsp_productimages)
	 EXEC('INSERT INTO dbo.Tmp_bsp_productimages (pimgid, pid, showimg, ismain, displayorder)
		SELECT pimgid, pid, showimg, CONVERT(int, ismain), displayorder FROM dbo.bsp_productimages WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_bsp_productimages OFF
GO
DROP TABLE dbo.bsp_productimages
GO
EXECUTE sp_rename N'dbo.Tmp_bsp_productimages', N'bsp_productimages', 'OBJECT' 
GO
ALTER TABLE dbo.bsp_productimages ADD CONSTRAINT
	PK_bsp_productimages PRIMARY KEY CLUSTERED 
	(
	pimgid
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX pid ON dbo.bsp_productimages
	(
	pid
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
COMMIT