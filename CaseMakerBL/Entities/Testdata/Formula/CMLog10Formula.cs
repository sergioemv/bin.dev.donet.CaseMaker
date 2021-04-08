using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMLog10Formula : CMAbstractFormula
    {
        public CMLog10Formula()
        {
            FormulaEnum = Formulas.LOG_10;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            double param1 = (double) getCalculatedParameter(FormulaParameter.NUMBER);
            return Math.Log10(param1);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}