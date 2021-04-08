using CaseMaker.DAO;
using CaseMaker.Entities;
using NUnit.Framework;

namespace CaseMaker.Test.DAO
{
    [TestFixture] 
    public class TestObjectDAOTest
    {
        private TestObjectDAO dao;
        [SetUp]
        protected void setUp()
        {
            dao = new TestObjectDAO();
        }


        [Test]
        public void TestObjectList()
        {
           
            TestObject to = new TestObject();
            to.Name = "Test Obejct 1";
            to.Description = "First Test Object";
            dao.Save(to);
            Assert.IsNotNull(dao.TestObjectList);
            Assert.Greater(dao.TestObjectList.Count,0);
            dao.DeleteItem(to);
            Assert.IsNotNull(dao.TestObjectList);
            Assert.IsFalse(dao.TestObjectList.Contains(to));
            TestObject to2 = new TestObject();
            to2.Name = "Test Obejct 2";
            to2.Description = "Second Test Object";
            dao.AddNew(to);
            dao.Save(to2);
            Assert.GreaterOrEqual(dao.TestObjectList.Count, 2);
            to2.Description = "This is a New description";
            dao.Save(to2);
            Assert.IsTrue(dao.TestObjectList[dao.TestObjectList.IndexOf(to2)].Description.Equals("This is a New description"));
        }

    }
}