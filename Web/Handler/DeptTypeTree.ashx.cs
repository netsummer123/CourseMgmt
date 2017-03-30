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
    /// DeptTypeTree 的摘要说明
    /// </summary>
    public class DeptTypeTree : IHttpHandler, IReadOnlySessionState
    {
        #region 变量 & 属性

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
            var rootDeptId = SysConsts.RootDeptID;

            switch (type)
            {
                case "getRoot":
                    return GetRoot(rootDeptId);

                default:
                    return GetRoot(rootDeptId);
            }
        }

        /// <summary>
        /// 获取根菜单Json
        /// </summary>
        private string GetRoot(int deptId)
        {
            //根结点
            var root = AllDepts.FirstOrDefault(p => p.ID == deptId);
            if (root == null)
                return null;

            var jObject = new JObject(
                    new JProperty("title", root.Name),
                    new JProperty("tooltip", root.ID.ToString()),
                    new JProperty("isFolder", true),
                    new JProperty("isLazy", false),
                    new JProperty("activate", true),
                    new JProperty("hideCheckbox", true),    //根菜单隐藏勾选框
                    new JProperty("addClass", "menuTreeRoot"),
                    new JProperty("expand", true), //展开
                    new JProperty("key", root.ID),
                    new JProperty("nodeType", "Dept")
                );


            var deptTypes = typeof(SysDeptType).GetValueDescriptionCollection();

            jObject.Add("children",
                new JArray(
                    deptTypes.Select(ParseDeptTypeJObject)
                ));

            return jObject.ToString();

        }

        /// <summary>
        /// 将dept对象解析为json对象
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        private JObject ParseDeptTypeJObject(KeyValuePair<int, string> deptType)
        {
            return new JObject(
                new JProperty("title", deptType.Value),
                new JProperty("tooltip", deptType.Key.ToString()),
                new JProperty("isFolder", false),
                new JProperty("isLazy", false),
                new JProperty("select", false),
                new JProperty("addClass", " "),
                new JProperty("key", deptType.Key),
                new JProperty("nodeType", "DeptType")
                );
        }

    }
}