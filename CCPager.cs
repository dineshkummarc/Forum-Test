namespace Forum
{
//
//    Filename: CCPager.cs
//    Generated with CodeCharge 2.0.5
//    ASP.NET C#.ccp build 03/07/2002
//
//-------------------------------
//

	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for Pager.
	/// </summary>
	
	public class PagingData 
	{
         
		private string page;
		private bool enabled;
 
		public PagingData(string page, bool enabled){
			this.page = page;
			this.enabled = enabled;
		}
 
		public string Page {
			get {return page;}
		}
 
		public bool Enabled 
		{
			get 
			{
				return enabled;
			}
		}
	}
 

	public delegate void NavigateCompletedHandler(object sender, int CurrentPage);

	public abstract class CCPager : System.Web.UI.UserControl
	{
		


		public bool ShowFirst,ShowLast,ShowPrev,ShowNext,ShowTotal;
		public string ShowFirstCaption,ShowLastCaption,ShowPrevCaption,ShowNextCaption,ShowTotalString,style,CssClass;
		public int MaxPage,CurrentPage=1,NumberOfPages;
		public enum PagerStyleEnum {NoPager,PageNumberOnly,Centered,Moved}
		public PagerStyleEnum PagerStyle;
		protected System.Web.UI.WebControls.LinkButton lnkFirst;
		protected System.Web.UI.WebControls.LinkButton lnkPrev;
		protected System.Web.UI.WebControls.LinkButton lnkNext;
		protected System.Web.UI.WebControls.LinkButton lnkLast;
		protected System.Web.UI.WebControls.Label lblNext;
		protected System.Web.UI.WebControls.Label lblLast;
		protected System.Web.UI.WebControls.Label ClosePar;
		protected System.Web.UI.WebControls.Label lblShowTotal;
		protected System.Web.UI.WebControls.Label lblFirst;
		protected System.Web.UI.WebControls.Label OpenPar;
		protected System.Web.UI.WebControls.Label Current;
		protected System.Web.UI.WebControls.Repeater Repeater1;
		protected System.Web.UI.WebControls.Label lblPrev;
		protected bool PagerStartPressed=false,PagerEndPressed=false;
		
		public event NavigateCompletedHandler NavigateCompleted;
		
		/// <summary>
		public CCPager()
		{
			this.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{	
				if(CssClass!=null)
				{
						try
						{
						lnkFirst.CssClass=CssClass;
						lnkLast.CssClass=CssClass;
						lnkPrev.CssClass=CssClass;
						lnkNext.CssClass=CssClass;
						lblPrev.CssClass=CssClass;
						lblNext.CssClass=CssClass;
						lblLast.CssClass=CssClass;
						lblFirst.CssClass=CssClass;
						lblShowTotal.CssClass=CssClass;
						}
						catch{}
				}


				if(style!=null)
				{string[] pairs=style.Split(new Char[] {';'});
					string key,val;
					for(int i=0;i<pairs.Length;i++)
					{
						try
						{key=pairs[i].Split(new Char[] {':'})[0].Trim();
						 val=pairs[i].Split(new Char[] {':'})[1].Trim();
						lnkFirst.Style.Add(key,val);
						lnkLast.Style.Add(key,val);
						lnkPrev.Style.Add(key,val);
						lnkNext.Style.Add(key,val);
						lblPrev.Style.Add(key,val);
						lblNext.Style.Add(key,val);
						lblLast.Style.Add(key,val);
						lblFirst.Style.Add(key,val);
						lblShowTotal.Style.Add(key,val);
						}
						catch{}
					}
				}

				ViewState["MaxPage"]=MaxPage;
				lnkFirst.Text=ShowFirstCaption ;
				lnkPrev.Text=ShowPrevCaption ;
				lnkNext.Text=ShowNextCaption ;
				lnkLast.Text=ShowLastCaption ;
				lblPrev.Text=ShowPrevCaption ;
				lblNext.Text=ShowNextCaption ;
				lblLast.Text=ShowLastCaption ;
				lblFirst.Text=ShowFirstCaption ;
				lblShowTotal.Text=ShowTotalString+' '+MaxPage.ToString();
				Refresh_Components();
			}
			else
			{
				MaxPage=(int)ViewState["MaxPage"];
				try{
					 CurrentPage=(int)ViewState["CurrPage"];}
				 catch{CurrentPage=1;}
			}
		}

		private void Refresh_Components()
		{
			if(ShowFirst) First_Create();
			if(ShowLast) Last_Create();
			if(ShowPrev) Prev_Create();
			if(ShowNext) Next_Create();
			Show_Pager();
				
			NavigateCompleted(this,CurrentPage);
		
		}
		
		protected void Repeater1_ItemDataBound(object source, RepeaterItemEventArgs e)
			{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
			if(CssClass!=null){
				try
				{
				((LinkButton)e.Item.FindControl("LinkButton1")).CssClass=CssClass;
				}
				catch{}
			}

			   if(style!=null)
				{string[] pairs=style.Split(new Char[] {';'});
					string key,val;
					for(int i=0;i<pairs.Length;i++)
					{
						try
						{key=pairs[i].Split(new Char[] {':'})[0].Trim();
						 val=pairs[i].Split(new Char[] {':'})[1].Trim();
						((LinkButton)e.Item.FindControl("LinkButton1")).Style.Add(key,val);
						
						}
						catch{}
					}
				}
			}
			
			}
		
		private void Show_Pager()
		{	System.Collections.ArrayList  values = new System.Collections.ArrayList();
			int StartRange;
			switch(PagerStyle)
			{
				case PagerStyleEnum.PageNumberOnly:
					Repeater1.Visible=false;
					Current.Visible=true;
					Current.Text=CurrentPage.ToString(); 
					lblShowTotal.Visible =ShowTotal;
					break;
				case PagerStyleEnum.Centered:
					Repeater1.Visible=true;
					Current.Visible=false;
					
					StartRange=(CurrentPage<=(NumberOfPages/2))?1:CurrentPage-(NumberOfPages/2);
					StartRange=(StartRange>=MaxPage-NumberOfPages+1)?MaxPage-NumberOfPages+1:StartRange;
					StartRange=(StartRange<=0)?1:StartRange;
					for(int i=StartRange;i<(StartRange+NumberOfPages)&&i<=MaxPage;i++)
					{values.Add(new PagingData(i.ToString(), CurrentPage!=i));}
					
					Repeater1.DataSource = values;
					Repeater1.DataBind();
					lblShowTotal.Visible =ShowTotal;
					break;
				case PagerStyleEnum.Moved:
					
					StartRange=((CurrentPage-1)/NumberOfPages)*NumberOfPages+1;
					if(StartRange!=1) values.Add(new PagingData('<'+(StartRange-1).ToString(), true));
					for(int i=StartRange;(i<(StartRange+NumberOfPages))&&i<=MaxPage;i++)
					{values.Add(new PagingData(i.ToString(), CurrentPage!=i));}
					if(StartRange+NumberOfPages<=MaxPage) values.Add(new PagingData((StartRange+NumberOfPages).ToString()+'>', true));
					
					Repeater1.DataSource = values;
					Repeater1.DataBind();

					Repeater1.Visible=true;
					Current.Visible=false;
					lblShowTotal.Visible =ShowTotal;
					break;
				case PagerStyleEnum.NoPager:
					Repeater1.Visible=false;
					Current.Visible=false;
					OpenPar.Visible=false;
					ClosePar.Visible=false;
					lblShowTotal.Visible =false;
					break;
			}

		}
		private void First_Create()
		{
			if (CurrentPage==1){lblFirst.Visible=true;lnkFirst.Visible=false;}
			else{lblFirst.Visible=false;lnkFirst.Visible=true;};
		}

		private void Last_Create()
		{
			if (CurrentPage==MaxPage){lblLast.Visible=true;lnkLast.Visible=false;}
			else{lblLast.Visible=false;lnkLast.Visible=true;};
		}

		private void Next_Create()
		{
			if (CurrentPage==MaxPage){lblNext.Visible=true;lnkNext.Visible=false;}
			else{lblNext.Visible=false;lnkNext.Visible=true;};
		}

		private void Prev_Create()
		{
			if (CurrentPage==1){lblPrev.Visible=true;lnkPrev.Visible=false;}
			else{lblPrev.Visible=false;lnkPrev.Visible=true;};
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lnkLast.Click += new System.EventHandler(this.lnkLast_Click);
			this.lnkNext.Click += new System.EventHandler(this.lnkNext_Click);
			this.lnkFirst.Click += new System.EventHandler(this.lnkFirst_Click);
			this.lnkPrev.Click += new System.EventHandler(this.lnkPrev_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnkFirst_Click(object sender, System.EventArgs e)
		{
			CurrentPage=1;
			ViewState["CurrPage"]=CurrentPage;
			Refresh_Components();
		}

		private void lnkPrev_Click(object sender, System.EventArgs e)
		{
			CurrentPage--;
			ViewState["CurrPage"]=CurrentPage;
			Refresh_Components();
			
		}

		private void lnkNext_Click(object sender, System.EventArgs e)
		{
			CurrentPage++;
			ViewState["CurrPage"]=CurrentPage;
			Refresh_Components();
			
		}

		private void lnkLast_Click(object sender, System.EventArgs e)
		{
			CurrentPage=MaxPage;
			ViewState["CurrPage"]=CurrentPage;
			Refresh_Components();

		}

		protected void Repeater1_ItemCommand(Object Sender, RepeaterCommandEventArgs e) 
		{   
			if(PagerStyle!=PagerStyleEnum.Moved){
				CurrentPage=Int16.Parse(e.CommandArgument.ToString ());
				ViewState["CurrPage"]=CurrentPage;
				Refresh_Components();
			}else{
				string temp=e.CommandArgument.ToString();
				PagerStartPressed=temp.StartsWith("<");
				PagerEndPressed=temp.EndsWith(">");
				CurrentPage=PagerStartPressed?Int16.Parse(temp.TrimStart('<')):PagerEndPressed?Int16.Parse(temp.ToString().TrimEnd('>')):Int16.Parse(temp);
				ViewState["CurrPage"]=CurrentPage;
				Refresh_Components();
				
			}
		}    
 

	}
}