//Author Sergio Moreno
//Business Innovations
using System;
using Iesi.Collections.Generic;

namespace CaseMaker.Entities.Administration
{
    public class User : EntityWithEvents, IEquatable<User>, IComparable<User>
    {

        /// <summary>
        /// id property from the db
        /// </summary>
        private int id;
        /// <summary>
        /// userLocked name
        /// </summary>
        private string userName;
        /// <summary>
        /// password
        /// </summary>
        private string password;
        /// <summary>
        /// Real Name for the userLocked
        /// </summary>
        private string name;

        /// <summary>
        /// set of permissions over the business obejcts 
        /// </summary>
        private ISet<Permission> permissions;
        /// <summary>
        /// set of permissions over the application
        /// </summary>
        private ISet<ApplicationRole> applicationRoles;

        /// <summary>
        /// id property from the db
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// userLocked name
        /// </summary>
        public virtual string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// password
        /// </summary>
        public virtual string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Real Name for the userLocked
        /// </summary>
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

   
        /// <summary>
        /// if the login is active
        /// </summary>
        public virtual ISet<Permission> Permissions
        {
            get
            {
                if (permissions == null)
                    permissions = new HashedSet<Permission>();
                return permissions;
            }
            set { permissions = value; }
        }

        public virtual void  AddPermission(Permission perm)
        {
            if (Permissions.Contains(perm)) return;
            Permissions.Add(perm);
            perm.UserOwner = this;
            OnChanged(new CMEntitiesEventArgs("Permissions",null,perm));
        }

        public virtual void RemovePermission(Permission perm)
        {
            if (!Permissions.Contains(perm)) return;
            Permissions.Remove(perm);
            perm.UserOwner = null;
            OnChanged(new CMEntitiesEventArgs("Permissions", perm, null));
        }

        /// <summary>
        /// set of permissions over the application
        /// </summary>
        public virtual ISet<ApplicationRole> ApplicationRoles
        {
            get { return applicationRoles; }
            set { applicationRoles = value; }
        }

        #region IEquatable<User> Members

        public bool Equals(User other)
        {
            if (Id != 0) return Id.Equals(other.Id);
            return Name.Equals(other.Name);
        }

        #endregion

        #region IComparable<User> Members

        public int CompareTo(User other)
        {
            return Name.CompareTo(other.Name);
        }
        #endregion
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}