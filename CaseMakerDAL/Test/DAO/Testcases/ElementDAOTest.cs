using System;
using System.Data;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using CaseMaker.DAO;
using NHibernate;
using NUnit.Framework;

namespace CaseMaker.Test.Testcases
{
    [TestFixture] 
    public class ElementDAOTest
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
            
            Element element = new Element(to.TestCasesStruct);
            DefaultDAO elementDAO = new DefaultDAO(element);
            Element element1 = new Element(to.TestCasesStruct);
            element1.Name = element.Name;
            try
            {
                elementDAO.Save();
                elementDAO.Save(element1);
            }catch(Exception e)
            {
                throw e;
            }finally
            {
                to.TestCasesStruct.RemoveElement(element);
                to.TestCasesStruct.RemoveElement(element1);
            }
        }

        [Test]
        public void IEquivalenceClassesBean()
        {
           // SessionManager.ReuseSession = false;
            Element elem = new Element(to.TestCasesStruct);
            DefaultDAO dao = new DefaultDAO(elem);
           
            EquivalenceClass equivalenceClass = new EquivalenceClass(elem);
            dao.AddNew();
            Assert.IsNotNull(dao.GetItem(elem.GetType(),elem.Id));
            Assert.IsNotNull(dao.GetItem(equivalenceClass.GetType(), equivalenceClass.Id));
            Element elem2 = dao.GetItem(elem.GetType(), elem.Id) as Element;
            //dao.Activate(elem2,"EquivalenceClasses");
            SessionManager.CurrentSession.Lock(elem2, LockMode.Read);
#pragma warning disable PossibleNullReferenceException
            Assert.IsTrue(elem2.EquivalenceClasses.Contains(equivalenceClass));
#pragma warning restore PossibleNullReferenceException


            
        }

       
    }
}