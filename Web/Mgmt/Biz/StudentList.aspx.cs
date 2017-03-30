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
    public partial class StudentList : BasePage
    {
        public int DeptID
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

        public int DeptType
        {
            get
            {
                if (string.IsNullOrEmpty(hdDeptType.Value))
                    return -1;
                return Convert.ToInt32(hdDeptType.Value);
            }
            set
            {
                hdDeptType.Value = value.ToString();
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
            var orderby = SysUser.SQLCOL_ORDERNUM + "," + SysUser.SQLCOL_ID;

            var sb = new StringBuilder(" IsDeleted=0 ");
            sb.AppendFormat(" AND {0} = {1}", SysUser.SQLCOL_USERTYPE, (int)SysUserType.Student);
            sb.AppendFormat(" AND {0} = {1}", SysUser.SQLCOL_REGYEAR, searchRegYear.SelectedValue);

            if (DeptID > 1)
            {
                sb.AppendFormat(" AND {0} = {1}", SysUser.SQLCOL_DEPARTMENTID, DeptID);
            }
            else if (DeptType > 0)
            {
                sb.AppendFormat(" AND {0} = {1}", SysUser.SQLCOL_DEPARTMENTTYPE, DeptType);
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
                var user = new SysUser(id);
                user.Load();
                //删除操作，工号添加前缀"XXXX_DEL_"
                user.IsDeleted = true;
                user.UserName = (new Random()).Next(0, 9999).ToString("0000") + "_DEL_" + user.UserName;
                user.UpdateTime = DateTime.Now;
                user.Update();

                //删除作业
                DataAccess.Delete(typeof(SysTask), string.Format("{0}='{1}'", SysTask.SQLCOL_STUDENTID, id));
                //删除成绩
                DataAccess.Delete(typeof(SysPerform), string.Format("{0}='{1}'", SysPerform.SQLCOL_STUDENTID, id));

                LoadData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentEdit.aspx");
        }

    }
}