using System.ComponentModel;

namespace CaseMaker.Entities.Testdata
{
    public enum FormulaCategory
    {
        [Description("Date and Time")] DATE_AND_TIME = 1,
        [Description("Mathematic")] MATHEMATICS,
        [Description("Trigonometry")] TRIGONOMETRY,
        [Description("Text")] TEXT,
        [Description("Constant")] CONSTANT
    }

    public class CMFormulaCategory
    {
        private string name;

        public CMFormulaCategory(FormulaCategory p_formulaCategory)
        {
            name = p_formulaCategory.ToString();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}