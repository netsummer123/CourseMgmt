using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class FestivalList :Page 
{
    protected int FestivalYear
    {
        get
        {
            if (ViewState["FestivalYear"] == null)
            {
                return DateTime.Now.Year;
            }
            else
                return (int)ViewState["FestivalYear"];
        }
        set
        {
            ViewState["FestivalYear"] = value;
        }
    }

 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindYear();
        }
    }

    protected void BindYear()
    {
        int year = DateTime.Now.Year;

    }
}
