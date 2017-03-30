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
    public partial class ViewTaskList : BasePage
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

            searchCategoryID.BindDataAppendEmptyItem(typeof(TaskCategory).GetValueDescriptionCollection(), "value", "key");
            searchStatus.BindDataAppendEmptyItem(typeof(TaskStatus).GetValueDescriptionCollection(), "value", "key");
            searchStatus.SelectedValue = ((int)TaskStatus.ToCorrect).ToString();

            phSearch.LoadSearchCondition("search", "AspNetPager1");

            BindDept(searchDepartmentType.SelectedValue.ToInt32(), searchRegYear.SelectedValue.ToInt32());
            phSearch.LoadSearchCondition("search", "AspNetPager1");

            BindCourse(searchDepartmentID.SelectedValue.ToInt32());
            phSearch.LoadSearchCondition("search", "AspNetPager1");

        }

        private void LoadData()
        {
            IsCourseTeacher = CurrentUser.IsInRole(2);

            var orderby = ViewTask.SQLCOL_ID;

            var sb = new StringBuilder("1=1");
            sb.AppendFormat(" AND {0}='{1}' ", ViewTask.SQLCOL_TEACHERID, CurrentUser.ID);

            if (searchDepartmentID.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", ViewTask.SQLCOL_DEPARTMENTID, searchDepartmentID.SelectedValue);
            }
            if (searchCourseID.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", ViewTask.SQLCOL_COURSEID, searchCourseID.SelectedValue);
            }
            if (searchCategoryID.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", ViewTask.SQLCOL_CATEGORYID, searchCategoryID.SelectedValue);
            }
            if (searchStatus.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", ViewTask.SQLCOL_STATUS, searchStatus.SelectedValue);
                if (searchStatus.SelectedValue == ((int)TaskStatus.Corrected).ToString())
                {
                    orderby = ViewTask.SQLCOL_SCORETIME + " ," + ViewTask.SQLCOL_ID;
                }
            }

            int count = 0;
            rpList.DataSource = DataAccess.Select(typeof(ViewTask), AspNetPager1.CurrentPageIndex - 1, AspNetPager1.PageSize, sb.ToString(), orderby, ref count, true) as IList<ViewTask>;
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