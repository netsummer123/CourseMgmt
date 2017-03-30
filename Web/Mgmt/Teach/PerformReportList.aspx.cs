using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Cells;
using CourseMgmt.BizLogic.Service;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;
using CourseMgmt.BizLogic.Util;
using Wicresoft.Common;

namespace CourseMgmt.Web.Mgmt.Teach
{
    public partial class PerformReportList : BasePage
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
            var orderby = SysPerformReport.SQLCOL_DEPARTMENTID + "," + SysPerformReport.SQLCOL_COURSEID;

            var sb = new StringBuilder("1=1");
            if (searchDepartmentType.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", SysPerformReport.SQLCOL_DEPARTMENTTYPE, searchDepartmentType.SelectedValue);
            }
            if (searchRegYear.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", SysPerformReport.SQLCOL_REGYEAR, searchRegYear.SelectedValue);
            }
            if (searchDepartmentID.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", SysPerformReport.SQLCOL_DEPARTMENTID, searchDepartmentID.SelectedValue);
            }
            if (searchCourseID.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND {0}='{1}' ", SysPerformReport.SQLCOL_COURSEID, searchCourseID.SelectedValue);
            }

            int count = 0;
            rpList.DataSource = DataAccess.Select(typeof(SysPerformReport), sb.ToString(), orderby, true) as IList<SysPerformReport>;
            rpList.DataBind();
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

        #region 导出
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportPreform(hdCourseID.Value.ToInt32(), hdDepartmentID.Value.ToInt32());
        }

        private void ExportPreform(int courseId, int deptId)
        {
            var course = new SysCourse(courseId);
            course.Load();

            var dept = new SysDepartment(deptId);
            dept.Load();

            var orderby = SysPerform.SQLCOL_USERNAME;

            var sb = new StringBuilder("1=1");
            sb.AppendFormat(" AND {0}='{1}' ", SysPerform.SQLCOL_COURSEID, courseId);
            sb.AppendFormat(" AND {0}='{1}' ", SysPerform.SQLCOL_DEPARTMENTID, deptId);

            var list = DataAccess.Select(typeof(SysPerform), sb.ToString(), orderby, true) as IList<SysPerform>;
            var book = new Workbook(Server.MapPath("PerformReportTmpl.xls"));
            var sheet = book.Worksheets[0];
            var cells = sheet.Cells;
            if (list.Count > 1)
            {
                sheet.Cells.InsertRows(5, list.Count - 1);
            }

            //标题
            //var report = new SysPerformReport(courseId, deptId);
            //report.Load();
            //var rowTitle = cells.Rows[0];
            //rowTitle[1].Value = EnumTypeHelper.GetDescriptionFromEnum(typeof(SysDeptType), report.DepartmentType);
            //rowTitle[4].Value = report.DepartmentName;
            //rowTitle[7].Value = report.CourseName;
            //rowTitle[12].Value = report.TeacherName;

            var cellStyle = book.Styles[book.Styles.Add()];
            cellStyle.IsTextWrapped = true;
            cellStyle.VerticalAlignment = TextAlignmentType.Center;
            cellStyle.Font.Name = "宋体";
            cellStyle.Font.Size = 10;
            cellStyle.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            cellStyle.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            cellStyle.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            cellStyle.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            var centerStyle = book.Styles[book.Styles.Add()];
            centerStyle.IsTextWrapped = true;
            centerStyle.HorizontalAlignment = TextAlignmentType.Center;
            centerStyle.VerticalAlignment = TextAlignmentType.Center;
            centerStyle.Font.Name = "宋体";
            centerStyle.Font.Size = 10;
            centerStyle.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            centerStyle.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            centerStyle.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            centerStyle.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            for (int i = 0; i < list.Count; i++)
            {
                var rowIndex = i + 4;
                var row = cells.Rows[rowIndex];
                var data = list[i];

                row[0].SetStyle(cellStyle);
                row[0].Value = string.Format("{0}", data.UserName);

                row[1].SetStyle(cellStyle);
                row[1].Value = string.Format("{0}", data.RealName);

                row[2].SetStyle(centerStyle);
                row[2].Value = string.Format("{0}", data.RoutineScore1.ToString("0"));
                cells.Merge(rowIndex, 2, 1, 2);

                row[4].SetStyle(centerStyle);
                row[4].Value = string.Format("{0}", data.RoutineScore2.ToString("0"));
                cells.Merge(rowIndex, 4, 1, 3);

                row[7].SetStyle(centerStyle);
                row[7].Value = string.Format("{0}", data.RoutineScore3.ToString("0"));
                cells.Merge(rowIndex, 7, 1, 4);

                row[11].SetStyle(centerStyle);
                row[11].Value = string.Format("{0}", data.TaskScore1.ToString("0"));
                cells.Merge(rowIndex, 11, 1, 3);

                row[14].SetStyle(centerStyle);
                row[14].Value = string.Format("{0}", data.TaskScore2.ToString("0"));
                cells.Merge(rowIndex, 14, 1, 3);

                row[17].SetStyle(centerStyle);
                row[17].Value = string.Format("{0}", data.TaskScore3.ToString("0"));
                cells.Merge(rowIndex, 17, 1, 3);

                row[20].SetStyle(centerStyle);
                row[20].Value = string.Format("{0}", data.RoutineScore4.ToString("0"));
                cells.Merge(rowIndex, 20, 1, 3);

                row[23].SetStyle(centerStyle);
                row[23].Value = string.Format("{0}", data.TaskScore4.ToString("0"));
                cells.Merge(rowIndex, 23, 1, 3);

                row[26].SetStyle(centerStyle);
                row[26].Value = string.Format("{0}", data.TaskScore5.ToString("0"));
                cells.Merge(rowIndex, 26, 1, 3);

                row[29].SetStyle(centerStyle);
                row[29].Value = string.Format("{0}", data.TaskScore6.ToString("0"));
                cells.Merge(rowIndex, 29, 1, 3);

                row[32].SetStyle(centerStyle);
                row[32].Value = string.Format("{0}", data.TaskScore7.ToString("0"));
                cells.Merge(rowIndex, 32, 1, 3);

                row[35].SetStyle(centerStyle);
                row[35].Value = string.Format("{0}", data.FinalScore.ToString("0"));
            }

            book.Save(Response, HttpUtility.UrlEncode(string.Format("{0}-{1}.xls", dept.Name, course.Name)),
                ContentDisposition.Attachment, new XlsSaveOptions(SaveFormat.Auto));
        }

        #endregion

    }
}