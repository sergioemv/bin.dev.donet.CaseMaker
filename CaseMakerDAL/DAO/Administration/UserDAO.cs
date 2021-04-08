//Author : Sergio Moreno
// Business Innovations
// Sample DAO class inherited from DefaultDAO all methods should be specialiced querys on the internal object
using System.Collections.Generic;
using CaseMaker.Entities.Administration;
using NHibernate;
using NHibernate.Expression;

namespace CaseMaker.DAO.Administration
{
    public class UserDAO : DefaultDAO
    {
        private IList<User> userList;
        

        public UserDAO(object ob) : base(ob)
        {}

        public UserDAO()
        {
        }

        public IList<User> UserList
        {
            get
            {
                ISession session = SessionManager.CurrentSession;
                if (userList == null)
                {

                    IList<User> list = session.CreateCriteria(typeof(User)).List<User>();
                    SessionManager.CloseSession();
                    userList = list;
                }
                return userList;
            }
        }

      

        public override void Refresh()
        {
            userList = null;
        }
       
        

        public User GetUserByName(string s)
        {
            ISession session = SessionManager.CurrentSession;

            ICriteria crit = session.CreateCriteria(typeof (User));
            SimpleExpression exp1 = Expression.Eq("UserName", s);
            crit.Add(exp1);

            IList<User> list = crit.List<User>();
            if (list.Count >= 1)
                return list[0];
            else
                return null;
        }
    }
}