namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Web;
    using System.Web.Caching;

    /// Cache操作类
    /// <summary>
    /// Cache操作类
    /// </summary>
    public static class CacheHelper
    {
        /// <summary>
        /// 检测目标对象是否存储在缓存中,存在返回true
        /// </summary>
        /// <param name="key">缓存项的键名</param>
        public static bool Contains(string key)
        {
            return (HttpContext.Current.Cache.Get(key) != null);
        }

        /// 删除Cache对象
        /// <summary>
        /// 删除Cache对象
        /// </summary>
        /// <param name="strCacheName">Cache名称</param>
        public static void Delete(string strCacheName)
        {
            HttpContext.Current.Cache.Remove(strCacheName);
        }

        /// 简单读取Cache对象的值，前提是这个值是字符串形式的
        /// <summary>
        /// 简单读取Cache对象的值，前提是这个值是字符串形式的
        /// </summary>
        /// <param name="strCacheName">Cache名称</param>
        /// <returns>Cache字符串值</returns>
        public static object Get(string strCacheName)
        {
            return HttpContext.Current.Cache[strCacheName];
        }

        /// <summary>
        /// 获取缓存中的目标对象
        /// </summary>
        /// <typeparam name="T">目标对象的类型</typeparam>
        /// <param name="key">缓存项的键名</param>
        public static T Get<T>(string key)
        {
            return ConvertHelper.ConvertTo<T>(HttpContext.Current.Cache.Get(key));
        }

        /// <summary>
        /// 简单创建/修改Cache.
        /// </summary>
        /// <param name="strCacheName">Name of the STR cache.</param>
        /// <param name="value">The value.</param>
        public static void Insert(string strCacheName, object value)
        {
            HttpContext.Current.Cache.Insert(strCacheName, value);
        }

        /// <summary>
        /// 将目标对象存储到缓存中
        /// </summary>
        /// <param name="key">缓存项的键名</param>
        /// <param name="target">目标对象</param>
        /// <param name="dependencyFilePath">依赖的文件绝对路径,当该文件更改时,则将该项移出缓存</param>
        public static void Insert(string key, object target, string dependencyFilePath)
        {
            CacheDependency dependencies = new CacheDependency(dependencyFilePath);
            HttpContext.Current.Cache.Insert(key, target, dependencies);
        }

        /// <summary>
        /// 简单创建/修改Cache，前提是这个值是字符串形式的
        /// </summary>
        /// <param name="strCacheName">Cache名称</param>
        /// <param name="value">Cache值</param>
        /// <param name="iExpires">有效期，秒数（使用的是当前时间+秒数得到一个绝对到期值）</param>
        /// <param name="priority">保留优先级，1最不会被清除，6最容易被内存管理清除（1:NotRemovable；2:High；3:AboveNormal；4:Normal；5:BelowNormal；6:Low）</param>
        public static void Insert(string strCacheName, object value, int iExpires, int priority)
        {
            CacheItemPriority notRemovable;
            TimeSpan span = new TimeSpan(0, 0, iExpires);
            switch (priority)
            {
                case 1:
                    notRemovable = CacheItemPriority.NotRemovable;
                    break;

                case 2:
                    notRemovable = CacheItemPriority.High;
                    break;

                case 3:
                    notRemovable = CacheItemPriority.AboveNormal;
                    break;

                case 4:
                    notRemovable = CacheItemPriority.Normal;
                    break;

                case 5:
                    notRemovable = CacheItemPriority.BelowNormal;
                    break;

                case 6:
                    notRemovable = CacheItemPriority.Low;
                    break;

                default:
                    notRemovable = CacheItemPriority.Normal;
                    break;
            }
            HttpContext.Current.Cache.Insert(strCacheName, value, null, DateTime.Now.Add(span), Cache.NoSlidingExpiration, notRemovable, null);
        }
    }
}

