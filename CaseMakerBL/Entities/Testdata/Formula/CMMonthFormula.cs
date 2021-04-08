using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMMonthFormula : CMAbstractFormula
    {
        public CMMonthFormula()
        {
            FormulaEnum = Formulas.MONTH;
        }

        public override string getFormattedValueResult()
        {
            throw new NotImplementedException();
        }

        public override object calculate()
        {
            return DateTime.Now;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}