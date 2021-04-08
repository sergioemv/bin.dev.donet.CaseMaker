using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMAbsFormula : CMAbstractFormula
    {
        public CMAbsFormula()
        {
            FormulaEnum = Formulas.ABS;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            decimal param1 = (decimal) getCalculatedParameter(FormulaParameter.NUMBER);
            return Math.Abs(param1);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}