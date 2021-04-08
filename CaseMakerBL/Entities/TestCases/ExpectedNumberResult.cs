//Author Sergio Moreno
//Business Innovations
namespace CaseMaker.Entities.Testcases
{
    public class ExpectedNumberResult : ExpectedResult {
        private float numberValue;

        public ExpectedNumberResult()
        {
        }

        public ExpectedNumberResult(Effect effect, float value ):base(effect)
        {
            numberValue = value;
        }

        public virtual float NumberValue
        {
            get { return numberValue; }
            set { numberValue = value; }
        }
    }
}