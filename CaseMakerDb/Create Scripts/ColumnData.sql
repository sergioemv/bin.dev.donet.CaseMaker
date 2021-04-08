IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColumnData]') AND type in (N'U'))
DROP TABLE [dbo].[ColumnData]
GO
/****** Object:  Table [dbo].[ColumnData]    Script Date: 03/05/2008 17:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColumnData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ColumnData](
	[id] [int] NOT NULL,
	[idColumnHead] [int] NOT NULL,
	[value] [varchar](50) NULL,
 CONSTRAINT [PK_ColumnData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ColumnData_ColumnHead]') AND parent_object_id = OBJECT_ID(N'[dbo].[ColumnData]'))
ALTER TABLE [dbo].[ColumnData]  WITH CHECK ADD  CONSTRAINT [FK_ColumnData_ColumnHead] FOREIGN KEY([idColumnHead])
REFERENCES [dbo].[ColumnHead] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ColumnData] CHECK CONSTRAINT [FK_ColumnData_ColumnHead] 
GO