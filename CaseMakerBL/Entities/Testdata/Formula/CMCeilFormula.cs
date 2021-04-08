using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    internal class CMCeilFormula : CMAbstractFormula
    {
        public CMCeilFormula()
        {
            FormulaEnum = Formulas.CEIL;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            decimal param1 = (decimal) getCalculatedParameter(FormulaParameter.NUMBER);
            int param2 = (int) getCalculatedParameter(FormulaParameter.DECIMAL);
            decimal result = Decimal.Round(param1, param2);
            if (result != param1)
            {
                result = Decimal.Round(param1 + (decimal) 0.0005, param2);
            }
            return result;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}