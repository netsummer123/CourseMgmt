using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class Register : System.Web.UI.Page
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
            tbxDepartmentType.BindDataAppendEmptyItem(typeof(SysDeptType).GetValueDescriptionCollection(), "value",
             "key");
            tbxRegYear.BindDataAppendEmptyItem(DateHelper.GetYearBetween(DateTime.Now.Year, SysConsts.StartYear), "value", "key");

            tbxSex.BindDataAppendEmptyItem(typeof(SexType).GetValueDescriptionCollection(), "Value", "Key");
        }

        private void BindDept(int deptType, int year)
        {
            tbxDepartmentID.Items.Clear();

            var sb = new StringBuilder(" IsDeleted = 0");
            sb.AppendFormat(" AND {0}={1}", SysDepartment.SQLCOL_DEPARTMENTTYPE, deptType);
            sb.AppendFormat(" AND {0}={1}", SysDepartment.SQLCOL_REGYEAR, year);
            var deptList = DataAccess.Select(typeof(SysDepartment), sb.ToString(), true) as IList<SysDepartment>;
            tbxDepartmentID.BindDataAppendEmptyItem(deptList, "Name", "ID");
        }

        private void LoadData()
        {
            if (UserID < 0)
                return;

            var user = new SysUser(UserID);
            user.Load();

            phData.BindObjectToControls(user, "tbx");
            tbxUserName.Attributes.Add("readonly", "readonly");

            BindDept(user.DepartmentType, user.RegYear);
            var li = tbxDepartmentID.Items.FindByValue(user.DepartmentID.ToString());
            if (li != null) li.Selected = true;
        }

        private bool Check()
        {
            if (UserService.CheckUserExsit(tbxUserName.Text, UserID))
            {
                Warning("学号已被使用");
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
                //学生初始化
                user.UserType = (int)SysUserType.Student;
                user.Password = tbxPassword.Text.MD5Hash().ToUpper();
                user.RoleIDs = "1";
                user.IsDeleted = false;

                var deptId = Convert.ToInt32(tbxDepartmentID.SelectedValue);
                var dept = new SysDepartment(deptId);
                dept.Load();
                user.DepartmentID = dept.ID;
                user.DepartmentName = dept.Name;
                user.BaseDeptID = dept.BaseDeptID;
                user.BaseDeptName = dept.BaseDeptName;
                user.DepartmentType = dept.DepartmentType;
                user.OrderNum = 0;

                user.Add();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Warning("注册成功，请重新登录", "parent.closeModal();");
        }


        protected void tbxDepartmentType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindDept(tbxDepartmentType.SelectedValue.ToInt32(), tbxRegYear.SelectedValue.ToInt32());
        }

        protected void tbxRegYear_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindDept(tbxDepartmentType.SelectedValue.ToInt32(), tbxRegYear.SelectedValue.ToInt32());
        }

        /// <summary>
        /// 弹出警告信息。
        /// </summary>
        private void Warning(string message)
        {
            RegisterJsAjax(Guid.NewGuid().ToString(), "alert('" + message + "');");
        }

        private void Warning(string message, string afterOnScript)
        {
            RegisterJsAjax(Guid.NewGuid().ToString(), "alert('" + message + "');" + afterOnScript);
        }

        private void RegisterJsAjax(string key, string function)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), key, function, true);
        }

    }
}