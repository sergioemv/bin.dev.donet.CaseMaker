using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMDayWeekFormula : CMAbstractFormula
    {
        public CMDayWeekFormula()
        {
            FormulaEnum = Formulas.DAY_WEEK;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            DateTime param1 = (DateTime) getCalculatedParameter(FormulaParameter.DATE);
            return param1;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}