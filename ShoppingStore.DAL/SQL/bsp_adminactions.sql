/*
   2014-11-0315:08:07
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
ALTER TABLE dbo.bsp_adminactions
	DROP CONSTRAINT DF_bsp_adminactions_title
GO
ALTER TABLE dbo.bsp_adminactions
	DROP CONSTRAINT DF_bsp_adminactions_action
GO
ALTER TABLE dbo.bsp_adminactions
	DROP CONSTRAINT DF_bsp_adminactions_parentid
GO
ALTER TABLE dbo.bsp_adminactions
	DROP CONSTRAINT DF_bsp_adminactions_displayorder
GO
CREATE TABLE dbo.Tmp_bsp_adminactions
	(
	adminaid int NOT NULL IDENTITY (1, 1),
	title nvarchar(50) NULL,
	action nvarchar(1000) NULL,
	parentid int NOT NULL,
	displayorder int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_bsp_adminactions SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_bsp_adminactions ADD CONSTRAINT
	DF_bsp_adminactions_title DEFAULT ('') FOR title
GO
ALTER TABLE dbo.Tmp_bsp_adminactions ADD CONSTRAINT
	DF_bsp_adminactions_parentid DEFAULT ((0)) FOR parentid
GO
ALTER TABLE dbo.Tmp_bsp_adminactions ADD CONSTRAINT
	DF_bsp_adminactions_displayorder DEFAULT ((0)) FOR displayorder
GO
SET IDENTITY_INSERT dbo.Tmp_bsp_adminactions ON
GO
IF EXISTS(SELECT * FROM dbo.bsp_adminactions)
	 EXEC('INSERT INTO dbo.Tmp_bsp_adminactions (adminaid, title, action, parentid, displayorder)
		SELECT adminaid, CONVERT(nvarchar(50), title), CONVERT(nvarchar(1000), action), parentid, displayorder FROM dbo.bsp_adminactions WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_bsp_adminactions OFF
GO
DROP TABLE dbo.bsp_adminactions
GO
EXECUTE sp_rename N'dbo.Tmp_bsp_adminactions', N'bsp_adminactions', 'OBJECT' 
GO
COMMIT
select Has_Perms_By_Name(N'dbo.bsp_adminactions', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.bsp_adminactions', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.bsp_adminactions', 'Object', 'CONTROL') as Contr_Per 