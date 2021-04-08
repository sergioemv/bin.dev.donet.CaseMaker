using System.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public interface IRequirementsBean
    {
        IList<Requirement> Requirements { get; set; }
        void AddRequirement(Requirement req);
        void RemoveRequirement(Requirement req);
    }
}