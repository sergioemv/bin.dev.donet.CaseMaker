//Author Sergio Moreno
//Business Innovations
using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;
using NHibernate.Classic;

namespace CaseMaker.Entities.Testcases
{
    public class EquivalenceClass : EntityWithEvents, IEquatable<EquivalenceClass>, IComparable<EquivalenceClass>, IEffectsBean, IRiskLevelObject, IStateObject
    {
        private int id;
        private const string NAME_PREFIX = "EC";
        private string description;
        private State currentState = State.POSITIVE;
        private Element parenElement;
        private int riskLevel;
        private string value;
        private int position=-1;
        private IList<Effect> effects;

        public EquivalenceClass()
        {
        }

        public EquivalenceClass(Element elem)
        {
            if (elem==null) return;
            elem.AddEquivalenceClass(this);
          
                position = elem.GetNewEquivalenceClassPosition();
            
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public  virtual string Name
        {
            get { return NAME_PREFIX + Position; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        

        #region IStateObject Members

        public virtual State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public ISet<IStateObject> GetParentObjectStates()
        {
            HashedSet<IStateObject> rlos = new HashedSet<IStateObject>();
            foreach (Effect effect in Effects)
            {
                rlos.Add(effect);
            }
            
            return rlos;
        }

        public ISet<IStateObject> GetChildrenObjectStates()
        {
            HashedSet<IStateObject> rlos = new HashedSet<IStateObject>();
            if (ParentElement != null)
                if (ParentElement.Structure != null)
                {
                    //			 all combinations that contains this equivalenceclass
                    foreach (Dependency dependency in ParentElement.Structure.Dependencies)
                        foreach (Combination combination in dependency.Combinations)
                        {
                            if (combination.EquivalenceClasses.Contains(this))
                                rlos.Add(combination);

                            foreach (TestCase testCase in ParentElement.Structure.TestCases)
                            {
                                if (testCase.EquivalenceClasses.Contains(this))
                                    rlos.Add(testCase);
                            }
                        }
                }
            return rlos;
        }

        #endregion

        public virtual Element ParentElement
        {
            get { return parenElement; }
            set { parenElement = value; }
        }
        #region IRiskLevelObject members
        public virtual int RiskLevel
        {
            get { return riskLevel; }
            set { riskLevel = value; }
        }

        public virtual ISet<IRiskLevelObject> GetParentRiskLevels()
        {
            HashedSet<IRiskLevelObject>  parents = new HashedSet<IRiskLevelObject>();
            foreach (Effect effect in Effects)
            {
                parents.Add(effect);
            }
            return parents;
        }

        public ISet<IRiskLevelObject> GetChildrenRiskLevels()
        {
            HashedSet<IRiskLevelObject> rlos = new HashedSet<IRiskLevelObject>();
            if (ParentElement != null)
                if (ParentElement.Structure != null)
                {
                    //			 all combinations that contains this equivalenceclass
                    foreach (Dependency dependency in ParentElement.Structure.Dependencies)
                        foreach (Combination combination in dependency.Combinations)
                        {
                            if (combination.EquivalenceClasses.Contains(this))
                                rlos.Add(combination);

                            foreach (TestCase testCase in ParentElement.Structure.TestCases)
                            {
                                if (testCase.EquivalenceClasses.Contains(this))
                                    rlos.Add(testCase);
                            }
                        }
                }
            return rlos;
        }
        #endregion
        public virtual string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        #region IEffectsBean Members
        public virtual IList<Effect> Effects
        {
            get
            {
                if (effects == null)
                    effects = new List<Effect>();
                return effects;
            }
            set { effects = value; }
        }

        public void AddEffect(Effect effect)
        {
            if (effect==null || Effects.Contains(effect)) return;
            Effects.Add(effect);
            OnChanged(new CMEntitiesEventArgs("Effects",null,effect));
        }
        public void RemoveEffect(Effect effect)
        {
            if (effect==null||!Effects.Contains(effect)) return;
            Effects.Remove(effect);
            OnChanged(new CMEntitiesEventArgs("Effects",effect,null));
        }

        #endregion

        public virtual int Position
        {
            get { return position; }
            set { position = value; }
        }

        #region IEquatable<EquivalenceClass> Members

        public bool Equals(EquivalenceClass other)
        {
            if (other == null) return false;

            if (other.ParentElement!=ParentElement) return false;
            if (Id!=0)
                return Id.Equals(other.Id);
            return UniqueId.Equals(other.UniqueId);
        }

        #endregion

        #region IComparable<EquivalenceClass> Members

        public int CompareTo(EquivalenceClass other)
        {
            if (other == null) return -1;
            if (other.ParentElement != ParentElement)
                return ParentElement.CompareTo(other.ParentElement);
            return Position.CompareTo(other.Position);
        }

        #endregion
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            if ( ParentElement!= null)
                return ParentElement.ToString()+' '+Name;
            return Name;
        }

        public override void Validate()
        {
            if (ParentElement==null) return;

            foreach (EquivalenceClass equivalenceClass in ParentElement.EquivalenceClasses)
            {
                if (!equivalenceClass.Equals(this) && equivalenceClass.Position.Equals(Position))
                    throw new ValidationFailure("Equivalence class position is repeated");
            }

            if (RiskLevel>10 || RiskLevel<0)
                throw new ValidationFailure("The risk level is not in the allowed range");
        }
    }
}
