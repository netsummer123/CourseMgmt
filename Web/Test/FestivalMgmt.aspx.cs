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


public partial class FestivalMgmt : Page
{
    protected int FestivalYear
    {
        get
        {
            if (ViewState["FestivalYear"] == null)
            {
                if (Request["year"] == null)
                    return DateTime.Now.Year;
                else
                    return int.Parse(Request["year"]);
            }
            else
                return (int) ViewState["FestivalYear"];
        }
        set { ViewState["FestivalYear"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
    }
}