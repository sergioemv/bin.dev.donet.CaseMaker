using System;

namespace CaseMaker.Entities.Administration
{
    public abstract class Permission : EntityWithEvents, IEquatable<Permission>, IComparable<Permission>
    {
        /// <summary>
        /// id for the database
        /// </summary>
        private int id;
        /// <summary>
        /// type of permission 
        /// </summary>
        private PermissionNature nature;
        /// <summary>
        /// user owner
        /// </summary>
        private User userOwner;
        /// <summary>
        /// id for the database
        /// </summary>
        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Permission()
        {
        }

        public Permission(User user)
        {
             user.AddPermission(this);

        }

        /// <summary>
        /// type of permission 
        /// </summary>
        public virtual PermissionNature Nature
        {
            get { return nature; }
            set { nature = value; }
        }

        /// <summary>
        /// user owner
        /// </summary>
        public virtual User UserOwner
        {
            get { return userOwner; }
            set { userOwner = value; }
        }

        #region IEquatable<Permission> Members

        public abstract bool Equals(Permission other);

        #endregion

        #region IComparable<Permission> Members

        public abstract int CompareTo(Permission other);
        
        #endregion
    }
}