<%@ Page language="c#" Codebehind="newthread.cs" AutoEventWireup="false" Inherits="Forum.newthread" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="header.ascx" %><%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<html>
  <head>
	<title>Forum</title>
	<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	<meta name="GENERATOR" content="YesSoftware CodeCharge v.2.0.5 using 'ASP.NET C#.ccp' build 9/27/2001">
	<meta name="CODE_LANGUAGE" Content="C#">
	<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="expires" content="0">
<meta http-equiv="cache-control" content="no-cache">
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1"></head>
  <body style="">

  <form method="post" runat="server">
<CC:Header id="Header" runat="server"/>
	<input type=hidden id=p_messages_message_id runat=server />
	
<table><tr><td valign="top" >

<table  id="messages_holder" runat="Server" style="width: 100%">
	<tr><td colspan=2 style="background-color: #c2c2c2"><font style="font-family: Arial; font-weight: bold; color: #0033cc"><asp:label id="messagesForm_Title" runat="server">Add New Thread</asp:label></font><br>
	</td></tr>
	<tr><td colspan="2" style="">
	<asp:Label id=messages_ValidationSummary style="" runat="server" Visible="false"></asp:Label>

	<input type="Hidden" id="messages_message_id" value="" runat="server">

	<input type="Hidden" id="messages_smiley_id" value="" runat="server">

	<input type="Hidden" id="messages_date_entered" value="" runat="server">

	<input type="Hidden" id="messages_last_modified" value="" runat="server">
</td></tr>
<tr>
	<td style="background-color: #f2f2f2; width: 150px"><font style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc">Icon</font></td>
    	<td style="">
        
	<asp:Label id=messages_smileys
style="font-family: Arial; font-size: 13px" runat="server">
	
	</asp:Label>
&nbsp;</td>
	</tr>
<tr>
	<td style="background-color: #f2f2f2; width: 150px"><font style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc">Topic *</font>
	<asp:RequiredFieldValidator id=messages_topic_Validator_Req runat="server" ErrorMessage="The value in field Topic * is required." ControlToValidate="messages_topic" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
    	<td style="">
        <asp:TextBox
	id=messages_topic
 Columns=50 MaxLength=50
	runat="server"/>
&nbsp;</td>
	</tr>
<tr>
	<td style="background-color: #f2f2f2; width: 150px"><font style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc">Author</font></td>
    	<td style="">
        <asp:TextBox
	id=messages_author
 Columns=20 MaxLength=50
	runat="server"/>
&nbsp;</td>
	</tr>
<tr>
	<td style="background-color: #f2f2f2; width: 150px"><font style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc">Message *</font>
	<asp:RequiredFieldValidator id=messages_message_Validator_Req runat="server" ErrorMessage="The value in field Message * is required." ControlToValidate="messages_message" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
    	<td style="">
        
	<asp:TextBox	id=messages_message
style="font-family: Arial; font-size: 13px" TextMode=MultiLine Rows=12 Columns=80 runat="server">
	
	</asp:TextBox>
&nbsp;</td>
	</tr>

    <tr><td align=right colspan=2 >

	<input type="button"
		id=messages_insert
		Value="Submit"
		runat="server" >
	
    </td></tr>

	</table>


</td>
    </tr></table>


    </form>
</body>
</html>