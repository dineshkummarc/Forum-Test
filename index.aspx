<%@ Page language="c#" Codebehind="index.cs" AutoEventWireup="false" Inherits="Forum.index" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="header.ascx" %><%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<html>
  <head>
	<title>Forum</title>
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0"/>
	<meta name="GENERATOR" content="YesSoftware CodeCharge v.2.0.5 using 'ASP.NET C#.ccp' build 9/27/2001"/>
	<meta name="CODE_LANGUAGE" content="C#"/>
	<meta http-equiv="pragma" content="no-cache"/>
<meta http-equiv="expires" content="0"/>
<meta http-equiv="cache-control" content="no-cache"/>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1"/></head>
  <body style="">

  <form method="post" runat="server">
<CC:Header id="Header" runat="server"/>
	<input type="hidden" id="p_Messages_message_id" runat="server" />
	
<table><tr><td valign="top" >


    <table id="Search_holder" runat="Server" style="border:0; padding:3; width:100%;">
	
	<tr>
      <td style=" background-color:#f2f2f2;"><font style=" size:2; font:bold; color:#0033cc;"></font></td>
      <td style="">
	<asp:TextBox id="Search_s_topic" Columns="35" MaxLength="50" runat="server"/>
	
	  </td>
      <td >
	  <asp:Button
		id="Search_search_button"
		Text="Search"
		runat="server"/>
	</td>
    </tr>
	</table>

</td></tr></table><table><tr><td valign="top" >


	<table   id="Messages_holder" runat="Server" style=" border:0; spacing:1; padding:3; width:100%;">
	<tr><td colspan="6"
        style=" background-color:#c2c2c2;"
><font style=" font:bold" color:#0033cc;"><asp:label id="MessagesForm_Title" runat="server">Discussions</asp:label></font></td></tr>
<tr>
<td style="background-color:#f2f2f2;">
<asp:Label id="Messages_Column_icon" runat="server" Text=""  style=" size:2; font:bold; color:#0033cc;"/></td>

<td style="background-color:#f2f2f2;">
<asp:LinkButton id="Messages_Column_topic" runat="server" Text="Thread" CommandArgument="m.topic" onClick="Messages_SortChange" style=" size:2; font:bold; color:#0033cc;" /></td>
	
<td style="background-color:#f2f2f2;">
<asp:LinkButton id="Messages_Column_author" Text="Author" CommandArgument="m.author" onClick="Messages_SortChange" style=" size:2; font:bold; color:#0033cc;" runat="server"/></td>
	
<td style="background-color:#f2f2f2;">
<asp:LinkButton id="Messages_Column_last_modified" Text="Last Modifed" CommandArgument="m.last_modified" onClick="Messages_SortChange" style=" size:2; font:bold; color:#0033cc" runat="server"/></td>
	
</tr><tr id="Messages_no_records" runat="server"><td style="" colspan="6"><font style=" size:2;">No records</font></td></tr>
	<tr><td><asp:Repeater id="Messages_Repeater" onitemdatabound="Messages_Repeater_ItemDataBound" runat="server">
	<HeaderTemplate>
	</td></tr>
	</HeaderTemplate>
	<ItemTemplate>
	<tr>
<td style="">
 <asp:Label id="Messages_icon" style=" size:2;" runat="server">  </asp:Label>&nbsp;
</td>
<td style="">
<asp:HyperLink id="Messages_topic" NavigateUrl="<%# 'viewthread.aspx'+'?'+'mid='+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "m_message_id").ToString()) +'&' +'s_topic=' + Server.UrlEncode(Utility.GetParam('s_topic')) + '&'%>" style=" size:2;" runat="server" value="<%#DataBinder.Eval(Container.DataItem, "m_topic") %>" ></asp:HyperLink>
</td>
<td style="">
 <asp:Label id="Messages_author" style=" size:2;" runat="server" value="<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_author").ToString()) %>"> </asp:Label>&nbsp;
</td>
<td style="">
<input type="hidden" id="Messages_message_id" runat="server" value="<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_message_id").ToString()) %>"/>
<input type="hidden" id="Messages_smiley_id" runat="server" value="<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_smiley_id").ToString()) %>"/>
 <asp:Label id="Messages_last_modified" style=" size:2;" runat="server" value="<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "m_last_modified").ToString().Replace('T', ' ')) %>" > </asp:Label>&nbsp;
</td></tr>
</ItemTemplate>
	<FooterTemplate>
	<tr><td>
	</FooterTemplate>
	</asp:Repeater></td></tr>
    <tr><td  style=" background-color:#f2f2f2; colspan:6;">

<asp:LinkButton id="Messages_insert" style=" size:2; color:#0033cc;" runat="server"><img alt="" style=" border:0;" src="images/thread.gif"/></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<font style=" size:2; color:#0033cc;">
<CC:Pager id="Messages_Pager" style=" size:2; color:#0033cc;" ShowFirst="False" showLast="False" showprev="True" shownext="True"	ShowFirstCaption=""	showLastCaption=""	showtotal="False"	showtotalstring="of"	shownextCaption="Next" 	showprevCaption="Previous"	PagerStyle="1"	NumberOfPages="10"	runat="server"/>
</font></td></tr>
	</table>


</td>
    </tr></table>


    </form>
</body>
</html>