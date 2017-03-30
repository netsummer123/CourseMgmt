namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Text;
    using System.Web;

    /// <summary>
    /// 
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void Add(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = HttpUtility.UrlEncode(strValue, Encoding.UTF8);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="expiresminutes">过期时间，单位分钟.</param>
        public static void Add(string strName, string strValue, int expiresminutes)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = HttpUtility.UrlEncode(strValue, Encoding.UTF8);
            cookie.Expires = DateTime.Now.AddMinutes((double)expiresminutes);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 删除cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        public static void Delete(string strName)
        {
            HttpCookie cookie = new HttpCookie(strName);
            cookie.Expires = DateTime.Now.AddDays(-1.0);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string Get(string strName)
        {
            if ((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[strName] != null))
            {
                return HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[strName].Value, Encoding.UTF8);
            }
            return string.Empty;
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static T Get<T>(string strName)
        {
            T local = default(T);
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie != null)
            {
                local = (T)Convert.ChangeType(HttpUtility.UrlDecode(cookie.Value, Encoding.UTF8), typeof(T));
            }
            return local;
        }
    }
}

