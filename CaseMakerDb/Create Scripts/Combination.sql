/****** Object:  Table [dbo].[Combination]    Script Date: 01/24/2008 10:03:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Combination]') AND type in (N'U'))
DROP TABLE [dbo].[Combination]
GO
/****** Object:  Table [dbo].[Combination]    Script Date: 01/24/2008 10:03:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Combination]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Combination](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[state] [int] NOT NULL,
	[parentcombinationid] [int] NULL,
	[risklevel] [int] NOT NULL,
	[origin] [int] NOT NULL,
	[dependencyid] [int] NOT NULL,
 CONSTRAINT [PK_Combination] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Combination_Dependency]') AND parent_object_id = OBJECT_ID(N'[dbo].[Combination]'))
ALTER TABLE [dbo].[Combination]  WITH CHECK ADD  CONSTRAINT [FK_Combination_Dependency] FOREIGN KEY([dependencyid])
REFERENCES [dbo].[Dependency] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
