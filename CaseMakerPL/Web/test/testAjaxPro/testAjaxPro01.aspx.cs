using System;
using System.Web.UI;
using AjaxPro;

[AjaxNamespace("MyClass")]
[AjaxNoTypeUsage]
public partial class _Default : Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Utility.RegisterTypeForAjax(typeof(_Default));
    }

	[AjaxMethod]
	public static string HelloWorld(string s)
	{
		return "Hello " + s + "!";
	}
}
