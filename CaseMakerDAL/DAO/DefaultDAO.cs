using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using CaseMaker.Localization;
using NHibernate;

namespace CaseMaker.DAO
{
    public class DefaultDAO : IDao
    {
        private object internalObject;
        public DefaultDAO(object ob)
        {
            //SessionManager.CurrentSession.Update(ob);
            internalObject = ob;
        }

        public DefaultDAO()
        {
        }

        public object InternalObject
        {
            get { return internalObject; }
            set { internalObject = value; }
        }


        public void SyncObject(object ob)
        {
            SessionManager.CurrentSession.Update(ob);
        }

        public void AddNew(object ob)
        {
            ITransaction trans = null;
            try
            {
                ISession session = SessionManager.CurrentSession;
                trans = session.BeginTransaction();
                session.Save(ob);
               // session.Flush();
                trans.Commit();
                Refresh();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                SessionManager.ForceCloseSession();
                throw new DataException(Resources.DefaultDao_AddNew_ErrorSaving, ex);
            }
            finally
            {
                SessionManager.CloseSession();
            }
            Refresh();
        }

        public void AddNew()
        {
            if (InternalObject==null) return;
            AddNew(InternalObject);
        }

        public virtual void Save(object ob)
        {
            ITransaction trans = null;
            try
            {
                ISession session = SessionManager.CurrentSession;
                trans = session.BeginTransaction();
                session.SaveOrUpdate(ob);
                //session.Flush();
                trans.Commit();
                Refresh();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                SessionManager.ForceCloseSession();
                throw new DataException(Resources.DefaultDao_AddNew_ErrorSaving, ex);
            }
            finally
            {
                SessionManager.CloseSession();
            }
            Refresh();
        }

        public void Save()
        {
            if (InternalObject==null) return;
            Save(internalObject);
        }


        public virtual void Save(IList items)
        {
            ISession session = SessionManager.CurrentSession;
            ITransaction trans = null;

            try
            {
                if (items == null)
                    throw new NullReferenceException("Items is null");

                trans = session.BeginTransaction();

                foreach (object item in items)
                {
                    session.SaveOrUpdate(item);
                    
                }
                //session.Flush();
                trans.Commit();
                Refresh();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                SessionManager.ForceCloseSession();
                throw new DataException(Resources.DefaultDao_AddNew_ErrorSaving, ex);
            }
            finally
            {
                SessionManager.CloseSession();
            }
        }
        public virtual object GetItem(Type type, object id)
        {
            ISession session = SessionManager.CurrentSession;
            try
            {
                return session.Load(type, id);
            }
            catch (Exception ex)
            {
                SessionManager.ForceCloseSession();
                throw new DataException("Error getting item", ex);
            }
            finally
            {
                SessionManager.CloseSession();
            }
        }

        #region IDao Members

        public void Activate(object obj, params string[] propertyNames)
        {
            ISession session = SessionManager.CurrentSession;
             try
             {
             if (!session.IsConnected )
                session.Reconnect();
                 session.Lock(obj, LockMode.UpgradeNoWait);
                ActivateProperties(obj, propertyNames);
            }
            catch (Exception ex)
           {
                throw new Exception("Activation Failed!", ex);
            }
            finally
            {
                session.Disconnect();
            }
        }

        #endregion
        private static void ActivateProperties(object obj, IEnumerable<string> propertyNames)
        {
            foreach (string propName in propertyNames)
                ActivateProperty(obj, propName);
        }
        private static void ActivateProperty(object obj,
                               string propName)
        {
            if (!propName.Contains("."))
                GetActivatedValue(obj, propName);
            else
            {
                string[] chain = propName.Split('.');
                object value = GetActivatedValue(obj, chain[0]);
                ActivateProperty(value,
                      propName.Substring(propName.IndexOf('.') + 1));
            }
        }
        private static object GetActivatedValue(object obj,
                                  string propName)
        {
            PropertyInfo property = obj.GetType().GetProperty(propName);
            object value = property.GetValue(obj, null);
            string activate = value.ToString();
            return value;
        }
        public virtual void DeleteItem(object item)
        {
            ITransaction trans = null;
            ISession session = SessionManager.CurrentSession;

            try
            {
                trans = session.BeginTransaction();

                session.Delete(item);
                //session.Flush();
                trans.Commit();
                Refresh();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                SessionManager.ForceCloseSession();
                throw new DataException("Error deleting item", ex);
            }
            finally
            {
                
                SessionManager.CloseSession();
            }
        }

        

        public void DeleteItem()
        {
            if (InternalObject==null) return;
            DeleteItem(InternalObject);
        }

        

        public virtual void Refresh()
        {
        }

       


        
    }
}