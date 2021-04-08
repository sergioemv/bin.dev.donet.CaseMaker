<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testState.aspx.cs" Inherits="testState" %>

<%@ Register Src="../../../webUserControls/utils/UCState/UCState.ascx" TagName="UCState"
    TagPrefix="uc1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>Untitled Page</title>
</head>
<body id="body" runat="server" leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
        <div>
            <uc1:UCState ID="UCState1" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></div>
    </form>
</body>
</html>
