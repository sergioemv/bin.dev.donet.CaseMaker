using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMSecondFormula : CMAbstractFormula
    {
        public CMSecondFormula()
        {
            FormulaEnum = Formulas.SECOND;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            DateTime param1 = (DateTime) getCalculatedParameter(FormulaParameter.HOUR);
            return param1;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}