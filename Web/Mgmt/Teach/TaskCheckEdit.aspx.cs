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

namespace CourseMgmt.Web.Mgmt.Teach
{
    public partial class TaskCheckEdit : BasePage
    {
        #region 属性

        public int StudentID
        {
            get
            {
                return ViewState["StudentID"] != null ? (int)ViewState["StudentID"] : int.MinValue;
            }
            set
            {
                ViewState["StudentID"] = value;
            }
        }

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
                LoadData();
            }
        }

        private void InitData()
        {
            StudentID = Convert.ToInt32(Request["StudentID"]);
            CourseID = Convert.ToInt32(Request["CourseID"]);
        }

        private void LoadData()
        {
            if (StudentID < 0 || CourseID < 0)
                return;

            var preform = new SysPerform(CourseID, StudentID);
            preform.Load();

            phData.BindObjectToControls(preform, "tbx");
            tbxRoutineScore1.Text = preform.RoutineScore1.ToString("0");
            tbxRoutineScore2.Text = preform.RoutineScore2.ToString("0");
            tbxRoutineScore3.Text = preform.RoutineScore3.ToString("0");
            tbxRoutineScore4.Text = preform.RoutineScore4.ToString("0");

            //默认
            //if (preform.FinalScoreTime == DateTime.MinValue)
            //{
            //    tbxRoutineScore3.Text = "0";
            //    tbxRoutineScore4.Text = "0";
            //}
        }

        private bool Check()
        {

            return true;
        }

        private void SetData(SysPerform preform)
        {
            preform.RoutineScore1 = tbxRoutineScore1.Text.ToInt32();
            preform.RoutineScore2 = tbxRoutineScore2.Text.ToInt32();
            preform.RoutineScore3 = tbxRoutineScore3.Text.ToInt32();
            preform.RoutineScore4 = tbxRoutineScore4.Text.ToInt32();
            preform.RoutineScoreTime = DateTime.Now;

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
            preform.FinalScoreTime = DateTime.Now;

            preform.UpdateTime = DateTime.Now;
        }

        private void SaveData()
        {
            if (CourseID > 0 && StudentID > 0)
            {
                var preform = new SysPerform(CourseID, StudentID);
                preform.Load();
                SetData(preform);
                preform.Update();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("TaskCheckList.aspx");
        }

    }
}