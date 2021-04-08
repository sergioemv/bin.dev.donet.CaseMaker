using System;
using System.Web.UI;
using AjaxPro;

[AjaxNamespace("MyClass")]
[AjaxNoTypeUsage]
public partial class test_testAjaxPro_testAjaxPro04 : Page {
    
    
    protected void Page_Load(object sender, EventArgs e) {
        Utility.RegisterTypeForAjax(typeof(test_testAjaxPro_testAjaxPro04));
        if (!IsPostBack && !IsCallback)
            Session["xxx"] = "10";

    }

    [AjaxMethod]
    public static string HelloWorld(string s) {
        return "Hello " + s + "!";
    }


    [AjaxMethod]
    public  bool getValue() {
       // System.Threading.Thread.Sleep(5000);
        
        return true;
    }


}
