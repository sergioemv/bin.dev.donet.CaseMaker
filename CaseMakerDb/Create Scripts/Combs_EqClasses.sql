/****** Object:  Table [dbo].[Combs_EqClasses]    Script Date: 01/28/2008 17:28:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Combs_EqClasses]') AND type in (N'U'))
DROP TABLE [dbo].[Combs_EqClasses]
GO
/****** Object:  Table [dbo].[Combs_EqClasses]    Script Date: 01/28/2008 17:28:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Combs_EqClasses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Combs_EqClasses](
	[combinationid] [int] NOT NULL,
	[equivalenceclassid] [int] NOT NULL,
 CONSTRAINT [PK_Combs_EqClasses] PRIMARY KEY CLUSTERED 
(
	[combinationid] ASC,
	[equivalenceclassid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Combs_EqClasses_Combination]') AND parent_object_id = OBJECT_ID(N'[dbo].[Combs_EqClasses]'))
ALTER TABLE [dbo].[Combs_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_Combs_EqClasses_Combination] FOREIGN KEY([combinationid])
REFERENCES [dbo].[Combination] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Combs_EqClasses_EquivalenceClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[Combs_EqClasses]'))
ALTER TABLE [dbo].[Combs_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_Combs_EqClasses_EquivalenceClass] FOREIGN KEY([equivalenceclassid])
REFERENCES [dbo].[EquivalenceClass] ([id])
GO
