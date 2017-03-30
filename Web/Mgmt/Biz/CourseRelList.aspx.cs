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
    public partial class CourseRelList : BasePage
    {
        #region 属性

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
                LoadData();
            }
        }

        private void InitData()
        {
            CourseID = Request.QueryString["CourseID"].ToInt32();

            var course = new SysCourse(CourseID);
            course.Load();
            ltlCourseName.Text = course.Name;
        }

        private void LoadData()
        {
            var courseRelList = DataAccess.Select(typeof(SysCourseRel),
                string.Format("{0}='{1}'", SysCourseRel.SQLCOL_COURSEID, CourseID), true) as IList<SysCourseRel>;
            var list = courseRelList.GroupBy(p => new { p.TeacherID, p.TeacherName }).Select(g => new
            {
                g.Key.TeacherID,
                g.Key.TeacherName,
                DeptNames = string.Join(",",
                    courseRelList.Where(p => p.TeacherID == g.Key.TeacherID).Select(p => p.DepartmentName).ToArray())
            });

            rpList.DataSource = list;
            rpList.DataBind();
        }


        protected void rpList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int teacherId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Delete")
            {
                DataAccess.Delete(typeof(SysCourseRel), string.Format("{0}='{1}' AND {2}='{3}'",
                    SysCourseRel.SQLCOL_COURSEID, CourseID, SysCourseRel.SQLCOL_TEACHERID, teacherId));

                LoadData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseRelEdit.aspx?CourseID=" + CourseID);
        }

    }
}