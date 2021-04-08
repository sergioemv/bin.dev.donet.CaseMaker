using System.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public interface IStdCombinationsBean
    {
        IList<StdCombination> StdCombinations { get; set; }
        void AddStdCombination(StdCombination stdCombination);
        void RemoveStdCombination(StdCombination stdCombination);
    }
}