namespace CaseMaker.Entities.Testdata
{
    internal interface ICMParameter : ICMFormula
    {
        FormulaParameter ParameterType { get; set; }

        ICMValue Result { get; set; }
    }
}