using System;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;

namespace CaseMaker.Policies
{
    internal class StateObjectManager
    {
        private readonly IStateObject stateObject;

        public StateObjectManager(IStateObject stateObject)
        {
            this.stateObject = stateObject;
        }

        public IUndoableEdit ChangeState( State newState) {
		CompoundEdit ce = new CompoundEdit();
		if ((stateObject==null))
			return ce;
		//check if the new state can apply to the statebean
		
		if (stateObject.GetParentObjectStates()!=null)
		foreach (IStateObject parentStateObject in stateObject.GetParentObjectStates())
			if (CompareState(parentStateObject.CurrentState, newState)<0){
		        throw new Exception("The state cannot change, contains a greater state as a parent");
			}
            if (stateObject.GetChildrenObjectStates() == null) return ce;
            foreach (IStateObject o in stateObject.GetChildrenObjectStates())
            {
                if (o is Combination && stateObject is EquivalenceClass && newState != State.POSITIVE)
                {
                    ce.AddEdit(PropagateStateChangeInCombination((Combination) o, (EquivalenceClass) stateObject));
                }
                else
                {
                    StateObjectManager rlc = new StateObjectManager(o);
                    ce.AddEdit(rlc.ChangeState(newState));
                }
            }
            ce.AddEdit(EditFactory.instance.CreateChangeStateEdit(stateObject, newState));
            stateObject.CurrentState = newState;

		return ce;
	}

        private static int CompareState(State state, State newState)
        {
            if (state==newState)
			return 0;
    		if (state<newState)
	    		return 1;
		    if (state>newState)
			    return -1;
            return 0;
        }

        public IUndoableEdit ApplyStateToChildren()
        {
            if (stateObject == null) return null;
            CompoundEdit ce = new CompoundEdit();
            if (stateObject.GetChildrenObjectStates()==null) return ce;
            foreach (IStateObject o in stateObject.GetChildrenObjectStates())
            { 
                    StateObjectManager rlc = new StateObjectManager(o);
                    ce.AddEdit(rlc.ChangeState(stateObject.CurrentState));                
            }
            return ce;
        }

        private static IUndoableEdit PropagateStateChangeInCombination(Combination target, EquivalenceClass parentEquivalenceClass) {
		CompoundEdit ce = new CompoundEdit();
				
			if (target.ParentDependency != null){
			    ce.AddEdit(EditFactory.instance.CreateRemoveEquivalenceClassEdit(target.ParentDependency, parentEquivalenceClass));
                target.ParentDependency.RemoveEquivalenceClass(parentEquivalenceClass);                
                CombinationManager cman = new CombinationManager(target);
			    ce.AddEdit(cman.DeleteCombination(target.ParentDependency.ParentStructure));
			}

		return ce;
	}
    }
}