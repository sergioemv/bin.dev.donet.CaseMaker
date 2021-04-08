using System;
using System.Web.UI;
using AjaxPro;

[AjaxNamespace("MyClass")]
[AjaxNoTypeUsage]
public partial class WebUserControl : UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //AjaxPro.Utility.RegisterTypeForAjax(typeof(_Default));
        Utility.RegisterTypeForAjax(typeof(WebUserControl));
    }

    [AjaxMethod]
    public static string HelloWorld(string s) {
        return "Hello " + s + "!";
    }


}
