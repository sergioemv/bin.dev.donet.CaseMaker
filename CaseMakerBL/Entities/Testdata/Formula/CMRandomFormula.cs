using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMRandomFormula : CMAbstractFormula
    {
        public CMRandomFormula()
        {
            FormulaEnum = Formulas.RANDOM;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            Random random = new Random();
            return random.NextDouble();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}