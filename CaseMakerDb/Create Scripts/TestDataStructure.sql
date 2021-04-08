IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestDataStructure]') AND type in (N'U'))
DROP TABLE [dbo].[TestDataStructure]
GO
/****** Object:  Table [dbo].[TestDataStructure]    Script Date: 02/25/2008 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestDataStructure]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TestDataStructure](
	[id] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[name] [varchar](50) NOT NULL CONSTRAINT [DF_TestDataStructure_name]  DEFAULT ('TestData'),
	[version] [varchar](50) NOT NULL,
	[creationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TestDataStructure] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO