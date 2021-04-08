using System;

namespace CaseMaker.Entities.Testdata.Formula
{
    public class CMHourFormula : CMAbstractFormula
    {
        public CMHourFormula()
        {
            FormulaEnum = Formulas.HOUR;
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