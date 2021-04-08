using System;
using System.Collections.Generic;

namespace CaseMaker.Entities
{
    public class ToolVendor : EntityWithEvents, IEquatable<ToolVendor>, IComparable<ToolVendor>
    {
        private int id;
        private string name;
        private IList<ToolType> toolTypes;

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public IList<ToolType> ToolTypes
        {
            get
            {
                if (toolTypes == null)
                    toolTypes = new List<ToolType>();
                return toolTypes;
            }
            set { toolTypes = value; }
        }

        #region IEquatable<ToolVendor> Members

        public bool Equals(ToolVendor other)
        {
           if (other==null) return false;
            return Id.Equals(other.Id);
        }

        #endregion

        #region IComparable<ToolVendor> Members

        public int CompareTo(ToolVendor other)
        {
            if (other == null) return -1;
            return Name.CompareTo(other.Name);
        }

        #endregion
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}