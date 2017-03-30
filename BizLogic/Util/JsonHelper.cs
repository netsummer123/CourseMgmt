namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Json数据转换封装
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 反序列化Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sJsonData"></param>
        /// <returns></returns>
        public static T DeJson<T>(this string sJsonData)
        {
            T local;
            if (string.IsNullOrEmpty(sJsonData))
            {
                return default(T);
            }
            string pattern = @"(\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2})";
            MatchEvaluator evaluator = new MatchEvaluator(JsonHelper.GetDatetimeJson);
            string s = Regex.Replace(sJsonData, pattern, evaluator);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
            try
            {
                local = (T) serializer.ReadObject(stream);
            }
            catch
            {
                local = default(T);
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }
            return local;
        }

        /// <summary>
        /// 将时间由 "yyyy-MM-dd HH:mm:ss" 格式的字符串转换成"\/Date(10000000000+0800)\/" 格式
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private static string GetDatetimeJson(Match m)
        {
            string str = "";
            try
            {
                TimeSpan span = DateTime.Parse(m.Groups[1].Value).Subtract(DateTime.Parse("1970-01-01"));
                str = string.Format(@"\\/Date\({0}(-|\+)\d+\)\\/", span.TotalMilliseconds);
            }
            catch
            {
            }
            return str;
        }

        /// <summary>
        /// 将时间由"\/Date(10000000000+0800)\/" 格式转换成 "yyyy-MM-dd HH:mm:ss" 格式的字符串
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private static string GetDatetimeString(Match m)
        {
            string str = "";
            try
            {
                DateTime time = new DateTime(0x7b2, 1, 1);
                str = time.AddMilliseconds((double) long.Parse(m.Groups[1].Value)).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
            }
            return str;
        }

        /// <summary>
        /// 将对象序列化为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            string input = Encoding.UTF8.GetString(stream.ToArray());
            stream.Close();
            stream.Dispose();
            string pattern = @"\\/Date\((\d+)(-|\+)\d+\)\\/";
            MatchEvaluator evaluator = new MatchEvaluator(JsonHelper.GetDatetimeString);
            return Regex.Replace(input, pattern, evaluator);
        }
    }
}

