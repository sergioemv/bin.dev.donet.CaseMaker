using System;

namespace CaseMaker.Entities.Testdata
{
    internal class TypeDataGlobal : EntityWithEvents, ITypeData
    {
        private string field = "";
        private int id;
        private ICMValue icmvalue;
        private string global = "";
        private string key = "";
        private string lenght = "";
        private string name = "";
        private string prefix = "";
        private string sufix = "";
        private StructureTypeData structureTypeData;
        private ITestDataFormat iTestDataFormat;

        #region Miembros de ITypeData

        public virtual string Field
        {
            get { return field; }
            set { field = value; }
        }

        public string FormulaNomenclature
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public virtual string Global
        {
            get { return global; }
            set { global = value; }
        }

        public virtual string Key
        {
            get { return key; }
            set { key = value; }
        }

        public virtual string Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        public virtual string Sufix
        {
            get { return sufix; }
            set { sufix = value; }
        }

        public ICMValue Value
        {
            get
            {
                if (icmvalue == null)
                    icmvalue = new CMDefaultValue("");
                return icmvalue;
            }
            set { icmvalue = value; }
        }

        public bool isFormula
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool isLinkElement
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public virtual ICMValue ICMValue
        {
            get
            {
                if (icmvalue == null)
                    icmvalue = new CMDefaultValue("");
                return icmvalue;
            }
            set { icmvalue = value; }
        }

        public StructureTypeData StructureTypeData
        {
            get
            {
                if (structureTypeData == null)
                    structureTypeData = new StructureTypeData();
                return structureTypeData;
            }
            set { structureTypeData = value; }
        }

        public ITestDataFormat ITestDataFormat
        {
            get { return iTestDataFormat; }
            set { iTestDataFormat = value; }
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        #endregion

        #region Miembros de IEquatable<ITypeData>

        public bool Equals(ITypeData other)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Miembros de IComparable<ITypeData>

        public int CompareTo(ITypeData other)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}