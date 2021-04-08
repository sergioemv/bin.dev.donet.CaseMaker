using System;
using System.Data;
using CaseMaker.DAO;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using NUnit.Framework;

namespace CaseMaker.Test.Testcases
{
    [TestFixture] 
    public class CombinationDAOTest
    {
       
        private TestObject to;

        [SetUp]
        protected void setUp()
        {
//            if (TestSetupClass.defaultTo == null)
                TestSetupClass.RunBeforeAnyTests();
            to = TestSetupClass.defaultTo;
             
        }

        [Test]
        [ExpectedException(typeof(DataException))]
        public void Validate()
        {
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            Dependency dep = new Dependency(to.TestCasesStruct);
            Combination com1 = new Combination(dep);
            Combination com2 = new Combination(dep);
            com1.Position = com2.Position;
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
                dep.RemoveCombination(com1);
                dao.DeleteItem(com1);
                dep.RemoveCombination(com2);
                dao.DeleteItem(com2);
                to.TestCasesStruct.RemoveDependency(dep);
                
                dao.DeleteItem(dep);
                
            }
        }
        [Test]
        public void ICombinationsBean()
        {
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            Dependency dep = new Dependency(to.TestCasesStruct);
            Combination combi = new Combination(dep);
            Combination combi2  = new Combination(dep);
            combi.AddCombination(combi2);
            
            dao.Save();
            combi.RemoveCombination(combi2);
            dep.RemoveCombination(combi2);
            dao.DeleteItem(combi2);
            dep.RemoveCombination(combi);
            dao.DeleteItem(combi);
            to.TestCasesStruct.RemoveDependency(dep);
            dao.DeleteItem(dep);
                    }

        [Test]
        public void IEquivalenceClassBean()
        {
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            Dependency dep = new Dependency(to.TestCasesStruct);
            Combination combi = new Combination(dep);
            Element elem = new Element(to.TestCasesStruct);
            EquivalenceClass equiv = new EquivalenceClass(elem);
            combi.AddEquivalenceClass(equiv);
            dao.Save();
            
            dep.RemoveCombination(combi);
            dao.DeleteItem(combi);
            to.TestCasesStruct.RemoveDependency(dep);
            dao.DeleteItem(dep);
            elem.RemoveEquivalenceClass(equiv);
            dao.DeleteItem(equiv);
            to.TestCasesStruct.RemoveElement(elem);
            dao.DeleteItem(elem);
        }
        
        [Test]
        public void IEffectsBean()
        {
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            Dependency dep = new Dependency(to.TestCasesStruct);
            Combination combi = new Combination(dep);
            Effect effect = new Effect(to.TestCasesStruct);
            combi.AddEffect(effect);
            dao.Save();

            dep.RemoveCombination(combi);
            dao.DeleteItem(combi);
            to.TestCasesStruct.RemoveDependency(dep);
            dao.DeleteItem(dep);
            to.TestCasesStruct.RemoveEffect(effect);
            dao.DeleteItem(effect);
        }

       
    }
}
