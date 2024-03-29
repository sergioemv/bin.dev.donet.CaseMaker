/****** Object:  Table [dbo].[Deps_Elems]    Script Date: 01/21/2008 09:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deps_Elems]') AND type in (N'U'))
DROP TABLE [dbo].[Deps_Elems]
GO
/****** Object:  Table [dbo].[Deps_Elems]    Script Date: 01/21/2008 09:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deps_Elems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Deps_Elems](
	[dependencyid] [int] NOT NULL,
	[elementid] [int] NOT NULL,
 CONSTRAINT [PK_Deps_Elems] PRIMARY KEY CLUSTERED 
(
	[dependencyid] ASC,
	[elementid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Elements_Deps_Dependency]') AND parent_object_id = OBJECT_ID(N'[dbo].[Deps_Elems]'))
ALTER TABLE [dbo].[Deps_Elems]  WITH CHECK ADD  CONSTRAINT [FK_Elements_Deps_Dependency] FOREIGN KEY([dependencyid])
REFERENCES [dbo].[Dependency] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Elements_Deps_Element]') AND parent_object_id = OBJECT_ID(N'[dbo].[Deps_Elems]'))
ALTER TABLE [dbo].[Deps_Elems]  WITH CHECK ADD  CONSTRAINT [FK_Elements_Deps_Element] FOREIGN KEY([elementid])
REFERENCES [dbo].[Element] ([id])
GO
