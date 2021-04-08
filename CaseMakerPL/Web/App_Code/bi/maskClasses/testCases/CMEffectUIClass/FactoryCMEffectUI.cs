using System.Collections.Generic;
using CaseMaker.Entities.Testcases;

namespace bi.maskClasses.testCases.CMEffectUIClass
{
    /// <summary>
    /// Autor: portiz
    /// Description: This class manages the transforms of Effects and CMEffectsUI
    /// Responsabilities:
    ///     -transform list of Effects in list of CMEffectsUI
    /// </summary>
    public class FactoryCMEffectUI
    {
        public static IList<CMEffectUI> transformToListOfCMEffectUI(IList<Effect> __realEffectList)
        {
            IList<CMEffectUI> listResult = new List<CMEffectUI>();
            if (__realEffectList != null)
                foreach (Effect realEffect in __realEffectList)
                {
                    CMEffectUI newMaskEff = new CMEffectUI(realEffect);
                    listResult.Add(newMaskEff);
                }
            return listResult;
        }

        private static void fillEffectReal(CMEffectUI __effectMask, Effect __realEffect)
        {
            __realEffect.Description = __effectMask.Description;
            __realEffect.CurrentState = __effectMask.EffectState;
            __realEffect.RiskLevel = __effectMask.RiskLevel;
        }

        public static IList<Effect> CreateNewEffects(IList<CMEffectUI> __newEffectsMaskList,
                                                     TestCasesStructure __Structure)
        {
            IList<Effect> newEffectList = new List<Effect>();
            foreach (CMEffectUI efMask in __newEffectsMaskList)
            {
                Effect newEffect = new Effect(__Structure);
                efMask.HashCodeIdentifier = newEffect.GetHashCodeReal();
                fillEffectReal(efMask, newEffect);
                newEffectList.Add(newEffect);
            }
            return newEffectList;
        }

        public static IList<CMEffectUI> IntersectEffectsToMaskEffects(IList<CMEffectUI> __actualMaskList,
                                                                      IList<Effect> __realEffectList)
        {
            IList<CMEffectUI> listResult = new List<CMEffectUI>();
            foreach (Effect effectReal in __realEffectList)
            {
                foreach (CMEffectUI effectMask in __actualMaskList)
                {
                    if (effectReal.GetHashCodeReal().Equals(effectMask.GetHashCode()))
                    {
                        listResult.Add(effectMask);
                        break;
                    }
                }
            }
            return listResult;
        }

        public static IList<Effect> IntersectEffectsWithEffects(IList<Effect> __listA, IList<Effect> __listB)
        {
            IList<Effect> listResult = new List<Effect>();
            foreach (Effect effA in __listA)
            {
                foreach (Effect effB in __listB)
                {
                    if (effA.GetHashCodeReal().Equals(effB.GetHashCodeReal()))
                    {
                        listResult.Add(effA);
                        break;
                    }
                }
            }
            return listResult;
        }

        public static IList<Effect> IntersectMaskEffectsToEffects(IList<CMEffectUI> __actualMaskList,
                                                                  IList<Effect> __realEffectList)
        {
            IList<Effect> listResult = new List<Effect>();
            foreach (CMEffectUI effectMask in __actualMaskList)
            {
                foreach (Effect effectReal in __realEffectList)
                {
                    if (effectReal.GetHashCodeReal().Equals(effectMask.GetHashCode()))
                    {
                        listResult.Add(effectReal);
                        break;
                    }
                }
            }
            return listResult;
        }


        public static IList<CMEffectUI> IntersectMaskEffectsToMaskEffects(IList<CMEffectUI> __listA,
                                                                          IList<CMEffectUI> __listB)
        {
            IList<CMEffectUI> listResult = new List<CMEffectUI>();
            foreach (CMEffectUI efA in __listA)
            {
                foreach (CMEffectUI efB in __listB)
                {
                    if (efA.GetHashCode().Equals(efB.GetHashCode()))
                    {
                        listResult.Add(efA);
                        break;
                    }
                }
            }
            return listResult;
        }


        public static IList<CMEffectUI> SubstractFromMask(IList<CMEffectUI> __listA, IList<CMEffectUI> __listB)
        {
            IList<CMEffectUI> listResult = new List<CMEffectUI>();
            foreach (CMEffectUI effA in __listA)
            {
                bool bContain = false;
                foreach (CMEffectUI effB in __listB)
                {
                    if (effA.GetHashCode().Equals(effB.GetHashCode()))
                    {
                        bContain = true;
                        break;
                    }
                }
                if (!bContain)
                    listResult.Add(effA);
            }
            return listResult;
        }

        public static IList<Effect> SubstractFromEffects(IList<Effect> __listA, IList<Effect> __listB)
        {
            IList<Effect> listResult = new List<Effect>();
            foreach (Effect effA in __listA)
            {
                bool bContain = false;
                foreach (Effect effB in __listB)
                {
                    if (effA.GetHashCodeReal().Equals(effB.GetHashCodeReal()))
                    {
                        bContain = true;
                        break;
                    }
                }
                if (!bContain)
                    listResult.Add(effA);
            }
            return listResult;
        }
    }
}