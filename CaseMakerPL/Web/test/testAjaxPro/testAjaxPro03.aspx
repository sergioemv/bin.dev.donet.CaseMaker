<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testAjaxPro03.aspx.cs" Inherits="testControl" %>

<%@ Register Src="WebUserControl.ascx" TagName="WebUserControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

  <%--  <script type="text/javascript" src="../../javascript/json.js"></script>--%>

    <script type="text/javascript" src="../../Javascript/jquery.js"></script>

    <script type="text/javascript">
   
       function test(){
       }
       
   
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:WebUserControl ID="WebUserControl1" runat="server" />
        </div>
    </form>
</body>
</html>
