using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Page_AutoRefreshQueueAllSend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
       
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
        BindData();
    }

    protected void pager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

}