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

public partial class FestivalDutyArrange : Page
{
    protected long ArrangeID
    {
        get
        {
            if (ViewState["ArrangeID"] == null)
            {
                if (Request["id"] == null)
                    return long.MinValue;
                else
                    return long.Parse(Request["id"]);
            }
            else
                return (long)ViewState["ArrangeID"];
        }
        set
        {
            ViewState["ArrangeID"] = value;
        }
    }

   

    protected string EditType
    {
        get
        {
            if (ViewState["EditType"] == null)
            {
                if (Request["type"] == null)
                    return "add";
                else
                    return Request["type"];
            }
            else
                return ViewState["EditType"].ToString();

        }
        set
        {
            ViewState["EditType"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      

    }

    protected void BindData()
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
       
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
     
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
      
    }

    protected void btnMessage_Click(object sender, EventArgs e)
    {
      
    }

    protected void btnSelectUser_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "selectuser", "<script>SelectUserWithoutType();</script>");
    }
}
