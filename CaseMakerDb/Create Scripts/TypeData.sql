IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeData]') AND type in (N'U'))
DROP TABLE [dbo].[TestCase]
GO
/****** Object:  Table [dbo].[TypeData]    Script Date: 02/26/2008 12:28:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TypeData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[field] [varchar](50) NULL,
	[global] [varchar](1) NULL,
	[keyTypeData] [varchar](1) NULL,
	[lenght] [int] NULL,
	[name] [varchar](50) NULL,
	[preffix] [varchar](50) NULL,
	[objectType] [varchar](50) NULL,
	[suffix] [varchar](50) NULL,
	[type] [varchar](50) NULL,
	[typeOfTypeData] [varchar](50) NOT NULL,
	[idStructureTypeData] [int] NOT NULL,
	[idValue] [int] NULL,
 CONSTRAINT [PK_TypeData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TypeData_StructureTypeData]') AND parent_object_id = OBJECT_ID(N'[dbo].[TypeData]'))
ALTER TABLE [dbo].[TypeData]  WITH CHECK ADD  CONSTRAINT [FK_TypeData_StructureTypeData] FOREIGN KEY([idStructureTypeData])
REFERENCES [dbo].[StructureTypeData] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeData] CHECK CONSTRAINT [FK_TypeData_StructureTypeData]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TypeData_TypeData]') AND parent_object_id = OBJECT_ID(N'[dbo].[TypeData]'))
ALTER TABLE [dbo].[TypeData]  WITH CHECK ADD  CONSTRAINT [FK_TypeData_TypeData] FOREIGN KEY([idValue])
REFERENCES [dbo].[TypeDataValue] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeData] CHECK CONSTRAINT [FK_TypeData_TypeData] 
GO