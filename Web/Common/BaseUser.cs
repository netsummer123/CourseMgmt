using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Caching;
using CourseMgmt.Domain.Entity;
using CourseMgmt.BizLogic.Util;
using Wicresoft.Common;

namespace CourseMgmt.Web.Common
{
    [Serializable]
    public class BaseUser
    {
        #region 属性

        #region Property <int> ID
        public int ID { get; set; }
        #endregion

        #region Property <string> UserName
        public string UserName { get; set; }
        #endregion

        #region Property <int> UserType
        public int UserType { get; set; }
        #endregion

        #region Property <string> RoleIDs
        public string RoleIDs { get; set; }
        #endregion

        #region Property <string> RealName
        public string RealName { get; set; }
        #endregion

        #region Property <byte> Sex
        public byte Sex { get; set; }
        #endregion

        #region Property <DateTime> Binrthday
        public DateTime Binrthday { get; set; }
        #endregion

        #region Property <string> Tel
        public string Tel { get; set; }
        #endregion

        #region Property <string> Mobile
        public string Mobile { get; set; }
        #endregion

        #region Property <string> Email
        public string Email { get; set; }
        #endregion

        #region Property <string> Duty
        public string Duty { get; set; }
        #endregion

        #region Property <int> BaseDeptID
        public int BaseDeptID { get; set; }
        #endregion

        #region Property <string> BaseDeptName
        public string BaseDeptName { get; set; }
        #endregion

        #region Property <int> DepartmentID
        public int DepartmentID { get; set; }
        #endregion

        #region Property <string> DepartmentName
        public string DepartmentName { get; set; }
        #endregion

        #region Property <string> DeptPath
        public string DeptPath { get; set; }
        #endregion

        #region Property <byte> Status
        public byte Status { get; set; }
        #endregion

        #endregion

        /// <summary>
        /// 登陆
        /// </summary>
        public static BaseUser UserLogin(SysUser user)
        {
            var dept = new SysDepartment(user.DepartmentID);
            dept.Load();
            user.DepartmentName = dept.Name;
            user.BaseDeptName = dept.BaseDeptName;

            user.LastLoginTime = DateTime.Now;
            user.UpdateTime = DateTime.Now;
            user.Update();

            return new BaseUser
            {
                ID = user.ID,
                UserName = user.UserName,
                UserType = user.UserType,
                RoleIDs = user.RoleIDs,
                RealName = user.RealName,
                Sex = user.Sex,
                Binrthday = user.Binrthday,
                Tel = user.Tel,
                Mobile = user.Mobile,
                Email = user.Email,
                Duty = user.Duty,
                BaseDeptID = user.BaseDeptID,
                BaseDeptName = user.BaseDeptName,
                DepartmentID = user.DepartmentID,
                DepartmentName = user.DepartmentName,
                DeptPath = user.DeptPath,
                Status = user.Status,
            };

        }

        private const string MenuListCacheKey = "MenuList_CacheKey_User_";

        public IList<SysMenu> UserMenuList
        {
            get
            {
                //if (CacheHelper.Contains(MenuListCacheKey + ID))
                //    return CacheHelper.Get(MenuListCacheKey + ID) as IList<SysMenu>;

                IList<SysMenu> menuList = new List<SysMenu>();

                if (IsSysAdmin)
                    menuList = DataAccess.SelectAll(typeof(SysMenu), true) as IList<SysMenu>;

                if (!string.IsNullOrEmpty(RoleIDs))
                {
                    var roleRelList = DataAccess.Select(typeof(SysRoleRel),
                        string.Format("{0} IN ({1})", SysRoleRel.SQLCOL_ROLEID, RoleIDs), true) as IList<SysRoleRel>;
                    var menuIds = string.Join(",", roleRelList.Select(r => r.MenuID.ToString()).ToArray());
                    if (!string.IsNullOrEmpty(menuIds))
                    {
                        menuList = DataAccess.Select(typeof(SysMenu),
                            string.Format("{0} IN ({1})", SysMenu.SQLCOL_ID, menuIds), true)
                            as IList<SysMenu>;
                    }
                }

                CacheHelper.Insert(MenuListCacheKey + ID, menuList, 300, (int)CacheItemPriority.Low);
                return menuList;
            }
        }

        /// <summary>
        /// 是否系统管理员
        /// </summary>
        public bool IsSysAdmin
        {
            get { return UserType == (int)SysUserType.SysAdmin; }
        }

        public bool IsInRole(int roleId)
        {
            var inRole = false;
            if (!string.IsNullOrEmpty(RoleIDs))
            {
                inRole = RoleIDs.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Any(r => Convert.ToInt32(r) == roleId);
            }

            return inRole;
        }

    }
}