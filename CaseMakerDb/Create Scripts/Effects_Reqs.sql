/****** Object:  Table [dbo].[Effects_Reqs]    Script Date: 01/20/2008 21:16:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Effects_Reqs]') AND type in (N'U'))
DROP TABLE [dbo].[Effects_Reqs]
GO
/****** Object:  Table [dbo].[Effects_Reqs]    Script Date: 01/20/2008 21:16:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Effects_Reqs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Effects_Reqs](
	[effectid] [int] NOT NULL,
	[requirementid] [int] NOT NULL,
 CONSTRAINT [PK_Effects_Reqs] PRIMARY KEY CLUSTERED 
(
	[effectid] ASC,
	[requirementid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Effects_Reqs_Effect]') AND parent_object_id = OBJECT_ID(N'[dbo].[Effects_Reqs]'))
ALTER TABLE [dbo].[Effects_Reqs]  WITH CHECK ADD  CONSTRAINT [FK_Effects_Reqs_Effect] FOREIGN KEY([effectid])
REFERENCES [dbo].[Effect] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Effects_Reqs_Requirement]') AND parent_object_id = OBJECT_ID(N'[dbo].[Effects_Reqs]'))
ALTER TABLE [dbo].[Effects_Reqs]  WITH CHECK ADD  CONSTRAINT [FK_Effects_Reqs_Requirement] FOREIGN KEY([requirementid])
REFERENCES [dbo].[Requirement] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
