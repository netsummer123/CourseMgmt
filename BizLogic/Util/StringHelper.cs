using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CourseMgmt.BizLogic.Util
{
    public static class StringHelper
    {
        /// <summary>
        /// 清除所有Html标签，得到文本内容.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns></returns>
        public static string CleanHtmlTag(this string html)
        {
            return Regex.Replace(html, "<[^<>]*>", "");
        }

        /// <summary>
        /// 逗号分隔的字符串是否包含字符串value.
        /// </summary>
        /// <param name="commaString">The comma string.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool CommaStringHasValue(this string commaString, string value)
        {
            return ((!string.IsNullOrEmpty(commaString) && !string.IsNullOrEmpty(value)) && (("," + commaString + ",").IndexOf("," + value + ",") >= 0));
        }

        /// <summary>
        /// 逗号分隔的字符串去除字符串value.
        /// </summary>
        /// <param name="commaString">The comma string.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string CommaStringRemoveValue(this string commaString, string value)
        {
            if (!string.IsNullOrEmpty(commaString))
            {
                if (string.IsNullOrEmpty(value))
                {
                    return commaString;
                }
                string str = ("," + commaString + ",").Replace("," + value + ",", ",");
                if (str.Length >= 2)
                {
                    return str.Substring(1, str.Length - 2);
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 用逗号分隔的字符串值序列中是否包含某个值.
        /// </summary>
        /// <param name="input">输入值(逗号分隔).</param>
        /// <param name="value">数值.</param>
        /// <returns>分隔字符串数组</returns>
        public static bool ContainsWithComma(this string input, string value)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return (("," + input + ",").IndexOf("," + value + ",") >= 0);
        }

        /// <summary>
        /// 还原HTML特殊字符.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string HTMLDecode(this string input)
        {
            return HttpUtility.HtmlDecode(input);
        }

        /// <summary>
        /// 转义HTML特殊字符.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string HTMLEncode(this string input)
        {
            return HttpUtility.HtmlEncode(input);
        }

        /// <summary>
        /// 判断字符串是否为null和空字符串.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        /// <c>true</c> if [is null or empty] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// 用逗号分隔字符串.
        /// </summary>
        /// <param name="input">输入值.</param>
        /// <returns>分隔字符串数组</returns>
        public static string[] SplitWithComma(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new string[0];
            }
            return input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 用指定的分隔符分隔字符串.
        /// </summary>
        /// <param name="input">输入值.</param>
        /// <param name="separator">分隔符.</param>
        /// <returns>分隔字符串数组</returns>
        public static string[] SplitWithSeparator(this string input, char separator)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            return input.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 用指定的字符串分隔字符串.
        /// </summary>
        /// <param name="input">输入值.</param>
        /// <param name="separator">分隔字符串.</param>
        /// <returns>分隔字符串数组</returns>
        public static string[] SplitWithString(this string input, string separator)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            return input.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 过滤SQL特殊字符串.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static string SQLFilter(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }
            source = source.Replace("'", "''");
            source = source.Replace(";", "");
            source = source.Replace("[", "");
            source = source.Replace("]", "");
            source = source.Replace("\"", "");
            source = source.Replace("%", "");
            source = source.Replace("--", "");
            source = source.Replace("(", "");
            source = source.Replace(")", "");
            Regex.Replace(source, "and", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "insert", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "select", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "delete", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "update", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "chr", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "mid", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "master", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "or", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "truncate", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "char", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "declare", "", RegexOptions.IgnoreCase);
            Regex.Replace(source, "join", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "Exec", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "Execute", "", RegexOptions.IgnoreCase);
            source = source.Replace("xp_", "");
            source = source.Replace("sp_", "");
            return source;
        }

        /// <summary>
        /// 替换SQL特殊字符串.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static string SQLReplace(this string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                source = source.Replace("'", "''");
                source = source.Replace(";", "；");
                source = source.Replace("(", "（");
                source = source.Replace(")", "）");
                source = source.Replace("[", "【");
                source = source.Replace("]", "】");
                source = Regex.Replace(source, "Exec", "", RegexOptions.IgnoreCase);
                source = Regex.Replace(source, "Execute", "", RegexOptions.IgnoreCase);
                source = source.Replace("xp_", "x p_");
                source = source.Replace("sp_", "s p_");
                source = source.Replace("0x", "0 x");
            }
            return source;
        }

        /// <summary>
        /// 还原URL特殊字符.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string UrlDecode(this string input)
        {
            return HttpContext.Current.Server.UrlDecode(input);
        }

        /// <summary>
        /// 转义URL特殊字符.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string UrlEncode(this string input)
        {
            return HttpContext.Current.Server.UrlEncode(input);
        }

        /// <summary>
        /// 还原XML特殊字符.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string XMLDecode(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return input.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        }

        /// <summary>
        /// 转义XML特殊字符.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string XMLEncode(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return input.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;").Replace("\"", "&quot;");
        }

    }
}