
using System;
using System.Data;
using CaseMaker.DAO;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Testcases
{
    [TestFixture] 
    public class StdCombinationDAOTest
    {
       
        private TestObject to;

        [SetUp]
        protected void setUp()
        {
         //   if (TestSetupClass.defaultTo == null)
            TestSetupClass.RunBeforeAnyTests();
            to = TestSetupClass.defaultTo;

        }
        
        [Test]
        public void ITestCasesBean()
        {

            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);  
            
            StdCombination stdComb = new StdCombination(to.TestCasesStruct);
            TestCase tc = new TestCase(to.TestCasesStruct);
            
            stdComb.AddTestCase(tc);
                  
            dao.Save();
            stdComb.RemoveTestCase(tc);
            to.TestCasesStruct.RemoveStdCombination(stdComb);
            dao.DeleteItem(stdComb);
            to.TestCasesStruct.RemoveTestCase(tc);
            dao.DeleteItem(tc);
            dao.Save();
        }

        [Test]
        [ExpectedException(typeof(DataException))]
        public void Validate()
        {

            DefaultDAO elementDAO = new DefaultDAO(to.TestCasesStruct);
            StdCombination st1 = new StdCombination(to.TestCasesStruct);
            StdCombination st2 = new StdCombination(to.TestCasesStruct);
            
            st1.Position = st2.Position;
            try
            {
                elementDAO.Save();
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                to.TestCasesStruct.RemoveStdCombination(st1);
                to.TestCasesStruct.RemoveStdCombination(st2);
            }
        }
        [Test]
        public void IEquivalenceClassesBean()
        {

            StdCombination st = new StdCombination(to.TestCasesStruct);
            Element elem = new Element(to.TestCasesStruct);
            EquivalenceClass equi = new EquivalenceClass(elem);
            st.AddEquivalenceClass(equi);
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            dao.Save();
            st.RemoveEquivalenceClass(equi);
            elem.RemoveEquivalenceClass(equi);
            dao.DeleteItem(equi);
            to.TestCasesStruct.RemoveElement(elem);
            dao.DeleteItem(elem);
            to.TestCasesStruct.RemoveStdCombination(st);
            dao.DeleteItem(st);
          }
       
    }
}
