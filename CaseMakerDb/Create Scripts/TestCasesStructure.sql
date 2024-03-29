/****** Object:  Table [dbo].[TestCasesStructure]    Script Date: 01/04/2008 12:19:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestCasesStructure]') AND type in (N'U'))
DROP TABLE [dbo].[TestCasesStructure]
GO
/****** Object:  Table [dbo].[TestCasesStructure]    Script Date: 01/04/2008 12:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestCasesStructure]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TestCasesStructure](
	[id] [int] NOT NULL,
	[creationDate] [datetime] NULL,
	[modDate] [datetime] NULL,
 CONSTRAINT [PK_TestCasesStructure] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TestCasesStructure_TestObject]') AND parent_object_id = OBJECT_ID(N'[dbo].[TestCasesStructure]'))
ALTER TABLE [dbo].[TestCasesStructure]  WITH CHECK ADD  CONSTRAINT [FK_TestCasesStructure_TestObject] FOREIGN KEY([id])
REFERENCES [dbo].[TestObject] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
