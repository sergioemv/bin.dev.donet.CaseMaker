USE [CaseMaker]
GO
/****** Object:  Table [dbo].[StdCombination]    Script Date: 05/26/2008 18:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StdCombination](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[structureid] [int] NULL,
 CONSTRAINT [PK_StdCombination] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[State]    Script Date: 05/26/2008 18:34:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[State](
	[id] [int] NOT NULL,
	[name] [char](1) NOT NULL,
	[description] [varchar](50) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestObject]    Script Date: 05/26/2008 18:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestObject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
	[precondition] [varchar](max) NULL,
	[decimalSeparator] [char](1) NULL,
	[thousandSeparator] [char](1) NULL,
	[version] [varchar](50) NULL,
	[creationDate] [datetime] NOT NULL,
	[modDate] [datetime] NULL,
 CONSTRAINT [PK_TestObject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 05/26/2008 18:35:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserLogin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NULL,
	[username] [nchar](20) NOT NULL,
	[password] [varchar](200) NOT NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Format]    Script Date: 05/26/2008 18:34:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Format](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[locale] [varchar](50) NULL,
	[pattern] [varchar](max) NULL,
	[idVariable] [int] NOT NULL,
 CONSTRAINT [PK_Format] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LinkElement]    Script Date: 05/26/2008 18:34:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LinkElement](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[linkKey] [varchar](max) NOT NULL,
 CONSTRAINT [PK_LinkElement] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Formula]    Script Date: 05/26/2008 18:34:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Formula](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[typeOfFormula] [int] NOT NULL,
 CONSTRAINT [PK_Formula] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StdCombs_EqClasses]    Script Date: 05/26/2008 18:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StdCombs_EqClasses](
	[stdcombinationid] [int] NOT NULL,
	[equivalenceclassid] [int] NOT NULL,
 CONSTRAINT [PK_StdCombs_EqClasses] PRIMARY KEY CLUSTERED 
(
	[stdcombinationid] ASC,
	[equivalenceclassid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestCase]    Script Date: 05/26/2008 18:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestCases_EqClasses]    Script Date: 05/26/2008 18:35:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCases_EqClasses](
	[testcaseid] [int] NOT NULL,
	[equivalenceclassid] [int] NOT NULL,
 CONSTRAINT [PK_TestCases_EqClasses] PRIMARY KEY CLUSTERED 
(
	[testcaseid] ASC,
	[equivalenceclassid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Combs_EqClasses]    Script Date: 05/26/2008 18:34:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Combs_EqClasses](
	[combinationid] [int] NOT NULL,
	[equivalenceclassid] [int] NOT NULL,
 CONSTRAINT [PK_Combs_EqClasses] PRIMARY KEY CLUSTERED 
(
	[combinationid] ASC,
	[equivalenceclassid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deps_EqClasses]    Script Date: 05/26/2008 18:34:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deps_EqClasses](
	[dependencyid] [int] NOT NULL,
	[eqclassid] [int] NOT NULL,
 CONSTRAINT [PK_Deps_EqClasses] PRIMARY KEY CLUSTERED 
(
	[dependencyid] ASC,
	[eqclassid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EqClasses_Effects]    Script Date: 05/26/2008 18:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EqClasses_Effects](
	[effectid] [int] NOT NULL,
	[eqclassid] [int] NOT NULL,
 CONSTRAINT [PK_EqClasses_Effects] PRIMARY KEY CLUSTERED 
(
	[effectid] ASC,
	[eqclassid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Combs_Effects]    Script Date: 05/26/2008 18:34:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Combs_Effects](
	[combinationid] [int] NOT NULL,
	[effectid] [int] NOT NULL,
 CONSTRAINT [PK_Combs_Effects] PRIMARY KEY CLUSTERED 
(
	[combinationid] ASC,
	[effectid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestCases_Combs]    Script Date: 05/26/2008 18:35:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCases_Combs](
	[testcaseid] [int] NOT NULL,
	[combinationid] [int] NOT NULL,
 CONSTRAINT [PK_TestCases_Combs] PRIMARY KEY CLUSTERED 
(
	[testcaseid] ASC,
	[combinationid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestCasesStructure]    Script Date: 05/26/2008 18:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCasesStructure](
	[id] [int] NOT NULL,
	[creationDate] [datetime] NULL,
	[modDate] [datetime] NULL,
 CONSTRAINT [PK_TestCasesStructure] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestDataStructure]    Script Date: 05/26/2008 18:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestDataStructure](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[name] [varchar](50) NOT NULL CONSTRAINT [DF_TestDataStructure_name]  DEFAULT ('TestData'),
	[version] [varchar](50) NOT NULL,
	[idTestObject] [int] NOT NULL,
	[creationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TestDataStructure] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Requirement]    Script Date: 05/26/2008 18:34:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Requirement](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[structureid] [int] NOT NULL,
 CONSTRAINT [PK_Requirements] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Effect]    Script Date: 05/26/2008 18:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Effect](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [int] NOT NULL CONSTRAINT [DF_Table1_position]  DEFAULT ((0)),
	[structureid] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[state] [int] NULL,
	[risklevel] [int] NOT NULL CONSTRAINT [DF_Table1_risklevel]  DEFAULT ((0)),
 CONSTRAINT [PK_Table1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Element]    Script Date: 05/26/2008 18:34:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Element](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
	[position] [int] NULL,
	[testObjectId] [int] NOT NULL,
 CONSTRAINT [PK_Element] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Element] ON [dbo].[Element] 
(
	[testObjectId] ASC,
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Element names must not be repeated' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Element', @level2type=N'INDEX',@level2name=N'IX_Element'
GO
/****** Object:  Table [dbo].[Dependency]    Script Date: 05/26/2008 18:34:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dependency](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[structureid] [int] NOT NULL,
	[position] [int] NOT NULL,
 CONSTRAINT [PK_Dependency] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Dependency_Position] ON [dbo].[Dependency] 
(
	[structureid] ASC,
	[position] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Effects_Reqs]    Script Date: 05/26/2008 18:34:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Effects_Reqs](
	[effectid] [int] NOT NULL,
	[requirementid] [int] NOT NULL,
 CONSTRAINT [PK_Effects_Reqs] PRIMARY KEY CLUSTERED 
(
	[effectid] ASC,
	[requirementid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpectedResult]    Script Date: 05/26/2008 18:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EquivalenceClass]    Script Date: 05/26/2008 18:34:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EquivalenceClass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[riskLevel] [int] NOT NULL CONSTRAINT [DF_EquivalenceClass_riskLevel]  DEFAULT ((0)),
	[elementId] [int] NOT NULL,
	[state] [int] NOT NULL,
	[value] [nvarchar](max) NULL,
	[position] [int] NOT NULL CONSTRAINT [DF_EquivalenceClass_position]  DEFAULT ((-1)),
 CONSTRAINT [PK_EquivalenceClass] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EquivalenceClass] ON [dbo].[EquivalenceClass] 
(
	[elementId] ASC,
	[position] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deps_Elems]    Script Date: 05/26/2008 18:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deps_Elems](
	[dependencyid] [int] NOT NULL,
	[elementid] [int] NOT NULL,
 CONSTRAINT [PK_Deps_Elems] PRIMARY KEY CLUSTERED 
(
	[dependencyid] ASC,
	[elementid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Combination]    Script Date: 05/26/2008 18:34:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Combination](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[state] [int] NOT NULL,
	[parentcombinationid] [int] NULL,
	[risklevel] [int] NOT NULL,
	[origin] [int] NOT NULL,
	[dependencyid] [int] NOT NULL,
 CONSTRAINT [PK_Combination] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TDStructure_TestCase]    Script Date: 05/26/2008 18:35:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TDStructure_TestCase](
	[idTestDataStructure] [int] NOT NULL,
	[idTestCase] [int] NOT NULL,
 CONSTRAINT [PK_TDStructure_TestCase] PRIMARY KEY CLUSTERED 
(
	[idTestDataStructure] ASC,
	[idTestCase] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Variable]    Script Date: 05/26/2008 18:35:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Variable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[name] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[idTestDataStructure] [int] NOT NULL,
 CONSTRAINT [PK_Variable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestData]    Script Date: 05/26/2008 18:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[riskLevel] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[idTestDataStructure] [int] NOT NULL,
 CONSTRAINT [PK_TestData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Parameter]    Script Date: 05/26/2008 18:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parameter](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeParameter] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[idLinkKey] [int] NULL,
	[idTypeDataValue] [int] NULL,
	[idVariable] [int] NULL,
	[idFormula] [int] NULL,
 CONSTRAINT [PK_Parameter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeDataValue]    Script Date: 05/26/2008 18:35:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeDataValue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[value] [varchar](max) NULL,
	[idFormula] [int] NULL,
	[idLinkElement] [int] NULL,
	[idVariable] [int] NULL,
	[idFormat] [int] NOT NULL,
 CONSTRAINT [PK_TypeDataValue] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TypeData]    Script Date: 05/26/2008 18:35:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[field] [varchar](50) NULL,
	[global] [varchar](1) NULL,
	[keyTypeData] [varchar](1) NULL,
	[lenght] [int] NULL,
	[name] [varchar](50) NULL,
	[preffix] [varchar](50) NULL,
	[objectType] [varchar](50) NULL,
	[suffix] [varchar](50) NULL,
	[type] [varchar](50) NULL,
	[typeOfTypeData] [varchar](50) NOT NULL,
	[idStructureTypeData] [int] NOT NULL,
	[idValue] [int] NULL,
 CONSTRAINT [PK_TypeData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 05/26/2008 18:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userLogin] [int] NOT NULL,
	[type] [varchar](50) NOT NULL,
	[permissionNature] [int] NOT NULL,
	[structure] [int] NULL,
	[testobject] [int] NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Formula_Parameter]    Script Date: 05/26/2008 18:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formula_Parameter](
	[idFormula] [int] NOT NULL,
	[idParameter] [int] NOT NULL,
 CONSTRAINT [PK_Formula_Parameter] PRIMARY KEY CLUSTERED 
(
	[idFormula] ASC,
	[idParameter] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Combination_Dependency]    Script Date: 05/26/2008 18:34:08 ******/
ALTER TABLE [dbo].[Combination]  WITH CHECK ADD  CONSTRAINT [FK_Combination_Dependency] FOREIGN KEY([dependencyid])
REFERENCES [dbo].[Dependency] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Combination] CHECK CONSTRAINT [FK_Combination_Dependency]
GO
/****** Object:  ForeignKey [FK_Combs_Effects_Combination]    Script Date: 05/26/2008 18:34:10 ******/
ALTER TABLE [dbo].[Combs_Effects]  WITH CHECK ADD  CONSTRAINT [FK_Combs_Effects_Combination] FOREIGN KEY([combinationid])
REFERENCES [dbo].[Combination] ([id])
GO
ALTER TABLE [dbo].[Combs_Effects] CHECK CONSTRAINT [FK_Combs_Effects_Combination]
GO
/****** Object:  ForeignKey [FK_Combs_Effects_Effect]    Script Date: 05/26/2008 18:34:10 ******/
ALTER TABLE [dbo].[Combs_Effects]  WITH CHECK ADD  CONSTRAINT [FK_Combs_Effects_Effect] FOREIGN KEY([effectid])
REFERENCES [dbo].[Effect] ([id])
GO
ALTER TABLE [dbo].[Combs_Effects] CHECK CONSTRAINT [FK_Combs_Effects_Effect]
GO
/****** Object:  ForeignKey [FK_Combs_EqClasses_Combination]    Script Date: 05/26/2008 18:34:12 ******/
ALTER TABLE [dbo].[Combs_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_Combs_EqClasses_Combination] FOREIGN KEY([combinationid])
REFERENCES [dbo].[Combination] ([id])
GO
ALTER TABLE [dbo].[Combs_EqClasses] CHECK CONSTRAINT [FK_Combs_EqClasses_Combination]
GO
/****** Object:  ForeignKey [FK_Combs_EqClasses_EquivalenceClass]    Script Date: 05/26/2008 18:34:12 ******/
ALTER TABLE [dbo].[Combs_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_Combs_EqClasses_EquivalenceClass] FOREIGN KEY([equivalenceclassid])
REFERENCES [dbo].[EquivalenceClass] ([id])
GO
ALTER TABLE [dbo].[Combs_EqClasses] CHECK CONSTRAINT [FK_Combs_EqClasses_EquivalenceClass]
GO
/****** Object:  ForeignKey [FK_Dependency_TestCasesStructure]    Script Date: 05/26/2008 18:34:15 ******/
ALTER TABLE [dbo].[Dependency]  WITH CHECK ADD  CONSTRAINT [FK_Dependency_TestCasesStructure] FOREIGN KEY([structureid])
REFERENCES [dbo].[TestCasesStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dependency] CHECK CONSTRAINT [FK_Dependency_TestCasesStructure]
GO
/****** Object:  ForeignKey [FK_Elements_Deps_Dependency]    Script Date: 05/26/2008 18:34:17 ******/
ALTER TABLE [dbo].[Deps_Elems]  WITH CHECK ADD  CONSTRAINT [FK_Elements_Deps_Dependency] FOREIGN KEY([dependencyid])
REFERENCES [dbo].[Dependency] ([id])
GO
ALTER TABLE [dbo].[Deps_Elems] CHECK CONSTRAINT [FK_Elements_Deps_Dependency]
GO
/****** Object:  ForeignKey [FK_Elements_Deps_Element]    Script Date: 05/26/2008 18:34:17 ******/
ALTER TABLE [dbo].[Deps_Elems]  WITH CHECK ADD  CONSTRAINT [FK_Elements_Deps_Element] FOREIGN KEY([elementid])
REFERENCES [dbo].[Element] ([id])
GO
ALTER TABLE [dbo].[Deps_Elems] CHECK CONSTRAINT [FK_Elements_Deps_Element]
GO
/****** Object:  ForeignKey [FK_Deps_EqClasses_Dependency]    Script Date: 05/26/2008 18:34:19 ******/
ALTER TABLE [dbo].[Deps_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_Deps_EqClasses_Dependency] FOREIGN KEY([dependencyid])
REFERENCES [dbo].[Dependency] ([id])
GO
ALTER TABLE [dbo].[Deps_EqClasses] CHECK CONSTRAINT [FK_Deps_EqClasses_Dependency]
GO
/****** Object:  ForeignKey [FK_Deps_EqClasses_EquivalenceClass]    Script Date: 05/26/2008 18:34:19 ******/
ALTER TABLE [dbo].[Deps_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_Deps_EqClasses_EquivalenceClass] FOREIGN KEY([eqclassid])
REFERENCES [dbo].[EquivalenceClass] ([id])
GO
ALTER TABLE [dbo].[Deps_EqClasses] CHECK CONSTRAINT [FK_Deps_EqClasses_EquivalenceClass]
GO
/****** Object:  ForeignKey [FK_Effect_TestCasesStructure]    Script Date: 05/26/2008 18:34:23 ******/
ALTER TABLE [dbo].[Effect]  WITH CHECK ADD  CONSTRAINT [FK_Effect_TestCasesStructure] FOREIGN KEY([structureid])
REFERENCES [dbo].[TestCasesStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Effect] CHECK CONSTRAINT [FK_Effect_TestCasesStructure]
GO
/****** Object:  ForeignKey [FK_Effects_Reqs_Effect]    Script Date: 05/26/2008 18:34:25 ******/
ALTER TABLE [dbo].[Effects_Reqs]  WITH CHECK ADD  CONSTRAINT [FK_Effects_Reqs_Effect] FOREIGN KEY([effectid])
REFERENCES [dbo].[Effect] ([id])
GO
ALTER TABLE [dbo].[Effects_Reqs] CHECK CONSTRAINT [FK_Effects_Reqs_Effect]
GO
/****** Object:  ForeignKey [FK_Effects_Reqs_Requirement]    Script Date: 05/26/2008 18:34:25 ******/
ALTER TABLE [dbo].[Effects_Reqs]  WITH CHECK ADD  CONSTRAINT [FK_Effects_Reqs_Requirement] FOREIGN KEY([requirementid])
REFERENCES [dbo].[Requirement] ([id])
GO
ALTER TABLE [dbo].[Effects_Reqs] CHECK CONSTRAINT [FK_Effects_Reqs_Requirement]
GO
/****** Object:  ForeignKey [FK_Element_TestObject1]    Script Date: 05/26/2008 18:34:28 ******/
ALTER TABLE [dbo].[Element]  WITH CHECK ADD  CONSTRAINT [FK_Element_TestObject1] FOREIGN KEY([testObjectId])
REFERENCES [dbo].[TestCasesStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Element] CHECK CONSTRAINT [FK_Element_TestObject1]
GO
/****** Object:  ForeignKey [FK_EqClasses_Effects_Effect]    Script Date: 05/26/2008 18:34:30 ******/
ALTER TABLE [dbo].[EqClasses_Effects]  WITH CHECK ADD  CONSTRAINT [FK_EqClasses_Effects_Effect] FOREIGN KEY([effectid])
REFERENCES [dbo].[Effect] ([id])
GO
ALTER TABLE [dbo].[EqClasses_Effects] CHECK CONSTRAINT [FK_EqClasses_Effects_Effect]
GO
/****** Object:  ForeignKey [FK_EqClasses_Effects_EquivalenceClass]    Script Date: 05/26/2008 18:34:30 ******/
ALTER TABLE [dbo].[EqClasses_Effects]  WITH CHECK ADD  CONSTRAINT [FK_EqClasses_Effects_EquivalenceClass] FOREIGN KEY([eqclassid])
REFERENCES [dbo].[EquivalenceClass] ([id])
GO
ALTER TABLE [dbo].[EqClasses_Effects] CHECK CONSTRAINT [FK_EqClasses_Effects_EquivalenceClass]
GO
/****** Object:  ForeignKey [FK_EquivalenceClass_Element]    Script Date: 05/26/2008 18:34:35 ******/
ALTER TABLE [dbo].[EquivalenceClass]  WITH CHECK ADD  CONSTRAINT [FK_EquivalenceClass_Element] FOREIGN KEY([elementId])
REFERENCES [dbo].[Element] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EquivalenceClass] CHECK CONSTRAINT [FK_EquivalenceClass_Element]
GO
/****** Object:  ForeignKey [FK_ExpectedResult_Effect]    Script Date: 05/26/2008 18:34:39 ******/
ALTER TABLE [dbo].[ExpectedResult]  WITH CHECK ADD  CONSTRAINT [FK_ExpectedResult_Effect] FOREIGN KEY([effectid])
REFERENCES [dbo].[Effect] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExpectedResult] CHECK CONSTRAINT [FK_ExpectedResult_Effect]
GO
/****** Object:  ForeignKey [FK_Formula_Parameter_Formula]    Script Date: 05/26/2008 18:34:45 ******/
ALTER TABLE [dbo].[Formula_Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Formula_Parameter_Formula] FOREIGN KEY([idFormula])
REFERENCES [dbo].[Formula] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Formula_Parameter] CHECK CONSTRAINT [FK_Formula_Parameter_Formula]
GO
/****** Object:  ForeignKey [FK_Parameter_Formula]    Script Date: 05/26/2008 18:34:50 ******/
ALTER TABLE [dbo].[Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Parameter_Formula] FOREIGN KEY([idFormula])
REFERENCES [dbo].[Formula] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parameter] CHECK CONSTRAINT [FK_Parameter_Formula]
GO
/****** Object:  ForeignKey [FK_Parameter_LinkElement]    Script Date: 05/26/2008 18:34:50 ******/
ALTER TABLE [dbo].[Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Parameter_LinkElement] FOREIGN KEY([idLinkKey])
REFERENCES [dbo].[LinkElement] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parameter] CHECK CONSTRAINT [FK_Parameter_LinkElement]
GO
/****** Object:  ForeignKey [FK_Parameter_Variable]    Script Date: 05/26/2008 18:34:50 ******/
ALTER TABLE [dbo].[Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Parameter_Variable] FOREIGN KEY([idVariable])
REFERENCES [dbo].[Variable] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parameter] CHECK CONSTRAINT [FK_Parameter_Variable]
GO
/****** Object:  ForeignKey [FK_Permission_UserLogin]    Script Date: 05/26/2008 18:34:54 ******/
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_UserLogin] FOREIGN KEY([userLogin])
REFERENCES [dbo].[UserLogin] ([id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_UserLogin]
GO
/****** Object:  ForeignKey [FK_Requirement_TestCasesStructure]    Script Date: 05/26/2008 18:34:56 ******/
ALTER TABLE [dbo].[Requirement]  WITH CHECK ADD  CONSTRAINT [FK_Requirement_TestCasesStructure] FOREIGN KEY([structureid])
REFERENCES [dbo].[TestCasesStructure] ([id])
GO
ALTER TABLE [dbo].[Requirement] CHECK CONSTRAINT [FK_Requirement_TestCasesStructure]
GO
/****** Object:  ForeignKey [FK_StdCombs_EqClasses_EquivalenceClass]    Script Date: 05/26/2008 18:35:02 ******/
ALTER TABLE [dbo].[StdCombs_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_StdCombs_EqClasses_EquivalenceClass] FOREIGN KEY([equivalenceclassid])
REFERENCES [dbo].[EquivalenceClass] ([id])
GO
ALTER TABLE [dbo].[StdCombs_EqClasses] CHECK CONSTRAINT [FK_StdCombs_EqClasses_EquivalenceClass]
GO
/****** Object:  ForeignKey [FK_StdCombs_EqClasses_StdCombination]    Script Date: 05/26/2008 18:35:02 ******/
ALTER TABLE [dbo].[StdCombs_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_StdCombs_EqClasses_StdCombination] FOREIGN KEY([stdcombinationid])
REFERENCES [dbo].[StdCombination] ([id])
GO
ALTER TABLE [dbo].[StdCombs_EqClasses] CHECK CONSTRAINT [FK_StdCombs_EqClasses_StdCombination]
GO
/****** Object:  ForeignKey [FK_TDStructure_TestCase_TestCase]    Script Date: 05/26/2008 18:35:04 ******/
ALTER TABLE [dbo].[TDStructure_TestCase]  WITH CHECK ADD  CONSTRAINT [FK_TDStructure_TestCase_TestCase] FOREIGN KEY([idTestCase])
REFERENCES [dbo].[TestCase] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TDStructure_TestCase] CHECK CONSTRAINT [FK_TDStructure_TestCase_TestCase]
GO
/****** Object:  ForeignKey [FK_TestCase_StdCombination]    Script Date: 05/26/2008 18:35:08 ******/
ALTER TABLE [dbo].[TestCase]  WITH NOCHECK ADD  CONSTRAINT [FK_TestCase_StdCombination] FOREIGN KEY([stdcombinationid])
REFERENCES [dbo].[StdCombination] ([id])
GO
ALTER TABLE [dbo].[TestCase] NOCHECK CONSTRAINT [FK_TestCase_StdCombination]
GO
/****** Object:  ForeignKey [FK_TestCase_TestCasesStructure]    Script Date: 05/26/2008 18:35:09 ******/
ALTER TABLE [dbo].[TestCase]  WITH CHECK ADD  CONSTRAINT [FK_TestCase_TestCasesStructure] FOREIGN KEY([structureid])
REFERENCES [dbo].[TestCasesStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TestCase] CHECK CONSTRAINT [FK_TestCase_TestCasesStructure]
GO
/****** Object:  ForeignKey [FK_TestCases_Combs_Combination]    Script Date: 05/26/2008 18:35:10 ******/
ALTER TABLE [dbo].[TestCases_Combs]  WITH CHECK ADD  CONSTRAINT [FK_TestCases_Combs_Combination] FOREIGN KEY([combinationid])
REFERENCES [dbo].[Combination] ([id])
GO
ALTER TABLE [dbo].[TestCases_Combs] CHECK CONSTRAINT [FK_TestCases_Combs_Combination]
GO
/****** Object:  ForeignKey [FK_TestCases_Combs_TestCase]    Script Date: 05/26/2008 18:35:11 ******/
ALTER TABLE [dbo].[TestCases_Combs]  WITH CHECK ADD  CONSTRAINT [FK_TestCases_Combs_TestCase] FOREIGN KEY([testcaseid])
REFERENCES [dbo].[TestCase] ([id])
GO
ALTER TABLE [dbo].[TestCases_Combs] CHECK CONSTRAINT [FK_TestCases_Combs_TestCase]
GO
/****** Object:  ForeignKey [FK_TestCases_EqClasses_EquivalenceClass]    Script Date: 05/26/2008 18:35:12 ******/
ALTER TABLE [dbo].[TestCases_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_TestCases_EqClasses_EquivalenceClass] FOREIGN KEY([equivalenceclassid])
REFERENCES [dbo].[EquivalenceClass] ([id])
GO
ALTER TABLE [dbo].[TestCases_EqClasses] CHECK CONSTRAINT [FK_TestCases_EqClasses_EquivalenceClass]
GO
/****** Object:  ForeignKey [FK_TestCases_EqClasses_TestCase]    Script Date: 05/26/2008 18:35:13 ******/
ALTER TABLE [dbo].[TestCases_EqClasses]  WITH CHECK ADD  CONSTRAINT [FK_TestCases_EqClasses_TestCase] FOREIGN KEY([testcaseid])
REFERENCES [dbo].[TestCase] ([id])
GO
ALTER TABLE [dbo].[TestCases_EqClasses] CHECK CONSTRAINT [FK_TestCases_EqClasses_TestCase]
GO
/****** Object:  ForeignKey [FK_TestCasesStructure_TestObject]    Script Date: 05/26/2008 18:35:15 ******/
ALTER TABLE [dbo].[TestCasesStructure]  WITH CHECK ADD  CONSTRAINT [FK_TestCasesStructure_TestObject] FOREIGN KEY([id])
REFERENCES [dbo].[TestObject] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TestCasesStructure] CHECK CONSTRAINT [FK_TestCasesStructure_TestObject]
GO
/****** Object:  ForeignKey [FK_TestData_TestDataStructure]    Script Date: 05/26/2008 18:35:18 ******/
ALTER TABLE [dbo].[TestData]  WITH CHECK ADD  CONSTRAINT [FK_TestData_TestDataStructure] FOREIGN KEY([idTestDataStructure])
REFERENCES [dbo].[TestDataStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TestData] CHECK CONSTRAINT [FK_TestData_TestDataStructure]
GO
/****** Object:  ForeignKey [FK_TestDataStructure_TestObject]    Script Date: 05/26/2008 18:35:22 ******/
ALTER TABLE [dbo].[TestDataStructure]  WITH CHECK ADD  CONSTRAINT [FK_TestDataStructure_TestObject] FOREIGN KEY([idTestObject])
REFERENCES [dbo].[TestObject] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TestDataStructure] CHECK CONSTRAINT [FK_TestDataStructure_TestObject]
GO
/****** Object:  ForeignKey [FK_TypeData_TypeData]    Script Date: 05/26/2008 18:35:33 ******/
ALTER TABLE [dbo].[TypeData]  WITH CHECK ADD  CONSTRAINT [FK_TypeData_TypeData] FOREIGN KEY([idValue])
REFERENCES [dbo].[TypeDataValue] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeData] CHECK CONSTRAINT [FK_TypeData_TypeData]
GO
/****** Object:  ForeignKey [FK_TypeDataValue_Format]    Script Date: 05/26/2008 18:35:36 ******/
ALTER TABLE [dbo].[TypeDataValue]  WITH CHECK ADD  CONSTRAINT [FK_TypeDataValue_Format] FOREIGN KEY([idFormat])
REFERENCES [dbo].[Format] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeDataValue] CHECK CONSTRAINT [FK_TypeDataValue_Format]
GO
/****** Object:  ForeignKey [FK_TypeDataValue_Formula]    Script Date: 05/26/2008 18:35:37 ******/
ALTER TABLE [dbo].[TypeDataValue]  WITH CHECK ADD  CONSTRAINT [FK_TypeDataValue_Formula] FOREIGN KEY([idFormula])
REFERENCES [dbo].[Formula] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeDataValue] CHECK CONSTRAINT [FK_TypeDataValue_Formula]
GO
/****** Object:  ForeignKey [FK_TypeDataValue_LinkElement]    Script Date: 05/26/2008 18:35:37 ******/
ALTER TABLE [dbo].[TypeDataValue]  WITH CHECK ADD  CONSTRAINT [FK_TypeDataValue_LinkElement] FOREIGN KEY([idLinkElement])
REFERENCES [dbo].[LinkElement] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeDataValue] CHECK CONSTRAINT [FK_TypeDataValue_LinkElement]
GO
/****** Object:  ForeignKey [FK_TypeDataValue_Variable]    Script Date: 05/26/2008 18:35:37 ******/
ALTER TABLE [dbo].[TypeDataValue]  WITH CHECK ADD  CONSTRAINT [FK_TypeDataValue_Variable] FOREIGN KEY([idVariable])
REFERENCES [dbo].[Variable] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeDataValue] CHECK CONSTRAINT [FK_TypeDataValue_Variable]
GO
/****** Object:  ForeignKey [FK_Variable_TestDataStructure]    Script Date: 05/26/2008 18:35:42 ******/
ALTER TABLE [dbo].[Variable]  WITH CHECK ADD  CONSTRAINT [FK_Variable_TestDataStructure] FOREIGN KEY([idTestDataStructure])
REFERENCES [dbo].[TestDataStructure] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Variable] CHECK CONSTRAINT [FK_Variable_TestDataStructure]
GO
