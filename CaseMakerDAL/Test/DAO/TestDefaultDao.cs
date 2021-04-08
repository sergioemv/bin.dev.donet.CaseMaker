using System.Collections.Generic;
using CaseMaker.DAO;
using CaseMaker.Entities.Testcases;
using NUnit.Framework;
using CaseMaker.Entities;

namespace CaseMaker.Test.DAO
{
    [TestFixture]
    public class TestDefaultDao
    {

        TestObject to;


        [SetUp]
        protected void setUp()
        {
            TestObjectDAO dao1 = new TestObjectDAO();
            to = dao1.GetTestObjectByName("Testing TestCases");
            if (to == null)
            {
                to = new TestObject("Testing TestCases");
                dao1.SaveAll(to);
            }
            dao1.SyncObject(to.TestCasesStruct);
            while (to.TestCasesStruct.Elements.Count < 2)
            {
                Element element1 = new Element(to.TestCasesStruct);
                
            }

            foreach (Element element in to.TestCasesStruct.Elements)
            {
                element.AddEquivalenceClass(new EquivalenceClass(element));
            }
            dao1.SaveAll(to);
        }

        [Test]
        public void DeleteItemTest()
        {
            DefaultDAO _dao = new DefaultDAO(to.TestCasesStruct);

            //force equi class to load
            IList<EquivalenceClass> myAuxlist= new List<EquivalenceClass>();
            
            //two objects extracted from the database.
            Element element1 = to.TestCasesStruct.Elements[0];
            Element element2 = to.TestCasesStruct.Elements[1];

            for (int h = 0; h < element1.EquivalenceClasses.Count;h++ )
            {
                EquivalenceClass eq = element1.EquivalenceClasses[h];
                myAuxlist.Add(eq);
                
                element1.RemoveEquivalenceClass(eq);
                h--;
            }

            for (int h = 0; h < element2.EquivalenceClasses.Count; h++)
            {
                EquivalenceClass eq = element2.EquivalenceClasses[h];
                myAuxlist.Add(eq);
                element2.RemoveEquivalenceClass(eq);
                h--;
            }
            to.TestCasesStruct.RemoveElement(element1);
            to.TestCasesStruct.RemoveElement(element2);

            _dao.Save(to);

          
        }




    }
}