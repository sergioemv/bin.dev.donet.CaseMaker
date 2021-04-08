IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StructureTypeData]') AND type in (N'U'))
DROP TABLE [dbo].[StructureTypeData]
GO
/****** Object:  Table [dbo].[StructureTypeData]    Script Date: 02/26/2008 11:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StructureTypeData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StructureTypeData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idTestDataStructure] [int] NOT NULL,
	[description] [varchar](max NULL,
	[idTestData] [int] NULL,
	[globalIndex] [int] NULL,
	[name] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StructureTypeData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StructureTypeData_TestData]') AND parent_object_id = OBJECT_ID(N'[dbo].[StructureTypeData]'))
ALTER TABLE [dbo].[StructureTypeData]  WITH CHECK ADD  CONSTRAINT [FK_StructureTypeData_TestData] FOREIGN KEY([idTestData])
REFERENCES [dbo].[TestData] ([id])
GO
ALTER TABLE [dbo].[StructureTypeData] CHECK CONSTRAINT [FK_StructureTypeData_TestData]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StructureTypeData_TestDataStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[StructureTypeData]'))
ALTER TABLE [dbo].[StructureTypeData]  WITH CHECK ADD  CONSTRAINT [FK_StructureTypeData_TestDataStructure] FOREIGN KEY([idTestDataStructure])
REFERENCES [dbo].[TestDataStructure] ([id])
GO
ALTER TABLE [dbo].[StructureTypeData] CHECK CONSTRAINT [FK_StructureTypeData_TestDataStructure] 
ON UPDATE CASCADE
ON DELETE CASCADE
GO