using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    internal class CMDivFormula : CMAbstractFormula
    {
        public CMDivFormula()
        {
            FormulaEnum = Formulas.DIV;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            decimal param1 = (decimal) getCalculatedParameter(FormulaParameter.NUMBERY);
            decimal param2 = (decimal) getCalculatedParameter(FormulaParameter.NUMBERX);
            return (param1/param2);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}