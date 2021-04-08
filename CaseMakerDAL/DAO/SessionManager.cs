using System;
using CaseMaker.Entities;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Type;

namespace CaseMaker.DAO
{
    class SessionManager
    {
        private static ISessionFactory sessionFactory ;
        private static ISession session;
        private static bool reuseSession = true;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory==null)
                {
                    Configuration cfg;
                    cfg = new Configuration();
                    cfg.Configure("hibernate.cfg.xml");
                    cfg.AddAssembly("CaseMakerDAL");
                    cfg.AddAssembly("CaseMakerBL");
                    sessionFactory = cfg.BuildSessionFactory();
                }
                return sessionFactory;
            }
        }

        public static ISession CurrentSession
        {
            get
            {
                if (session == null)
                    session = SessionFactory.OpenSession(new DefaultInterceptor());
                if (!session.IsConnected)
                    session.Reconnect();
                return session;
            }
            set { session = value; }
        }

        public static bool ReuseSession
        {
            get { return reuseSession; }
            set { reuseSession = value; }
        }

        public static void CloseSession()
        {
            if (session!=null)
            {
               // CurrentSession.Disconnect();
                if (!ReuseSession)
                {
                    CurrentSession.Close();
                 
                    session = null;
                }
            }
        }

        public static void ForceCloseSession()
        {
            if (session != null)
            {
                CurrentSession.Close();
                 session = null;
            }
        }
    }

    internal class DefaultInterceptor : EmptyInterceptor
    {
        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            bool modified=false;
            if (entity is IAuditable)
            {
                int index = 0;
                foreach (IType type in types)
                {
                    //esto corresponde a una fecha no inicializada
                    if (type.ReturnedClass == typeof (DateTime) &&
                        DateTime.MinValue.Equals(state[index]))
                    {
                        state[index] = null;
                    }
                    index++;
                }
                for (int i = 0; i < propertyNames.Length; i++)
                {
                    if ("CreationDate" == propertyNames[i])
                    {
                        state[i] = DateTime.Now;
                        modified = true;
                    }
                    if ("ModDate" == propertyNames[i])
                    {
                        state[i] = DateTime.Now;
                        modified = true;
                    }
                }
            }
            return modified;
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            if (entity is IAuditable)
            {
                for (int i = 0; i < propertyNames.Length; i++)
                {
                    if ("ModDate" == propertyNames[i])
                    {
                        currentState[i] = DateTime.Now;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}