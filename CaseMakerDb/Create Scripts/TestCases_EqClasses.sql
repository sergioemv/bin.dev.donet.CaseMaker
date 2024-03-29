/****** Object:  Table [dbo].[TestCases_EqClasses]    Script Date: 01/30/2008 16:55:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestCases_EqClasses]') AND type in (N'U'))
DROP TABLE [dbo].[TestCases_EqClasses]
GO
/****** Object:  Table [dbo].[TestCases_EqClasses]    Script Date: 01/30/2008 16:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestCases_EqClasses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TestCases_EqClasses](
	[testcaseid] [int] NOT NULL,
	[equivalenceclassid] [int] NOT NULL,
 CONSTRAINT [PK_TestCases_EqClasses] PRIMARY KEY CLUSTERED 
(
	[testcaseid] ASC,
	[equivalenceclassid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TestCases_EqClasses_EquivalenceClass]') AND parent_object_id = OBJECT_ID(N'[dbo].[TestCases_EqClasses]'))
ALTER TABLE [dbo].[TestCases_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_TestCases_EqClasses_EquivalenceClass] FOREIGN KEY([equivalenceclassid])
REFERENCES [dbo].[EquivalenceClass] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TestCases_EqClasses_TestCase]') AND parent_object_id = OBJECT_ID(N'[dbo].[TestCases_EqClasses]'))
ALTER TABLE [dbo].[TestCases_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_TestCases_EqClasses_TestCase] FOREIGN KEY([testcaseid])
REFERENCES [dbo].[TestCase] ([id])
GO
