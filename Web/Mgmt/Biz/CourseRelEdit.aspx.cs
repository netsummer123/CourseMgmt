using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;
using CourseMgmt.BizLogic.Util;
using Wicresoft.Common;

namespace CourseMgmt.Web.Mgmt.Biz
{
    public partial class CourseRelEdit : BasePage
    {
        #region 属性
        public string SelectedDeptIds
        {
            get
            {
                return hdSelectedTreeItemId.Value;
            }
            set
            {
                hdSelectedTreeItemId.Value = value;
            }
        }

        public int TeacherID
        {
            get { return tbxTeacher.SelectedValue.ToInt32(); }
            set { tbxTeacher.SelectedValue = value.ToString(); }
        }

        public int CourseID
        {
            get { return ViewState["CourseID"] != null ? (int)ViewState["CourseID"] : int.MinValue; }
            set { ViewState["CourseID"] = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

                //判断是修改还是新增
                if (!string.IsNullOrEmpty(Request["TeacherID"]))
                {
                    TeacherID = Convert.ToInt32(Request["TeacherID"]);
                    LoadData();
                }
            }
        }

        private void InitData()
        {
            CourseID = Request.QueryString["CourseID"].ToInt32();

            var teacherList = DataAccess.Select(typeof(SysUser),
                string.Format("IsDeleted=0 AND {0}={1}", SysUser.SQLCOL_USERTYPE, (int)SysUserType.Teacher),
                true) as IList<SysUser>;
            tbxTeacher.BindDataAppendEmptyItem(teacherList, "RealName", "ID");

            tbxRegYear.BindData(DateHelper.GetYearBetween(DateTime.Now.Year, SysConsts.StartYear), "value", "key");

        }

        private void LoadData()
        {
            if (TeacherID < 0)
                return;

            var courseRelList = DataAccess.Select(typeof(SysCourseRel),
                 string.Format("{0}='{1}' AND {2}='{3}'",
                    SysCourseRel.SQLCOL_COURSEID, CourseID, SysCourseRel.SQLCOL_TEACHERID, TeacherID), true) as IList<SysCourseRel>;
            SelectedDeptIds = string.Join(",", courseRelList.Select(r => r.DepartmentID.ToString()).ToArray());
        }

        private bool Check()
        {
            if (SelectedDeptIds.IsNullOrEmpty())
            {
                Warning("请选择班级");
                return false;
            }

            return true;
        }


        private void SaveData()
        {
            var teacher = new SysUser(TeacherID);
            teacher.Load();

            #region 保存关系
            DataAccess.Delete(typeof(SysCourseRel), string.Format("{0}='{1}' AND {2}='{3}'",
                    SysCourseRel.SQLCOL_COURSEID, CourseID, SysCourseRel.SQLCOL_TEACHERID, TeacherID));
            //从隐藏域中读取勾选的菜单值

            var deptList = DataAccess.Select(typeof(SysDepartment),
                string.Format("IsDeleted=0 AND {0} IN ({1})", SysDepartment.SQLCOL_ID,
                    SelectedDeptIds.TrimStart(',').TrimEnd(',')), true) as IList<SysDepartment>;
            foreach (var dept in deptList)
            {
                var rel = new SysCourseRel(CourseID, TeacherID, dept.ID);
                rel.TeacherName = tbxTeacher.SelectedItem.Text;
                rel.DepartmentName = dept.Name;
                rel.RegYear = tbxRegYear.SelectedValue.ToInt32();
                rel.Save();
            }
            #endregion


        }

        protected void tbxRegYear_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedDeptIds = string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("CourseRelList.aspx?CourseID=" + CourseID);
        }

        protected void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("CourseRelEdit.aspx?CourseID=" + CourseID);
        }

    }
}