IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StrucTypeData_ColumnHead]') AND type in (N'U'))
DROP TABLE [dbo].[StrucTypeData_ColumnHead]
GO
/****** Object:  Table [dbo].[StrucTypeData_ColumnHead]    Script Date: 03/05/2008 17:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StrucTypeData_ColumnHead]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StrucTypeData_ColumnHead](
	[idStructureTypeData] [int] NOT NULL,
	[idColumnHead] [int] NOT NULL,
 CONSTRAINT [PK_StrucTypeData_ColumnHead] PRIMARY KEY CLUSTERED 
(
	[idStructureTypeData] ASC,
	[idColumnHead] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StrucTypeData_ColumnHead_ColumnHead]') AND parent_object_id = OBJECT_ID(N'[dbo].[StrucTypeData_ColumnHead]'))
ALTER TABLE [dbo].[StrucTypeData_ColumnHead]  WITH CHECK ADD  CONSTRAINT [FK_StrucTypeData_ColumnHead_ColumnHead] FOREIGN KEY([idColumnHead])
REFERENCES [dbo].[ColumnHead] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StrucTypeData_ColumnHead] CHECK CONSTRAINT [FK_StrucTypeData_ColumnHead_ColumnHead]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StrucTypeData_ColumnHead_StructureTypeData]') AND parent_object_id = OBJECT_ID(N'[dbo].[StrucTypeData_ColumnHead]'))
ALTER TABLE [dbo].[StrucTypeData_ColumnHead]  WITH CHECK ADD  CONSTRAINT [FK_StrucTypeData_ColumnHead_StructureTypeData] FOREIGN KEY([idStructureTypeData])
REFERENCES [dbo].[StructureTypeData] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StrucTypeData_ColumnHead] CHECK CONSTRAINT [FK_StrucTypeData_ColumnHead_StructureTypeData] 
GO