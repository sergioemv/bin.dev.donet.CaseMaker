using System;
using System.Web.UI;
using CaseMaker.Entities.Testcases;

public partial class testState : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        body.Style.Add("overflow", "hidden");
        if (!IsPostBack)
            UCState1.Initialize();
        UCState1.Value = State.NEGATIVE;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write(UCState1.Value);
    }
}