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

namespace CourseMgmt.Web.Mgmt.Stu
{
    public partial class TaskEdit : BasePage
    {
        #region 属性

        public int TaskID
        {
            get
            {
                return ViewState["TaskID"] != null ? (int)ViewState["TaskID"] : int.MinValue;
            }
            set
            {
                ViewState["TaskID"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

                //判断是修改还是新增
                if (!string.IsNullOrEmpty(Request["TaskID"]))
                {
                    TaskID = Convert.ToInt32(Request["TaskID"]);
                    LoadData();
                }
            }
        }

        private void InitData()
        {
            tbxCategoryID.BindDataAppendEmptyItem(typeof(TaskCategory).GetValueDescriptionCollection(), "value", "key");
            tbxCourseID.BindDataAppendEmptyItem(
                CourseService.GetAvailCourseList(CurrentUser.DepartmentID, DateTime.Now), "Name", "ID");
        }

        private void LoadData()
        {
            if (TaskID < 0)
                return;

            var task = new SysTask(TaskID);
            task.Load();

            phData.BindObjectToControls(task, "tbx");
        }

        private bool Check()
        {
            var whereClause = string.Format(" {0}='{1}' AND {2}='{3}' AND {4}='{5}'",
                SysTask.SQLCOL_STUDENTID, CurrentUser.ID, SysTask.SQLCOL_COURSEID, tbxCourseID.SelectedValue,
                SysTask.SQLCOL_CATEGORYID, tbxCategoryID.SelectedValue);
            var count = DataAccess.Count(typeof(SysTask), whereClause);
            if (count > 0)
            {
                var exsitTask = new SysTask();
                exsitTask.Load(whereClause);
                if (TaskID <= 0 || TaskID != exsitTask.ID)
                {
                    RegisterJsAjax("-1", "alert('每个作业项目只能提交一次，无法重复提交');");
                    return false;
                }
            }

            return true;
        }

        private void SetData(SysTask task)
        {
            phData.BindControlsToObject(task, "tbx");

            task.DepartmentID = CurrentUser.DepartmentID;
            task.StudentID = CurrentUser.ID;
            task.FinishTime = DateTime.Now;
            task.CourseName = tbxCourseID.SelectedItem.Text;

            task.UpdateTime = DateTime.Now;
        }

        private void SaveData()
        {
            var task = new SysTask();
            if (TaskID > 0)
            {
                task.LoadByIdentity(TaskID);
                SetData(task);
                task.Update();
            }
            else
            {
                SetData(task);
                task.Status = (int)TaskStatus.ToCorrect;
                task.Add();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("TaskList.aspx");
        }

        protected void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("TaskEdit.aspx");
        }

    }
}