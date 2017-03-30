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
    public partial class ViewTaskEdit : BasePage
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

        }

        private void LoadData()
        {
            if (TaskID < 0)
                return;

            var task = new SysTask(TaskID);
            task.Load();

            phData.BindObjectToControls(task, "tbx");

            tbxFinishTime.Text = task.FinishTime.ToString("yyyy-MM-dd");
            tbxCategory.Text = EnumTypeHelper.GetDescriptionFromEnum(typeof(TaskCategory), task.CategoryID);
            tbxScore.Text = task.Score > 0 ? task.Score.ToString("0") : string.Empty;
            tbxCounter.Text = task.Content.CleanHtmlTag().Replace("\r", "").Replace("\n", "").Replace("&nbsp;", "").Length.ToString();
        }

        private bool Check()
        {

            return true;
        }

        private void SetData(SysTask task)
        {
            task.Score = tbxScore.Text.ToInt32();
            task.ScoreTime = DateTime.Now;
            task.Status = (int)TaskStatus.Corrected;
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
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("ViewTaskList.aspx");
        }

    }
}