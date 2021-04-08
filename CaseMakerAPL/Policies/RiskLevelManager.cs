using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Policies
{
    internal class RiskLevelManager
    {
        private readonly IRiskLevelObject riskLevelObject;
        
        public RiskLevelManager(IRiskLevelObject riskLevelObject)
        {
            this.riskLevelObject = riskLevelObject;
        }

        public IUndoableEdit ChangeRiskLevel(int newRiskLevel)
        {
           CompoundEdit ce = new CompoundEdit();	
		//check if is posible to assign the new risk level
        if (riskLevelObject.GetParentRiskLevels()!=null)
		foreach (IRiskLevelObject parentRiskLevel in riskLevelObject.GetParentRiskLevels())
			if (newRiskLevel<parentRiskLevel.RiskLevel){
			    throw new Exception("The risk level cannot change, contains a greater risk level as a parent");
			}
            //change the risk level of each children
            if (riskLevelObject.GetChildrenRiskLevels()!=null)
                foreach (IRiskLevelObject o in riskLevelObject.GetChildrenRiskLevels())
                {
                    RiskLevelManager rlm = new RiskLevelManager(o);
                    ce.AddEdit(rlm.ChangeRiskLevel(newRiskLevel));
                }
			ce.AddEdit(EditFactory.instance.CreateChangeRiskLevelEdit(riskLevelObject, newRiskLevel));
			riskLevelObject.RiskLevel = newRiskLevel;	
		return ce;
        }

        public IUndoableEdit ApplyRiskLevelToChildren()
        {
            if (riskLevelObject == null) return null;
            CompoundEdit ce = new CompoundEdit();
            if (riskLevelObject.GetChildrenRiskLevels()==null) return ce;
            foreach (IRiskLevelObject o in riskLevelObject.GetChildrenRiskLevels())
            {
                if (o.RiskLevel<riskLevelObject.RiskLevel)
                {
                    
                    RiskLevelManager rlc = new RiskLevelManager(o);
                    ce.AddEdit(rlc.ChangeRiskLevel(riskLevelObject.RiskLevel));
                }
            }
            return ce;
        }
    }
}