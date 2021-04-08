<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testAjaxPro04.aspx.cs" Inherits="test_testAjaxPro_testAjaxPro04" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">

        <script language="javascript" type="text/javascript">

                /*
                    Just testing Ajaxpro. Note, in ajaxpro, the components should not be seen.
                */

                function help(res){
                alert(res.value);
                }

                function testAjaxPro(){
                    MyClass.getValue(help);   
                }
    
        </script>

        <div>
            <asp:Button ID="btn1" runat="server" Text="hope" OnClientClick="testAjaxPro();return false;" />
        </div>
    </form>
</body>
</html>
