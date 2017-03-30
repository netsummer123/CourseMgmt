using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;
using CourseMgmt.BizLogic.Util;
using Wicresoft.Common;

namespace CourseMgmt.Web.Mgmt.Sys
{
    public partial class UserEdit : BasePage
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
            tbxSex.BindDataAppendEmptyItem(typeof(SexType).GetValueDescriptionCollection(), "Value", "Key");

            UserID = CurrentUser.ID;
            if (CurrentUser.UserType == (int)SysUserType.Teacher)
            {
                ltlTitle.Text = "工号";
            }
            if (CurrentUser.UserType == (int)SysUserType.Student)
            {
                ltlTitle.Text = "学号";
            }
        }
        private void LoadData()
        {
            if (UserID < 0)
                return;

            var user = new SysUser(UserID);
            user.Load();

            phData.BindObjectToControls(user, "tbx");
            tbxUserName.Attributes.Add("readonly", "readonly");
        }

        private bool Check()
        {

            return true;
        }

        private void SetData(SysUser user)
        {
            phData.BindControlsToObject(user, "tbx");

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
