<%@ Page language="c#" Codebehind="viewthread.cs" AutoEventWireup="false" Inherits="Forum.viewthread" %>
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
	
<table><tr><td valign="top">


	<table   id="message_holder" runat="Server" style="width: 100%">
	<tr><td colspan="2"
        style="background-color: #c2c2c2"
><font style="font-family: Arial; font-weight: bold; color: #0033cc"><asp:label id="messageForm_Title" runat="server">Original Message</asp:label></font></td></tr>
<tr id=message_no_records runat="server"><td style="" colspan="5"><font style="font-family: Arial; font-size: 13px">No records</font></td></tr>
	<tr><td><asp:Repeater id=message_Repeater onitemdatabound="message_Repeater_ItemDataBound" runat="server">
	<HeaderTemplate>
	</td></tr>
	</HeaderTemplate>
	<ItemTemplate>

<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Topic" id="topic_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 <asp:Label id=message_topic style="font-family: Arial; font-size: 13px" runat="server">  <%# DataBinder.Eval(Container.DataItem, "m_topic") %> </asp:Label>&nbsp;
</td></tr>
<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Author" id="author_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 <asp:Label id=message_author style="font-family: Arial; font-size: 13px" runat="server">  <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_author").ToString()) %> </asp:Label>&nbsp;
</td></tr>
<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Date Created" id="date_entered_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 <asp:Label id=message_date_entered style="font-family: Arial; font-size: 13px" runat="server">  <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_date_entered").ToString().Replace('T', ' ')) %> </asp:Label>&nbsp;
</td></tr>
<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Message" id="message_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 
<input type=hidden id=message_smiley_id runat="server" value=<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_smiley_id").ToString()) %>>
 <asp:Label id=message_message style="font-family: Arial; font-size: 13px" runat="server">  <%# DataBinder.Eval(Container.DataItem, "m_message") %> </asp:Label>&nbsp;
</td></tr></ItemTemplate>

	<SeparatorTemplate>
		<tr><td colspan=2style="">&nbsp;</td></tr>
	</SeparatorTemplate>

	<FooterTemplate>
	<tr><td>
	</FooterTemplate>
	</asp:Repeater></td></tr>

    <tr><td
        style="background-color: f2f2f2; width: 150px"
        colspan=2>

<asp:LinkButton id="message_insert" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"><img border="0" src="images/reply.gif"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<font style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc">
<CC:Pager id=message_Pager 
	style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc"
	ShowFirst=False
	showLast=False
	showprev=True
	shownext=True
	ShowFirstCaption=""
	showLastCaption=""
	showtotal=False
	showtotalstring="of"
	shownextCaption="Next"
	showprevCaption="Previous"
	PagerStyle=1
	NumberOfPages=10
	runat="server"/>
</font></td></tr>
	</table>





	<table   id="replies_holder" runat="Server" style="width: 100%">
	<tr><td colspan="2"
        style="background-color: #c2c2c2"
><font style="font-family: Arial; font-weight: bold; color: #0033cc"><asp:label id="repliesForm_Title" runat="server">Responses</asp:label></font></td></tr>
<tr id=replies_no_records runat="server"><td style="" colspan="5"><font style="font-family: Arial; font-size: 13px">No records</font></td></tr>
	<tr><td><asp:Repeater id=replies_Repeater onitemdatabound="replies_Repeater_ItemDataBound" runat="server">
	<HeaderTemplate>
	</td></tr>
	</HeaderTemplate>
	<ItemTemplate>

<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Topic" id="topic_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 <asp:Label id=replies_topic style="font-family: Arial; font-size: 13px" runat="server">  <%# DataBinder.Eval(Container.DataItem, "m_topic") %> </asp:Label>&nbsp;
</td></tr>
<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Author" id="author_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 <asp:Label id=replies_author style="font-family: Arial; font-size: 13px" runat="server">  <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_author").ToString()) %> </asp:Label>&nbsp;
</td></tr>
<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Date Created" id="date_entered_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 <asp:Label id=replies_date_entered style="font-family: Arial; font-size: 13px" runat="server">  <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_date_entered").ToString().Replace('T', ' ')) %> </asp:Label>&nbsp;
</td></tr>
<tr><td style="background-color: f2f2f2; width: 150px">
<asp:Label Text="Message" id="message_Column_Title" style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc" runat="server"/>
</td>
<td style="">

 
<input type=hidden id=replies_smiley_id runat="server" value=<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_smiley_id").ToString()) %>>
 <asp:Label id=replies_message style="font-family: Arial; font-size: 13px" runat="server">  <%# DataBinder.Eval(Container.DataItem, "m_message") %> </asp:Label>&nbsp;
</td></tr></ItemTemplate>

	<SeparatorTemplate>
		<tr><td colspan=2style="">&nbsp;</td></tr>
	</SeparatorTemplate>

	<FooterTemplate>
	<tr><td>
	</FooterTemplate>
	</asp:Repeater></td></tr>

    <tr><td
        style="background-color: f2f2f2; width: 150px"
        colspan=2>


<font style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc">
<CC:Pager id=replies_Pager 
	style="font-family: Arial; font-size: 13px; font-weight: bold; color: #0033cc"
	ShowFirst=False
	showLast=False
	showprev=True
	shownext=True
	ShowFirstCaption=""
	showLastCaption=""
	showtotal=False
	showtotalstring="of"
	shownextCaption="Next"
	showprevCaption="Previous"
	PagerStyle=1
	NumberOfPages=10
	runat="server"/>
</font></td></tr>
	</table>


</td>
    </tr></table>


    </form>
</body>
</html>