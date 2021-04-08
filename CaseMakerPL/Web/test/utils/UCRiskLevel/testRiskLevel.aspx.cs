using System;
using System.Web.UI;

public partial class testRiskLevel : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        body.Style.Add("overflow", "hidden");
        if (!IsPostBack)
            UCRiskLevel1.Initialize();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write(UCRiskLevel1.Value);
    }
}