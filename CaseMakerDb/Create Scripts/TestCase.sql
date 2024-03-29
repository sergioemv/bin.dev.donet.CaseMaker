/****** Object:  Table [dbo].[TestCase]    Script Date: 01/30/2008 16:17:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestCase]') AND type in (N'U'))
DROP TABLE [dbo].[TestCase]
GO
/****** Object:  Table [dbo].[TestCase]    Script Date: 01/30/2008 16:17:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestCase]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TestCase](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [int] NOT NULL,
	[structureid] [int] NULL,
	[description] [varchar](max) NULL,
	[state] [int] NOT NULL,
	[risklevel] [int] NOT NULL,
	[origin] [int] NOT NULL,
	[stdcombinationid] [int] NULL,
 CONSTRAINT [PK_TestCase] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TestCase_StdCombination]') AND parent_object_id = OBJECT_ID(N'[dbo].[TestCase]'))
ALTER TABLE [dbo].[TestCase]  WITH NOCHECK ADD  CONSTRAINT [FK_TestCase_StdCombination] FOREIGN KEY([stdcombinationid])
REFERENCES [dbo].[StdCombination] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TestCase_TestCasesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[TestCase]'))
ALTER TABLE [dbo].[TestCase]  WITH CHECK ADD  CONSTRAINT [FK_TestCase_TestCasesStructure] FOREIGN KEY([structureid])
REFERENCES [dbo].[TestCasesStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
