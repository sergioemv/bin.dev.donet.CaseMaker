using System;
using System.Web.UI;

public partial class test_testCase_testWebGridElement_testWebGridElement : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && !Page.IsCallback)
        {
            WebGridElement1.Input_ElementList = SessionObjects.getTestObject.TestCasesStruct.Elements;
            WebGridElement1.Initialize();
            WebGridElement1.setTemplateElements();
            SessionObjects.getScriptResourceManager.registerAllScripts(this);
        }
    }
}