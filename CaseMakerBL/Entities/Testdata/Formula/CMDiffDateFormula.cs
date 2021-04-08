using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMDiffDateFormula : CMAbstractFormula
    {
        public CMDiffDateFormula()
        {
            FormulaEnum = Formulas.DIFF_DATE;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            DateTime param1 = (DateTime) getCalculatedParameter(FormulaParameter.DATE1);
            DateTime param2 = (DateTime) getCalculatedParameter(FormulaParameter.DATE2);
            TimeSpan result = param1 - param2;
            return result;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}