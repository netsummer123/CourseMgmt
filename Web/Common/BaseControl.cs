using System;
using System.Web.UI;

namespace CourseMgmt.Web.Common
{
    public class BaseControl : UserControl
    {
        #region 当前用户
        public BaseUser CurrentUser
        {
            get
            {
                if (Session[SysConsts.AccountKey] == null)
                {
                    return null;
                }
                else
                {
                    return (BaseUser)Session[SysConsts.AccountKey];
                }
            }
            set
            {
                Session[SysConsts.AccountKey] = value;
            }
        }
        #endregion

        protected override void OnInit(EventArgs e)
        {
            if (CurrentUser == null)
            {
                Response.Redirect(SysConsts.SignInPath);
            }

            base.OnInit(e);
        }

        /// <summary>
        /// 跳转至无权访问页面
        /// </summary>
        protected void NotAuthorized()
        {
            Server.Transfer("~/403.htm", false);
        }

        /// <summary>
        /// 使用asp.net ajax执行指定名称的js;
        /// </summary>
        protected void RegisterJsAjax(string key, string function)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), key, function, true);
        }

    }
}
