using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using CourseMgmt.Domain.Entity;
using Newtonsoft.Json.Linq;
using Wicresoft.Common;

namespace CourseMgmt.Web.Handler
{
    /// <summary>
    /// MenuTree 的摘要说明
    /// </summary>
    public class MenuTree : IHttpHandler, IReadOnlySessionState
    {
        #region 变量 & 属性
        /// <summary>
        /// 已展开的结点参数
        /// </summary>
        private string _expandedKeyList;
        /// <summary>
        /// 已展开的结点列表
        /// </summary>
        private List<string> _expandedKeys;

        private IList<SysMenu> _allMenus;
        /// <summary>
        /// 所有菜单列表
        /// </summary>
        private IList<SysMenu> AllMenus
        {
            get
            {
                if (_allMenus == null)
                    _allMenus = DataAccess.SelectAll(typeof(SysMenu), true) as IList<SysMenu>;
                return _allMenus;
            }
        }

        private IList<SysRoleRel> _roleAllMenus;
        /// <summary>
        /// 角色所有能访问的菜单列表
        /// </summary>
        private IList<SysRoleRel> RoleAllMenus
        {
            get
            {
                if (_selectedRoleId == 0)
                    return new List<SysRoleRel>();

                if (_roleAllMenus == null)
                    _roleAllMenus = DataAccess.Select(typeof(SysRoleRel), string.Format("{0}='{1}'", SysRoleRel.SQLCOL_ROLEID, _selectedRoleId), true) as IList<SysRoleRel>;
                return _roleAllMenus;
            }
        }

        private int _selectedRoleId;
        #endregion

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            //操作类型
            var type = context.Request["type"];
            if (string.IsNullOrEmpty(type))
                return;

            var result = Process(type, context);

            if (result != null)
            {
                context.Response.Write(result);
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 根据操作类型就行处理并返回处理结果
        /// </summary>
        /// <returns></returns>
        private string Process(string type, HttpContext context)
        {
            var menuId = Convert.ToInt32(context.Request["treeItemId"]);
            _expandedKeyList = context.Request["expandedKeyList"];
            _selectedRoleId = Convert.ToInt32(context.Request["roleId"]);

            switch (type)
            {
                case "getRootMenu":
                    return GetRootMenu(menuId, true);
                case "getVisibleRootMenu":
                    return GetRootMenu(menuId, false);
                case "getChildrenMenu":
                    return GetChildrenMenu(menuId, true);
                case "getVisibleChildrenMenu":
                    return GetChildrenMenu(menuId, false);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 获取根菜单Json
        /// </summary>
        private string GetRootMenu(int treeItemId, bool isShowHideMenu)
        {
            //根结点
            var root = AllMenus.FirstOrDefault(p => p.ID == treeItemId);
            if (root == null)
                return null;
            //不显示隐藏的菜单，并且根菜单隐藏，则返回null值
            if (!isShowHideMenu && !root.Visible)
                return null;

            var jObject = new JObject(
                    new JProperty("title", root.DisplayName),
                    new JProperty("tooltip", root.ID.ToString()),
                    new JProperty("isFolder", true),
                    new JProperty("isLazy", false),
                    new JProperty("activate", true),
                    new JProperty("hideCheckbox", true),    //根菜单隐藏勾选框
                    new JProperty("addClass", "menuTreeRoot"),
                    new JProperty("expand", true), //展开
                    new JProperty("key", root.ID)
                );


            IEnumerable<SysMenu> childrenMenus = AllMenus.Where(p => p.ParentID == treeItemId).OrderBy(m => m.OrderNum);
            if (!isShowHideMenu)
                childrenMenus = childrenMenus.Where(p => p.Visible);

            jObject.Add("children",
                new JArray(
                    childrenMenus
                    .OrderBy(p => p.OrderNum)
                    .ThenBy(p => p.ID)
                    .Select(ParseMenuJObject)
                ));

            //已展开的结点列表
            if (_expandedKeyList != null && _expandedKeyList.Length > 0)
            {
                _expandedKeys = _expandedKeyList.Split(',').ToList();
                if (_expandedKeys.Count > 0)
                {
                    //去除根结点
                    _expandedKeys.Remove(root.ID.ToString());
                    InitPersistKey(jObject);
                }
            }

            return jObject.ToString();

        }

        /// <summary>
        /// 获取子菜单Json
        /// </summary>
        private string GetChildrenMenu(int menuId, bool isShowHideMenu)
        {
            IEnumerable<SysMenu> menus = AllMenus.Where(p => p.ParentID == menuId)
                .OrderBy(p => p.OrderNum)
                .ThenBy(p => p.ID);

            //不显示隐藏的菜单
            if (!isShowHideMenu)
                menus = menus.Where(p => p.Visible);

            var jArray = new JArray(menus.Select(ParseMenuJObject));
            return jArray.ToString();
        }

        /// <summary>
        /// 将dept对象解析为json对象
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        private JObject ParseMenuJObject(SysMenu menu)
        {
            return new JObject(
                new JProperty("title", menu.DisplayName),
                new JProperty("tooltip",
                    menu.ID + (menu.Visible ? "" : "该项不显示")),
                new JProperty("isFolder", AllMenus.Any(m => m.ParentID == menu.ID)),
                new JProperty("isLazy", AllMenus.Any(m => m.ParentID == menu.ID)),
                new JProperty("select", RoleAllMenus.Any(p => p.MenuID == menu.ID)),
                new JProperty("addClass", (menu.Visible ? " " : "menu-hide")),
                new JProperty("key", menu.ID)
                );
        }


        /// <summary>
        /// 递归初始化持久化内容
        /// </summary>
        private void InitPersistKey(JObject jobject)
        {
            //1、遍历所有的子菜单，找到匹配的展开项
            //2、加载展开项的子菜单，从匹配列表中移除已加载的展开项
            //3、重新执行 1~2
            //AllCategories.

            foreach (JObject jCate in jobject["children"])
            {

                if (_expandedKeys.Count == 0)
                    break;

                var matchedExpandedKey = _expandedKeys.FirstOrDefault(p => p == jCate["key"].ToString());
                if (matchedExpandedKey != null)
                {

                    Func<SysMenu, bool> predicate = ((p) => p.ParentID == Convert.ToInt32(matchedExpandedKey));

                    jCate["children"] = new JArray(
                        AllMenus.Where(predicate)
                        .OrderBy(p => p.OrderNum)
                        .ThenBy(p => p.ID)
                        .Select(ParseMenuJObject));

                    _expandedKeys.Remove(matchedExpandedKey);

                    InitPersistKey(jCate);
                }
            }
        }
    }
}