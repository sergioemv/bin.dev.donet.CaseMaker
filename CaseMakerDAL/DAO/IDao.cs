using System;
using System.Collections;

namespace CaseMaker.DAO
{
    public interface IDao
    {
        void AddNew(object ob);
        void AddNew();
        void Save(object ob);
        void Save();
        void Save(IList items);
        void DeleteItem(object item);
        void DeleteItem();
        object GetItem(Type type, object id);
        void Activate(object obj,
                   params string[] propertyNames);

        /// <summary>
        ///   Refresh all local data
        /// </summary>
        void Refresh();

    }
}