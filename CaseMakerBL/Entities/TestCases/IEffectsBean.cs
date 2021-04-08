using System.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public interface IEffectsBean
    {
        IList<Effect> Effects { get; set; }
        void AddEffect(Effect effect);
        void RemoveEffect(Effect effect);
    }
}