/****** Object:  Table [dbo].[StdCombs_EqClasses]    Script Date: 01/30/2008 16:17:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StdCombs_EqClasses]') AND type in (N'U'))
DROP TABLE [dbo].[StdCombs_EqClasses]
GO
/****** Object:  Table [dbo].[StdCombs_EqClasses]    Script Date: 01/30/2008 16:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StdCombs_EqClasses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StdCombs_EqClasses](
	[stdcombinationid] [int] NOT NULL,
	[equivalenceclassid] [int] NOT NULL,
 CONSTRAINT [PK_StdCombs_EqClasses] PRIMARY KEY CLUSTERED 
(
	[stdcombinationid] ASC,
	[equivalenceclassid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StdCombs_EqClasses_EquivalenceClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[StdCombs_EqClasses]'))
ALTER TABLE [dbo].[StdCombs_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_StdCombs_EqClasses_EquivalenceClass] FOREIGN KEY([equivalenceclassid])
REFERENCES [dbo].[EquivalenceClass] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StdCombs_EqClasses_StdCombination]') AND parent_object_id = OBJECT_ID(N'[dbo].[StdCombs_EqClasses]'))
ALTER TABLE [dbo].[StdCombs_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_StdCombs_EqClasses_StdCombination] FOREIGN KEY([stdcombinationid])
REFERENCES [dbo].[StdCombination] ([id])
GO
