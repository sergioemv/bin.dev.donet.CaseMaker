
using CaseMaker.DAO;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using NUnit.Framework;

namespace CaseMaker.Test.Testcases
{
    [TestFixture] 
    public class EffectDAOTest
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
        public void IRequirements()
        {

            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);  
            
            Effect effect = new Effect(to.TestCasesStruct);
            Requirement req = new Requirement(to.TestCasesStruct,"Effect requirement");
            effect.AddRequirement(req);
                  
            dao.Save();
            effect.RemoveRequirement(req);
            dao.Save();
        }
        [Test]
        public void IExpectedResults()
        {

            Effect effect = new Effect(to.TestCasesStruct);
            ExpectedResult res = new ExpectedStringResult(effect,"Testing string");
            
            ExpectedNumberResult res2 = new ExpectedNumberResult(effect,2000);

            DefaultDAO dao = new DefaultDAO(to.TestCasesStruct);
            dao.Save();
          }
       
    }
}
