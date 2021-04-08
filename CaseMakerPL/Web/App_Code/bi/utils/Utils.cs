using System;
using System.Collections.Generic;
using CaseMaker.Entities.Testcases;
using utils;

/// <summary>
/// Utility class that contains utils methods for the IList Business Objects of casemaker
/// </summary>
public class Utils : BasePage
{
    public static string AppThemeBaseDir = StaticObjects.getApplicationData.Root_Path + "App_Themes/" +
                                           SessionObjects.getSessionData.CurrentTheme + "/";

    public static string COMBGENBYALLPAIR = AppThemeBaseDir + "images/Tabs/TestCases/comb_allpairs.gif";

    public static string COMBGENBYALLPERM = AppThemeBaseDir + "images/Tabs/TestCases/dependencies.gif";

    public static string COMBGENMANUALLY = AppThemeBaseDir + "images/Tabs/TestCases/comb_manual.gif";

    public static string AllPairImageUrl = AppThemeBaseDir + "images/Tabs/TestCases/comb_allpairs.gif";

    public static string PermutImageUrl = AppThemeBaseDir + "images/Tabs/TestCases/dependencies.gif";

    public static Combination FindObjectById(IList<Combination> _combinations, int id)
    {
        foreach (Combination combination in _combinations)
            if (combination.Id == id)
                return combination;
        return null;
    }

    public static EquivalenceClass FindObjectById(IList<EquivalenceClass> _equivalences, int id)
    {
        foreach (EquivalenceClass equivalence in _equivalences)
            if (equivalence.Id == id)
                return equivalence;
        return null;
    }

    public static Dependency FindObjectById(IList<Dependency> _dependencies, int id)
    {
        foreach (Dependency dependency in _dependencies)
            if (dependency.Id == id)
                return dependency;
        return null;
    }

    public static Element FindObjectById(IList<Element> _elements, int id)
    {
        foreach (Element element in _elements)
            if (element.Id == id)
                return element;
        return null;
    }

    public override void Initialize()
    {
        throw new NotImplementedException();
    }

    protected override void InitializeComponents()
    {
        throw new NotImplementedException();
    }

    protected override void RegisterResources()
    {
        throw new NotImplementedException();
    }

    protected override void RegisterScripts()
    {
        throw new NotImplementedException();
    }
}