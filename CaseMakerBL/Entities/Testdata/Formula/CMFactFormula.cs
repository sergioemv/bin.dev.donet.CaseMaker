using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMFactFormula : CMAbstractFormula
    {
        public CMFactFormula()
        {
            FormulaEnum = Formulas.FACT;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            double param1 = (double) getCalculatedParameter(FormulaParameter.NUMBER);
            long contador = 1;
            if (param1 > 0)
            {
                int i = 0;
                for (i = 2; i <= param1; i++)
                {
                    contador = Math.Abs(contador*i);
                }
            }
            return contador;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}