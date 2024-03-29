/****** Object:  Table [dbo].[Element]    Script Date: 01/10/2008 15:51:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Element]') AND type in (N'U'))
DROP TABLE [dbo].[Element]
GO
/****** Object:  Table [dbo].[Element]    Script Date: 01/10/2008 15:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Element]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Element](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
	[position] [int] NULL,
	[testObjectId] [int] NOT NULL,
 CONSTRAINT [PK_Element] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_Element]    Script Date: 01/10/2008 15:51:18 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Element]') AND name = N'IX_Element')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Element] ON [dbo].[Element] 
(
	[testObjectId] ASC,
	[name] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Element names must not be repeated' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Element', @level2type=N'INDEX', @level2name=N'IX_Element'

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Element_TestCasesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[Element]'))
ALTER TABLE [dbo].[Element]  WITH CHECK ADD  CONSTRAINT [FK_Element_TestCasesStructure] FOREIGN KEY([testObjectId])
REFERENCES [dbo].[TestCasesStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
