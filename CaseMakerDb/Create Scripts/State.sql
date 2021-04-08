 /****** Object:  Table [dbo].[State]    Script Date: 01/05/2008 20:36:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
DROP TABLE [dbo].[State]
GO
/****** Object:  Table [dbo].[State]    Script Date: 01/05/2008 20:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[State](
	[id] [int]  NOT NULL,
	[name] [char](1) NOT NULL,
	[description] [varchar](50) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

DELETE FROM STATE
 
INSERT INTO STATE VALUES (3,'+','Positive')
INSERT INTO STATE VALUES (2,'-','Negative')
INSERT INTO STATE VALUES (0,'F','Faulty') 
INSERT INTO STATE VALUES (1,'I','Irrelevant')

GO