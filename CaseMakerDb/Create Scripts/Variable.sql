IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Variable]') AND type in (N'U'))
DROP TABLE [dbo].[Variable]
GO
/****** Object:  Table [dbo].[Variable]    Script Date: 02/26/2008 17:19:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Variable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Variable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[name] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[idTestDataStructure] [int] NOT NULL,
 CONSTRAINT [PK_Variable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Variable_TestDataStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[Variable]'))
ALTER TABLE [dbo].[Variable]  WITH CHECK ADD  CONSTRAINT [FK_Variable_TestDataStructure] FOREIGN KEY([idTestDataStructure])
REFERENCES [dbo].[TestDataStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Variable] CHECK CONSTRAINT [FK_Variable_TestDataStructure] 
GO