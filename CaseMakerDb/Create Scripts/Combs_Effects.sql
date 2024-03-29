/****** Object:  Table [dbo].[Combs_Effects]    Script Date: 01/28/2008 17:43:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Combs_Effects]') AND type in (N'U'))
DROP TABLE [dbo].[Combs_Effects]
GO
/****** Object:  Table [dbo].[Combs_Effects]    Script Date: 01/28/2008 17:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Combs_Effects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Combs_Effects](
	[combinationid] [int] NOT NULL,
	[effectid] [int] NOT NULL,
 CONSTRAINT [PK_Combs_Effects] PRIMARY KEY CLUSTERED 
(
	[combinationid] ASC,
	[effectid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Combs_Effects_Combination]') AND parent_object_id = OBJECT_ID(N'[dbo].[Combs_Effects]'))
ALTER TABLE [dbo].[Combs_Effects]  WITH CHECK ADD  CONSTRAINT [FK_Combs_Effects_Combination] FOREIGN KEY([combinationid])
REFERENCES [dbo].[Combination] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Combs_Effects_Effect]') AND parent_object_id = OBJECT_ID(N'[dbo].[Combs_Effects]'))
ALTER TABLE [dbo].[Combs_Effects]  WITH CHECK ADD  CONSTRAINT [FK_Combs_Effects_Effect] FOREIGN KEY([effectid])
REFERENCES [dbo].[Effect] ([id])
GO
