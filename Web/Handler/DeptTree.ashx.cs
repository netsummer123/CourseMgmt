using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using CourseMgmt.BizLogic.Util;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;
using Newtonsoft.Json.Linq;
using Wicresoft.Common;

namespace CourseMgmt.Web.Handler
{
    /// <summary>
    /// DeptTree 的摘要说明
    /// </summary>
    public class DeptTree : IHttpHandler, IReadOnlySessionState
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

        private IList<SysDepartment> _allDepts;

        /// <summary>
        /// 所有菜单列表
        /// </summary>
        private IList<SysDepartment> AllDepts
        {
            get
            {
                if (_allDepts == null)
                    _allDepts = DataAccess.Select(typeof(SysDepartment), "IsDeleted=0", true) as IList<SysDepartment>;
                return _allDepts;
            }
        }

        #endregion

        private IList<SysCourseRel> _courseAllDepts;

        private IList<SysCourseRel> CourseAllDepts
        {
            get
            {
                if (_courseId <= 0 || _teacherId <= 0)
                    return new List<SysCourseRel>();

                if (_courseAllDepts == null)
                    _courseAllDepts = DataAccess.Select(typeof(SysCourseRel), string.Format("{0}='{1}' AND {2}='{3}'",
                    SysCourseRel.SQLCOL_COURSEID, _courseId, SysCourseRel.SQLCOL_TEACHERID, _teacherId), true) as IList<SysCourseRel>;
                return _courseAllDepts;
            }
        }

        private int _courseId;
        private int _teacherId;

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
            get { return true; }
        }

        /// <summary>
        /// 根据操作类型就行处理并返回处理结果
        /// </summary>
        /// <returns></returns>
        private string Process(string type, HttpContext context)
        {
            _expandedKeyList = context.Request["expandedKeyList"];
            var year = Convert.ToInt32(context.Request["year"]);
            _teacherId = Convert.ToInt32(context.Request["teacherId"]);
            _courseId = Convert.ToInt32(context.Request["courseId"]);

            switch (type)
            {
                case "getRoot":
                    return GetRoot(year);
                case "getChildren":
                    var deptType = Convert.ToInt32(context.Request["deptType"]);
                    return GetChildren(deptType, year);
                default:
                    return GetRoot(year);
            }
        }

        /// <summary>
        /// 获取根菜单Json
        /// </summary>
        private string GetRoot(int year)
        {
            //根结点
            var root = AllDepts.FirstOrDefault(p => p.ID == SysConsts.RootDeptID);
            if (root == null)
                return null;

            var jObject = new JObject(
                new JProperty("title", root.Name),
                new JProperty("tooltip", root.ID.ToString()),
                new JProperty("isFolder", true),
                new JProperty("isLazy", false),
                new JProperty("activate", true),
                new JProperty("hideCheckbox", true), //根菜单隐藏勾选框
                new JProperty("addClass", "menuTreeRoot"),
                new JProperty("expand", true), //展开
                new JProperty("key", root.ID),
                new JProperty("nodeType", "Dept")
                );


            var deptTypes = typeof(SysDeptType).GetValueDescriptionCollection();

            jObject.Add("children",
                new JArray(
                    deptTypes.Select(d => ParseDeptTypeJObject(d, year))
                    ));

            //已展开的结点列表
            if (_expandedKeyList != null && _expandedKeyList.Length > 0)
            {
                _expandedKeys = _expandedKeyList.Split(',').ToList();
                if (_expandedKeys.Count > 0)
                {
                    //去除根结点
                    _expandedKeys.Remove(root.ID.ToString());
                    InitPersistKey(jObject, year);
                }
            }

            return jObject.ToString();
        }

        private string GetChildren(int deptType, int year)
        {
            var children = AllDepts.Where(p => p.DepartmentType == deptType && p.RegYear == year)
                .OrderBy(p => p.OrderNum)
                .ThenBy(p => p.ID);

            var jArray = new JArray(children.Select(ParseDeptJObject));
            return jArray.ToString();
        }

        /// <summary>
        /// 将dept对象解析为json对象
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        private JObject ParseDeptTypeJObject(KeyValuePair<int, string> deptType, int year)
        {
            return new JObject(
                new JProperty("title", deptType.Value),
                new JProperty("tooltip", deptType.Key.ToString()),
                new JProperty("isFolder", AllDepts.Any(m => m.DepartmentType == deptType.Key && m.RegYear == year)),
                new JProperty("isLazy", AllDepts.Any(m => m.DepartmentType == deptType.Key && m.RegYear == year)),
                new JProperty("select", false),
                new JProperty("hideCheckbox", true), //隐藏勾选框
                new JProperty("addClass", " "),
                new JProperty("expand", false),
                new JProperty("key", deptType.Key),
                new JProperty("nodeType", "DeptType")
                );
        }

        private JObject ParseDeptJObject(SysDepartment dept)
        {
            return new JObject(
                new JProperty("title", dept.Name),
                new JProperty("tooltip", dept.ID.ToString()),
                new JProperty("isFolder", false),
                new JProperty("isLazy", false),
                new JProperty("select", CourseAllDepts.Any(p => p.DepartmentID == dept.ID)),
                new JProperty("addClass", " "),
                new JProperty("key", dept.ID),
                new JProperty("nodeType", "Dept")
                );
        }

        /// <summary>
        /// 递归初始化持久化内容
        /// </summary>
        private void InitPersistKey(JObject jobject, int year)
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

                    jCate["children"] = new JArray(
                        AllDepts.Where(m => m.DepartmentType == (int)jCate["key"] && m.RegYear == year)
                        .OrderBy(p => p.OrderNum)
                        .ThenBy(p => p.ID)
                        .Select(ParseDeptJObject));

                    _expandedKeys.Remove(matchedExpandedKey);

                }
            }
        }

    }
}