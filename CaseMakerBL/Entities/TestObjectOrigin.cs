using System;

namespace CaseMaker.Entities
{
    public class TestObjectOrigin : EntityWithEvents, IEquatable<TestObjectOrigin>, IComparable<TestObjectOrigin>
    {
        private string importFilePath;
        private TestObject testObject;

        public TestObjectOrigin(TestObject testObject)
        {
            this.testObject = testObject;
        }

        public virtual string ImportFilePath
        {
            get { return importFilePath; }
            set { importFilePath = value; }
        }

        public virtual TestObject TestObject
        {
            get { return testObject; }
            set { testObject = value; }
        }

        #region IEquatable<TestObjectOrigin> Members

        public bool Equals(TestObjectOrigin other)
        {
            return this.ImportFilePath.Equals(other.ImportFilePath);
        }

        #endregion

        #region IComparable<TestObjectOrigin> Members

        public int CompareTo(TestObjectOrigin other)
        {
            return TestObject.CompareTo(other.TestObject);
        }

        #endregion
    }
}