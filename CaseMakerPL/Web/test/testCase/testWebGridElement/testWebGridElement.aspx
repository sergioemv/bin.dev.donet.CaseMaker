<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testWebGridElement.aspx.cs"
    Inherits="test_testCase_testWebGridElement_testWebGridElement" StylesheetTheme="Default" %>

<%@ Register Assembly="ISNet.WebUI.WebTreeView" Namespace="ISNet.WebUI.WebTreeView"
    TagPrefix="ISWebTreeView" %>
<%@ Register Assembly="ISNet.WebUI.Silverlight.WebAqua" Namespace="ISNet.WebUI.Silverlight.WebAqua"
    TagPrefix="ISWebAqua" %>
<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop"
    TagPrefix="ISWebDesktop" %>
<%@ Register Src="~/WebUserControls/Workspace/project/TestObject/TestCases/WebGridElement/WebGridElement.ascx"
    TagName="WebGridElement" TagPrefix="uc1" %>
<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:WebGridElement ID="WebGridElement1" runat="server"></uc1:WebGridElement>
            <br />
        </div>
    </form>
</body>
</html>
