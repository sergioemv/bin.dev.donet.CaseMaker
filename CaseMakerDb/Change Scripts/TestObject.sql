/*
   Martes, 01 de Enero de 200810:36:37 a.m.
   User: 
   Server: .\SQLEXPRESS
   Database: 
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.TestObject
	DROP COLUMN testCaseStructureId
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TestObject', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TestObject', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TestObject', 'Object', 'CONTROL') as Contr_Per 