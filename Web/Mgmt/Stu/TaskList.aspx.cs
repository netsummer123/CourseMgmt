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

namespace CourseMgmt.Web.Mgmt.Stu
{
    public partial class TaskList : BasePage
    {
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
            searchCourseID.BindDataAppendEmptyItem(
               CourseService.GetCourseListByDeptId(CurrentUser.DepartmentID), "Name", "ID");

            phSearch.LoadSearchCondition("search", "AspNetPager1");
        }

        private void LoadData()
        {
            var orderby = SysTask.SQLCOL_ID + " desc";

            var sb = new StringBuilder("1=1");
            sb.AppendFormat(" AND {0}='{1}'", SysTask.SQLCOL_STUDENTID, CurrentUser.ID);
            if (searchName.Text.Trim() != string.Empty)
            {
                sb.AppendFormat(" AND {0} LIKE '%{1}%' ", SysTask.SQLCOL_TITLE, searchName.Text);
            }
            if (searchCourseID.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", SysTask.SQLCOL_COURSEID, searchCourseID.SelectedValue);
            }

            int count = 0;
            rpList.DataSource = DataAccess.Select(typeof(SysTask), AspNetPager1.CurrentPageIndex - 1, AspNetPager1.PageSize, sb.ToString(), orderby, ref count, true) as IList<SysTask>;
            rpList.DataBind();
            AspNetPager1.RecordCount = count;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            LoadData();

            phSearch.PersistSearchCondition("search", "AspNetPager1");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            LoadData();

            phSearch.PersistSearchCondition("search", "AspNetPager1");
        }

        protected void rpList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Delete")
            {
                DataAccess.Delete(typeof(SysTask), string.Format("{0}='{1}'", SysTask.SQLCOL_ID, id));

                LoadData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("TaskEdit.aspx");
        }

        protected void rpList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var task = e.Item.DataItem as SysTask;
                if (task.Status != (int)TaskStatus.ToCorrect)
                {
                    var phItemOp = e.Item.FindControl("phItemOp") as PlaceHolder;
                    phItemOp.Visible = false;
                }
            }
        }
    }
}