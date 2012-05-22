<%@ Page language="c#" Codebehind="reply.cs" AutoEventWireup="false" Inherits="Forum.reply" %>
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
	<input type=hidden id=p_reply_message_id runat=server />
	
<table><tr><td valign="top" >


	<table   id="original_holder" runat="Server" style="width: 100%">
	<tr><td colspan="2"
        style="background-color: #c2c2c2"
><font style="font-family: Arial; font-weight: bold; color: #0033cc"><asp:label id="originalForm_Title" runat="server">Original Message</asp:label></font></td></tr>
<tr id=original_no_records runat="server"><td style="" colspan="4"><font style="font-family: Arial; font-size: 13px">No records</font></td></tr>
	<tr><td><asp:Repeater id=original_Repeater onitemdatabound="original_Repeater_ItemDataBound" runat="server">
	<HeaderTemplate>
	</td></tr>
	</HeaderTemplate>
	<ItemTemplate>

<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Author" id="author_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 <asp:Label id=original_author style="font-family: Arial; font-size: 13px" runat="server">  <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_author").ToString()) %> </asp:Label>&nbsp;
</td></tr>
<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Topic" id="topic_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 <asp:Label id=original_topic style="font-family: Arial; font-size: 13px" runat="server">  <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_topic").ToString()) %> </asp:Label>&nbsp;
</td></tr>
<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Date Entered" id="date_entered_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 <asp:Label id=original_date_entered style="font-family: Arial; font-size: 13px" runat="server">  <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_date_entered").ToString().Replace('T', ' ')) %> </asp:Label>&nbsp;
</td></tr>
<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Message" id="message_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 <asp:Label id=original_message style="font-family: Arial; font-size: 13px" runat="server">  <%# DataBinder.Eval(Container.DataItem, "m_message") %> </asp:Label>&nbsp;
</td></tr></ItemTemplate>

	<SeparatorTemplate>
		<tr><td colspan=2style="">&nbsp;</td></tr>
	</SeparatorTemplate>

	<FooterTemplate>
	<tr><td>
	</FooterTemplate>
	</asp:Repeater></td></tr>

	</table>


</td></tr></table><table><tr><td valign="top" >

<table  id="reply_holder" runat="Server" style="width: 100%">
	<tr><td colspan=2 style="background-color: #c2c2c2"><font style="font-family: Arial; font-weight: bold; color: #0033cc"><asp:label id="replyForm_Title" runat="server">Your Response</asp:label></font><br>
	</td></tr>
	<tr><td colspan="2" style="">
	<asp:Label id=reply_ValidationSummary style="" runat="server" Visible="false"></asp:Label>

	<input type="Hidden" id="reply_message_id" value="" runat="server">

	<input type="Hidden" id="reply_smiley_id" value="0" runat="server">

	<input type="Hidden" id="reply_date_entered" value="" runat="server">

	<input type="Hidden" id="reply_last_modified" value="" runat="server">

	<input type="Hidden" id="reply_mid" value="" runat="server">
</td></tr>
<tr>
	<td style="background-color: #f2f2f2; width: 150px"><font style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc">Icon</font></td>
    	<td style="">
        
	<asp:Label id=reply_smileys
style="font-family: Arial; font-size: 13px" runat="server">
	
	</asp:Label>
&nbsp;</td>
	</tr>
<tr>
	<td style="background-color: #f2f2f2; width: 150px"><font style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc">Topic *</font>
	<asp:RequiredFieldValidator id=reply_topic_Validator_Req runat="server" ErrorMessage="The value in field Topic * is required." ControlToValidate="reply_topic" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
    	<td style="">
        <asp:TextBox
	id=reply_topic
 Columns=50
	runat="server"/>
&nbsp;</td>
	</tr>
<tr>
	<td style="background-color: #f2f2f2; width: 150px"><font style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc">Author</font></td>
    	<td style="">
        <asp:TextBox
	id=reply_author
 Columns=20
	runat="server"/>
&nbsp;</td>
	</tr>
<tr>
	<td style="background-color: #f2f2f2; width: 150px"><font style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc">Message *</font>
	<asp:RequiredFieldValidator id=reply_message_Validator_Req runat="server" ErrorMessage="The value in field Message * is required." ControlToValidate="reply_message" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
    	<td style="">
        
	<asp:TextBox	id=reply_message
style="font-family: Arial; font-size: 13px" TextMode=MultiLine Rows=12 Columns=80 runat="server">
	
	</asp:TextBox>
&nbsp;</td>
	</tr>

    <tr><td align=right colspan=2 >

	<input type="button"
		id=reply_insert
		Value="Reply"
		runat="server" >
	
    </td></tr>

	</table>


</td>
    </tr></table>


    </form>
</body>
</html>