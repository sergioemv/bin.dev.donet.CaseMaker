using System;
using System.Web.UI;
using AjaxPro;

[AjaxNamespace("MyClasses")]
[AjaxNoTypeUsage]
public partial class Default2 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(Default2));
    }

    [AjaxMethod]
    public static string HelloWorld()
    {
        return "Hello Bi!!";
    }


}
