namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 
    /// </summary>
    public static class EnumTypeHelper
    {
        private static Dictionary<Type, Dictionary<int, string>> EnumDics = new Dictionary<Type, Dictionary<int, string>>();

        /// <summary>
        /// 根据枚举值获取枚举描述信息.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static string GetDescriptionFromEnum(Enum item)
        {
            Type enumType = item.GetType();
            object obj2 = item;
            int num = (int) obj2;
            return GetDescriptionFromEnum(enumType, num);
        }

        /// <summary>
        /// 根据枚举类型和int值获取枚举描述信息.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <param name="value">必须能转化为int型.</param>
        /// <returns></returns>
        public static string GetDescriptionFromEnum(Type enumType, object value)
        {
            Dictionary<int, string> valueDescriptionCollection = enumType.GetValueDescriptionCollection();
            int key = Convert.ToInt32(value);
            if (valueDescriptionCollection.ContainsKey(key))
            {
                return valueDescriptionCollection[key];
            }
            return string.Empty;
        }

        /// <summary>
        /// 利用反射获取枚举类型的Description和Value键值对,如果没有Description则返回Name
        /// </summary>
        /// <param name="enumType">Type,该参数的格式为typeof(需要读的枚举类型)</param>
        /// <returns>键值对</returns>
        public static Dictionary<int, string> GetValueDescriptionCollection(this Type enumType)
        {
            Dictionary<int, string> dictionary = null;
            if (EnumDics.ContainsKey(enumType))
            {
                return EnumDics[enumType];
            }
            dictionary = enumType.InitValueDescriptionCollection();
            EnumDics.Add(enumType, dictionary);
            return dictionary;
        }

        /// <summary>
        /// 初始化.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns></returns>
        private static Dictionary<int, string> InitValueDescriptionCollection(this Type enumType)
        {
            Type attributeType = typeof(DescriptionAttribute);
            FieldInfo[] fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            Dictionary<int, string> dictionary = new Dictionary<int, string>(fields.Length);
            string description = string.Empty;
            int key = 0;
            foreach (FieldInfo info in fields)
            {
                if (info.FieldType == enumType)
                {
                    key = (int) info.GetValue(null);
                    object[] customAttributes = info.GetCustomAttributes(attributeType, true);
                    if (customAttributes.Length > 0)
                    {
                        description = ((DescriptionAttribute) customAttributes[0]).Description;
                    }
                    else
                    {
                        description = info.Name;
                    }
                    dictionary.Add(key, description);
                }
            }
            return dictionary;
        }

        /// <summary>
        /// 通过字符串获取枚举成员实例
        /// </summary>
        /// <typeparam name="T">枚举名,比如Enum1</typeparam>
        /// <param name="member">枚举成员的常量名或常量值,
        /// 范例:Enum1枚举有两个成员A=0,B=1,则传入"A"或"0"获取 Enum1.A 枚举类型</param>
        /// <returns></returns>
        public static object ToEnum<T>(this string member) where T: struct
        {
            return Enum.Parse(typeof(T), member, true);
        }

        /// <summary>
        /// 利用反射获取Int型枚举值的Description属性.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static string ToEnumDescriptionString(this Enum member)
        {
            return GetDescriptionFromEnum(member);
        }

        /// <summary>
        /// 利用反射获取Int型枚举值的Description属性，传入的参数必须能转化为int型.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member">传入的参数必须能转化为int型.</param>
        /// <returns></returns>
        public static string ToEnumDescriptionString<T>(this object member)
        {
            return GetDescriptionFromEnum(typeof(T), member);
        }

        /// <summary>
        /// 将Int值转化为枚举名称.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static string ToEnumNameString<T>(this int member) where T: struct
        {
            return Enum.GetName(typeof(T), member);
        }

        /// <summary>
        /// 将枚举值转化为的枚举名称.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static string ToEnumNameString(this object member)
        {
            return Enum.GetName(member.GetType(), member);
        }

        /// <summary>
        /// 获取枚举值字符串.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static string ToEnumValueString(this object member)
        {
            int num = (int) member;
            return num.ToString();
        }
    }
}

