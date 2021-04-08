using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMTodayFormula : CMAbstractFormula
    {
        public CMTodayFormula()
        {
            FormulaEnum = Formulas.TODAY;
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