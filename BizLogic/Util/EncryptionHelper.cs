namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Security;

    /// <summary>
    /// 加密辅助类.
    /// </summary>
    public static class EncryptionHelper
    {
        /// <summary>
        /// Base64解密.
        /// </summary>
        /// <param name="stringToDecrypt">The string to decrypt.</param>
        /// <returns></returns>
        public static string Base64Decrypt(this string stringToDecrypt)
        {
            string str;
            byte[] rgbKey = new byte[] { 11, 0x16, 0x21, 0x2c, 0x37, 0x42, 0x4d, 0x55 };
            byte[] rgbIV = new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] buffer = new byte[stringToDecrypt.Length];
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                buffer = Convert.FromBase64String(stringToDecrypt);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                str = Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        /// <summary>
        /// Base64加密.
        /// </summary>
        /// <param name="stringToEncrypt">The string to encrypt.</param>
        /// <returns></returns>
        public static string Base64Encrypt(this string stringToEncrypt)
        {
            string str;
            byte[] rgbKey = new byte[] { 11, 0x16, 0x21, 0x2c, 0x37, 0x42, 0x4d, 0x55 };
            byte[] rgbIV = new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 };
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                str = Convert.ToBase64String(stream.ToArray());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        /// <summary>
        /// FormsAuthentication的Md5加密.
        /// </summary>
        /// <param name="str">输入字符串.</param>
        /// <returns>返回MD5字符串</returns>
        public static string MD5Encrypt(this string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }

        /// <summary>
        /// MD5CryptoServiceProvider的MD5加密.
        /// </summary>
        /// <param name="inputString">输入字符串</param>
        /// <returns>返回MD5字符串.</returns>
        public static string MD5Hash(this string inputString)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(inputString));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.AppendFormat("{0:x2}", buffer[i]);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Base64加密 QueryString.
        /// </summary>
        /// <param name="stringToDecrypt">The string to decrypt.</param>
        /// <returns></returns>
        public static string QueryStringBase64Decrypt(this string stringToDecrypt)
        {
            return stringToDecrypt.UrlDecode().Replace(' ', '+').Base64Decrypt();
        }

        /// <summary>
        /// Base64解密 QueryString.
        /// </summary>
        /// <param name="stringToEncrypt">The string to encrypt.</param>
        /// <returns></returns>
        public static string QueryStringBase64Encrypt(this string stringToEncrypt)
        {
            return stringToEncrypt.Base64Encrypt().UrlEncode();
        }
    }
}

