/*
   Domingo, 30 de Diciembre de 200705:08:59 p.m.
   User: Sergio Moreno
   Server: .\SQLEXPRESS
   Database: Casemaker
   Application: CasemakerNet
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
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'TestObject')
	BEGIN
		DROP  Table TestObject
	END
GO
CREATE TABLE dbo.TestObject
	(
	id int NOT NULL IDENTITY (1, 1),
	name varchar(50) NOT NULL,
	description varchar(MAX) NULL,
	precondition varchar(MAX) NULL,
	decimalSeparator char(1) NULL,
	thousandSeparator char(1) NULL,
	version varchar(50) NULL,
	creationDate datetime NOT NULL,
	modDate datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.TestObject ADD CONSTRAINT
	PK_TestObject PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.TestObject', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TestObject', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TestObject', 'Object', 'CONTROL') as Contr_Per 