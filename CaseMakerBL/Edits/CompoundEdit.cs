using System.Collections.Generic;

namespace CaseMaker.Edits
{
    public class CompoundEdit:AbstractUndoableEdit
    {
        protected bool inProgress;
        protected IList<IUndoableEdit> edits;

        public CompoundEdit() : base()
        {
            inProgress = true;
            edits = new List<IUndoableEdit>();
        }

        public override void Undo()
        {
            base.Undo();
            int i = edits.Count;
            while(i-- >0)
                edits[i].Undo();
        }
        public override void Redo()
        {
            base.Redo();
            foreach (IUndoableEdit edit in edits)
                edit.Redo();
        }

        public void EndAllEdits(){
	        End(); 
		    foreach(IUndoableEdit edit in edits )
		        if (edit is CompoundEdit)
                    ((CompoundEdit)edit).EndAllEdits();
            
	    }
        protected IUndoableEdit LastEdit()
        {
            int count = edits.Count;
            if (count > 0)
                return edits[count - 1];
            else
                return null;
        }
        public override void Die()
        {
             int i = edits.Count;
            while (i-- > 0)
                edits[i].Die();
            base.Die();
        }

        public override bool AddEdit(IUndoableEdit edit)
        {
            if (!inProgress) return false;

            IUndoableEdit lastEdit = LastEdit();
            if (lastEdit == null)
            {
                edits.Add(edit);
            }else if (!lastEdit.AddEdit(edit))
            {
                if (edit.ReplaceEdit(lastEdit))
                {
                    edits.RemoveAt(edits.Count-1);
                }
                edits.Add(edit);
            }
            return true;
        }

        public virtual void End()
        {
            inProgress = false;
        }

        public override bool CanUndo()
        {
            return !inProgress && base.CanUndo();
        }

        public override bool CanRedo()
        {
            return !inProgress && base.CanRedo();
        }

        public override bool isSignificant()
        {
            foreach (IUndoableEdit edit in edits)
            {
                if (edit.isSignificant())
                    return true;
            }
            return false;
        }

        public override string GetPresentationName()
        {
            if (LastEdit() != null) LastEdit().GetPresentationName();
            return base.GetPresentationName();
        }
    }
}