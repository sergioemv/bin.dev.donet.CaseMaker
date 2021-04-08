using System;
using System.Collections.Generic;
using System.Web.UI;
using CaseMaker.Entities.Testcases;
using ISNet.WebUI.WebDesktop;

public partial class testWebGridElementCombination : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && !Page.IsCallback)
        {
            WebGridElement1.Input_ElementList = SessionObjects.getTestObject.TestCasesStruct.Elements;
            WebGridElement1.Initialize();
            WebGridElement1.setTemplateCombination();
            WebGridElement1.jsFunctionToExecuteCheck = "show";
            SessionObjects.getScriptResourceManager.registerAllScripts(this);
        }
    }


    protected void WebButton1_Clicked(object sender, WebButtonClickedEventArgs e)
    {
        WebGridElement1.updateEquivalenceClassesChecked();
        IList<EquivalenceClass> selectedEq = WebGridElement1.getCheckedEquivalenceClass;
        foreach (EquivalenceClass eq in selectedEq)
        {
            WebButton1.ClientAction.Alert(eq.Name);
        }
    }
}