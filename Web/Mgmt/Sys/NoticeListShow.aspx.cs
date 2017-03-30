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

namespace CourseMgmt.Web.Mgmt.Sys
{
    public partial class NoticeListShow : BasePage
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

            phSearch.LoadSearchCondition("search", "AspNetPager1");
        }

        private void LoadData()
        {
            var orderby = SysNotice.SQLCOL_ID + " desc";

            var sb = new StringBuilder("1=1");
            sb.AppendFormat(" AND {0} = 1 ", SysNotice.SQLCOL_ISPUBLISHED);
            if (searchTitle.Text.Trim() != string.Empty)
            {
                sb.AppendFormat(" AND {0} LIKE '%{1}%' ", SysNotice.SQLCOL_TITLE, searchTitle.Text.Trim());
            }

            int count = 0;
            rpList.DataSource = DataAccess.Select(typeof(SysNotice), AspNetPager1.CurrentPageIndex - 1, AspNetPager1.PageSize, sb.ToString(), orderby, ref count, true) as IList<SysNotice>;
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

            }
        }
    }
}