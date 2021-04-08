//Author Sergio Moreno
//Business Innovations
namespace CaseMaker.Entities.Testcases
{
    public class ExpectedStringResult : ExpectedResult
    {

        private string stringValue;

        public ExpectedStringResult()
        {
        }

        public ExpectedStringResult(Effect effect, string value):base(effect)
        {
            stringValue = value;
        }


        public virtual string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
        
    }
}