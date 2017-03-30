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

namespace CourseMgmt.Web.Metro.Control
{
    public partial class SubMenu : BaseControl
    {
        #region 属性

        private IList<SysMenu> UserMenuList
        {
            get { return CurrentUser.UserMenuList; }
        }

        #endregion

        public void LoadMenu(int menuId)
        {
            BindChildMenu(rpLv2Menu, menuId);
        }

        private void BindChildMenu(Repeater rp, int pMenuId)
        {
            var menuList = UserMenuList.Where(i => i.ParentID == pMenuId).OrderBy(m => m.OrderNum).ToList();
            if (menuList.Count > 0)
            {
                rp.DataSource = menuList;
                rp.DataBind();
            }
        }

        protected void rpLv2Menu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var pMenu = e.Item.DataItem as SysMenu;
                var rpLv3Menu = e.Item.FindControl("rpLv3Menu") as Repeater;
                BindChildMenu(rpLv3Menu, pMenu.ID);
            }
        }

        protected bool HasChild(object menuId)
        {
            return UserMenuList.Any(m => m.ParentID == Convert.ToInt32(menuId.ToString()));
        }
    }
}