using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseMgmt.Web.Common;

namespace CourseMgmt.Web
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies.Clear();
            Session.Clear();
            Session.Abandon();

            Response.Redirect(SysConsts.SignInPath);
        }
    }
}
