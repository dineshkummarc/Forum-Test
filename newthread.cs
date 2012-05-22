namespace Forum
{
	
//
//    Filename: newthread.cs
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
    ///    Summary description for newthread.
    /// </summary>

	public class newthread : System.Web.UI.Page
	
    { 



//newthread CustomIncludes begin
		protected CCUtility Utility;
		
		//Record form messages variables and controls declarations
		protected System.Web.UI.WebControls.Label messages_ValidationSummary;
		protected System.Web.UI.HtmlControls.HtmlInputButton messages_insert;
		protected System.Web.UI.HtmlControls.HtmlInputHidden messages_message_id;
		protected System.Web.UI.HtmlControls.HtmlInputHidden messages_smiley_id;
		protected System.Web.UI.WebControls.Label messages_smileys;
		protected System.Web.UI.WebControls.TextBox messages_topic;
		protected System.Web.UI.WebControls.TextBox messages_author;
		protected System.Web.UI.WebControls.TextBox messages_message;
		protected System.Web.UI.HtmlControls.HtmlInputHidden messages_date_entered;
		protected System.Web.UI.HtmlControls.HtmlInputHidden messages_last_modified;
		
		// For each messages form hiddens for PK's,List of Values and Actions
		protected string messages_FormAction="index.aspx?";
		protected System.Web.UI.HtmlControls.HtmlInputHidden p_messages_message_id;

	
	public newthread()
	{
	this.Init += new System.EventHandler(Page_Init);
	}
	
// newthread CustomIncludes end
//-------------------------------


	public void ValidateNumeric(object source, ServerValidateEventArgs args) {
			try{
				Decimal temp=Decimal.Parse(args.Value);
				args.IsValid=true;
		        }catch{
				args.IsValid=false;	}
		}
//===============================
// newthread Show begin
        protected void Page_Load(object sender, EventArgs e)
        {	
		Utility=new CCUtility(this);
		//===============================
// newthread Open Event begin
// newthread Open Event end
		//===============================
		
		//===============================
// newthread OpenAnyPage Event begin
// newthread OpenAnyPage Event end
		//===============================
		//
		//===============================
		// newthread PageSecurity begin
		// newthread PageSecurity end
		//===============================

		if (!IsPostBack){
			
			p_messages_message_id.Value = Utility.GetParam("message_id");Page_Show(sender, e);
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
		messages_insert.ServerClick += new System.EventHandler (this.messages_Action);
		
		
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
		messages_Show();
		
        }



// newthread Show end

// End of Login form 






private bool messages_Validate(){
	bool result=true;
	messages_ValidationSummary.Text="";

	for(int i=0;i<Page.Validators.Count;i++){
		if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("messages")){
			if(!Page.Validators[i].IsValid){
				messages_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
				result=false;
			}
		}
	}

	messages_ValidationSummary.Visible=(!result);
	return result;
}

/*===============================
 Display Record Form
-------------------------------*/


void messages_Show() {
	
	// messages Show begin
	
	bool ActionInsert=true;
	
	if (p_messages_message_id.Value.Length > 0 ) {
		string sWhere = "";
		
		sWhere += "message_id=" + CCUtility.ToSQL(p_messages_message_id.Value, FieldTypes.Number);
		
// messages Open Event begin
// messages Open Event end
		string sSQL = "select * from messages where " + sWhere;
		OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
		DataSet ds = new DataSet();
		DataRow row;

		if (dsCommand.Fill(ds, 0, 1, "messages") > 0) {
		row = ds.Tables[0].Rows[0];
				
	messages_message_id.Value = CCUtility.GetValue(row, "message_id");
		

	messages_smiley_id.Value = CCUtility.GetValue(row, "smiley_id");
		

	
		
		
		

	messages_topic.Text = CCUtility.GetValue(row, "topic");
	messages_author.Text = CCUtility.GetValue(row, "author");
	messages_message.Text = CCUtility.GetValue(row, "message");
		

	messages_date_entered.Value = CCUtility.GetValue(row, "date_entered").Replace('T', ' ');
		

	messages_last_modified.Value = CCUtility.GetValue(row, "last_modified").Replace('T', ' ');
		

	messages_insert.Visible=false;
		ActionInsert=false;
		
// messages ShowEdit Event begin
// messages ShowEdit Event end

	}}

		if(ActionInsert){

// messages ShowInsert Event begin
messages_date_entered.Value=DateTime.Now.ToString("g");
messages_last_modified.Value=DateTime.Now.ToString("g");
messages_smiley_id.Value="";

messages_smileys.Text="<input type=\"radio\" name=\"smiley_id\" value=\"0\" checked>none&nbsp;";
OleDbCommand command = new OleDbCommand("SELECT * FROM smileys", Utility.Connection);
OleDbDataReader reader = command.ExecuteReader();
while(reader.Read()) {	
  messages_smileys.Text+="<input type=\"radio\" name=\"smiley_id\" value=\"" + 
  reader["smiley_id"].ToString() + "\"><img src=\"" +
  reader["smiley_url"].ToString() + "\" title=\"" +
  reader["smiley_name"].ToString() + "\">&nbsp;";
}
reader.Close();
// messages ShowInsert Event end

}



// messages Open Event begin
// messages Open Event end

// messages Show Event begin
// messages Show Event end

	// messages Show end
	
// messages Close Event begin
// messages Close Event end

	}
	
	// messages Action begin
	
bool messages_insert_Click(Object Src, EventArgs E) {
		string sSQL="";
		bool bResult=messages_Validate();
		
// messages Check Event begin
// messages Check Event end

		string p2_smiley_id=CCUtility.ToSQL(Utility.GetParam("messages_smiley_id"), FieldTypes.Number) ;
		string p2_topic=CCUtility.ToSQL(Utility.GetParam("messages_topic"), FieldTypes.Text) ;
		string p2_author=CCUtility.ToSQL(Utility.GetParam("messages_author"), FieldTypes.Text) ;
		string p2_message=CCUtility.ToSQL(Utility.GetParam("messages_message"), FieldTypes.Memo) ;
		string p2_date_entered=CCUtility.ToSQL(Utility.GetParam("messages_date_entered"), FieldTypes.Date) ;
		string p2_last_modified=CCUtility.ToSQL(Utility.GetParam("messages_last_modified"), FieldTypes.Date) ;
// messages Insert Event begin
p2_smiley_id=CCUtility.ToSQL(Utility.GetParam("smiley_id"), FieldTypes.Number) ;
// messages Insert Event end


		if(bResult){	
			
			if(sSQL.Length==0){
			sSQL = "insert into messages (" +
				"smiley_id," +
				"topic," +
				"author," +
				"message," +
				"date_entered," +
				"last_modified)" +
				" values (" +
				p2_smiley_id + "," + 
				p2_topic + "," + 
				p2_author + "," + 
				p2_message + "," + 
				p2_date_entered + "," + 
				p2_last_modified + ")";
			}
			messages_BeforeSQLExecute(sSQL,"Insert");
			OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
			try {
				cmd.ExecuteNonQuery();
			} catch(Exception e) {
				messages_ValidationSummary.Text += e.Message;
				messages_ValidationSummary.Visible = true;
				return false;
			}
			
// messages AfterInsert Event begin
// messages AfterInsert Event end
		}
		return bResult;
	}


	void messages_BeforeSQLExecute(string SQL,String Action){
	  
// messages BeforeExecute Event begin
// messages BeforeExecute Event end

	}

	
void messages_Action(Object Src, EventArgs E) {
bool bResult=true;
if(((HtmlInputButton)Src).ID.IndexOf("insert")>0) bResult=messages_insert_Click(Src,E);
					

if(bResult)Response.Redirect(messages_FormAction+"");
}
// messages Action end



    }
}