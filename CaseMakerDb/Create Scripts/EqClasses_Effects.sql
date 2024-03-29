/****** Object:  Table [dbo].[EqClasses_Effects]    Script Date: 01/20/2008 21:16:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EqClasses_Effects]') AND type in (N'U'))
DROP TABLE [dbo].[EqClasses_Effects]
GO
/****** Object:  Table [dbo].[EqClasses_Effects]    Script Date: 01/20/2008 21:16:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EqClasses_Effects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EqClasses_Effects](
	[effectid] [int] NOT NULL,
	[eqclassid] [int] NOT NULL,
 CONSTRAINT [PK_EqClasses_Effects] PRIMARY KEY CLUSTERED 
(
	[effectid] ASC,
	[eqclassid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EqClasses_Effects_Effect]') AND parent_object_id = OBJECT_ID(N'[dbo].[EqClasses_Effects]'))
ALTER TABLE [dbo].[EqClasses_Effects]  WITH CHECK ADD  CONSTRAINT [FK_EqClasses_Effects_Effect] FOREIGN KEY([effectid])
REFERENCES [dbo].[Effect] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EqClasses_Effects_EquivalenceClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[EqClasses_Effects]'))
ALTER TABLE [dbo].[EqClasses_Effects]  WITH CHECK ADD  CONSTRAINT [FK_EqClasses_Effects_EquivalenceClass] FOREIGN KEY([eqclassid])
REFERENCES [dbo].[EquivalenceClass] ([id])
GO
