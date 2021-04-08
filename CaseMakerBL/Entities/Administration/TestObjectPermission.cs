namespace CaseMaker.Entities.Administration
{
    public class TestObjectPermission : Permission
    {
        private TestObject permittedTestObject;

        public TestObjectPermission()
        {
        }

        public TestObjectPermission(User user, TestObject permittedTestObject) : base(user)
        {
            permittedTestObject.AddPermission(this);
        }

        public virtual TestObject PermittedTestObject
        {
            get { return permittedTestObject; }
            set { permittedTestObject = value; }
        }

        #region IEquatable<Permission> Members

        public override bool Equals(Permission other)
        {
            if (!(other is TestObjectPermission)) return false;
            if (Id != 0) return Id.Equals(other.Id);

            return PermittedTestObject.Equals(((TestObjectPermission)other).PermittedTestObject);
        }

        #endregion

        #region IComparable<Permission> Members

        public override int CompareTo(Permission other)
        {
            if (!(other is TestObjectPermission)) return 0;
            if (Id != 0) return Id.CompareTo(other.Id);

            return PermittedTestObject.CompareTo(((TestObjectPermission)other).PermittedTestObject);
        }

        #endregion
    }
}