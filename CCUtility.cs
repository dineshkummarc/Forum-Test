namespace Forum
{

//
//    Filename: CCUtility.cs
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

	

	public class PositionData {
        
		private string name;
		private string CatID;

		public PositionData(string Name, string CategoryID) {
			this.name = Name;
			this.CatID = CategoryID;
		}

		public string Name {
			get {
				return name;
			}
		}

		public string CategoryID {
			get {
				return CatID;
			}
		}
	}

	public enum FieldTypes{Text,Number,Date,Memo}

	public class CCUtility 
	{
	        
		protected HttpSessionState Session;
		protected HttpServerUtility Server;
		protected HttpRequest Request;
		protected HttpResponse Response;

		
//  GlobalFuncs Event begin
//  GlobalFuncs Event end
		public static string ToSQL(string Param, FieldTypes Type) {
		if (Param == null || Param.Length == 0) {
			return "Null";
		} else {
			string str = Quote(Param);
			if (Type == FieldTypes.Number) {
			  return str.Replace(',','.');
			} else {
			  return "\'" + str + "\'";
			}
		}
		}
		
		public CCUtility(object parent){
			Session=HttpContext.Current.Session;
			Server=HttpContext.Current.Server;
			Request=HttpContext.Current.Request;
			Response=HttpContext.Current.Response;
			DBOpen();
		} 

		

		public static String GetValFromLOV(String val, String[] arr) {
			String ret = "";
			if (arr.Length % 2 == 0) {
			int temp=Array.IndexOf(arr,val);
			ret=temp==-1?"":arr[temp+1];}
			return ret;
		}

		

		public bool IsNumeric(object source, string value) {
			try{
				Decimal temp=Convert.ToDecimal(value);
				return true;
		        }catch {
				return false;
			}
		}

		public static string Quote(string Param) {
			if (Param == null || Param.Length == 0) {
				return "";
			} else {
				return Param.Replace("'","''");
			}
		}

		public static string GetValue(DataRow row, string field) {
			if (row[field].ToString() == null)
				return "";
			else
				return row[field].ToString();
		}

        public OleDbConnection Connection;
	
	public DataSet FillDataSet(string sSQL)
	{
		DataSet ds = new DataSet();
		OleDbDataAdapter command = new OleDbDataAdapter(sSQL, Connection);
	 	return ds;
	}

	public int FillDataSet(string sSQL,ref DataSet ds)
	{
		OleDbDataAdapter command = new OleDbDataAdapter(sSQL, Connection);
		return command.Fill(ds, "Table");
	}

	public int FillDataSet(string sSQL,ref DataSet ds,int start, int count)
	{
		OleDbDataAdapter command = new OleDbDataAdapter(sSQL, Connection);
		return command.Fill(ds, start, count, "Table");
	}


	public void DBOpen()
	{
		
		// get Connection string from Config.web
		
		string sConnectionString=System.Configuration.ConfigurationSettings.AppSettings["sForumDBConnectionString"];
		
		// open DB Connection via OleDb
		Connection = new OleDbConnection(sConnectionString);
		Connection.Open();
		
	}

	public void DBClose(){
		Connection.Close();
	}

	public string GetParam(string ParamName) {
		string Param = Request.QueryString[ParamName];
		if (Param == null)
			Param = Request.Form[ParamName];
		if (Param == null)
			return "";
		else 
			return Param;
	}

	public string Dlookup(string table, string field, string sWhere)
	{
		string sSQL = "SELECT " + field + " FROM " + table + " WHERE " + sWhere;

		OleDbCommand command = new OleDbCommand(sSQL, Connection);
		OleDbDataReader reader=command.ExecuteReader(CommandBehavior.SingleRow);
		string sReturn;

		if (reader.Read()) {
			sReturn = reader[0].ToString();
			if (sReturn == null)
			sReturn = "";
		} else {
			sReturn = "";
		}

		reader.Close();
		return sReturn;
	}

	public int DlookupInt(string table, string field, string sWhere)
	{
		string sSQL = "SELECT " + field + " FROM " + table + " WHERE " + sWhere;

		OleDbCommand command = new OleDbCommand(sSQL, Connection);
		OleDbDataReader reader=command.ExecuteReader(CommandBehavior.SingleRow);
		int iReturn = -1;

		if (reader.Read()) {
			iReturn = reader.GetInt32(0);
		}

		reader.Close();
		return iReturn;
	}

	public void Execute(string sSQL){
		OleDbCommand cmd = new OleDbCommand(sSQL, Connection);
		cmd.ExecuteNonQuery();
	}


	public void buildListBox(ListItemCollection Items,string sSQL, string sId, string sTitle, string CustomInitialDisplayValue,string CustomInitialSubmitValue)
	{	
		Items.Clear();
		OleDbCommand command = new OleDbCommand(sSQL, Connection);
		OleDbDataReader reader = command.ExecuteReader();
	
		if(CustomInitialDisplayValue!=null) Items.Add(new ListItem(CustomInitialDisplayValue,CustomInitialSubmitValue));

		while(reader.Read()) {	
			if(sId==""&&sTitle=="")	{
				Items.Add(new ListItem(reader[1].ToString(),reader[0].ToString()));
			}else{
				Items.Add(new ListItem(reader[sTitle].ToString(),reader[sId].ToString()));
			}
		}
		reader.Close();
	}
	
	public void buildListBox(ListItemCollection Items,string[] values, string CustomInitialDisplayValue,string CustomInitialSubmitValue)
	{	
		Items.Clear();
		if(CustomInitialDisplayValue!=null) Items.Add(new ListItem(CustomInitialDisplayValue,CustomInitialSubmitValue));
		for(int i=0;i<values.Length;i+=2)Items.Add(new ListItem(values[i+1],values[i]));
	}


	public ICollection buildListBox(string sSQL, string sId, string sTitle, string CustomInitialDisplayValue,string CustomInitialSubmitValue)
	{
		DataRow row;

		OleDbDataAdapter command = new OleDbDataAdapter(sSQL, Connection);
		DataSet ds = new DataSet();
		ds.Tables.Add("lookup");

		DataColumn column = new DataColumn();
		column.DataType = System.Type.GetType("System.String");
		column.ColumnName = sId;
		ds.Tables[0].Columns.Add(column);

		column = new DataColumn();
		column.DataType = System.Type.GetType("System.String");
		column.ColumnName = sTitle;
		ds.Tables[0].Columns.Add(column);

		if (CustomInitialDisplayValue!=null) {
			row = ds.Tables[0].NewRow();
			row[0] = CustomInitialSubmitValue;
			row[1] = CustomInitialDisplayValue;
			ds.Tables[0].Rows.Add(row);}

		command.Fill(ds, "lookup");
		return new DataView(ds.Tables[0]);
	}


	public static string getCheckBoxValue(string sVal, string CheckedValue, string UnCheckedValue, FieldTypes Type) 
	{
		if (sVal.Length == 0) {
			return ToSQL(UnCheckedValue, Type);
		} else {
			return ToSQL(CheckedValue, Type);
		}
	}


	public void CheckSecurity() {
		if (Session["UserID"] == null || Session["UserID"].ToString().Length == 0) {
			Response.Redirect(".aspx?querystring=" + Server.UrlEncode(Request.ServerVariables["QUERY_STRING"]) + "&ret_page=" + Server.UrlEncode(Request.ServerVariables["SCRIPT_NAME"]));
		}
	}


    }

}