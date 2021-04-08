<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs"
    Inherits="WebUserControl" %>
<div id="display">
</div>

<script type="text/javascript">

	$(document).ready(function() {
		MyClass.HelloWorld("Michael Schwarz", function(res) {
			jQuery("#display").html(res.value);
		});
	});
	
</script>

