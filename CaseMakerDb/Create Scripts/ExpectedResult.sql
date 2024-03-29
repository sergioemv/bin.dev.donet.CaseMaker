/****** Object:  Table [dbo].[ExpectedResult]    Script Date: 01/20/2008 20:54:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult]') AND type in (N'U'))
DROP TABLE [dbo].[ExpectedResult]
GO
/****** Object:  Table [dbo].[ExpectedResult]    Script Date: 01/20/2008 20:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExpectedResult](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[stringvalue] [varchar](max) NULL,
	[numbervalue] [float] NULL,
	[type] [varchar](50) NOT NULL,
	[effectid] [int] NOT NULL,
 CONSTRAINT [PK_ExpectedResult] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExpectedResult_Effect]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExpectedResult]'))
ALTER TABLE [dbo].[ExpectedResult]  WITH CHECK ADD  CONSTRAINT [FK_ExpectedResult_Effect] FOREIGN KEY([effectid])
REFERENCES [dbo].[Effect] ([id])
GO
