/****** Object:  Table [dbo].[StdCombination]    Script Date: 01/30/2008 16:16:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StdCombination]') AND type in (N'U'))
DROP TABLE [dbo].[StdCombination]
GO
/****** Object:  Table [dbo].[StdCombination]    Script Date: 01/30/2008 16:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StdCombination]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StdCombination](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[structureid] [int] NULL,
 CONSTRAINT [PK_StdCombination] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
