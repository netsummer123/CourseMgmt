using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;
using CourseMgmt.BizLogic.Util;
using Wicresoft.Common;

namespace CourseMgmt.Web
{
    public partial class SignIn : System.Web.UI.Page
    {
        #region 变量 & 属性

        /// <summary>
        /// 消息提醒js key计数
        /// </summary>
        private int _notyNum = 0;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
            }
        }

        public void InitData()
        {
        }

        //登录按钮点击
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbValidateCode.Text))
            {
                Warning("请输入验证码");
                return;
            }
            if (Session["Login_ValidateCode"] == null || Session["Login_ValidateCode"].ToString() != tbValidateCode.Text)
            {
                Warning("验证码输入错误");
                return;
            }
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                Warning("请输入用户名");
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                Warning("请输入密码");
                return;
            }

            CheckValidUser(tbUsername.Text.SQLFilter(), tbPassword.Text.SQLFilter());
        }

        #region 私有方法

        /// <summary>
        /// 校验用户名密码
        /// </summary>
        private void CheckValidUser(string username, string pwd)
        {
            //用户和部门数据从第三方读取
            var userList = DataAccess.Select(typeof(SysUser),
                string.Format("IsDeleted=0 AND {0}='{1}'", SysUser.SQLCOL_USERNAME, username), true) as IList<SysUser>;
            if (userList == null || userList.FirstOrDefault() == null ||
                userList.First().Password != pwd.MD5Encrypt())
            {
                Warning("用户名或密码错误");
                return;
            }

            if (ConfigurationManager.AppSettings["License"].IsNullOrEmpty())
            {
                if (DateTime.Now > DateTime.Parse("2015-07-30"))
                {
                    Warning("系统许可证有效期结束，请联系维护人员");
                    return;
                }
            }

            var currentUser = BaseUser.UserLogin(userList.First());

            //当前用户信息存入Session
            Session[SysConsts.AccountKey] = currentUser;

            Response.Redirect("~/Index.aspx");
        }

        /// <summary>
        /// 弹出警告信息。
        /// </summary>
        private void Warning(string message)
        {
            _notyNum++;
            ClientScript.RegisterStartupScript(this.GetType(), "noty" + _notyNum,
                string.Format("alert('{0}');", message), true);
        }

        #endregion
    }
}