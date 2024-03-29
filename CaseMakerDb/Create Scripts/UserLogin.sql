/****** Object:  Table [dbo].[UserLogin]    Script Date: 05/26/2008 17:39:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserLogin]') AND type in (N'U'))
DROP TABLE [dbo].[UserLogin]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 05/26/2008 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserLogin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserLogin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NULL,
	[username] [nchar](20) NOT NULL,
	[password] [varchar](200) NOT NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
