using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    internal class CMLogFormula : CMAbstractFormula
    {
        public CMLogFormula()
        {
            FormulaEnum = Formulas.LOG;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            double param1 = (double) getCalculatedParameter(FormulaParameter.NUMBER);
            double param2 = (double) getCalculatedParameter(FormulaParameter.BASE);
            return Math.Log(param1, param2);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}