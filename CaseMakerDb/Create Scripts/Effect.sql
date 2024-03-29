/****** Object:  Table [dbo].[Effect]    Script Date: 01/18/2008 08:46:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Effect]') AND type in (N'U'))
DROP TABLE [dbo].[Effect]
GO
/****** Object:  Table [dbo].[Effect]    Script Date: 01/18/2008 08:46:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Effect]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Effect](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [int] NOT NULL CONSTRAINT [DF_Table1_position]  DEFAULT ((0)),
	[structureid] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[state] [varchar](50) NULL,
	[risklevel] [int] NOT NULL CONSTRAINT [DF_Table1_risklevel]  DEFAULT ((0)),
 CONSTRAINT [PK_Table1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Effect_TestCasesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[Effect]'))
ALTER TABLE [dbo].[Effect]  WITH CHECK ADD  CONSTRAINT [FK_Effect_TestCasesStructure] FOREIGN KEY([structureid])
REFERENCES [dbo].[TestCasesStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
