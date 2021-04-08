<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testRiskLevel.aspx.cs" Inherits="testRiskLevel" %>

<%@ Register Src="../../../webUserControls/utils/UCRiskLevel/UCRiskLevel.ascx" TagName="UCRiskLevel"
    TagPrefix="uc1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>Untitled Page</title>
</head>
<body id="body" runat="server" leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
        <div>
            <uc1:UCRiskLevel ID="UCRiskLevel1" runat="server" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" /></div>
    </form>
</body>
</html>
