using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMAddYearFormula : CMAbstractFormula
    {
        public CMAddYearFormula()
        {
            FormulaEnum = Formulas.ADD_YEAR;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            DateTime param1 = (DateTime) getCalculatedParameter(FormulaParameter.DATE);
            int param2 = (int) getCalculatedParameter(FormulaParameter.YEAR);
            param1.AddYears(param2);
            return param1;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}