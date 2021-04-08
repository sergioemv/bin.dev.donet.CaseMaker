using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMMaxFormula : CMAbstractFormula
    {
        public CMMaxFormula()
        {
            FormulaEnum = Formulas.MAX;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            double param1 = (double) getCalculatedParameter(FormulaParameter.NUMBERX);
            double param2 = (double) getCalculatedParameter(FormulaParameter.NUMBERY);
            return Math.Max(param1, param2);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}