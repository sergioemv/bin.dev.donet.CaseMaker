CREATE TABLE [dbo].[TestCase](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [int] NOT NULL,
	[structureid] [int] NULL,
	[description] [varchar](max) NULL,
	[state] [int] NOT NULL,
	[risklevel] [int] NOT NULL,
	[origin] [int] NOT NULL,
	[stdcombinationid] [int] NULL,
 CONSTRAINT [PK_TestCase] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY] 
) ON [PRIMARY]