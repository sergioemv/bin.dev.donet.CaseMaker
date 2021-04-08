using System;
using System.Collections.Generic;

namespace CaseMaker.Entities
{
    public class ToolType : EntityWithEvents, IComparable<ToolType>, IEquatable<ToolType>
    {
        private int id;
        private string name;
        private IList<ToolItem> toolItems;

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

        public virtual IList<ToolItem> ToolItems
        {
            get
            {
                if (toolItems == null)
                    toolItems = new List<ToolItem>();
                return toolItems;
            }
            set { toolItems = value; }
        }

        #region IEquatable<ToolType> Members

        public bool Equals(ToolType other)
        {
           if (other==null) return false;
            return Id.Equals(other.Id);
        }

        #endregion

        #region IComparable<ToolType> Members

        public int CompareTo(ToolType other)
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