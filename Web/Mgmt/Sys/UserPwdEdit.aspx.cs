using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;
using CourseMgmt.BizLogic.Util;

namespace CourseMgmt.Web.Mgmt.Sys
{
    public partial class UserPwdEdit : BasePage
    {
        #region 属性
        public int UserID
        {
            get
            {
                return ViewState["UserID"] != null ? (int)ViewState["UserID"] : int.MinValue;
            }
            set
            {
                ViewState["UserID"] = value;
            }
        }

        #endregion

        /// <summary>
        /// 页面载入初始化.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitData();

                LoadData();
            }
        }

        private void InitData()
        {
            //UserID传值代表管理员重置密码，需要判断当前用户角色，否则，代表自己修改密码
            if (!string.IsNullOrEmpty(Request["UserID"]))
            {
                if (CurrentUser.IsSysAdmin)
                {
                    UserID = Convert.ToInt32(Request.QueryString["UserID"]);
                }
                else
                {
                    NotAuthorized();
                    UserID = -1;
                }
            }
            else
            {
                UserID = CurrentUser.ID;
                phPwdCheck.Visible = true;
            }
        }
        private void LoadData()
        {
        }

        private bool Check()
        {
            //校验老密码
            if (phPwdCheck.Visible)
            {
                var oldUser = new SysUser(UserID);
                oldUser.Load();
                if (oldUser.Password != tbxOldPassword.Text.MD5Encrypt())
                {
                    Warning("旧密码不正确，请重新输入！");
                    return false;
                }
            }

            if (tbxRepeatPassword.Text.Length < 6)
            {
                Warning("密码至少输入6位！");
                return false;
            }

            if (tbxRepeatPassword.Text != tbxPassword.Text)
            {
                Warning("两次输入密码不一致，请重新输入！");
                return false;
            }

            return true;
        }

        private void SetData(SysUser user)
        {
            user.Password = tbxPassword.Text.MD5Encrypt();
            user.UpdateTime = DateTime.Now;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            //修改
            if (UserID > 0)
            {
                var user = new SysUser(UserID);
                user.Load();
                SetData(user);
                user.Update();
            }

            Success("保存成功");
        }

    }
}
