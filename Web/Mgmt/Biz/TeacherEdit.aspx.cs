using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseMgmt.BizLogic.Service;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;
using CourseMgmt.BizLogic.Util;
using Wicresoft.Common;

namespace CourseMgmt.Web.Mgmt.Biz
{
    public partial class TeacherEdit : BasePage
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

                //判断是修改还是新增
                if (!string.IsNullOrEmpty(Request["UserID"]))
                {
                    UserID = Convert.ToInt32(Request["UserID"]);
                    LoadData();
                }
            }
        }

        private void InitData()
        {
            tbxSex.BindDataAppendEmptyItem(typeof(SexType).GetValueDescriptionCollection(), "Value", "Key");
            tbxOrderNum.Text = "0";
        }

        private void LoadData()
        {
            if (UserID < 0)
                return;

            var user = new SysUser(UserID);
            user.Load();

            phData.BindObjectToControls(user, "tbx");
        }

        private bool Check()
        {
            if (UserService.CheckUserExsit(tbxUserName.Text, UserID))
            {
                Warning("工号已被使用");
                return false;
            }

            return true;
        }

        private void SetData(SysUser user)
        {
            phData.BindControlsToObject(user, "tbx");

            user.UpdateTime = DateTime.Now;
        }

        private void SaveData()
        {
            var user = new SysUser();
            if (UserID > 0)
            {
                user.LoadByIdentity(UserID);
                SetData(user);
                user.Update();
            }
            else
            {
                SetData(user);
                //老师初始化
                user.UserType = (int)SysUserType.Teacher;
                user.Password = SysConsts.InitPassword.MD5Hash().ToUpper();
                user.RoleIDs = "2";
                user.IsDeleted = false;

                var dept = new SysDepartment(SysConsts.TeacherDeptID);
                dept.Load();
                user.DepartmentID = dept.ID;
                user.DepartmentName = dept.Name;
                user.BaseDeptID = dept.BaseDeptID;
                user.BaseDeptName = dept.BaseDeptName;
                user.DepartmentType = dept.DepartmentType;

                user.Add();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("TeacherList.aspx");
        }

        protected void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("TeacherEdit.aspx");
        }

    }
}