using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;
using CourseMgmt.BizLogic.Util;
using Wicresoft.Common;

namespace CourseMgmt.Web.Mgmt.Sys
{
    public partial class MenuEdit : BasePage
    {
        #region 属性

        public int SelectedTreeItemId
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

        public int MenuID
        {
            get
            {
                return ViewState["MenuID"] != null ? (int)ViewState["MenuID"] : int.MinValue;
            }
            set
            {
                ViewState["MenuID"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

                //判断是修改还是新增
                if (!string.IsNullOrEmpty(Request["MenuID"]))
                {
                    MenuID = Convert.ToInt32(Request["MenuID"]);
                    LoadData();
                }
            }
        }

        private void InitData()
        {

            tbxOrderNum.Text = "0";
        }

        private void LoadData()
        {
            if (MenuID < 0)
                return;

            var menu = new SysMenu(MenuID);
            menu.Load();

            phData.BindObjectToControls(menu, "tbx");

            SelectedTreeItemId = menu.ParentID;
            var pMenu = new SysMenu(menu.ParentID);
            pMenu.Load();
            tbxParentName.Text = pMenu.Name;
        }

        private bool Check()
        {
            return true;
        }

        private void SetData(SysMenu menu)
        {
            phData.BindControlsToObject(menu, "tbx");

            menu.ParentID = SelectedTreeItemId;
        }

        private void SaveData()
        {
            var menu = new SysMenu();
            if (MenuID > 0)
            {
                menu.LoadByIdentity(MenuID);
                SetData(menu);
                menu.Update();
            }
            else
            {
                SetData(menu);
                menu.Add();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("MenuList.aspx");
        }

        protected void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("MenuEdit.aspx");
        }

    }
}