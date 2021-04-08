IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeDataValue]') AND type in (N'U'))
DROP TABLE [dbo].[TypeDataValue]
GO
/****** Object:  Table [dbo].[TypeDataValue]    Script Date: 02/26/2008 17:31:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeDataValue]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TypeDataValue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[value] [varchar](max) NULL,
	[idFormula] [int] NULL,
	[idLinkElement] [int] NULL,
	[idVariable] [int] NULL,
	[idFormat] [int] NOT NULL,
 CONSTRAINT [PK_TypeDataValue] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TypeDataValue_Format]') AND parent_object_id = OBJECT_ID(N'[dbo].[TypeDataValue]'))
ALTER TABLE [dbo].[TypeDataValue]  WITH CHECK ADD  CONSTRAINT [FK_TypeDataValue_Format] FOREIGN KEY([idFormat])
REFERENCES [dbo].[Format] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeDataValue] CHECK CONSTRAINT [FK_TypeDataValue_Format]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TypeDataValue_Formula]') AND parent_object_id = OBJECT_ID(N'[dbo].[TypeDataValue]'))
ALTER TABLE [dbo].[TypeDataValue]  WITH CHECK ADD  CONSTRAINT [FK_TypeDataValue_Formula] FOREIGN KEY([idFormula])
REFERENCES [dbo].[Formula] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeDataValue] CHECK CONSTRAINT [FK_TypeDataValue_Formula]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TypeDataValue_LinkElement]') AND parent_object_id = OBJECT_ID(N'[dbo].[TypeDataValue]'))
ALTER TABLE [dbo].[TypeDataValue]  WITH CHECK ADD  CONSTRAINT [FK_TypeDataValue_LinkElement] FOREIGN KEY([idLinkElement])
REFERENCES [dbo].[LinkElement] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeDataValue] CHECK CONSTRAINT [FK_TypeDataValue_LinkElement]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TypeDataValue_Variable]') AND parent_object_id = OBJECT_ID(N'[dbo].[TypeDataValue]'))
ALTER TABLE [dbo].[TypeDataValue]  WITH CHECK ADD  CONSTRAINT [FK_TypeDataValue_Variable] FOREIGN KEY([idVariable])
REFERENCES [dbo].[Variable] ([id])
on delete no action on update no action
GO
ALTER TABLE [dbo].[TypeDataValue] CHECK CONSTRAINT [FK_TypeDataValue_Variable] 
GO