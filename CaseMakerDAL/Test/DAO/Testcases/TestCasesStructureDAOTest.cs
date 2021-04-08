using CaseMaker.DAO;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using NHibernate;
using NUnit.Framework;
using TestCase=CaseMaker.Entities.Testcases.TestCase;

namespace CaseMaker.Test.Testcases
{
    [TestFixture] 
    public class TestCasesStructureDAOTest
    {
        private DefaultDAO  dao;
        private TestObject to;
        private TestObjectDAO dao1;
        [SetUp]
        protected void setUp()
        {
            if (TestSetupClass.defaultTo == null)
                TestSetupClass.RunBeforeAnyTests();
            to = TestSetupClass.defaultTo;
            dao1 = new TestObjectDAO();
            dao = new DefaultDAO(to.TestCasesStruct);
         
        }
        [Test]
        public void IElementsBean()
        {
            Element elem = new Element(to.TestCasesStruct);
            
            dao.Save();
            

            to.TestCasesStruct.RemoveElement(elem);
            dao.DeleteItem(elem);
          
        }

    
        [Test]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public void IEffectsBean()
        {
            Effect effect = new Effect(to.TestCasesStruct);
            Effect effect2 = new Effect(to.TestCasesStruct);
            dao.Save();
            dao1.Refresh();
            to.TestCasesStruct.RemoveEffect(effect);
            dao.DeleteItem(effect);
            to.TestCasesStruct.RemoveEffect(effect2);
            dao.DeleteItem(effect2);
            Effect ef2 = dao.GetItem(effect.GetType(), effect.Id) as Effect;
            Assert.IsNull(ef2);
        }

    
        [Test]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public void IRequirementsBean()
        {
            Requirement req = new Requirement(to.TestCasesStruct,"Req 1");
            Requirement req2 = new Requirement(to.TestCasesStruct,"Req 2");
            Effect effect = new Effect(to.TestCasesStruct);
            effect.AddRequirement(req2);
            dao.Save();
            to.TestCasesStruct.RemoveRequirement(req);
            dao.DeleteItem(req);
            effect.RemoveRequirement(req2);
            to.TestCasesStruct.RemoveRequirement(req2);
            dao.DeleteItem(req2);
            dao.Save();
            Requirement req3 = dao.GetItem(req2.GetType(), req.Id) as Requirement;
            Assert.IsNull(req3);
            
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public void IDependencyBean()
        {
            Dependency dep = new Dependency(to.TestCasesStruct);
            Dependency dep2 = new Dependency (to.TestCasesStruct);
            dao.Save();
            to.TestCasesStruct.RemoveDependency(dep);
            dao.DeleteItem(dep);
            to.TestCasesStruct.RemoveDependency(dep2);
            dao.DeleteItem(dep2);
            Dependency req3 = dao.GetItem(dep2.GetType(), dep2.Id) as Dependency;
            Assert.IsNull(req3);

        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public void ITestCasesBean()
        {
            TestCase tc = new TestCase(to.TestCasesStruct);
            dao.Save();
            to.TestCasesStruct.RemoveTestCase(tc);
            dao.DeleteItem(tc);
            TestCase tc2 = dao.GetItem(tc.GetType(), tc.Id) as TestCase;
            Assert.IsNull(tc2);

        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public void IStdCombinationsBean()
        {
            StdCombination st = new StdCombination(to.TestCasesStruct);
            dao.Save();
            to.TestCasesStruct.RemoveStdCombination(st);
            dao.DeleteItem(st);
            StdCombination st2 = dao.GetItem(st.GetType(), st.Id) as StdCombination;
            Assert.IsNull(st2);

        }


    }
}
