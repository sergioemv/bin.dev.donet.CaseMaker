IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TDStructure_TestCase]') AND type in (N'U'))
DROP TABLE [dbo].[TDStructure_TestCase]
GO
/****** Object:  Table [dbo].[TDStructure_TestCase]    Script Date: 02/26/2008 18:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TDStructure_TestCase]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TDStructure_TestCase](
	[idTestDataStructure] [int] NOT NULL,
	[idTestCase] [int] NOT NULL,
 CONSTRAINT [PK_TDStructure_TestCase] PRIMARY KEY CLUSTERED 
(
	[idTestDataStructure] ASC,
	[idTestCase] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TDStructure_TestCase_TestCase]') AND parent_object_id = OBJECT_ID(N'[dbo].[TDStructure_TestCase]'))
ALTER TABLE [dbo].[TDStructure_TestCase]  WITH CHECK ADD  CONSTRAINT [FK_TDStructure_TestCase_TestCase] FOREIGN KEY([idTestCase])
REFERENCES [dbo].[TestCase] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TDStructure_TestCase] CHECK CONSTRAINT [FK_TDStructure_TestCase_TestCase]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TDStructure_TestCase_TestDataStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[TDStructure_TestCase]'))
ALTER TABLE [dbo].[TDStructure_TestCase]  WITH CHECK ADD  CONSTRAINT [FK_TDStructure_TestCase_TestDataStructure] FOREIGN KEY([idTestDataStructure])
REFERENCES [dbo].[TestDataStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TDStructure_TestCase] CHECK CONSTRAINT [FK_TDStructure_TestCase_TestDataStructure] 
GO