IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Formula_Parameter]') AND type in (N'U'))
DROP TABLE [dbo].[Formula_Parameter]
GO
/****** Object:  Table [dbo].[Formula_Parameter]    Script Date: 02/26/2008 18:33:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Formula_Parameter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Formula_Parameter](
	[idFormula] [int] NOT NULL,
	[idParameter] [int] NOT NULL,
 CONSTRAINT [PK_Formula_Parameter] PRIMARY KEY CLUSTERED 
(
	[idFormula] ASC,
	[idParameter] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Formula_Parameter_Formula]') AND parent_object_id = OBJECT_ID(N'[dbo].[Formula_Parameter]'))
ALTER TABLE [dbo].[Formula_Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Formula_Parameter_Formula] FOREIGN KEY([idFormula])
REFERENCES [dbo].[Formula] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Formula_Parameter] CHECK CONSTRAINT [FK_Formula_Parameter_Formula]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Formula_Parameter_Parameter]') AND parent_object_id = OBJECT_ID(N'[dbo].[Formula_Parameter]'))
ALTER TABLE [dbo].[Formula_Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Formula_Parameter_Parameter] FOREIGN KEY([idParameter])
REFERENCES [dbo].[Parameter] ([id])
GO
ALTER TABLE [dbo].[Formula_Parameter] CHECK CONSTRAINT [FK_Formula_Parameter_Parameter] 
GO