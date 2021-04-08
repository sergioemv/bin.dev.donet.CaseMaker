IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkElement]') AND type in (N'U'))
DROP TABLE [dbo].[LinkElement]
GO
/****** Object:  Table [dbo].[LinkElement]    Script Date: 02/26/2008 18:05:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkElement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LinkElement](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[linkKey] [varchar](max) NOT NULL,
 CONSTRAINT [PK_LinkElement] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF 
GO