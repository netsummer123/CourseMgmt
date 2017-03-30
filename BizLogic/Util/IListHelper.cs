namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 
    /// </summary>
    public static class IListHelper
    {
        /// <summary>
        /// 将对象列表某个属性拼接成逗号分隔的字符串.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static string ToCommaString(this IList<string> list)
        {
            if (list == null)
            {
                return string.Empty;
            }
            string str = string.Empty;
            foreach (string str2 in list)
            {
                str = str + "," + str2;
            }
            if (str != string.Empty)
            {
                str = str.Substring(1);
            }
            return str;
        }

        /// <summary>
        /// 将对象列表某个属性拼接成逗号分隔的字符串.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="func">The func.</param>
        /// <returns></returns>
        public static string ToCommaString<T>(this IList<T> list, Func<T, string> func) where T: class
        {
            if (list == null)
            {
                return string.Empty;
            }
            string str = string.Empty;
            foreach (T local in list)
            {
                str = str + "," + func(local);
            }
            if (str != string.Empty)
            {
                str = str.Substring(1);
            }
            return str;
        }

        /// <summary>
        /// 将对象列表指定条数的某个属性拼接成逗号分隔的字符串.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="func">The func.</param>
        /// <param name="joinCount">The join count.</param>
        /// <returns></returns>
        public static string ToCommaString<T>(this IList<T> list, Func<T, string> func, int joinCount) where T: class
        {
            if (list == null)
            {
                return string.Empty;
            }
            int count = list.Count;
            if (count > joinCount)
            {
                count = joinCount;
            }
            string str = string.Empty;
            for (int i = 0; i < count; i++)
            {
                str = str + "," + func(list[i]);
            }
            if (str != string.Empty)
            {
                str = str.Substring(1);
            }
            return str;
        }

        /// <summary>
        /// 将对象列表某个属性拼接成逗号分隔的字符串.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static string ToSemicolonString(this IList<string> list)
        {
            if (list == null)
            {
                return string.Empty;
            }
            string str = string.Empty;
            foreach (string str2 in list)
            {
                str = str + ";" + str2;
            }
            if (str != string.Empty)
            {
                str = str.Substring(1);
            }
            return str;
        }

        /// <summary>
        /// 将对象列表某个属性拼接成分号分隔的字符串.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="func">The func.</param>
        /// <returns></returns>
        public static string ToSemicolonString<T>(this IList<T> list, Func<T, string> func) where T: class
        {
            if (list == null)
            {
                return string.Empty;
            }
            string str = string.Empty;
            foreach (T local in list)
            {
                str = str + ";" + func(local);
            }
            if (str != string.Empty)
            {
                str = str.Substring(1);
            }
            return str;
        }
    }
}

