using System;
using System.Collections.Generic;
using System.Text;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Entities.Administration
{
    public class TestCasesStructurePermission : Permission
    {
        private TestCasesStructure structure;

        public TestCasesStructurePermission()
        {
        }

        public TestCasesStructurePermission(User user, TestCasesStructure structure) : base(user)
        {
           structure.AddPermission(this);
        }

        public virtual TestCasesStructure Structure
        {
            get { return structure; }
            set { structure = value; }
        }

        #region IEquatable<Permission> Members

        public override bool Equals(Permission other)
        {
            if  (!(other is TestCasesStructurePermission)) return false;
            if (Id != 0) return Id.Equals(other.Id);
            
                return Structure.Equals(((TestCasesStructurePermission) other).Structure);
        }

        #endregion

        #region IComparable<Permission> Members

        public  override int CompareTo(Permission other)
        {
            if (!(other is TestCasesStructurePermission)) return 0;
            if (Id != 0) return Id.CompareTo(other.Id);

            return Structure.CompareTo(((TestCasesStructurePermission)other).Structure);
        }

        #endregion
    }
}