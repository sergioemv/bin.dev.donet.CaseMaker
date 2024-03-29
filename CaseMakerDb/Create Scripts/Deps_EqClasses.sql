/****** Object:  Table [dbo].[Deps_EqClasses]    Script Date: 01/22/2008 23:45:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deps_EqClasses]') AND type in (N'U'))
DROP TABLE [dbo].[Deps_EqClasses]
GO
/****** Object:  Table [dbo].[Deps_EqClasses]    Script Date: 01/22/2008 23:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deps_EqClasses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Deps_EqClasses](
	[dependencyid] [int] NOT NULL,
	[eqclassid] [int] NOT NULL,
 CONSTRAINT [PK_Deps_EqClasses] PRIMARY KEY CLUSTERED 
(
	[dependencyid] ASC,
	[eqclassid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Deps_EqClasses_Dependency]') AND parent_object_id = OBJECT_ID(N'[dbo].[Deps_EqClasses]'))
ALTER TABLE [dbo].[Deps_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_Deps_EqClasses_Dependency] FOREIGN KEY([dependencyid])
REFERENCES [dbo].[Dependency] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Deps_EqClasses_EquivalenceClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[Deps_EqClasses]'))
ALTER TABLE [dbo].[Deps_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_Deps_EqClasses_EquivalenceClass] FOREIGN KEY([eqclassid])
REFERENCES [dbo].[EquivalenceClass] ([id])
GO
