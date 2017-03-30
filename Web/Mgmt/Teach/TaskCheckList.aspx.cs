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
    public partial class TaskCheckList : BasePage
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
            if (searchCourseID.SelectedIndex <= 0)
                return;

            IsCourseTeacher = DataAccess.Count(typeof(SysCourseRel),
            string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}'",
                SysCourseRel.SQLCOL_COURSEID, searchCourseID.SelectedValue,
                SysCourseRel.SQLCOL_DEPARTMENTID, searchDepartmentID.SelectedValue,
                SysCourseRel.SQLCOL_TEACHERID, CurrentUser.ID)) > 0;

            var orderby = SysPerform.SQLCOL_USERNAME;

            var sb = new StringBuilder("1=1");
            if (searchDepartmentID.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", SysPerform.SQLCOL_DEPARTMENTID, searchDepartmentID.SelectedValue);
            }
            if (searchCourseID.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", SysPerform.SQLCOL_COURSEID, searchCourseID.SelectedValue);
            }

            int count = 0;
            rpList.DataSource = DataAccess.Select(typeof(SysPerform), sb.ToString(), orderby, true) as IList<SysPerform>;
            rpList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (searchCourseID.SelectedIndex <= 0)
            {
                Warning("请选择课程");
                return;
            }

            CalcPreform(searchDepartmentID.SelectedValue.ToInt32(), searchCourseID.SelectedValue.ToInt32());

            LoadData();

            phSearch.PersistSearchCondition("search", "AspNetPager1");
        }

        private void CalcPreform(int deptId, int courseId)
        {
            var report = new SysPerformReport(courseId, deptId);
            if (!report.Load())
            {
                report.Status = 10;
            }

            report.TeacherID = CurrentUser.ID;
            report.TeacherName = CurrentUser.RealName;
            report.CourseName = searchCourseID.SelectedItem.Text;
            report.DepartmentName = searchDepartmentID.SelectedItem.Text;

            var dept = new SysDepartment(deptId);
            dept.Load();
            report.RegYear = dept.RegYear;
            report.DepartmentType = dept.DepartmentType;

            report.UpdateTime = DateTime.Now;
            report.Save();

            var studentList = DataAccess.Select(typeof(SysUser),
                string.Format("IsDeleted=0 AND {0}='{1}' AND {2}='{3}'", SysUser.SQLCOL_DEPARTMENTID, deptId,
                    SysUser.SQLCOL_USERTYPE, (int)SysUserType.Student), true) as IList<SysUser>;
            var taskList = DataAccess.Select(typeof(SysTask),
                string.Format("{0}='{1}' AND {2}='{3}'", SysTask.SQLCOL_DEPARTMENTID, deptId,
                    SysTask.SQLCOL_COURSEID, courseId), true) as IList<SysTask>;
            foreach (var student in studentList)
            {
                var preform = new SysPerform(courseId, student.ID);
                if (!preform.Load())
                {
                    preform.RoutineScore1 = 10;
                    preform.RoutineScore2 = 10;
                    preform.RoutineScore3 = 0;//5;
                    preform.RoutineScore4 = 0;//10;
                }

                preform.UserName = student.UserName;
                preform.RealName = student.RealName;
                preform.DepartmentID = student.DepartmentID;

                preform.TaskScore1 = GetTaskScore(taskList, student.ID, (int)TaskCategory.Task1);
                preform.TaskScore2 = GetTaskScore(taskList, student.ID, (int)TaskCategory.Task2);
                preform.TaskScore3 = GetTaskScore(taskList, student.ID, (int)TaskCategory.Task3);
                preform.TaskScore4 = GetTaskScore(taskList, student.ID, (int)TaskCategory.Task4);
                preform.TaskScore5 = GetTaskScore(taskList, student.ID, (int)TaskCategory.Task5);
                preform.TaskScore6 = GetTaskScore(taskList, student.ID, (int)TaskCategory.Task6);
                preform.TaskScore7 = GetTaskScore(taskList, student.ID, (int)TaskCategory.Task7);

                preform.FinalScore = preform.RoutineScore1 +
                                     preform.RoutineScore2 +
                                     preform.RoutineScore3 +
                                     preform.RoutineScore4 +
                                     preform.TaskScore1 +
                                     preform.TaskScore2 +
                                     preform.TaskScore3 +
                                     preform.TaskScore4 +
                                     preform.TaskScore5 +
                                     preform.TaskScore6 +
                                     preform.TaskScore7;
                preform.UpdateTime = DateTime.Now;
                preform.Save();
            }
        }

        private decimal GetTaskScore(IList<SysTask> taskList, int studentId, int categoryId)
        {
            var task = taskList.FirstOrDefault(t => t.StudentID == studentId && t.CategoryID == categoryId);
            if (task != null && task.Score > 0)
                return task.Score;
            return 0;
        }


        protected void rpList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

        }

        protected void rpList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                if (IsCourseTeacher)
                {
                    var phItemOp = e.Item.FindControl("phItemOp") as PlaceHolder;
                    phItemOp.Visible = true;
                }
            }
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