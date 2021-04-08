using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMPowFormula : CMAbstractFormula
    {
        public CMPowFormula()
        {
            FormulaEnum = Formulas.POW;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            double param1 = (double) getCalculatedParameter(FormulaParameter.NUMBER);
            double param2 = (double) getCalculatedParameter(FormulaParameter.POWER);
            return Math.Pow(param1, param2);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}