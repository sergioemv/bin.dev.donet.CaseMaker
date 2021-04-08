using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMExpFormula : CMAbstractFormula
    {
        public CMExpFormula()
        {
            FormulaEnum = Formulas.EXP;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            double param1 = (double) getCalculatedParameter(FormulaParameter.NUMBER);
            return Math.Exp(param1);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}