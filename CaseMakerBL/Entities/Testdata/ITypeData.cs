using System;

namespace CaseMaker.Entities.Testdata
{
    public interface ITypeData : IEquatable<ITypeData>, IComparable<ITypeData>
    {
        string Field { get; set; }

        string FormulaNomenclature { get; }

        string Global { get; set; }

        string Key { get; set; }

        string Lenght { get; set; }

        string Name { get; set; }

        string Prefix { get; set; }

        string Sufix { get; set; }

        bool isFormula { get; }

        bool isLinkElement { get; }

        ICMValue ICMValue { get; set; }

        StructureTypeData StructureTypeData { get; set; }

        ITestDataFormat ITestDataFormat { get; set; }
    }
}