<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="testAjaxPro01.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <%--<script type="text/javascript" src="../../javascript/json.js"></script>--%>
    <script type="text/javascript" src="../../Javascript/jquery.js"></script>
    <script type="text/javascript">
    //jQuery.noConflict();
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="display"></div>

	<script type="text/javascript">

	$(document).ready(function() {
		MyClass.HelloWorld("Business Innovations", function(res) {
			jQuery("#display").html(res.value);
		});
	});
	



	</script>
    
    </form>
</body>
</html>
