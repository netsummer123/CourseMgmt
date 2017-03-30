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
    public partial class RoleEdit : BasePage
    {
        #region 属性
        public string SelectedMenuIds
        {
            get
            {
                return hdSelectedTreeItemId.Value;
            }
            set
            {
                hdSelectedTreeItemId.Value = value;
            }
        }

        public int RoleID
        {
            get
            {
                return ViewState["RoleID"] != null ? (int)ViewState["RoleID"] : int.MinValue;
            }
            set
            {
                ViewState["RoleID"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

                //判断是修改还是新增
                if (!string.IsNullOrEmpty(Request["RoleID"]))
                {
                    RoleID = Convert.ToInt32(Request["RoleID"]);
                    LoadData();
                }
            }
        }

        private void InitData()
        {

        }

        private void LoadData()
        {
            if (RoleID < 0)
                return;

            var role = new SysRole(RoleID);
            role.Load();

            phData.BindObjectToControls(role, "tbx");

            phMenu.Visible = true;
            hdSelectedRoleId.Value = RoleID.ToString();

            var roleMenuList = DataAccess.Select(typeof(SysRoleRel),
                string.Format("{0}='{1}'", SysRoleRel.SQLCOL_ROLEID, RoleID), true) as IList<SysRoleRel>;
            SelectedMenuIds = string.Join(",", roleMenuList.Select(r => r.MenuID.ToString()).ToArray());
        }

        private bool Check()
        {
            return true;
        }

        private void SetData(SysRole role)
        {
            phData.BindControlsToObject(role, "tbx");

        }

        private void SaveData()
        {
            var role = new SysRole();
            if (RoleID > 0)
            {
                role.LoadByIdentity(RoleID);
                SetData(role);
                role.Update();

                #region 保存角色关系
                DataAccess.Delete(typeof(SysRoleRel), string.Format("{0}='{1}'", SysRoleRel.SQLCOL_ROLEID, RoleID));
                //从隐藏域中读取勾选的菜单值
                var menuIds = SelectedMenuIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var menuId in menuIds)
                {
                    var rel = new SysRoleRel(RoleID, Convert.ToInt32(menuId));
                    rel.Save();
                }
                #endregion
            }
            else
            {
                SetData(role);
                role.Add();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("RoleList.aspx");
        }

        protected void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("RoleEdit.aspx");
        }

    }
}