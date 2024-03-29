/****** Object:  Table [dbo].[Dependency]    Script Date: 01/21/2008 14:38:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dependency]') AND type in (N'U'))
DROP TABLE [dbo].[Dependency]
GO
/****** Object:  Table [dbo].[Dependency]    Script Date: 01/21/2008 14:38:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dependency]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Dependency](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[structureid] [int] NOT NULL,
	[position] [int] NOT NULL,
 CONSTRAINT [PK_Dependency] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_Dependency_Position]    Script Date: 01/21/2008 14:38:41 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Dependency]') AND name = N'IX_Dependency_Position')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Dependency_Position] ON [dbo].[Dependency] 
(
	[structureid] ASC,
	[position] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Dependency_TestCasesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[Dependency]'))
ALTER TABLE [dbo].[Dependency]  WITH CHECK ADD  CONSTRAINT [FK_Dependency_TestCasesStructure] FOREIGN KEY([structureid])
REFERENCES [dbo].[TestCasesStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
