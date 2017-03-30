using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseMgmt.BizLogic.Util;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;
using Wicresoft.Common;

namespace CourseMgmt.Web.Mgmt.Sys
{
    public partial class UserList : BasePage
    {
        #region 属性

        public int SelectedDeptId
        {
            get
            {
                if (string.IsNullOrEmpty(hdSelectedTreeItemId.Value))
                    return -1;
                return Convert.ToInt32(hdSelectedTreeItemId.Value);
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

            phSearch.LoadSearchCondition("search", "AspNetPager1");
        }

        private void LoadData()
        {
            var orderby = SysUser.SQLCOL_ORDERNUM + "," + SysUser.SQLCOL_ID;

            var sb = new StringBuilder("1=1");
            if (searchName.Text.Trim() != string.Empty)
            {
                sb.AppendFormat(" AND ({0} LIKE '%{1}%' ", SysUser.SQLCOL_USERNAME, searchName.Text);
                sb.AppendFormat(" OR   {0} LIKE '%{1}%')", SysUser.SQLCOL_USERNAME, searchName.Text);
                orderby = SysUser.SQLCOL_ID;
            }
            else
            {
                if (SelectedDeptId > 0)
                    sb.AppendFormat(" AND {0} = '{1}'", SysUser.SQLCOL_DEPARTMENTID, SelectedDeptId);
            }

            int count = 0;
            rpList.DataSource = DataAccess.Select(typeof(SysUser), AspNetPager1.CurrentPageIndex - 1, AspNetPager1.PageSize, sb.ToString(), orderby, ref count, true) as IList<SysUser>;
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
                DataAccess.Delete(typeof(SysUser), string.Format("{0}='{1}'", SysUser.SQLCOL_ID, id));
                LoadData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEdit.aspx");
        }

    }
}