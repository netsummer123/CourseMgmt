namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    public class TypeHelper
    {
        /// <summary>
        /// 对象属性拷贝(全匹配拷贝)
        /// </summary>
        /// <typeparam name="TK">The type of the K.</typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj1">源对象</param>
        /// <param name="obj2">目标对象</param>
        /// <returns>目标对象</returns>
        public static T CopyProperty<TK, T>(TK obj1, T obj2)
        {
            Type type = obj1.GetType();
            Type type2 = obj2.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (properties != null)
            {
                foreach (PropertyInfo info in properties)
                {
                    if ((info.PropertyType.BaseType != typeof(Array)) && info.PropertyType.ToString().StartsWith("System"))
                    {
                        string name = info.Name;
                        PropertyInfo property = type2.GetProperty(name);
                        if (property != null)
                        {
                            property.SetValue(obj2, info.GetValue(obj1, null), null);
                        }
                    }
                }
            }
            return obj2;
        }

        /// <summary>
        /// 获取类型默认值.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object GetDefaultValue(Type type)
        {
            if (type != null)
            {
                if (type == typeof(bool))
                {
                    return false;
                }
                if (type == typeof(byte))
                {
                    return (byte) 0;
                }
                if (type == typeof(char))
                {
                    return '0';
                }
                if (type == typeof(decimal))
                {
                    return 0.0M;
                }
                if (type == typeof(double))
                {
                    return 0.0;
                }
                if (type == typeof(float))
                {
                    return 0f;
                }
                if (type == typeof(int))
                {
                    return 0;
                }
                if (type == typeof(long))
                {
                    return 0L;
                }
                if (type == typeof(sbyte))
                {
                    return (sbyte) 0;
                }
                if (type == typeof(short))
                {
                    return (short) 0;
                }
                if (type == typeof(uint))
                {
                    return 0;
                }
                if (type == typeof(ulong))
                {
                    return (ulong) 0L;
                }
                if (type == typeof(ushort))
                {
                    return (ushort) 0;
                }
            }
            return null;
        }
    }
}

