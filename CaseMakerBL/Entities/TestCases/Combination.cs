//Author : Sergio Moreno
//Business Innovations
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Iesi.Collections.Generic;
using NHibernate.Classic;

namespace CaseMaker.Entities.Testcases
{
    public enum CombinationOrigin
    {    [Description("Manual")]
        MANUAL,
        [Description("Automatic by Permutation")]
        PERMUTATION,
        [Description("Automatic by All Pairs")]
        ALLPAIRS
    }
    public class Combination : EntityWithEvents, ICombinationsBean, IEquivalenceClassesBean, IEffectsBean, IEquatable<Combination>, IComparable<Combination>, IRiskLevelObject, IStateObject
    {
        private int id;
        
        private string description;
        private State currentState = State.POSITIVE;
        private const string NAME_PREFIX = "C";
        private int position;
        private Dependency parentDependency;
        private Combination parentCombination;
        private IList<Combination> combinations;
        private IList<EquivalenceClass> equivalenceClasses;
        private IList<Effect> effects;
        private int riskLevel;
        private CombinationOrigin origin=CombinationOrigin.MANUAL;

        public Combination(Dependency dep)
        {
            if (dep == null) return;
            position = dep.getNewCombinationPosition();
            dep.AddCombination(this);
        }

        public Combination()
        {
        }
    

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
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
            foreach (EquivalenceClass equivalenceClass in EquivalenceClasses)
            {
                rlos.Add(equivalenceClass);
            }
            
            return rlos;
        }

        public ISet<IStateObject> GetChildrenObjectStates()
        {
            HashedSet<IStateObject> listRL = new HashedSet<IStateObject>();
            if (ParentDependency != null)
                if (ParentDependency.ParentStructure != null)
                    foreach (TestCase testCase in ParentDependency.ParentStructure.TestCases)
                        if (testCase.Combinations.Contains(this))
                            listRL.Add(testCase);
            return listRL;
        }

        #endregion

        #region IEquatable<Combination> Members

        public bool Equals(Combination other)
        {
            if (other == null) return false;
            if (other.ParentDependency != ParentDependency) return false;
            if (Id != 0)
                return Id.Equals(other.Id);
            return UniqueId.Equals(other.UniqueId); 
        }

        #endregion

        #region IComparable<Combination> Members

        public int CompareTo(Combination other)
        {
            if (other == null) return -1;
            if (ParentDependency != other.ParentDependency) 
                return ParentDependency.CompareTo(other.ParentDependency);
            return Position.CompareTo(other.Position);
        }

        #endregion

        public override int GetHashCode()
        {
            return Id.GetHashCode()+Position.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        private string Name
        {
            get { return NAME_PREFIX + Position; }
        }

        #region ICombinationsBean Members

        public virtual IList<Combination> Combinations
        {
            get
            {
                if (combinations == null)
                    combinations = new List<Combination>();
                return combinations;
            }
            set { combinations = value; }
        }

        public void AddCombination(Combination combination)
        {
            if (combination==null || Combinations.Contains(combination)) return;
            Combinations.Add(combination);
            combination.ParentCombination = this;
            OnChanged(new CMEntitiesEventArgs("Combinations",null,combination));
        }

        public void RemoveCombination(Combination combination)
        {
            if (combination==null||!Combinations.Contains(combination)) return;
            Combinations.Remove(combination);
            combination.ParentCombination = null;
            OnChanged(new CMEntitiesEventArgs("Combinations",combination,null));
        }

        #endregion

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
            if (effect == null|| !Effects.Contains(effect)) return;
            Effects.Remove(effect);
            OnChanged(new CMEntitiesEventArgs("Effect",effect,null));
        }

        #endregion

        public virtual int RiskLevel
        {
            get { return riskLevel; }
            set { riskLevel = value; }
        }

        public ISet<IRiskLevelObject> GetParentRiskLevels()
        {
            HashedSet<IRiskLevelObject> rlos = new HashedSet<IRiskLevelObject>();
            foreach (Effect effect in Effects)
            {
                rlos.Add(effect);
            }
            foreach (EquivalenceClass equivalenceClass in EquivalenceClasses)
            {
                rlos.Add(equivalenceClass);
            }
            
            return rlos;
        }

        public ISet<IRiskLevelObject> GetChildrenRiskLevels()
        {
            HashedSet<IRiskLevelObject> listRL = new HashedSet<IRiskLevelObject>();
		    if (ParentDependency!=null)
			if (ParentDependency.ParentStructure!=null)
				foreach (TestCase testCase in ParentDependency.ParentStructure.TestCases)
					if (testCase.Combinations.Contains(this))
						listRL.Add(testCase);
		return listRL;
        }

        public virtual  CombinationOrigin Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public virtual Dependency ParentDependency
        {
            get { return parentDependency; }
            set { parentDependency = value; }
        }

        public virtual Combination ParentCombination
        {
            get { return parentCombination; }
            set { parentCombination = value; }
        }

        public virtual int Position
        {
            get { return position; }
            set { position = value; }
        }

        public override void Validate()
        {
            if (RiskLevel > 10 || RiskLevel < 0)
                throw new ValidationFailure("The risk level is not in the allowed range");

            if (ParentDependency == null) return;

            foreach (Combination com in ParentDependency.Combinations)
            {
                if (!com.Equals(this) && com.Position.Equals(Position))
                    throw new ValidationFailure("Combination position is repeated");
            }

            
        }

        #region IEquivalenceClassesBean Members
        
        public virtual IList<EquivalenceClass> EquivalenceClasses
        {
            get
            {
                if (equivalenceClasses == null)
                    equivalenceClasses = new List<EquivalenceClass>();
                return equivalenceClasses;
            }
            set { equivalenceClasses = value; }
        }

      

        public void AddEquivalenceClass(EquivalenceClass equivalenceClass)
        {
            if (equivalenceClass == null || EquivalenceClasses.Contains(equivalenceClass)) return;
            EquivalenceClasses.Add(equivalenceClass);
            OnChanged(new CMEntitiesEventArgs( "EquivalenceClasses", null,equivalenceClass));
        }

        public void RemoveEquivalenceClass(EquivalenceClass equivalenceClass)
        {
            if (equivalenceClass==null || !EquivalenceClasses.Contains(equivalenceClass)) return;
            EquivalenceClasses.Remove(equivalenceClass);
            OnChanged(new CMEntitiesEventArgs("EquivalenceClasses",equivalenceClass,null));
        }

        #endregion
    
        //Gets all the equivalence classes asigned to this combination including the ones from its children
        public virtual ISet<EquivalenceClass> GetAllEquivalenceClasses()
        {
            HashedSet<EquivalenceClass> eqs = new HashedSet<EquivalenceClass>(EquivalenceClasses);
            foreach (Combination combination in Combinations)
            {
                eqs.AddAll(combination.GetAllEquivalenceClasses());
            }
            return eqs;
        }

        //get all reated elements
        public virtual ISet<Element> GetAllElements()
        {
            HashedSet<Element> elms = new HashedSet<Element>();
            foreach (EquivalenceClass equivalenceClass in GetAllEquivalenceClasses())
            {
                elms.Add(equivalenceClass.ParentElement);
            }
            return elms;
        }

        public virtual ISet<EquivalenceClass> GetChildrenCombinationEquivalenceClasses()
        {
            HashedSet<EquivalenceClass> eqs = new HashedSet<EquivalenceClass>();
            foreach (Combination combination in Combinations)
            {
                eqs.AddAll(combination.GetAllEquivalenceClasses());
            }
            return eqs;
        }

        public virtual ISet<Combination> GetAllChildrenCombination()
        {
            HashedSet<Combination> combis = new HashedSet<Combination>(Combinations);
            foreach (Combination combination in Combinations)
            {
                combis.AddAll(combination.GetAllChildrenCombination());
            }
            return combis;
        }

        public virtual string GeneratedDescription
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (Element element in GetAllElements())
                {
                    builder.Append("(");
                    foreach (EquivalenceClass equivalenceClass in GetAllEquivalenceClasses())
                    {
                        if (element.EquivalenceClasses.Contains(equivalenceClass))
                        {
                            builder.Append(element.Name);
                            builder.Append("=");
                            builder.Append("'");
                            builder.Append(equivalenceClass.Value);
                            builder.Append("'");
                            builder.Append(" OR ");
                        }
                        
                    }
                    builder.Remove(builder.Length - 4, 4);
                    builder.Append(")");
                    builder.Append(" AND ");
                }
                builder.Remove(builder.Length - 5, 5);
                if (Effects.Count == 0) return builder.ToString();
                builder.Append(" THEN {");
                foreach (Effect effect in GetAllEffects())
                {
                    if (effect.Description == "" || effect.Description == null)
                        builder.Append(effect.Name);
                    else
                        builder.Append(effect.Description);
                    builder.Append(",");
                
                }
                builder.Remove(builder.Length - 1, 1);
                builder.Append("}");
                return builder.ToString();
            }
        }

        public string FullName
        {
            get { return ParentDependency.Name + "." + Name; }
        }

        public virtual ISet<Effect> GetAllEffects()
        {
            HashedSet<Effect> effs = new HashedSet<Effect>(Effects);
            foreach (Combination combination in GetAllChildrenCombination())
            {
                effs.AddAll(combination.Effects);
            }
            foreach (EquivalenceClass equivalenceClass in GetAllEquivalenceClasses())
            {
                effs.AddAll(equivalenceClass.Effects);
            }
            return effs;
        }
    }
}
