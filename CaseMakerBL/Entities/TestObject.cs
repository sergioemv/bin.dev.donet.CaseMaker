using System;
using CaseMaker.Entities.Administration;
using CaseMaker.Entities.Testcases;
using CaseMaker.Entities.Testdata;
using Iesi.Collections.Generic;

namespace CaseMaker.Entities
{
    public class TestObject : EntityWithEvents, IAuditable, IEquatable<TestObject>, IComparable<TestObject> 
    {
        private const string DEFAULT_THOUSAND_SEP = ".";
        private const string DEFAULT_DECIMAL_SEP = ",";
        public const string CURRENT_VERSION="1.0";
        private string decimalSeparator;
        private bool defaultSeparator = true;
        private string description;
        private string thousandSeparator;
        private string name;
        private string preconditions;
        private DateTime creationDate;
        private DateTime modDate;
        private string version = CURRENT_VERSION;
        private int id;
        private TestCasesStructure testCasesStruct;
        private TestDataStructure testDataStruct;
        private ISet<TestObjectPermission> permissions;
        
        public TestObject()
        {
            testCasesStruct = new TestCasesStructure();
            testCasesStruct.ParentTestObject = this;
            testDataStruct = new TestDataStructure();
            testDataStruct.TestObject = this;
        }

        public TestObject(string s)
        {
            name = s;
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set
            {
                string oldvalue = name;
                name = value;
                OnChanged(new CMEntitiesEventArgs("Name", oldvalue, name));
            }
        }

        public virtual string Description
        {
            get { return description; }
            set
            {
                string oldvalue = description;
                description = value;
                OnChanged(new CMEntitiesEventArgs("Description",oldvalue,description));
            }
        }

        public virtual string Preconditions
        {
            get { return preconditions; }
            set
            {
                string oldvalue = preconditions;
                preconditions = value;
                OnChanged(new CMEntitiesEventArgs("Preconditions",oldvalue,preconditions));
            }
        }

        public virtual bool DefaultSeparator
        {
            get { return defaultSeparator; }
            set { defaultSeparator = value; }
        }

        public virtual string DecimalSeparator
        {
            get
            {
                if (DefaultSeparator)
                    return DEFAULT_DECIMAL_SEP;
                return decimalSeparator;
            }
            set
            {
                string oldvalue = decimalSeparator;
                decimalSeparator = value;
                OnChanged(new CMEntitiesEventArgs("DecimalSeparator",oldvalue,value));
            }
        }

        public virtual string ThousandSeparator
        {
            get
            {
                if (DefaultSeparator) 
                    return DEFAULT_THOUSAND_SEP;
                return thousandSeparator;
            }
            set
            {
                string oldvalue = thousandSeparator;
                thousandSeparator = value;
                OnChanged(new CMEntitiesEventArgs("ThousandSeparator",oldvalue,value));
            }
        }

        public virtual DateTime CreationDate
        {
            get
            {
                
                return creationDate;
            }
            set { creationDate = value; }
        }

        public virtual DateTime ModDate
        {
            get { return modDate; }
            set { modDate = value; }
        }

        public virtual string Version
        {
            get
            {
                if (version == null || version == "")
                    version = CURRENT_VERSION;
                return version;
            }
            set { version = value; }
        }

        public virtual TestCasesStructure TestCasesStruct
        {
            get
            {
                return testCasesStruct;
            }
            set
            {
                testCasesStruct = value;
                if (testCasesStruct != null)
                {
                    testCasesStruct.ParentTestObject = this;
                }
            }
        }

        public TestDataStructure TestDataStruct
        {
            get { return testDataStruct; }
            set
            {
                testDataStruct = value;
                if (testDataStruct != null)
                {
                    testDataStruct.TestObject = this;
                }
            }
        }

        public virtual ISet<TestObjectPermission> Permissions
        {
            get
            {
                if (permissions == null)
                    permissions = new HashedSet<TestObjectPermission>();
                return permissions;
            }
            set { permissions = value; }
        }

        public virtual void AddPermission(TestObjectPermission perm)
        {
            if (Permissions.Contains(perm)) return;
            Permissions.Add(perm);
            perm.PermittedTestObject = this;
            OnChanged(new CMEntitiesEventArgs("Permissions",null,perm));
        }

        public virtual void RemovePermission(TestObjectPermission perm)
        {
            if (!Permissions.Contains(perm)) return;
            Permissions.Remove(perm);
            perm.PermittedTestObject = null;
            //remove the permission from the user also
            OnChanged(new CMEntitiesEventArgs("Permissions", perm, null));
        }

        public bool Equals(TestObject other)
        {
            if (other==null) return false;
            return Id.Equals(other.Id);
        }

        public int CompareTo(TestObject other)
        {
            if (other == null) return -1;
            return Name.CompareTo(other.Name);
        }

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