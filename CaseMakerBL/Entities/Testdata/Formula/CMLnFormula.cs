using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMLnFormula : CMAbstractFormula
    {
        public CMLnFormula()
        {
            FormulaEnum = Formulas.LN;
        }


        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            double param1 = (double) getCalculatedParameter(FormulaParameter.NUMBER);
            return Math.Log(param1);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}