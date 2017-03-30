using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using CourseMgmt.Web.Metro.Control;

namespace CourseMgmt.Web.Metro
{
    /// <summary>
    /// SubMenuHandler 的摘要说明
    /// </summary>
    public class SubMenuHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            var menuId = Convert.ToInt32(context.Request["menuId"]);

            var page = new Page();
            var control = page.LoadControl("~/Metro/Control/SubMenu.ascx") as SubMenu;
            control.LoadMenu(menuId);

            var tw = new StringWriter();
            var writer = new HtmlTextWriter(tw);
            control.RenderControl(writer);
            context.Response.ContentType = "text/plain";
            context.Response.Write(writer.InnerWriter.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}