using System;

namespace CaseMaker.Entities.Testdata
{
    internal class TypeDataLocal : EntityWithEvents, ITypeData
    {
        private ITypeData referencedTypeData;
        private StructureTypeData structureTypeData;
        private ICMValue icmValue;
        private ITestDataFormat iTestDataFormat;
        private int id;


        public virtual string Field
        {
            get { return ReferencedTypeData.Field; }
            set { throw new NotImplementedException(); }
        }

        public string FormulaNomenclature
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string Global
        {
            get { return ReferencedTypeData.Global; }
            set { throw new NotImplementedException(); }
        }

        public virtual string Key
        {
            get { return ReferencedTypeData.Key; }
            set { throw new NotImplementedException(); }
        }

        public virtual string Lenght
        {
            get { return ReferencedTypeData.Lenght; }
            set { throw new NotImplementedException(); }
        }

        public virtual string Name
        {
            get { return ReferencedTypeData.Name; }
            set { throw new NotImplementedException(); }
        }

        public virtual string Prefix
        {
            get { return ReferencedTypeData.Prefix; }
            set { throw new NotImplementedException(); }
        }

        public virtual string Sufix
        {
            get { return ReferencedTypeData.Sufix; }
            set { throw new NotImplementedException(); }
        }

        public bool isFormula
        {
            get { throw new NotImplementedException(); }
        }

        public bool isLinkElement
        {
            get { throw new NotImplementedException(); }
        }

        public virtual ICMValue ICMValue
        {
            get
            {
                if (icmValue == null)
                    icmValue = new CMDefaultValue("");
                return icmValue;
            }
            set { icmValue = value; }
        }

        public virtual StructureTypeData StructureTypeData
        {
            get
            {
                if (structureTypeData == null)
                    structureTypeData = new StructureTypeData();
                return structureTypeData;
            }
            set { structureTypeData = value; }
        }

        public virtual ITestDataFormat ITestDataFormat
        {
            get { return iTestDataFormat; }
            set { iTestDataFormat = value; }
        }

        public virtual ITypeData ReferencedTypeData
        {
            get { return referencedTypeData; }
            set { referencedTypeData = value; }
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool Equals(ITypeData other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(ITypeData other)
        {
            throw new NotImplementedException();
        }
    }
}