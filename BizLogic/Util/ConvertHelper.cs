namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class ConvertHelper
    {
        /// <summary>
        /// 将byte[]转换成string
        /// </summary>
        /// <param name="bytes">要转换的字节数组</param>
        public static string BytesToString(byte[] bytes)
        {
            return Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// 使用指定字符集将byte[]转换成string
        /// </summary>
        /// <param name="bytes">要转换的字节数组</param>
        /// <param name="encoding">字符编码</param>
        public static string BytesToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 将数据转换为指定类型
        /// </summary>
        /// <typeparam name="T">转换的目标类型</typeparam>
        /// <param name="data">转换的数据</param>
        public static T ConvertTo<T>(object data)
        {
            if (data == null)
            {
                return default(T);
            }
            try
            {
                if (data is T)
                {
                    return (T) data;
                }
                if (data is IConvertible)
                {
                    return (T) Convert.ChangeType(data, typeof(T));
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 将数据转换为指定类型
        /// </summary>
        /// <param name="data">转换的数据</param>
        /// <param name="targetType">转换的目标类型</param>
        public static object ConvertTo(object data, Type targetType)
        {
            if (data == null)
            {
                return null;
            }
            try
            {
                if (data is IConvertible)
                {
                    return Convert.ChangeType(data, targetType);
                }
                return data;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将string转换成byte[]
        /// </summary>
        /// <param name="text">要转换的字符串</param>
        public static byte[] StringToBytes(string text)
        {
            return Encoding.Default.GetBytes(text);
        }

        /// <summary>
        /// 使用指定字符集将string转换成byte[]
        /// </summary>
        /// <param name="text">要转换的字符串</param>
        /// <param name="encoding">字符编码</param>
        public static byte[] StringToBytes(string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }
    }
}

