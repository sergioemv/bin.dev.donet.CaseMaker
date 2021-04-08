IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Format]') AND type in (N'U'))
DROP TABLE [dbo].[Format]
GO
/****** Object:  Table [dbo].[Format]    Script Date: 02/26/2008 17:48:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Format]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Format](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[locale] [varchar](50) NULL,
	[pattern] [varchar](max) NULL,
	[idVariable] [int] NOT NULL,
 CONSTRAINT [PK_Format] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Format_Variable]') AND parent_object_id = OBJECT_ID(N'[dbo].[Format]'))
ALTER TABLE [dbo].[Format]  WITH CHECK ADD  CONSTRAINT [FK_Format_Variable] FOREIGN KEY([idVariable])
REFERENCES [dbo].[Variable] ([id])
GO
ALTER TABLE [dbo].[Format] CHECK CONSTRAINT [FK_Format_Variable]
GO