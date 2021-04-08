using System;
using System.Collections.Generic;

namespace CaseMaker.Entities.Testdata
{
    public class StructureTypeData : IEquatable<StructureTypeData>, IComparable<StructureTypeData>
    {
        private string description = null;
        private int globalIndex;
        private int id;
        private string name = null;
        private string type = null;
        private IList<ITypeData> typeDatas;
        private TestDataStructure testDataStructure;
        private TestData testData;


        public virtual string Type
        {
            get { return type; }
            set { type = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }


        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual int GlobalIndex
        {
            get { return globalIndex; }
            set { globalIndex = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual IList<ITypeData> TypeDatas
        {
            get { return typeDatas; }
            set { typeDatas = value; }
        }

        public virtual TestDataStructure TestDataStructure
        {
            get { return testDataStructure; }
            set { testDataStructure = value; }
        }

        public virtual TestData TestData
        {
            get { return testData; }
            set { testData = value; }
        }

        public bool Equals(StructureTypeData other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(StructureTypeData other)
        {
            throw new NotImplementedException();
        }
    }
}