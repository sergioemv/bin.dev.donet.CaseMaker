/****** Object:  Table [dbo].[TestCases_Combs]    Script Date: 01/29/2008 21:31:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestCases_Combs]') AND type in (N'U'))
DROP TABLE [dbo].[TestCases_Combs]
GO
/****** Object:  Table [dbo].[TestCases_Combs]    Script Date: 01/29/2008 21:31:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestCases_Combs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TestCases_Combs](
	[testcaseid] [int] NOT NULL,
	[combinationid] [int] NOT NULL,
 CONSTRAINT [PK_TestCases_Combs] PRIMARY KEY CLUSTERED 
(
	[testcaseid] ASC,
	[combinationid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TestCases_Combs_Combination]') AND parent_object_id = OBJECT_ID(N'[dbo].[TestCases_Combs]'))
ALTER TABLE [dbo].[TestCases_Combs]  WITH CHECK ADD  CONSTRAINT [FK_TestCases_Combs_Combination] FOREIGN KEY([combinationid])
REFERENCES [dbo].[Combination] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TestCases_Combs_TestCase]') AND parent_object_id = OBJECT_ID(N'[dbo].[TestCases_Combs]'))
ALTER TABLE [dbo].[TestCases_Combs]  WITH CHECK ADD  CONSTRAINT [FK_TestCases_Combs_TestCase] FOREIGN KEY([testcaseid])
REFERENCES [dbo].[TestCase] ([id])
GO
