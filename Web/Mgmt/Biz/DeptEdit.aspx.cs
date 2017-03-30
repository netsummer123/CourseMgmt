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

namespace CourseMgmt.Web.Mgmt.Biz
{
    public partial class DeptEdit : BasePage
    {
        #region 属性

        public int DeptID
        {
            get
            {
                return ViewState["DeptID"] != null ? (int)ViewState["DeptID"] : int.MinValue;
            }
            set
            {
                ViewState["DeptID"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

                //判断是修改还是新增
                if (!string.IsNullOrEmpty(Request["DeptID"]))
                {
                    DeptID = Convert.ToInt32(Request["DeptID"]);
                    LoadData();
                }
            }
        }

        private void InitData()
        {
            tbxDepartmentType.BindDataAppendEmptyItem(typeof(SysDeptType).GetValueDescriptionCollection(), "value",
                "key");
            tbxRegYear.BindDataAppendEmptyItem(DateHelper.GetYearBetween(DateTime.Now.Year, SysConsts.StartYear), "value", "key");
            tbxOrderNum.Text = "0";
        }

        private void LoadData()
        {
            if (DeptID < 0)
                return;

            var dept = new SysDepartment(DeptID);
            dept.Load();

            phData.BindObjectToControls(dept, "tbx");

        }

        private bool Check()
        {
            return true;
        }

        private void SetData(SysDepartment dept)
        {
            phData.BindControlsToObject(dept, "tbx");

            dept.UpdateTime = DateTime.Now;
        }

        private void SaveData()
        {
            var dept = new SysDepartment();
            if (DeptID > 0)
            {
                dept.LoadByIdentity(DeptID);
                SetData(dept);
                dept.Update();
            }
            else
            {
                SetData(dept);
                //班级初始化
                dept.IsDeleted = false;

                var rootDept = new SysDepartment(SysConsts.RootDeptID);
                rootDept.Load();
                dept.BaseDeptName = rootDept.Name;
                dept.BaseDeptID = rootDept.ID;
                dept.ParentID = rootDept.ID;
                dept.ParentName = rootDept.Name;

                dept.Add();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("DeptList.aspx");
        }

        protected void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("DeptEdit.aspx");
        }

    }
}