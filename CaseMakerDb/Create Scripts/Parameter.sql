IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parameter]') AND type in (N'U'))
DROP TABLE [dbo].[Parameter]
GO
/****** Object:  Table [dbo].[Parameter]    Script Date: 02/26/2008 18:24:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parameter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Parameter](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeParameter] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[idLinkKey] [int] NULL,
	[idTypeDataValue] [int] NULL,
	[idVariable] [int] NULL,
	[idFormula] [int] NULL,
 CONSTRAINT [PK_Parameter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Parameter_Formula]') AND parent_object_id = OBJECT_ID(N'[dbo].[Parameter]'))
ALTER TABLE [dbo].[Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Parameter_Formula] FOREIGN KEY([idFormula])
REFERENCES [dbo].[Formula] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parameter] CHECK CONSTRAINT [FK_Parameter_Formula]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Parameter_LinkElement]') AND parent_object_id = OBJECT_ID(N'[dbo].[Parameter]'))
ALTER TABLE [dbo].[Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Parameter_LinkElement] FOREIGN KEY([idLinkKey])
REFERENCES [dbo].[LinkElement] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parameter] CHECK CONSTRAINT [FK_Parameter_LinkElement]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Parameter_TypeDataValue]') AND parent_object_id = OBJECT_ID(N'[dbo].[Parameter]'))
ALTER TABLE [dbo].[Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Parameter_TypeDataValue] FOREIGN KEY([idTypeDataValue])
REFERENCES [dbo].[TypeDataValue] ([id])
GO
ALTER TABLE [dbo].[Parameter] CHECK CONSTRAINT [FK_Parameter_TypeDataValue]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Parameter_Variable]') AND parent_object_id = OBJECT_ID(N'[dbo].[Parameter]'))
ALTER TABLE [dbo].[Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Parameter_Variable] FOREIGN KEY([idVariable])
REFERENCES [dbo].[Variable] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parameter] CHECK CONSTRAINT [FK_Parameter_Variable] 
GO