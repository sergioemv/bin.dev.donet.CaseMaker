using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public interface IRiskLevelObject
    {
        int RiskLevel{ get; set;}
        ISet<IRiskLevelObject> GetParentRiskLevels();
        ISet<IRiskLevelObject> GetChildrenRiskLevels();

    }
}