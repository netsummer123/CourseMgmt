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
    public partial class DeptList : BasePage
    {
        public int DeptType
        {
            get
            {
                if (string.IsNullOrEmpty(hdSelectedTreeItemId.Value))
                    return -1;
                return Convert.ToInt32(hdSelectedTreeItemId.Value);
            }
            set
            {
                hdSelectedTreeItemId.Value = value.ToString();
            }
        }

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
            searchRegYear.BindData(DateHelper.GetYearBetween(DateTime.Now.Year, SysConsts.StartYear), "value", "key");

            phSearch.LoadSearchCondition("search", "AspNetPager1");
        }

        private void LoadData()
        {
            var orderby = SysDepartment.SQLCOL_ORDERNUM + "," + SysDepartment.SQLCOL_ID;

            var sb = new StringBuilder(" IsDeleted=0 ");
            sb.AppendFormat(" AND {0}='{1}' ", SysDepartment.SQLCOL_REGYEAR, searchRegYear.SelectedValue);
            if (DeptType > 1)
                sb.AppendFormat(" AND {0}={1} ", SysDepartment.SQLCOL_DEPARTMENTTYPE, DeptType);

            int count = 0;
            rpList.DataSource = DataAccess.Select(typeof(SysDepartment), AspNetPager1.CurrentPageIndex - 1, AspNetPager1.PageSize, sb.ToString(), orderby, ref count, true) as IList<SysDepartment>;
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
                var dept = new SysDepartment(id);
                dept.Load();
                dept.IsDeleted = true;
                dept.Update();

                LoadData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeptEdit.aspx");
        }

    }
}