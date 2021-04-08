using System;
using System.ComponentModel;
using System.Reflection;
using NHibernate.Classic;

namespace CaseMaker.Entities
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class CMEntitiesEventArgs:EventArgs
    {
        private string field;
        private object oldValue;
        private object newValue;
        public CMEntitiesEventArgs(string field, object oldValue, object newValue)
        {
            this.field = field;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public CMEntitiesEventArgs(string field)
        {
            this.field = field;
        }

        public string Field
        {
            get { return field; }
            set { field = value; }
        }

        public object OldValue
        {
            get { return oldValue; }
            set { oldValue = value; }
        }

        public object NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }
    }

    public abstract class EntityWithEvents : IValidatable

    {
        public virtual event ChangedEventHandler Changed;
        protected readonly Guid uniqueId = Guid.NewGuid();
        protected virtual void OnChanged(CMEntitiesEventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }
        public virtual Guid UniqueId
        {
            get { return uniqueId; }
        }
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] meminfo = type.GetMember(en.ToString());
            if (meminfo != null && meminfo.Length > 0)
            {
                object[] attr = meminfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attr != null && attr.Length > 0)
                    return ((DescriptionAttribute)attr[0]).Description;

            }
            return en.ToString();
        }

        #region IValidatable Members

        public virtual void Validate()
        {
            
        }

        #endregion
    }
}