CREATE TABLE [dbo].[Element](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
	[position] [int] NULL,
	[testObjectId] [int] NOT NULL,
 CONSTRAINT [PK_Element] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE INDEX [IX_Element_testObject_name] ON [dbo].[Element] ([testObjectId], [name])
