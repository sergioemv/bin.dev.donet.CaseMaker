IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeData_ColumnData]') AND type in (N'U'))
DROP TABLE [dbo].[TypeData_ColumnData]
GO
/****** Object:  Table [dbo].[TypeData_ColumnData]    Script Date: 03/05/2008 18:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeData_ColumnData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TypeData_ColumnData](
	[idTypeData] [int] NOT NULL,
	[idColumnData] [int] NOT NULL,
 CONSTRAINT [PK_TypeData_ColumnData] PRIMARY KEY CLUSTERED 
(
	[idTypeData] ASC,
	[idColumnData] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TypeData_ColumnData_ColumnData]') AND parent_object_id = OBJECT_ID(N'[dbo].[TypeData_ColumnData]'))
ALTER TABLE [dbo].[TypeData_ColumnData]  WITH CHECK ADD  CONSTRAINT [FK_TypeData_ColumnData_ColumnData] FOREIGN KEY([idColumnData])
REFERENCES [dbo].[ColumnData] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeData_ColumnData] CHECK CONSTRAINT [FK_TypeData_ColumnData_ColumnData]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TypeData_ColumnData_TypeData]') AND parent_object_id = OBJECT_ID(N'[dbo].[TypeData_ColumnData]'))
ALTER TABLE [dbo].[TypeData_ColumnData]  WITH CHECK ADD  CONSTRAINT [FK_TypeData_ColumnData_TypeData] FOREIGN KEY([idTypeData])
REFERENCES [dbo].[TypeData] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeData_ColumnData] CHECK CONSTRAINT [FK_TypeData_ColumnData_TypeData] 
GO