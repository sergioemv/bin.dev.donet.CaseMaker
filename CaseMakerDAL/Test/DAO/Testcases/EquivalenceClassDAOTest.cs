using System;
using System.Data;
using CaseMaker.DAO;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using NUnit.Framework;

namespace CaseMaker.Test.Testcases
{
    [TestFixture] 
    public class EquivalenceClassDAOTest
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
        public void CheckConstraints()
        {
            
            Element element = new Element(to.TestCasesStruct);
            DefaultDAO elementDAO = new DefaultDAO(element);
            EquivalenceClass eq1  = new EquivalenceClass(element);
            EquivalenceClass eq2 = new EquivalenceClass(element);
            //this must throw an exception in the save (same position two equivalence classes)
            eq2.Position = eq1.Position;
            try
            {
                elementDAO.Save();
            }catch(Exception e)
            {
                throw e;
            }finally
            {
                element.RemoveEquivalenceClass(eq1);
                element.RemoveEquivalenceClass(eq2);
                to.TestCasesStruct.RemoveElement(element);
            }
        }

        [Test]
        public void IEffectsBean()
        {

            Element elem = new Element(to.TestCasesStruct);
            EquivalenceClass equivalenceClass = new EquivalenceClass(elem);
            Effect effect = new Effect(to.TestCasesStruct);
            equivalenceClass.AddEffect(effect);
            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            dao.Save();
            Assert.IsNotNull(dao.GetItem(elem.GetType(),elem.Id));
            Assert.IsNotNull(dao.GetItem(equivalenceClass.GetType(), equivalenceClass.Id));
            Assert.IsNotNull(dao.GetItem(effect.GetType(), effect.Id));
            EquivalenceClass eq2 = dao.GetItem(equivalenceClass.GetType(), equivalenceClass.Id) as EquivalenceClass;
#pragma warning disable PossibleNullReferenceException
            Assert.IsTrue(eq2.Effects.Contains(effect));
#pragma warning restore PossibleNullReferenceException
            
        }

       
    }
}
