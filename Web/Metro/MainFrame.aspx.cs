using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wicresoft.Common;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;

namespace CourseMgmt.Web.Metro
{
    public partial class MainFrame : BasePage
    {
        #region 属性

        private IList<SysMenu> UserMenuList
        {
            get { return CurrentUser.UserMenuList; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMenu();

                LoadUserInfo();
            }
        }

        #region 加载数据
        /// <summary>
        /// 加载菜单
        /// </summary>
        private void LoadMenu()
        {
            var menulist = UserMenuList.Where(i => i.ParentID == SysConsts.RootMenuID).OrderBy(m => m.OrderNum).ToList();
            rpLv1Menu.DataSource = menulist;
            rpLv1Menu.DataBind();
        }

        /// <summary>
        /// 加载用户信息
        /// </summary>
        private void LoadUserInfo()
        {
           
        }

        protected bool HasChild(object menuId)
        {
            return UserMenuList.Any(m => m.ParentID == Convert.ToInt32(menuId.ToString()));
        }

        #endregion


    }
}