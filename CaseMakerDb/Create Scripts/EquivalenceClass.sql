/****** Object:  Table [dbo].[EquivalenceClass]    Script Date: 01/16/2008 14:19:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EquivalenceClass]') AND type in (N'U'))
DROP TABLE [dbo].[EquivalenceClass]
GO
/****** Object:  Table [dbo].[EquivalenceClass]    Script Date: 01/16/2008 14:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EquivalenceClass]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EquivalenceClass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[riskLevel] [int] NOT NULL CONSTRAINT [DF_EquivalenceClass_riskLevel]  DEFAULT ((0)),
	[elementId] [int] NOT NULL,
	[state] [varchar](50) NOT NULL,
	[value] [nvarchar](max) NULL,
	[position] [int] NOT NULL CONSTRAINT [DF_EquivalenceClass_position]  DEFAULT ((-1)),
 CONSTRAINT [PK_EquivalenceClass] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_EquivalenceClass]    Script Date: 01/16/2008 14:19:52 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[EquivalenceClass]') AND name = N'IX_EquivalenceClass')
CREATE UNIQUE NONCLUSTERED INDEX [IX_EquivalenceClass] ON [dbo].[EquivalenceClass] 
(
	[elementId] ASC,
	[position] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EquivalenceClass_Element]') AND parent_object_id = OBJECT_ID(N'[dbo].[EquivalenceClass]'))
ALTER TABLE [dbo].[EquivalenceClass]  WITH CHECK ADD  CONSTRAINT [FK_EquivalenceClass_Element] FOREIGN KEY([elementId])
REFERENCES [dbo].[Element] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
