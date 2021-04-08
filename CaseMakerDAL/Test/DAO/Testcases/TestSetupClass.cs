//Author Sergio Moreno
//Business Innovations
using CaseMaker.DAO;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using NUnit.Framework;

namespace CaseMaker.Test.Testcases
{
    [SetUpFixture]
    public class TestSetupClass
    {
        public static TestObject defaultTo;
        [SetUp]
        public static void RunBeforeAnyTests()
	    {
            TestObjectDAO dao1 = new TestObjectDAO();
            defaultTo = dao1.GetTestObjectByName("Testing TestCases");
            if (defaultTo == null)
            {
                defaultTo = new TestObject("Testing TestCases");
                dao1.SaveAll(defaultTo);

            }
            if (defaultTo.TestCasesStruct == null)
            {
                defaultTo.TestCasesStruct = new TestCasesStructure();
                dao1.SaveAll(defaultTo);
            }
            dao1.SyncObject(defaultTo.TestCasesStruct);
	    }
    }
}