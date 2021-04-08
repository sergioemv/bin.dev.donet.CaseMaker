IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestData]') AND type in (N'U'))
DROP TABLE [dbo].[TestData]
GO
/****** Object:  Table [dbo].[TestData]    Script Date: 02/26/2008 11:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TestData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[riskLevel] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[testCaseInTestData] [varchar](50) NOT NULL,
	[idTestDataStructure] [int] NOT NULL,
 CONSTRAINT [PK_TestData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TestData_TestDataStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[TestData]'))
ALTER TABLE [dbo].[TestData]  WITH CHECK ADD  CONSTRAINT [FK_TestData_TestDataStructure] FOREIGN KEY([idTestDataStructure])
REFERENCES [dbo].[TestDataStructure] ([id])
GO
ALTER TABLE [dbo].[TestData] CHECK CONSTRAINT [FK_TestData_TestDataStructure] 
GO