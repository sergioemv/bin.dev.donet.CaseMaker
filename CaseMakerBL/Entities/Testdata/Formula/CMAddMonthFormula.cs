using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMAddMonthFormula : CMAbstractFormula
    {
        public CMAddMonthFormula()

        {
            FormulaEnum = Formulas.ADD_MONTH;
        }


        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            DateTime param1 = (DateTime) getCalculatedParameter(FormulaParameter.DATE);
            int param2 = (int) getCalculatedParameter(FormulaParameter.MONTH);
            param1.AddMonths(param2);
            return param1;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}