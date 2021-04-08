using System.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public interface ICombinationsBean
    {
        IList<Combination> Combinations { get; set; }
        void AddCombination(Combination combination);
        void RemoveCombination(Combination combination);
    }
}