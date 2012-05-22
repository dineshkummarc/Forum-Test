namespace Forum
{
	
//
//    Filename: viewthread.cs
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
    ///    Summary description for viewthread.
    /// </summary>

	public class viewthread : System.Web.UI.Page
	
    { 



//viewthread CustomIncludes begin
		protected CCUtility Utility;
		
		//Grid form message variables and controls declarations
		protected System.Web.UI.HtmlControls.HtmlTableRow message_no_records;
		protected string message_sSQL;
		protected string message_sCountSQL;
		protected int message_CountPage;
		protected CCPager message_Pager;protected System.Web.UI.WebControls.LinkButton message_insert;
		protected System.Web.UI.WebControls.Repeater message_Repeater;
		protected int i_message_curpage=1;	
	
		//Grid form replies variables and controls declarations
		protected System.Web.UI.HtmlControls.HtmlTableRow replies_no_records;
		protected string replies_sSQL;
		protected string replies_sCountSQL;
		protected int replies_CountPage;
		protected CCPager replies_Pager;
		protected System.Web.UI.WebControls.Repeater replies_Repeater;
		protected int i_replies_curpage=1;	
	
		// For each message form hiddens for PK's,List of Values and Actions
		protected string message_FormAction="reply.aspx?";
		
		// For each replies form hiddens for PK's,List of Values and Actions
		protected string replies_FormAction="viewthread.aspx?";
		

	
	public viewthread()
	{
	this.Init += new System.EventHandler(Page_Init);
	}
	
// viewthread CustomIncludes end
//-------------------------------


	public void ValidateNumeric(object source, ServerValidateEventArgs args) {
			try{
				Decimal temp=Decimal.Parse(args.Value);
				args.IsValid=true;
		        }catch{
				args.IsValid=false;	}
		}
//===============================
// viewthread Show begin
        protected void Page_Load(object sender, EventArgs e)
        {	
		Utility=new CCUtility(this);
		//===============================
// viewthread Open Event begin
// viewthread Open Event end
		//===============================
		
		//===============================
// viewthread OpenAnyPage Event begin
// viewthread OpenAnyPage Event end
		//===============================
		//
		//===============================
		// viewthread PageSecurity begin
		// viewthread PageSecurity end
		//===============================

		if (!IsPostBack){
			Page_Show(sender, e);
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
		message_insert.Click += new System.EventHandler (this.message_insert_Click);
		message_Pager.NavigateCompleted+=new NavigateCompletedHandler(this.message_pager_navigate_completed);
		
		replies_Pager.NavigateCompleted+=new NavigateCompletedHandler(this.replies_pager_navigate_completed);
		
		
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
		message_Bind();
		replies_Bind();
		
        }



// viewthread Show end

// End of Login form 








const int message_PAGENUM = 20;




public void message_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e){
	
// message Show Event begin
if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
  ((Label)e.Item.FindControl("message_message")).Text = ((DataRowView)e.Item.DataItem )["m_message"].ToString().Replace("\r\n","<br>");
  ((Label)e.Item.FindControl("message_topic")).Text = "<b>"+((DataRowView)e.Item.DataItem )["m_topic"].ToString().Replace("\r\n","<br>")+"</b>";

  if(Int32.Parse(((DataRowView)e.Item.DataItem )["m_smiley_id"].ToString())>0) 
  ((Label)e.Item.FindControl("message_topic")).Text="<img align=\"middle\" border=\"0\" src=\"" 
      + Utility.Dlookup("smileys","smiley_url","smiley_id=" + ((DataRowView)e.Item.DataItem )["m_smiley_id"].ToString()) + "\">&nbsp;" + "<b>"+((DataRowView)e.Item.DataItem )["m_topic"].ToString().Replace("\r\n","<br>")+"</b>";
}
// message Show Event end
}


ICollection message_CreateDataSource() {

       
       // message Show begin
	message_sSQL = "";
	message_sCountSQL = "";

	string sWhere = "", sOrder = "";

	
	bool HasParam = false;
	
	
	//-------------------------------
	// Build ORDER BY statement
	//-------------------------------
	//-------------------------------
	// Build WHERE statement
	//-------------------------------
	System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();
	
	
	if(!Params.ContainsKey("mid")){
	string temp=Utility.GetParam("mid");
	if (Utility.IsNumeric(null,temp) && temp.Length>0) { temp = CCUtility.ToSQL(temp, FieldTypes.Number);} else {temp = "";}
	Params.Add("mid",temp);}
	
	  if (Params["mid"].Length>0) {
	    HasParam = true;
	    sWhere +="m.[message_id]=" + Params["mid"];
	  }

	
	  if(HasParam)
	    sWhere = " WHERE (" + sWhere + ")";

	//-------------------------------
	// Build base SQL statement
	//-------------------------------


	message_sSQL = "select [m].[author] as m_author, " +
    "[m].[date_entered] as m_date_entered, " +
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



	  message_sSQL = message_sSQL + sWhere + sOrder;
	  if (message_sCountSQL.Length== 0) {
	    int iTmpI = message_sSQL.ToLower().IndexOf("select ");
	    int iTmpJ = message_sSQL.ToLower().LastIndexOf(" from ")-1;
	    message_sCountSQL = message_sSQL.Replace(message_sSQL.Substring(iTmpI + 7, iTmpJ-6), " count(*) ");
	    iTmpI = message_sCountSQL.ToLower().IndexOf(" order by");
	    if (iTmpI > 1) message_sCountSQL = message_sCountSQL.Substring(0, iTmpI);
	  }
	  
	  
	//-------------------------------
	
	OleDbDataAdapter command = new OleDbDataAdapter(message_sSQL, Utility.Connection);
	DataSet ds = new DataSet();
	
	command.Fill(ds, (i_message_curpage - 1) * message_PAGENUM, message_PAGENUM,"message");
	OleDbCommand ccommand = new OleDbCommand(message_sCountSQL, Utility.Connection);
	int PageTemp=(int)ccommand.ExecuteScalar();
	message_Pager.MaxPage=(PageTemp%message_PAGENUM)>0?(int)(PageTemp/message_PAGENUM)+1:(int)(PageTemp/message_PAGENUM);
	bool AllowScroller=message_Pager.MaxPage==1?false:true;
	
	DataView Source;
        Source = new DataView(ds.Tables[0]);

		if (ds.Tables[0].Rows.Count == 0){
			message_no_records.Visible = true;
			AllowScroller=false;}
		else
			{message_no_records.Visible = false;
			AllowScroller=AllowScroller&&true;}
		
		message_Pager.Visible=AllowScroller;
		return Source;
		// message Show end
		
	}
	

	protected void message_pager_navigate_completed(Object Src, int CurrPage)
		{
			i_message_curpage=CurrPage;
			
// message CustomNavigation Event begin
// message CustomNavigation Event end
message_Bind();
		}
	

	void message_Bind() {
		message_Repeater.DataSource = message_CreateDataSource();
		message_Repeater.DataBind();
		
	}

	void message_insert_Click(Object Src, EventArgs E) {
		string sURL = message_FormAction+"mid=" + Server.UrlEncode(Utility.GetParam("mid")) + "&";
		Response.Redirect(sURL);
	}


// End of Login form 








const int replies_PAGENUM = 20;




public void replies_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e){
	
// replies Show Event begin
if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
  ((Label)e.Item.FindControl("replies_message")).Text = ((DataRowView)e.Item.DataItem )["m_message"].ToString().Replace("\r\n","<br>");
  ((Label)e.Item.FindControl("replies_topic")).Text = "<b>"+((DataRowView)e.Item.DataItem )["m_topic"].ToString().Replace("\r\n","<br>")+"</b>";

  if(Int32.Parse(((DataRowView)e.Item.DataItem )["m_smiley_id"].ToString())>0) 
  ((Label)e.Item.FindControl("replies_topic")).Text="<img align=\"middle\" border=\"0\" src=\"" 
      + Utility.Dlookup("smileys","smiley_url","smiley_id=" + ((DataRowView)e.Item.DataItem )["m_smiley_id"].ToString()) + "\">&nbsp;" + "<b>"+((DataRowView)e.Item.DataItem )["m_topic"].ToString().Replace("\r\n","<br>")+"</b>";
}
// replies Show Event end
}


ICollection replies_CreateDataSource() {

       
       // replies Show begin
	replies_sSQL = "";
	replies_sCountSQL = "";

	string sWhere = "", sOrder = "";

	
	bool HasParam = false;
	
	
	//-------------------------------
	// Build ORDER BY statement
	//-------------------------------
	sOrder = " order by m.date_entered Desc";
	//-------------------------------
	// Build WHERE statement
	//-------------------------------
	System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();
	
	
	if(!Params.ContainsKey("mid")){
	string temp=Utility.GetParam("mid");
	if (Utility.IsNumeric(null,temp) && temp.Length>0) { temp = CCUtility.ToSQL(temp, FieldTypes.Number);} else {temp = "";}
	Params.Add("mid",temp);}
	
	  if (Params["mid"].Length>0) {
	    HasParam = true;
	    sWhere +="m.[message_parent_id]=" + Params["mid"];
	  }

	
	  if(HasParam)
	    sWhere = " WHERE (" + sWhere + ")";

	//-------------------------------
	// Build base SQL statement
	//-------------------------------


	replies_sSQL = "select [m].[author] as m_author, " +
    "[m].[date_entered] as m_date_entered, " +
    "[m].[message] as m_message, " +
    "[m].[message_parent_id] as m_message_parent_id, " +
    "[m].[smiley_id] as m_smiley_id, " +
    "[m].[topic] as m_topic " +
    " from [messages] m ";
	
	//-------------------------------
	//-------------------------------
	

	//-------------------------------

	//-------------------------------
	// Assemble full SQL statement
	//-------------------------------



	  replies_sSQL = replies_sSQL + sWhere + sOrder;
	  if (replies_sCountSQL.Length== 0) {
	    int iTmpI = replies_sSQL.ToLower().IndexOf("select ");
	    int iTmpJ = replies_sSQL.ToLower().LastIndexOf(" from ")-1;
	    replies_sCountSQL = replies_sSQL.Replace(replies_sSQL.Substring(iTmpI + 7, iTmpJ-6), " count(*) ");
	    iTmpI = replies_sCountSQL.ToLower().IndexOf(" order by");
	    if (iTmpI > 1) replies_sCountSQL = replies_sCountSQL.Substring(0, iTmpI);
	  }
	  
	  
	//-------------------------------
	
	OleDbDataAdapter command = new OleDbDataAdapter(replies_sSQL, Utility.Connection);
	DataSet ds = new DataSet();
	
	command.Fill(ds, (i_replies_curpage - 1) * replies_PAGENUM, replies_PAGENUM,"replies");
	OleDbCommand ccommand = new OleDbCommand(replies_sCountSQL, Utility.Connection);
	int PageTemp=(int)ccommand.ExecuteScalar();
	replies_Pager.MaxPage=(PageTemp%replies_PAGENUM)>0?(int)(PageTemp/replies_PAGENUM)+1:(int)(PageTemp/replies_PAGENUM);
	bool AllowScroller=replies_Pager.MaxPage==1?false:true;
	
	DataView Source;
        Source = new DataView(ds.Tables[0]);

		if (ds.Tables[0].Rows.Count == 0){
			replies_no_records.Visible = true;
			AllowScroller=false;}
		else
			{replies_no_records.Visible = false;
			AllowScroller=AllowScroller&&true;}
		
		replies_Pager.Visible=AllowScroller;
		return Source;
		// replies Show end
		
	}
	

	protected void replies_pager_navigate_completed(Object Src, int CurrPage)
		{
			i_replies_curpage=CurrPage;
			
// replies CustomNavigation Event begin
// replies CustomNavigation Event end
replies_Bind();
		}
	

	void replies_Bind() {
		replies_Repeater.DataSource = replies_CreateDataSource();
		replies_Repeater.DataBind();
		
	}



    }
}