namespace Forum
{
	
//
//    Filename: reply.cs
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
    ///    Summary description for reply.
    /// </summary>

	public class reply : System.Web.UI.Page
	
    { 



//reply CustomIncludes begin
		protected CCUtility Utility;
		
		//Record form reply variables and controls declarations
		protected System.Web.UI.WebControls.Label reply_ValidationSummary;
		protected System.Web.UI.HtmlControls.HtmlInputButton reply_insert;
		protected System.Web.UI.HtmlControls.HtmlInputHidden reply_message_id;
		protected System.Web.UI.HtmlControls.HtmlInputHidden reply_smiley_id;
		protected System.Web.UI.WebControls.Label reply_smileys;
		protected System.Web.UI.WebControls.TextBox reply_topic;
		protected System.Web.UI.WebControls.TextBox reply_author;
		protected System.Web.UI.WebControls.TextBox reply_message;
		protected System.Web.UI.HtmlControls.HtmlInputHidden reply_date_entered;
		protected System.Web.UI.HtmlControls.HtmlInputHidden reply_last_modified;
		protected System.Web.UI.HtmlControls.HtmlInputHidden reply_mid;
		
		//Grid form original variables and controls declarations
		protected System.Web.UI.HtmlControls.HtmlTableRow original_no_records;
		protected string original_sSQL;
		protected string original_sCountSQL;
		protected int original_CountPage;
		
		protected System.Web.UI.WebControls.Repeater original_Repeater;
		protected int i_original_curpage=1;	
	
		// For each reply form hiddens for PK's,List of Values and Actions
		protected string reply_FormAction="index.aspx?";
		protected System.Web.UI.HtmlControls.HtmlInputHidden p_reply_message_id;
		// For each original form hiddens for PK's,List of Values and Actions
		protected string original_FormAction=".aspx?";
		

	
	public reply()
	{
	this.Init += new System.EventHandler(Page_Init);
	}
	
// reply CustomIncludes end
//-------------------------------


	public void ValidateNumeric(object source, ServerValidateEventArgs args) {
			try{
				Decimal temp=Decimal.Parse(args.Value);
				args.IsValid=true;
		        }catch{
				args.IsValid=false;	}
		}
//===============================
// reply Show begin
        protected void Page_Load(object sender, EventArgs e)
        {	
		Utility=new CCUtility(this);
		//===============================
// reply Open Event begin
// reply Open Event end
		//===============================
		
		//===============================
// reply OpenAnyPage Event begin
// reply OpenAnyPage Event end
		//===============================
		//
		//===============================
		// reply PageSecurity begin
		// reply PageSecurity end
		//===============================

		if (!IsPostBack){
			
			p_reply_message_id.Value = Utility.GetParam("message_id");Page_Show(sender, e);
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
		reply_insert.ServerClick += new System.EventHandler (this.reply_Action);
		
		
		
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
		reply_Show();
		original_Bind();
		
        }



// reply Show end

// End of Login form 






private bool reply_Validate(){
	bool result=true;
	reply_ValidationSummary.Text="";

	for(int i=0;i<Page.Validators.Count;i++){
		if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("reply")){
			if(!Page.Validators[i].IsValid){
				reply_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
				result=false;
			}
		}
	}

	reply_ValidationSummary.Visible=(!result);
	return result;
}

/*===============================
 Display Record Form
-------------------------------*/


void reply_Show() {
	
	// reply Show begin
	
	bool ActionInsert=true;
	
	if (p_reply_message_id.Value.Length > 0 ) {
		string sWhere = "";
		
		sWhere += "message_id=" + CCUtility.ToSQL(p_reply_message_id.Value, FieldTypes.Number);
		
// reply Open Event begin
// reply Open Event end
		string sSQL = "select * from messages where " + sWhere;
		OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
		DataSet ds = new DataSet();
		DataRow row;

		if (dsCommand.Fill(ds, 0, 1, "reply") > 0) {
		row = ds.Tables[0].Rows[0];
				
	reply_message_id.Value = CCUtility.GetValue(row, "message_id");
		

	reply_smiley_id.Value = CCUtility.GetValue(row, "smiley_id");
		

	
		
		
		

	reply_topic.Text = CCUtility.GetValue(row, "topic");
	reply_author.Text = CCUtility.GetValue(row, "author");
	reply_message.Text = CCUtility.GetValue(row, "message");
		

	reply_date_entered.Value = CCUtility.GetValue(row, "date_entered").Replace('T', ' ');
		

	reply_last_modified.Value = CCUtility.GetValue(row, "last_modified").Replace('T', ' ');
		

	reply_mid.Value = CCUtility.GetValue(row, "message_parent_id");
		

	reply_insert.Visible=false;
		ActionInsert=false;
		
// reply ShowEdit Event begin
// reply ShowEdit Event end

	}}

		if(ActionInsert){

		String pValue;

		pValue = Utility.GetParam("mid");reply_mid.Value = pValue;
// reply ShowInsert Event begin
reply_date_entered.Value=DateTime.Now.ToString("g");
reply_last_modified.Value=DateTime.Now.ToString("g");
reply_smiley_id.Value="";

reply_smileys.Text="<input type=\"radio\" name=\"smiley_id\" value=\"0\" checked>none&nbsp;";
OleDbCommand command = new OleDbCommand("SELECT * FROM smileys", Utility.Connection);
OleDbDataReader reader = command.ExecuteReader();
while(reader.Read()) {	
  reply_smileys.Text+="<input type=\"radio\" name=\"smiley_id\" value=\"" + 
  reader["smiley_id"].ToString() + "\"><img src=\"" +
  reader["smiley_url"].ToString() + "\" title=\"" +
  reader["smiley_name"].ToString() + "\">&nbsp;";
}
reader.Close();
// reply ShowInsert Event end

}



// reply Open Event begin
// reply Open Event end

// reply Show Event begin
// reply Show Event end

	// reply Show end
	
// reply Close Event begin
// reply Close Event end

	}
	
	// reply Action begin
	
bool reply_insert_Click(Object Src, EventArgs E) {
		string sSQL="";
		bool bResult=reply_Validate();
		
// reply Check Event begin
// reply Check Event end

		string p2_smiley_id=CCUtility.ToSQL(Utility.GetParam("reply_smiley_id"), FieldTypes.Number) ;
		string p2_topic=CCUtility.ToSQL(Utility.GetParam("reply_topic"), FieldTypes.Text) ;
		string p2_author=CCUtility.ToSQL(Utility.GetParam("reply_author"), FieldTypes.Text) ;
		string p2_message=CCUtility.ToSQL(Utility.GetParam("reply_message"), FieldTypes.Memo) ;
		string p2_date_entered=CCUtility.ToSQL(Utility.GetParam("reply_date_entered"), FieldTypes.Date) ;
		string p2_last_modified=CCUtility.ToSQL(Utility.GetParam("reply_last_modified"), FieldTypes.Date) ;
		string p2_mid=CCUtility.ToSQL(Utility.GetParam("reply_mid"), FieldTypes.Number) ;
// reply Insert Event begin
Utility.Execute("UPDATE messages SET last_modified="+CCUtility.ToSQL(System.DateTime.Now.ToString("g"), FieldTypes.Date)
+" WHERE message_id=" + reply_mid.Value);
p2_smiley_id=CCUtility.ToSQL(Utility.GetParam("smiley_id"), FieldTypes.Number) ;
// reply Insert Event end


		if(bResult){	
			
			if(sSQL.Length==0){
			sSQL = "insert into messages (" +
				"smiley_id," +
				"topic," +
				"author," +
				"message," +
				"date_entered," +
				"last_modified," +
				"message_parent_id)" +
				" values (" +
				p2_smiley_id + "," + 
				p2_topic + "," + 
				p2_author + "," + 
				p2_message + "," + 
				p2_date_entered + "," + 
				p2_last_modified + "," + 
				p2_mid + ")";
			}
			reply_BeforeSQLExecute(sSQL,"Insert");
			OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
			try {
				cmd.ExecuteNonQuery();
			} catch(Exception e) {
				reply_ValidationSummary.Text += e.Message;
				reply_ValidationSummary.Visible = true;
				return false;
			}
			
// reply AfterInsert Event begin
// reply AfterInsert Event end
		}
		return bResult;
	}


	void reply_BeforeSQLExecute(string SQL,String Action){
	  
// reply BeforeExecute Event begin
// reply BeforeExecute Event end

	}

	
void reply_Action(Object Src, EventArgs E) {
bool bResult=true;
if(((HtmlInputButton)Src).ID.IndexOf("insert")>0) bResult=reply_insert_Click(Src,E);
					

if(bResult)Response.Redirect(reply_FormAction+"mid=" + Server.UrlEncode(Utility.GetParam("mid")) + "&");
}
// reply Action end


// End of Login form 








const int original_PAGENUM = 20;




public void original_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e){
	
// original Show Event begin
if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
  ((Label)e.Item.FindControl("original_message")).Text = ((DataRowView)e.Item.DataItem )["m_message"].ToString().Replace("\r\n","<br>");
}
// original Show Event end
}


ICollection original_CreateDataSource() {

       
       // original Show begin
	original_sSQL = "";
	original_sCountSQL = "";

	string sWhere = "", sOrder = "";

	
	bool HasParam = false;
	
	
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


	original_sSQL = "select [m].[author] as m_author, " +
    "[m].[date_entered] as m_date_entered, " +
    "[m].[message] as m_message, " +
    "[m].[message_id] as m_message_id, " +
    "[m].[topic] as m_topic " +
    " from [messages] m ";
	
	//-------------------------------
	//-------------------------------
	

	//-------------------------------

	//-------------------------------
	// Assemble full SQL statement
	//-------------------------------



	  original_sSQL = original_sSQL + sWhere + sOrder;
	//-------------------------------
	
	OleDbDataAdapter command = new OleDbDataAdapter(original_sSQL, Utility.Connection);
	DataSet ds = new DataSet();
	 	
	command.Fill(ds, 0, original_PAGENUM, "original");
	DataView Source;
        Source = new DataView(ds.Tables[0]);

		if (ds.Tables[0].Rows.Count == 0){
			original_no_records.Visible = true;
			}
		else
			{original_no_records.Visible = false;
			}
		
		
		return Source;
		// original Show end
		
	}
	

	void original_Bind() {
		original_Repeater.DataSource = original_CreateDataSource();
		original_Repeater.DataBind();
		
	}



    }
}