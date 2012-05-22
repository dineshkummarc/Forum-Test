namespace Forum
{
	
//
//    Filename: index.cs
//    Generated with CodeCharge 2.0.5
//    ASP.NET C#.ccp build 03/07/2002
//
//-------------------------------
//

    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Drawing;
    using System.Web;
    using System.Web.SessionState;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;

    /// <summary>
    ///    Summary description for index.
    /// </summary>

	public class index : System.Web.UI.Page
	
    { 



//index CustomIncludes begin
		protected CCUtility Utility;
		
		//Grid form Messages variables and controls declarations
		protected System.Web.UI.HtmlControls.HtmlTableRow Messages_no_records;
		protected string Messages_sSQL;
		protected string Messages_sCountSQL;
		protected int Messages_CountPage;
		protected CCPager Messages_Pager;protected System.Web.UI.WebControls.LinkButton Messages_insert;
		protected System.Web.UI.WebControls.Repeater Messages_Repeater;
		protected int i_Messages_curpage=1;	
	
		//Search form Search variables and controls declarations
		protected System.Web.UI.WebControls.Button Search_search_button;
		protected System.Web.UI.WebControls.TextBox Search_s_topic;
		
		// For each Messages form hiddens for PK's,List of Values and Actions
		protected string Messages_FormAction="newthread.aspx?";
		protected System.Web.UI.HtmlControls.HtmlInputHidden p_Messages_message_id;
		// For each Search form hiddens for PK's,List of Values and Actions
		protected string Search_FormAction="searches.aspx?";
		

	
	public index()
	{
	this.Init += new System.EventHandler(Page_Init);
	}
	
// index CustomIncludes end
//-------------------------------


	public void ValidateNumeric(object source, ServerValidateEventArgs args) {
			try{
				Decimal temp=Decimal.Parse(args.Value);
				args.IsValid=true;
		        }catch{
				args.IsValid=false;	}
		}
//===============================
// index Show begin
        protected void Page_Load(object sender, EventArgs e)
        {	
		Utility=new CCUtility(this);
		//===============================
// index Open Event begin
// index Open Event end
		//===============================
		
		//===============================
// index OpenAnyPage Event begin
// index OpenAnyPage Event end
		//===============================
		//
		//===============================
		// index PageSecurity begin
		// index PageSecurity end
		//===============================

		if (!IsPostBack){
			
			p_Messages_message_id.Value = Utility.GetParam("message_id");Page_Show(sender, e);
		}
	}

	protected void Page_Unload(object sender, EventArgs e)
	{
		//
		// CODEGEN: This call is required by the ASP+ Windows Form Designer.
		//
		if(Utility!=null) Utility.DBClose();
	}

	protected void Page_Init(object sender, EventArgs e)
	{
		//
		// CODEGEN: This call is required by the ASP+ Windows Form Designer.
		//
		InitializeComponent();
		Messages_insert.Click += new System.EventHandler (this.Messages_insert_Click);
		Messages_Pager.NavigateCompleted+=new NavigateCompletedHandler(this.Messages_pager_navigate_completed);
		
		Search_search_button.Click += new System.EventHandler (this.Search_search_Click);
		
		
	}

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
		this.Load += new System.EventHandler(this.Page_Load);
		this.Unload += new System.EventHandler(this.Page_Unload);
        }


        protected void Page_Show(object sender, EventArgs e)
        {
		Messages_Bind();
		Search_Show();
		
        }



// index Show end

// End of Login form 








const int Messages_PAGENUM = 25;




public void Messages_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e){
	
// Messages Show Event begin
if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
string nreplies=Utility.Dlookup("messages","count(*)","message_parent_id=" + ((DataRowView)e.Item.DataItem )["m_message_id"].ToString());
switch(nreplies){
   case "0":
   ((Label)e.Item.FindControl("Messages_icon")).Text="<img src=\"images/disc1.gif\">&nbsp;no&nbsp;replies";
   break;
   case "1":
   ((Label)e.Item.FindControl("Messages_icon")).Text="<img src=\"images/disc.gif\">&nbsp;" + nreplies + "&nbsp;reply";
   break;
   default:
   ((Label)e.Item.FindControl("Messages_icon")).Text="<img src=\"images/disc.gif\">&nbsp;" + nreplies + "&nbsp;replies";
   break;
}
  if(Int32.Parse(((DataRowView)e.Item.DataItem )["m_smiley_id"].ToString())>0) 
	  ((HyperLink)e.Item.FindControl("Messages_topic")).Text="<img align=\"middle\" border=\"0\" src=\"" 
      + Utility.Dlookup("smileys","smiley_url","smiley_id=" + ((DataRowView)e.Item.DataItem )["m_smiley_id"].ToString()) + "\">&nbsp;" + ((DataRowView)e.Item.DataItem )["m_topic"].ToString();
}
// Messages Show Event end
}


ICollection Messages_CreateDataSource() {

       
       // Messages Show begin
	Messages_sSQL = "";
	Messages_sCountSQL = "";

	string sWhere = "", sOrder = "";

	
	bool HasParam = false;
	
	
	//-------------------------------
	// Build ORDER BY statement
	//-------------------------------
	sOrder = " order by m.last_modified Desc";
	if(Utility.GetParam("FormMessages_Sorting").Length>0&&!IsPostBack)
	{ViewState["SortColumn"]=Utility.GetParam("FormMessages_Sorting");
	 ViewState["SortDir"]="ASC";}
	if(ViewState["SortColumn"]!=null) sOrder = " ORDER BY " + ViewState["SortColumn"].ToString()+" "+ViewState["SortDir"].ToString();
	
	//-------------------------------
	// Build WHERE statement
	//-------------------------------
	System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();
	
	
	if(!Params.ContainsKey("s_topic")){
	string temp=Utility.GetParam("s_topic");
	Params.Add("s_topic",temp);}
	
	if(!Params.ContainsKey("s_topic")){
	string temp=Utility.GetParam("s_topic");
	Params.Add("s_topic",temp);}
		
	  if (Params["s_topic"].Length>0) {
	    HasParam = true;
	    sWhere = "m.[topic] like '%" + Params["s_topic"].Replace( "'", "''") +  "%'" + " or " + "m.[message] like '%" + Params["s_topic"].Replace( "'", "''") +  "%'";
	  }

	
	  if (HasParam) {
	    sWhere = " WHERE (message_parent_id is null) AND (" + sWhere + ")";
	  }else{
	    sWhere = " WHERE message_parent_id is null";
	  }

	//-------------------------------
	// Build base SQL statement
	//-------------------------------


	Messages_sSQL = "select [m].[author] as m_author, " +
    "[m].[last_modified] as m_last_modified, " +
    "[m].[message] as m_message, " +
    "[m].[message_id] as m_message_id, " +
    "[m].[smiley_id] as m_smiley_id, " +
    "[m].[topic] as m_topic " +
    " from [messages] m ";
	
	//-------------------------------
	//-------------------------------
	

	//-------------------------------

	//-------------------------------
	// Assemble full SQL statement
	//-------------------------------



	  Messages_sSQL = Messages_sSQL + sWhere + sOrder;
	  if (Messages_sCountSQL.Length== 0) {
	    int iTmpI = Messages_sSQL.ToLower().IndexOf("select ");
	    int iTmpJ = Messages_sSQL.ToLower().LastIndexOf(" from ")-1;
	    Messages_sCountSQL = Messages_sSQL.Replace(Messages_sSQL.Substring(iTmpI + 7, iTmpJ-6), " count(*) ");
	    iTmpI = Messages_sCountSQL.ToLower().IndexOf(" order by");
	    if (iTmpI > 1) Messages_sCountSQL = Messages_sCountSQL.Substring(0, iTmpI);
	  }
	  
	  
	//-------------------------------
	
	OleDbDataAdapter command = new OleDbDataAdapter(Messages_sSQL, Utility.Connection);
	DataSet ds = new DataSet();
	
	command.Fill(ds, (i_Messages_curpage - 1) * Messages_PAGENUM, Messages_PAGENUM,"Messages");
	OleDbCommand ccommand = new OleDbCommand(Messages_sCountSQL, Utility.Connection);
	int PageTemp=(int)ccommand.ExecuteScalar();
	Messages_Pager.MaxPage=(PageTemp%Messages_PAGENUM)>0?(int)(PageTemp/Messages_PAGENUM)+1:(int)(PageTemp/Messages_PAGENUM);
	bool AllowScroller=Messages_Pager.MaxPage==1?false:true;
	
	DataView Source;
        Source = new DataView(ds.Tables[0]);

		if (ds.Tables[0].Rows.Count == 0){
			Messages_no_records.Visible = true;
			AllowScroller=false;}
		else
			{Messages_no_records.Visible = false;
			AllowScroller=AllowScroller&&true;}
		
		Messages_Pager.Visible=AllowScroller;
		return Source;
		// Messages Show end
		
	}
	

	protected void Messages_pager_navigate_completed(Object Src, int CurrPage)
		{
			i_Messages_curpage=CurrPage;
			
// Messages CustomNavigation Event begin
// Messages CustomNavigation Event end
Messages_Bind();
		}
	

	void Messages_Bind() {
		Messages_Repeater.DataSource = Messages_CreateDataSource();
		Messages_Repeater.DataBind();
		
	}

	void Messages_insert_Click(Object Src, EventArgs E) {
		string sURL = Messages_FormAction+"s_topic=" + Server.UrlEncode(Utility.GetParam("s_topic")) + "&";
		Response.Redirect(sURL);
	}

	protected void Messages_SortChange(Object Src, EventArgs E) {
		if(ViewState["SortColumn"]==null || ViewState["SortColumn"].ToString()!=((LinkButton)Src).CommandArgument){
			ViewState["SortColumn"]=((LinkButton)Src).CommandArgument; 
			ViewState["SortDir"]="ASC";
		}else{
			ViewState["SortDir"]=ViewState["SortDir"].ToString()=="ASC"?"DESC":"ASC";
		}
		Messages_Bind();
	}


// End of Login form 







void Search_Show() {
	
// Search Open Event begin
// Search Open Event end

	// Search Show begin
	

	string s;
	
	s=Utility.GetParam("s_topic");
	Search_s_topic.Text = s;
	
// Search Show Event begin
// Search Show Event end

	// Search Show end
	
// Search Close Event begin
// Search Close Event end
}

void Search_search_Click(Object Src, EventArgs E) {
	string sURL = Search_FormAction + "s_topic="+Search_s_topic.Text+"&"
	;
	// Transit
	sURL += "";
	Response.Redirect(sURL);
}




    }
}