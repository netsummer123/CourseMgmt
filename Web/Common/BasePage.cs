using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace CourseMgmt.Web.Common
{
    public class BasePage : Page
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

        #region 公共方法
        /// <summary>
        /// 跳转至无权访问页面
        /// </summary>
        protected void NotAuthorized()
        {
            Server.Transfer("~/403.htm", false);
        }

        /// <summary>
        /// 移除url中域名及虚拟应用名
        /// </summary>
        /// <param name="url"></param>
        protected string RemoveAppPath(string url)
        {
            if (Request.ApplicationPath != null)
                return url.Replace(Request.ApplicationPath, "");
            return url;
        }

        /// <summary>
        /// 截取指定长度的字符串
        /// </summary>
        /// <param name="val"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string SubString(object val, int length)
        {
            if (val == null)
                return "";
            var strVal = val.ToString();
            int valLen = strVal.Length;
            if (valLen < length)
                return strVal;

            return strVal.Substring(0, length) + "...";
        }

        /// <summary>
        /// 使用asp.net执行指定名称的js;
        /// </summary>
        protected void RegisterJs(string key, string function)
        {
            ClientScript.RegisterStartupScript(this.GetType(), key, function, true);
        }

        /// <summary>
        /// 使用asp.net ajax执行指定名称的js;
        /// </summary>
        protected void RegisterJsAjax(string key, string function)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), key, function, true);
        }

        #region 消息提示
        /// <summary>
        /// 消息提醒js key计数
        /// </summary>
        private int _notyNum = 0;

        /// <summary>
        /// 弹出警告信息。
        /// </summary>
        public void Warning(string message)
        {
            _notyNum++;
            RegisterJsAjax("noty" + _notyNum, string.Format("warning('{0}');", message));
        }

        /// <summary>
        /// 弹出警告信息。
        /// </summary>
        public void Danger(string message)
        {
            _notyNum++;
            RegisterJsAjax("noty" + _notyNum, string.Format("danger('{0}');", message));
        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        public void Info(string message)
        {
            _notyNum++;
            RegisterJsAjax("noty" + _notyNum, string.Format("info('{0}');", message));
        }

        /// <summary>
        /// 弹出成功信息
        /// </summary>
        public void Success(string message)
        {
            _notyNum++;
            RegisterJsAjax("noty" + _notyNum, string.Format("success('{0}');", message));
        }

        /// <summary>
        /// 弹出确认框
        /// </summary>
        public void Confirm(string message)
        {
            _notyNum++;
            RegisterJsAjax("noty" + _notyNum, string.Format("confirm('{0}');", message));
        }

        #endregion

        #endregion
    }
}
