using System;
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

namespace CourseMgmt.Web.Mgmt.Teach
{
    public partial class TaskNumCheckList : BasePage
    {
        #region 属性

        public bool IsCourseTeacher
        {
            get
            {
                return ViewState["IsCourseTeacher"] != null ? (bool)ViewState["IsCourseTeacher"] : false;
            }
            set
            {
                ViewState["IsCourseTeacher"] = value;
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

                LoadData();
            }
        }

        private void InitData()
        {
            searchDepartmentType.BindDataAppendEmptyItem(typeof(SysDeptType).GetValueDescriptionCollection(), "value", "key");
            searchRegYear.BindDataAppendEmptyItem(DateHelper.GetYearBetween(DateTime.Now.Year, SysConsts.StartYear), "value", "key");

            phSearch.LoadSearchCondition("search", "AspNetPager1");

            BindDept(searchDepartmentType.SelectedValue.ToInt32(), searchRegYear.SelectedValue.ToInt32());
            phSearch.LoadSearchCondition("search", "AspNetPager1");

            BindCourse(searchDepartmentID.SelectedValue.ToInt32());
            phSearch.LoadSearchCondition("search", "AspNetPager1");

        }

        private void LoadData()
        {
            CalcTaskNum(searchDepartmentID.SelectedValue.ToInt32(), searchCourseID.SelectedValue.ToInt32());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (searchCourseID.SelectedIndex <= 0)
            {
                Warning("请选择课程");
                return;
            }

            LoadData();

            phSearch.PersistSearchCondition("search", "AspNetPager1");
        }

        private void CalcTaskNum(int deptId, int courseId)
        {
            var studentList = DataAccess.Select(typeof(SysUser),
                string.Format("IsDeleted=0 AND {0}='{1}' AND {2}='{3}'", SysUser.SQLCOL_DEPARTMENTID, deptId,
                    SysUser.SQLCOL_USERTYPE, (int)SysUserType.Student), SysUser.SQLCOL_USERNAME, true) as IList<SysUser>;
            var taskList = DataAccess.Select(typeof(SysTask),
                string.Format("{0}='{1}' AND {2}='{3}'", SysTask.SQLCOL_DEPARTMENTID, deptId,
                    SysTask.SQLCOL_COURSEID, courseId), true) as IList<SysTask>;

            var list = new List<SysPerform>();

            foreach (var student in studentList)
            {
                var preform = new SysPerform();

                preform.UserName = student.UserName;
                preform.RealName = student.RealName;

                preform.TaskScore1 = GetTaskNum(taskList, student.ID, (int)TaskCategory.Task1);
                preform.TaskScore2 = GetTaskNum(taskList, student.ID, (int)TaskCategory.Task2);
                preform.TaskScore3 = GetTaskNum(taskList, student.ID, (int)TaskCategory.Task3);
                preform.TaskScore4 = GetTaskNum(taskList, student.ID, (int)TaskCategory.Task4);
                preform.TaskScore5 = GetTaskNum(taskList, student.ID, (int)TaskCategory.Task5);
                preform.TaskScore6 = GetTaskNum(taskList, student.ID, (int)TaskCategory.Task6);
                preform.TaskScore7 = GetTaskNum(taskList, student.ID, (int)TaskCategory.Task7);

                list.Add(preform);
            }

            rpList.DataSource = list;
            rpList.DataBind();
        }

        private decimal GetTaskNum(IList<SysTask> taskList, int studentId, int categoryId)
        {
            var task = taskList.FirstOrDefault(t => t.StudentID == studentId && t.CategoryID == categoryId);
            if (task != null)
                return 1;
            return -1;
        }


        protected void rpList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

        }

        protected void rpList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void searchDepartmentType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindDept(searchDepartmentType.SelectedValue.ToInt32(), searchRegYear.SelectedValue.ToInt32());
        }

        protected void searchRegYear_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindDept(searchDepartmentType.SelectedValue.ToInt32(), searchRegYear.SelectedValue.ToInt32());
        }

        protected void searchDepartmentID_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindCourse(searchDepartmentID.SelectedValue.ToInt32());
        }

        private void BindDept(int deptType, int year)
        {
            searchDepartmentID.Items.Clear();

            var sb = new StringBuilder(" IsDeleted = 0");
            sb.AppendFormat(" AND {0}={1}", SysDepartment.SQLCOL_DEPARTMENTTYPE, deptType);
            sb.AppendFormat(" AND {0}={1}", SysDepartment.SQLCOL_REGYEAR, year);
            var deptList = DataAccess.Select(typeof(SysDepartment), sb.ToString(), true) as IList<SysDepartment>;
            searchDepartmentID.BindDataAppendEmptyItem(deptList, "Name", "ID");
        }

        private void BindCourse(int deptId)
        {
            searchCourseID.Items.Clear();
            var courseList = DataAccess.Select(typeof(ViewCourseRel),
                    string.Format("{0}='{1}'", ViewCourseRel.SQLCOL_DEPARTMENTID, deptId), true) as IList<ViewCourseRel>;
            searchCourseID.BindDataAppendEmptyItem(courseList, "Name", "ID");
        }

    }
}