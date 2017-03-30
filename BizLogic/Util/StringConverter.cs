namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public static class StringConverter
    {
        /// <summary>
        /// 反编码Base64.
        /// </summary>
        /// <param name="input">A base64 encoded string</param>
        /// <returns>A decoded string</returns>
        public static string Base64Decode(this string input)
        {
            byte[] bytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// 获取Base64 编码.
        /// </summary>
        /// <param name="input">A string</param>
        /// <returns>A base64 encoded string</returns>
        public static string Base64Encode(this string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        /// <summary>
        /// 将 GB2312 值转换为 UTF8 字符串 (如：娴嬭瘯 -&gt; 测试)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConvertGBToUTF8(this string source)
        {
            return Encoding.UTF8.GetString(Encoding.GetEncoding("GB2312").GetBytes(source));
        }

        /// <summary>
        /// 由16进制转为汉字字符串（如：B2E2 -&gt; 测 ）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConvertHexToString(this string source)
        {
            byte[] bytes = new byte[source.Length / 2];
            for (int i = 0; i < source.Length; i += 2)
            {
                Convert.ToInt32(source.Substring(i, 2), 0x10).ToString();
                bytes[i / 2] = Convert.ToByte(source.Substring(i, 2), 0x10);
            }
            return Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// 转化为ASC码方法.
        /// </summary>
        /// <param name="txt">The TXT.</param>
        /// <returns></returns>
        public static string ConvertToASC(this string txt)
        {
            string str = "";
            foreach (char ch in txt)
            {
                str = str + Convert.ToString((int) ch);
            }
            return str;
        }

        /// <summary>
        /// 字符串转为16进制字符串（如：测 -&gt; B2E2 ）
        /// </summary>
        /// <param name="Word"></param>
        /// <returns></returns>
        public static string ConvertToHex(this string Word)
        {
            int length = Word.Length;
            string str2 = "";
            byte[] bytes = new byte[2];
            for (int i = 0; i < length; i++)
            {
                int num2;
                string s = Word.Substring(i, 1);
                bytes = Encoding.Default.GetBytes(s);
                int num5 = bytes.Length;
                if (num5.ToString() == "1")
                {
                    num2 = Convert.ToInt32(bytes[0]);
                    str2 = str2 + Convert.ToString(num2, 0x10);
                }
                else
                {
                    num2 = Convert.ToInt32(bytes[0]);
                    int num3 = Convert.ToInt32(bytes[1]);
                    str2 = str2 + Convert.ToString(num2, 0x10) + Convert.ToString(num3, 0x10);
                }
            }
            return str2.ToUpper();
        }

        /// <summary>
        /// 字符串转为unicode字符串（如：测试 -&gt; 测试）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConvertToUnicode(this string source)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(source.Substring(i, 1));
                if (bytes.Length > 1)
                {
                    string str = Convert.ToString((short) bytes[1], 0x10);
                    string str2 = Convert.ToString((short) bytes[0], 0x10);
                    str = ((str.Length == 1) ? "0" : "") + str;
                    str2 = ((str2.Length == 1) ? "0" : "") + str2;
                    builder.Append("&#" + Convert.ToInt32(str + str2, 0x10) + ";");
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// 字符串转为UTF8字符串（如：测试 -&gt; \u6d4b\u8bd5）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConvertToUTF8(this string source)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(source.Substring(i, 1));
                if (bytes.Length > 1)
                {
                    string str = Convert.ToString((short) bytes[1], 0x10);
                    string str2 = Convert.ToString((short) bytes[0], 0x10);
                    builder.Append(@"\u" + (((str.Length == 1) ? "0" : "") + str) + (((str2.Length == 1) ? "0" : "") + str2));
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// 将 UTF8 值转换为 GB2312 字符串(如：测试 -&gt; 娴嬭瘯 )
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConvertUTF8ToGB(this string source)
        {
            return Encoding.GetEncoding("GB2312").GetString(Encoding.UTF8.GetBytes(source));
        }

        /// <summary>
        /// 转化为bool型，默认值为false.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static bool ToBoolean(this string val)
        {
            bool result = false;
            bool.TryParse(val, out result);
            return result;
        }

        /// <summary>
        /// 转化为DateTime型，默认值为DateTime.MinValue.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string val)
        {
            DateTime minValue = DateTime.MinValue;
            DateTime.TryParse(val, out minValue);
            return minValue;
        }

        /// <summary>
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        /// <remarks>
        /// 全角空格为12288，半角空格为32
        /// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        /// </remarks>
        public static string ToDBC(this string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == '　')
                {
                    chArray[i] = ' ';
                }
                else if ((chArray[i] > 0xff00) && (chArray[i] < 0xff5f))
                {
                    chArray[i] = (char) (chArray[i] - 0xfee0);
                }
            }
            return new string(chArray);
        }

        /// <summary>
        /// 转化为decimal型，默认值为0.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string val)
        {
            decimal result = 0M;
            decimal.TryParse(val, out result);
            return result;
        }

        /// <summary>
        /// 转化为double型，默认值为0.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static double ToDouble(this string val)
        {
            double result = 0.0;
            double.TryParse(val, out result);
            return result;
        }

        /// <summary>
        /// 通过字符串获取枚举成员实例
        /// </summary>
        /// <typeparam name="T">枚举名,比如Enum1</typeparam>
        /// <param name="member">枚举成员的常量名或常量值,
        /// 范例:Enum1枚举有两个成员A=0,B=1,则传入"A"或"0"获取 Enum1.A 枚举类型</param>
        public static T ToEnum<T>(string member)
        {
            return Enum.Parse(typeof(T), member, true).ToType<T>();
        }

        /// <summary>
        /// 转化为Guid型，默认值为Guid.Empty.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static Guid ToGuid(this string val)
        {
            Guid empty = Guid.Empty;
            if (!string.IsNullOrEmpty(val))
            {
                empty = new Guid(val);
            }
            return empty;
        }

        /// <summary>
        /// 转化为int型，默认值为0.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static int ToInt32(this string val)
        {
            int result = 0;
            int.TryParse(val, out result);
            return result;
        }

        /// <summary>
        /// 转化为DateTime型,如果不成功，返回null
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(this string val)
        {
            DateTime minValue = DateTime.MinValue;
            if (!DateTime.TryParse(val, out minValue))
            {
                return null;
            }
            if (minValue == DateTime.MinValue)
            {
                return null;
            }
            return new DateTime?(minValue);
        }

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        /// <remarks>
        /// 全角空格为12288，半角空格为32
        /// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        /// </remarks>
        public static string ToSBC(this string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == ' ')
                {
                    chArray[i] = '　';
                }
                else if (chArray[i] < '\x007f')
                {
                    chArray[i] = (char) (chArray[i] + 0xfee0);
                }
            }
            return new string(chArray);
        }

        /// <summary>
        /// 转化为short型，默认值为0.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static short ToShort(this string val)
        {
            short result = 0;
            short.TryParse(val, out result);
            return result;
        }
    }
}

