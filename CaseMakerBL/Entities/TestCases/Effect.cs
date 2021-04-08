//Author Sergio Moreno
//Business Innovations
using System;
using System.Collections;
using System.Collections.Generic;
using CaseMaker.Entities.Utils;
using Iesi.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public class Effect : EntityWithEvents, IEquatable<Effect>, IComparable<Effect>, IRequirementsBean, IRiskLevelObject, IStateObject
    {
        private int id;
        private string description;
        private int position;
        private State currentState = State.POSITIVE;
        private int riskLevel;
        private TestCasesStructure parentStructure;
        private const string NAME_PREFIX="CE";
        private IList<Requirement> requirements;
        private IList<ExpectedResult> expectedResults;

        public Effect(IEffectsBean effectBean)
        {
            if (effectBean == null) return;
            effectBean.AddEffect(this);
            if (effectBean is TestCasesStructure)
                position = (effectBean as TestCasesStructure).GetNewEffectPosition();
        }
        public Effect()
        {
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name
        {
            get { return NAME_PREFIX + Position; }
        }


        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }
        #region IStateObject  Members
        public virtual State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public virtual ISet<IStateObject> GetParentObjectStates()
        {
            return null;
        }

        public virtual ISet<IStateObject> GetChildrenObjectStates()
        {
            ISet<IStateObject> listRL = new HashedSet<IStateObject>();
            if (parentStructure != null)
            {
                //all equivalence classes that contains this effect
                foreach (Element element in parentStructure.Elements)
                    foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                        if (equivalenceClass.Effects.Contains(this))
                            listRL.Add(equivalenceClass);
                // all combinations that contains this effect
                foreach (Dependency dependency in parentStructure.Dependencies)
                    foreach (Combination combination in dependency.Combinations)
                    {
                        if (combination.Effects.Contains(this))
                            listRL.Add(combination);
                    }
            }
            return listRL;
        }
        #endregion
        #region IStateObject  Members
        public virtual int RiskLevel
        {
            get { return riskLevel; }
            set { riskLevel = value; }
        }

        public virtual ISet<IRiskLevelObject> GetParentRiskLevels()
        {
            return null;
        }

        public virtual ISet<IRiskLevelObject> GetChildrenRiskLevels()
        {
            HashedSet<IRiskLevelObject> listRL = new HashedSet<IRiskLevelObject>();
            if (parentStructure != null)
            {
                //all equivalence classes that contains this effect
                foreach (Element element in parentStructure.Elements)
                    foreach (EquivalenceClass equivalenceClass in element.EquivalenceClasses)
                        if (equivalenceClass.Effects.Contains(this))
                            listRL.Add(equivalenceClass);
                // all combinations that contains this effect
                foreach (Dependency dependency in parentStructure.Dependencies)
                    foreach (Combination combination in dependency.Combinations)
                    {
                        if (combination.Effects.Contains(this))
                            listRL.Add(combination);
                    }
            }
            return listRL;
        }
        #endregion
        #region IRequirementsBean Members
        public virtual IList<Requirement> Requirements
        {
            get
            {
                if (requirements == null)
                    requirements = new List<Requirement>();
                return requirements;
            }
            set { requirements = value; }
        }

        public void AddRequirement(Requirement req)
        {
            if (req == null || Requirements.Contains(req)) return;
            Requirements.Add(req);
            OnChanged(new CMEntitiesEventArgs("Requirements",null,req));
        }
        public void RemoveRequirement(Requirement req)
        {
            if (req==null|| !Requirements.Contains(req)) return;
            Requirements.Remove(req);
            OnChanged(new CMEntitiesEventArgs("Requirements",req,null));

        }

        #endregion

        public virtual TestCasesStructure ParentStructure
        {
            get { return parentStructure; }
            set { parentStructure = value; }
        }

        public virtual IList<ExpectedResult> ExpectedResults
        {
            get
            {
                if (expectedResults == null)
                    expectedResults = new List<ExpectedResult>();
                return expectedResults;
            }
            set { expectedResults = value; }
        }

        public virtual int Position
        {
            get { return position; }
            set { position = value; }
        }

        #region IEquatable<Effect> Members

        public bool Equals(Effect other)
        {
            if (other == null) return false;
            if (other.ParentStructure != ParentStructure) return false;
            if (id == 0 && other.id == 0) return Position.Equals(other.Position);

            return Id.Equals(other.Id);

        }

        #endregion

        #region IComparable<Effect> Members

        public int CompareTo(Effect other)
        {
            if (other == null) return -1;
            if (other.ParentStructure != ParentStructure) return other.ParentStructure.CompareTo(ParentStructure);
            return Position.CompareTo(other.Position);
        }

        #endregion

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }


        public virtual string GetNewExpectedResultName()
        {
            EntityNamer namer = new EntityNamer((IList)ExpectedResults, "Value");
            return namer.GenerateName(); 
        }

        public virtual void AddExpectedResult(ExpectedResult result)
        {
            if (result == null || ExpectedResults.Contains(result)) return;

            ExpectedResults.Add(result);
            result.ParentEffect = this;
            OnChanged( new CMEntitiesEventArgs("ExpectedResults",null,result));

        }
        public virtual void RemoveExpectedResult(ExpectedResult result)
        {
            if (result == null || !ExpectedResults.Contains(result)) return;

            ExpectedResults.Remove(result);
            result.ParentEffect = null;
            OnChanged(new CMEntitiesEventArgs("ExpectedResults", result, null));

        }

    }
}