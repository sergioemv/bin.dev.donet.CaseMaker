using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    internal class CMDifferenceFormula : CMAbstractFormula
    {
        public CMDifferenceFormula()
        {
            FormulaEnum = Formulas.DIFFERENCE;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            decimal param1 = (decimal) getCalculatedParameter(FormulaParameter.NUMBERX);
            decimal param2 = (decimal) getCalculatedParameter(FormulaParameter.NUMBERY);
            return param1 - param2;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}