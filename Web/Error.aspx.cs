using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CourseMgmt.Web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                Exception innerException = ex.InnerException;
                if (innerException != null)
                {
                    //if (innerException is AccessForbiddenException)
                    //{

                    //    HttpContext.Current.Response.StatusCode = 403;
                    //    this.lblTitle.Text = "403 禁止访问";
                    //    this.lblError.Text = "您没有访问权限.";

                    //}
                    //else
                    //{
                    HttpContext.Current.Response.StatusCode = 500;
                    this.lblTitle.Text = "500 系统错误:";
                    this.lblError.Text = innerException.Message;
                    //}
                }
                else
                {
                    HttpContext.Current.Response.StatusCode = 500;
                    this.lblTitle.Text = "500 系统错误:";
                    this.lblError.Text = ex.Message;
                }
            }
            else
            {
                this.lblTitle.Text = "系统错误...";
            }
        }
    }
}
