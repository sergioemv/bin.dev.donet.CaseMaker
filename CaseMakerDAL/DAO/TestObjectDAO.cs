//Author : Sergio Moreno
// Business Innovations
// Sample DAO class inherited from DefaultDAO all methods should be specialiced querys on the internal object
using System.Collections.Generic;
using System.ComponentModel;
using CaseMaker.Entities;
using CaseMaker.Entities.Testcases;
using NHibernate;
using NHibernate.Expression;

namespace CaseMaker.DAO
{
    public class TestObjectDAO : DefaultDAO
    {
        private IList<TestObject> testObjectList;
        private BindingList<TestObject> testObjectBindingList;

        public TestObjectDAO(object ob) : base(ob)
        {}

        public TestObjectDAO()
        {
        }

        public IList<TestObject> TestObjectList
        {
            get
            {
                ISession session = SessionManager.CurrentSession;
                if (testObjectList == null)
                {

                    IList<TestObject> list = session.CreateCriteria(typeof(TestObject)).List<TestObject>();
                    SessionManager.CloseSession();
                    testObjectList = list;
                }
                return testObjectList;
            }
        }

        public BindingList<TestObject> TestObjectBindingList
        {
            get
            {
                if (testObjectBindingList == null)
                    testObjectBindingList = new BindingList<TestObject>(TestObjectList);
                return testObjectBindingList;
            }

        }

        public override void Refresh()
        {
            testObjectList = null;
            testObjectBindingList = null;
        }
       
        public void SaveAll(TestObject to)
        {
            Save(to);
            if (to.TestCasesStruct == null)
            {
                TestCasesStructure strc = new TestCasesStructure();
                to.TestCasesStruct = strc;
                AddNew(strc);
            }
            else
                Save(to.TestCasesStruct);
        }


        public TestObject GetTestObjectByName(string s)
        {
            ISession session = SessionManager.CurrentSession;

            ICriteria crit = session.CreateCriteria(typeof (TestObject));
            SimpleExpression exp1 = Expression.Eq("Name", s);
            crit.Add(exp1);

            IList<TestObject> list = crit.List<TestObject>();
            if (list.Count >= 1)
                return list[0];
            else
                return null;
        }
    }
}