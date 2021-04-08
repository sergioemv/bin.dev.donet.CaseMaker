using System;
using System.Data;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using CaseMaker.DAO;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Testcases
{
    [TestFixture] 
    public class TestCaseDAOTest
    {
       
        private TestObject to;

        [SetUp]
        protected void setUp()
        {
            if (TestSetupClass.defaultTo == null)
                TestSetupClass.RunBeforeAnyTests();
            to = TestSetupClass.defaultTo;
             
        }
        [Test]
        [ExpectedException(typeof(DataException))]
        public void Validate()
        {
            
            TestCase testcase = new TestCase(to.TestCasesStruct);
            TestCase testcase1 = new TestCase(to.TestCasesStruct); 
            DefaultDAO elementDAO = new DefaultDAO(to.TestCasesStruct);
            testcase.Position = testcase1.Position;
            try
            {
                elementDAO.Save();
                
            }catch(Exception e)
            {
                throw e;
            }finally
            {
                to.TestCasesStruct.RemoveTestCase(testcase1);
                to.TestCasesStruct.RemoveTestCase(testcase);
            }
        }

        [Test]
        public void IEquivalenceClassesBean()
        {

            TestCase tc = new TestCase(to.TestCasesStruct);
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
           Element elem = new Element(to.TestCasesStruct);
            EquivalenceClass equivalenceClass = new EquivalenceClass(elem);
            tc.AddEquivalenceClass(equivalenceClass);
            dao.Save();
            Assert.IsNotNull(dao.GetItem(tc.GetType(), tc.Id));
            Assert.IsNotNull(dao.GetItem(equivalenceClass.GetType(), equivalenceClass.Id));
            tc.RemoveEquivalenceClass(equivalenceClass);
            elem.RemoveEquivalenceClass(equivalenceClass);
            dao.DeleteItem(equivalenceClass);
            to.TestCasesStruct.RemoveTestCase(tc);
            dao.DeleteItem(tc);
            to.TestCasesStruct.RemoveElement(elem);
            dao.DeleteItem(elem);
        }

        [Test]
        public void ICombinationsBean()
        {

            TestCase tc = new TestCase(to.TestCasesStruct);
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            Dependency dep = new Dependency(to.TestCasesStruct);
            Combination comb = new Combination(dep);

            tc.AddCombination(comb);
            dao.Save();
            Assert.IsNotNull(dao.GetItem(tc.GetType(), tc.Id));
            Assert.IsNotNull(dao.GetItem(comb.GetType(), comb.Id));
            tc.RemoveCombination(comb);
            dep.RemoveCombination(comb);
            dao.DeleteItem(comb);
            to.TestCasesStruct.RemoveTestCase(tc);
            dao.DeleteItem(tc);
            to.TestCasesStruct.RemoveDependency(dep);
            dao.DeleteItem(dep);
        }
       
    }
}