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
    public partial class CourseEdit : BasePage
    {
        #region 属性

        public int CourseID
        {
            get
            {
                return ViewState["CourseID"] != null ? (int)ViewState["CourseID"] : int.MinValue;
            }
            set
            {
                ViewState["CourseID"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

                //判断是修改还是新增
                if (!string.IsNullOrEmpty(Request["CourseID"]))
                {
                    CourseID = Convert.ToInt32(Request["CourseID"]);
                    LoadData();
                }
            }
        }

        private void InitData()
        {
            tbxYear.BindDataAppendEmptyItem(DateHelper.GetYearBetween(DateTime.Now.Year, SysConsts.StartYear), "value", "key");
        }

        private void LoadData()
        {
            if (CourseID < 0)
                return;

            var course = new SysCourse(CourseID);
            course.Load();

            phData.BindObjectToControls(course, "tbx");
            tbxStartTime.Text = course.StartTime.ToString("yyyy-MM-dd");
            tbxEndTime.Text = course.EndTime.ToString("yyyy-MM-dd");
        }

        private bool Check()
        {

            return true;
        }

        private void SetData(SysCourse course)
        {
            phData.BindControlsToObject(course, "tbx");

        }

        private void SaveData()
        {
            var course = new SysCourse();
            if (CourseID > 0)
            {
                course.LoadByIdentity(CourseID);
                SetData(course);
                course.Update();
            }
            else
            {
                SetData(course);
                course.Add();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("CourseList.aspx");
        }

        protected void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("CourseEdit.aspx");
        }

    }
}