using CaseMaker.DAO;
using CaseMaker.Entities;
using CaseMaker.Entities.Administration;
using CaseMaker.Test.Testcases;
using NUnit.Framework;

namespace CaseMaker.Test.DAO.Administration
{
    [TestFixture] 
    public class UserDAOTest
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
        public void Create()
        {
            User user = new User();
            user.Name = "Sergio Moreno";
            user.UserName = "smoreno";
            user.Password = "secreto";
            DefaultDAO dao = new DefaultDAO(user);
            dao.AddNew();
            user.Name = "Sergio Moreno Velez";
            dao.Save();
            dao.DeleteItem();            
        }

        [Test]
        public void CreatePermissions()
        {
            
            User user = new User();
            user.Name = "Sergio Moreno";
            user.UserName = "smoreno";
            user.Password = "secreto";
            DefaultDAO dao = new DefaultDAO(user);
            TestObjectPermission permi = new TestObjectPermission(user,to);
            TestCasesStructurePermission permi2 = new TestCasesStructurePermission(user, to.TestCasesStruct);
            dao.Save();
            user.RemovePermission(permi);
            user.RemovePermission(permi2);
            to.RemovePermission(permi);
            to.TestCasesStruct.RemovePermission(permi2);
            dao.Save();
            dao.DeleteItem();
            
        }

        
            
        

       
    }
}