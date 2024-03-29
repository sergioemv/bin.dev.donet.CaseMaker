/****** Object:  Table [dbo].[Requirement]    Script Date: 01/20/2008 21:16:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Requirement]') AND type in (N'U'))
DROP TABLE [dbo].[Requirement]
GO
/****** Object:  Table [dbo].[Requirement]    Script Date: 01/20/2008 21:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Requirement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Requirement](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[structureid] [int] NOT NULL,
 CONSTRAINT [PK_Requirements] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Requirement_TestCasesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[Requirement]'))
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Requirement_TestCasesStructure] FOREIGN KEY([structureid])
REFERENCES [dbo].[TestCasesStructure] ([id])
GO
