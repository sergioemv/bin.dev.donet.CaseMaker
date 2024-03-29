USE [CaseMaker]
GO
/****** Object:  ForeignKey [FK_Combination_Dependency]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Combination] DROP CONSTRAINT [FK_Combination_Dependency]
GO
/****** Object:  ForeignKey [FK_Combs_Effects_Combination]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Combs_Effects] DROP CONSTRAINT [FK_Combs_Effects_Combination]
GO
/****** Object:  ForeignKey [FK_Combs_Effects_Effect]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Combs_Effects] DROP CONSTRAINT [FK_Combs_Effects_Effect]
GO
/****** Object:  ForeignKey [FK_Combs_EqClasses_Combination]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Combs_EqClasses] DROP CONSTRAINT [FK_Combs_EqClasses_Combination]
GO
/****** Object:  ForeignKey [FK_Combs_EqClasses_EquivalenceClass]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Combs_EqClasses] DROP CONSTRAINT [FK_Combs_EqClasses_EquivalenceClass]
GO
/****** Object:  ForeignKey [FK_Dependency_TestCasesStructure]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Dependency] DROP CONSTRAINT [FK_Dependency_TestCasesStructure]
GO
/****** Object:  ForeignKey [FK_Elements_Deps_Dependency]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Deps_Elems] DROP CONSTRAINT [FK_Elements_Deps_Dependency]
GO
/****** Object:  ForeignKey [FK_Elements_Deps_Element]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Deps_Elems] DROP CONSTRAINT [FK_Elements_Deps_Element]
GO
/****** Object:  ForeignKey [FK_Deps_EqClasses_Dependency]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Deps_EqClasses] DROP CONSTRAINT [FK_Deps_EqClasses_Dependency]
GO
/****** Object:  ForeignKey [FK_Deps_EqClasses_EquivalenceClass]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Deps_EqClasses] DROP CONSTRAINT [FK_Deps_EqClasses_EquivalenceClass]
GO
/****** Object:  ForeignKey [FK_Effect_TestCasesStructure]    Script Date: 05/26/2008 18:37:29 ******/
ALTER TABLE [dbo].[Effect] DROP CONSTRAINT [FK_Effect_TestCasesStructure]
GO
/****** Object:  ForeignKey [FK_Effects_Reqs_Effect]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[Effects_Reqs] DROP CONSTRAINT [FK_Effects_Reqs_Effect]
GO
/****** Object:  ForeignKey [FK_Effects_Reqs_Requirement]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[Effects_Reqs] DROP CONSTRAINT [FK_Effects_Reqs_Requirement]
GO
/****** Object:  ForeignKey [FK_Element_TestObject1]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[Element] DROP CONSTRAINT [FK_Element_TestObject1]
GO
/****** Object:  ForeignKey [FK_EqClasses_Effects_Effect]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[EqClasses_Effects] DROP CONSTRAINT [FK_EqClasses_Effects_Effect]
GO
/****** Object:  ForeignKey [FK_EqClasses_Effects_EquivalenceClass]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[EqClasses_Effects] DROP CONSTRAINT [FK_EqClasses_Effects_EquivalenceClass]
GO
/****** Object:  ForeignKey [FK_EquivalenceClass_Element]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[EquivalenceClass] DROP CONSTRAINT [FK_EquivalenceClass_Element]
GO
/****** Object:  ForeignKey [FK_ExpectedResult_Effect]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[ExpectedResult] DROP CONSTRAINT [FK_ExpectedResult_Effect]
GO
/****** Object:  ForeignKey [FK_Formula_Parameter_Formula]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[Formula_Parameter] DROP CONSTRAINT [FK_Formula_Parameter_Formula]
GO
/****** Object:  ForeignKey [FK_Parameter_Formula]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[Parameter] DROP CONSTRAINT [FK_Parameter_Formula]
GO
/****** Object:  ForeignKey [FK_Parameter_LinkElement]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[Parameter] DROP CONSTRAINT [FK_Parameter_LinkElement]
GO
/****** Object:  ForeignKey [FK_Parameter_Variable]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[Parameter] DROP CONSTRAINT [FK_Parameter_Variable]
GO
/****** Object:  ForeignKey [FK_Permission_UserLogin]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[Permission] DROP CONSTRAINT [FK_Permission_UserLogin]
GO
/****** Object:  ForeignKey [FK_Requirement_TestCasesStructure]    Script Date: 05/26/2008 18:37:30 ******/
ALTER TABLE [dbo].[Requirement] DROP CONSTRAINT [FK_Requirement_TestCasesStructure]
GO
/****** Object:  ForeignKey [FK_StdCombs_EqClasses_EquivalenceClass]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[StdCombs_EqClasses] DROP CONSTRAINT [FK_StdCombs_EqClasses_EquivalenceClass]
GO
/****** Object:  ForeignKey [FK_StdCombs_EqClasses_StdCombination]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[StdCombs_EqClasses] DROP CONSTRAINT [FK_StdCombs_EqClasses_StdCombination]
GO
/****** Object:  ForeignKey [FK_TDStructure_TestCase_TestCase]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TDStructure_TestCase] DROP CONSTRAINT [FK_TDStructure_TestCase_TestCase]
GO
/****** Object:  ForeignKey [FK_TestCase_StdCombination]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TestCase] DROP CONSTRAINT [FK_TestCase_StdCombination]
GO
/****** Object:  ForeignKey [FK_TestCase_TestCasesStructure]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TestCase] DROP CONSTRAINT [FK_TestCase_TestCasesStructure]
GO
/****** Object:  ForeignKey [FK_TestCases_Combs_Combination]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TestCases_Combs] DROP CONSTRAINT [FK_TestCases_Combs_Combination]
GO
/****** Object:  ForeignKey [FK_TestCases_Combs_TestCase]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TestCases_Combs] DROP CONSTRAINT [FK_TestCases_Combs_TestCase]
GO
/****** Object:  ForeignKey [FK_TestCases_EqClasses_EquivalenceClass]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TestCases_EqClasses] DROP CONSTRAINT [FK_TestCases_EqClasses_EquivalenceClass]
GO
/****** Object:  ForeignKey [FK_TestCases_EqClasses_TestCase]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TestCases_EqClasses] DROP CONSTRAINT [FK_TestCases_EqClasses_TestCase]
GO
/****** Object:  ForeignKey [FK_TestCasesStructure_TestObject]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TestCasesStructure] DROP CONSTRAINT [FK_TestCasesStructure_TestObject]
GO
/****** Object:  ForeignKey [FK_TestData_TestDataStructure]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TestData] DROP CONSTRAINT [FK_TestData_TestDataStructure]
GO
/****** Object:  ForeignKey [FK_TestDataStructure_TestObject]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TestDataStructure] DROP CONSTRAINT [FK_TestDataStructure_TestObject]
GO
/****** Object:  ForeignKey [FK_TypeData_TypeData]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TypeData] DROP CONSTRAINT [FK_TypeData_TypeData]
GO
/****** Object:  ForeignKey [FK_TypeDataValue_Format]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TypeDataValue] DROP CONSTRAINT [FK_TypeDataValue_Format]
GO
/****** Object:  ForeignKey [FK_TypeDataValue_Formula]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TypeDataValue] DROP CONSTRAINT [FK_TypeDataValue_Formula]
GO
/****** Object:  ForeignKey [FK_TypeDataValue_LinkElement]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TypeDataValue] DROP CONSTRAINT [FK_TypeDataValue_LinkElement]
GO
/****** Object:  ForeignKey [FK_TypeDataValue_Variable]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[TypeDataValue] DROP CONSTRAINT [FK_TypeDataValue_Variable]
GO
/****** Object:  ForeignKey [FK_Variable_TestDataStructure]    Script Date: 05/26/2008 18:37:31 ******/
ALTER TABLE [dbo].[Variable] DROP CONSTRAINT [FK_Variable_TestDataStructure]
GO
/****** Object:  Table [dbo].[State]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[State]
GO
/****** Object:  Table [dbo].[Effects_Reqs]    Script Date: 05/26/2008 18:37:29 ******/
DROP TABLE [dbo].[Effects_Reqs]
GO
/****** Object:  Table [dbo].[ExpectedResult]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[ExpectedResult]
GO
/****** Object:  Table [dbo].[EqClasses_Effects]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[EqClasses_Effects]
GO
/****** Object:  Table [dbo].[Combs_Effects]    Script Date: 05/26/2008 18:37:29 ******/
DROP TABLE [dbo].[Combs_Effects]
GO
/****** Object:  Table [dbo].[Formula_Parameter]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[Formula_Parameter]
GO
/****** Object:  Table [dbo].[TDStructure_TestCase]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[TDStructure_TestCase]
GO
/****** Object:  Table [dbo].[Deps_Elems]    Script Date: 05/26/2008 18:37:29 ******/
DROP TABLE [dbo].[Deps_Elems]
GO
/****** Object:  Table [dbo].[Combs_EqClasses]    Script Date: 05/26/2008 18:37:29 ******/
DROP TABLE [dbo].[Combs_EqClasses]
GO
/****** Object:  Table [dbo].[StdCombs_EqClasses]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[StdCombs_EqClasses]
GO
/****** Object:  Table [dbo].[TestCases_EqClasses]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[TestCases_EqClasses]
GO
/****** Object:  Table [dbo].[TestCases_Combs]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[TestCases_Combs]
GO
/****** Object:  Table [dbo].[TestData]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[TestData]
GO
/****** Object:  Table [dbo].[TypeData]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[TypeData]
GO
/****** Object:  Table [dbo].[Deps_EqClasses]    Script Date: 05/26/2008 18:37:29 ******/
DROP TABLE [dbo].[Deps_EqClasses]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[Permission]
GO
/****** Object:  Table [dbo].[Parameter]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[Parameter]
GO
/****** Object:  Table [dbo].[Formula]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[Formula]
GO
/****** Object:  Table [dbo].[TestCase]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[TestCase]
GO
/****** Object:  Table [dbo].[Requirement]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[Requirement]
GO
/****** Object:  Table [dbo].[Effect]    Script Date: 05/26/2008 18:37:29 ******/
DROP TABLE [dbo].[Effect]
GO
/****** Object:  Table [dbo].[EquivalenceClass]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[EquivalenceClass]
GO
/****** Object:  Table [dbo].[Combination]    Script Date: 05/26/2008 18:37:29 ******/
DROP TABLE [dbo].[Combination]
GO
/****** Object:  Table [dbo].[Element]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[Element]
GO
/****** Object:  Table [dbo].[Dependency]    Script Date: 05/26/2008 18:37:29 ******/
DROP TABLE [dbo].[Dependency]
GO
/****** Object:  Table [dbo].[StdCombination]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[StdCombination]
GO
/****** Object:  Table [dbo].[TestObject]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[TestObject]
GO
/****** Object:  Table [dbo].[TestCasesStructure]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[TestCasesStructure]
GO
/****** Object:  Table [dbo].[TestDataStructure]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[TestDataStructure]
GO
/****** Object:  Table [dbo].[TypeDataValue]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[TypeDataValue]
GO
/****** Object:  Table [dbo].[Variable]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[Variable]
GO
/****** Object:  Table [dbo].[LinkElement]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[LinkElement]
GO
/****** Object:  Table [dbo].[Format]    Script Date: 05/26/2008 18:37:30 ******/
DROP TABLE [dbo].[Format]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 05/26/2008 18:37:31 ******/
DROP TABLE [dbo].[UserLogin]
GO
