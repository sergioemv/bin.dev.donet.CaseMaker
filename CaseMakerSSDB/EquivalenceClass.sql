CREATE TABLE [dbo].[EquivalenceClass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[riskLevel] [int] NOT NULL CONSTRAINT [DF_EquivalenceClass_riskLevel]  DEFAULT ((0)),
	[elementId] [int] NOT NULL,
	[state] [varchar](50) NOT NULL,
	[value] [nvarchar](max) NULL,
	[position] [int] NOT NULL CONSTRAINT [DF_EquivalenceClass_position]  DEFAULT ((-1)),
 CONSTRAINT [PK_EquivalenceClass] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



GO

CREATE INDEX [IX_EquivalenceClass_ElementId_position] ON [dbo].[EquivalenceClass] ([elementId], [position])
