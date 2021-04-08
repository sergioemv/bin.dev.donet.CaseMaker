using System;

namespace CaseMaker.Edits
{
    public class AbstractUndoableEdit:IUndoableEdit
    {
        private bool hasBeenDone;
        private bool alive;

        public AbstractUndoableEdit()
        {
            hasBeenDone = true;
            alive = true;
        }


        public virtual void Undo()
        {
            if (!CanUndo())
                throw new CannotUndoException();
            hasBeenDone = false;
        }

        public virtual bool CanUndo()
        {
            return alive && hasBeenDone;
        }

        public virtual void Redo()
        {
            if (!CanRedo())
                throw new CannotRedoException();
            hasBeenDone = true;
        }

        public virtual bool CanRedo()
        {
            return alive && !hasBeenDone;
        }

        public virtual void Die()
        {
            alive = false;
        }

        public virtual bool AddEdit(IUndoableEdit edit)
        {
            return false;
        }

        public virtual bool ReplaceEdit(IUndoableEdit edit)
        {
            return false;
        }

        public virtual bool isSignificant()
        {
            return true;
        }

        public virtual string GetPresentationName()
        {
            return String.Empty;
        }
    }

    internal class CannotRedoException : Exception
    {
    }

    internal class CannotUndoException : Exception
    {
    }
}