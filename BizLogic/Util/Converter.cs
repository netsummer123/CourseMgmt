namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// 扩展System.Convert的ChangeType方法，支持泛型和Nullable.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="conversionType">Type of the conversion.</param>
        /// <returns></returns>
        public static object ChangeNullableType(object value, Type conversionType)
        {
            if (value == null)
            {
                return null;
            }
            if (value is string)
            {
                string str = value as string;
                if (string.IsNullOrEmpty(str))
                {
                    return TypeHelper.GetDefaultValue(conversionType);
                }
                if (conversionType == typeof(Guid))
                {
                    if (value.ToString() == "00000000-0000-0000-0000-000000000000")
                    {
                        return Guid.Empty;
                    }
                    try
                    {
                        return new Guid(value.ToString());
                    }
                    catch
                    {
                        return Guid.Empty;
                    }
                }
            }
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                NullableConverter converter = new NullableConverter(conversionType);
                conversionType = converter.UnderlyingType;
            }
            return Convert.ChangeType(value, conversionType);
        }

        /// <summary>
        /// 将数据转换为指定类型
        /// </summary>
        /// <typeparam name="T">转换的目标类型</typeparam>
        /// <param name="data">转换的数据</param>
        public static T ToType<T>(this object data)
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
    }
}

