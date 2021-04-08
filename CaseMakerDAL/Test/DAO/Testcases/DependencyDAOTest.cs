using System;
using System.Data;
using CaseMaker.DAO;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using NUnit.Framework;

namespace CaseMaker.Test.Testcases
{
    [TestFixture] 
    public class DependencyDAOTest
    {
       
        private TestObject to;

        [SetUp]
        protected void setUp()
        {
            //if (TestSetupClass.defaultTo == null)
                TestSetupClass.RunBeforeAnyTests();
            to = TestSetupClass.defaultTo;
             
        }

        [Test]
        [ExpectedException(typeof(DataException))]
        public void Validate()
        {
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            Dependency dep = new Dependency(to.TestCasesStruct);
            Dependency dep1 = new Dependency(to.TestCasesStruct);
            dep.Position = dep1.Position;
            try
            {
                dao.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                to.TestCasesStruct.RemoveDependency(dep);
                to.TestCasesStruct.RemoveDependency(dep1);
                dao.DeleteItem(dep);
                dao.DeleteItem(dep1);
            }
        }
        [Test]
        public void IElementsBean()
        {
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            Dependency dep = new Dependency(to.TestCasesStruct);
            Element element = new Element(to.TestCasesStruct);
            dep.AddElement(element);
            dao.Save();
            to.TestCasesStruct.RemoveDependency(dep);
            dao.DeleteItem(dep);
        }

        [Test]
        public void IEquivalenceClassesBean()
        {
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            Dependency dep = new Dependency(to.TestCasesStruct);
            Element element = new Element(to.TestCasesStruct);
            EquivalenceClass equivalenceClass = new EquivalenceClass(element);
            dep.AddElement(element);
            dep.AddEquivalenceClass(equivalenceClass);
            dao.Save();
            to.TestCasesStruct.RemoveDependency(dep);

            dao.DeleteItem(dep);
        }

        [Test]
        public void ICombinationsBean()
        {
            
            Dependency dep = new Dependency(to.TestCasesStruct);
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            Combination combination = new Combination(dep);
            dao.Save();
            dep.RemoveCombination(combination);
            dao.DeleteItem(combination);
        }
    }
}
