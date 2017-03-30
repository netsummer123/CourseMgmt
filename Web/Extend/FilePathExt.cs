using System;
using System.IO;
using System.Text;

namespace CourseMgmt.Web.Extend
{
    public class FilePathExt
    {
        /// <summary>
        /// 连接多个路径
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string CombineToPhysicalPath(string path1, string path2)
        {
            return Path.Combine(path1, path2)
                .Replace("~/", "/")
                .Replace('/', Path.DirectorySeparatorChar)
                .Replace(@"\\", @"\");
        }


        public static string ReadFile(string filePath)
        {
            string resultStr = "";
            StreamReader myStreamReader = new StreamReader(filePath, Encoding.UTF8);
            using (myStreamReader)
            {
                resultStr = myStreamReader.ReadToEnd();
            }
            return resultStr;
        }

        public static bool WriteFile(string filePath, string fileContent)
        {
            PathExists(filePath);
            StreamWriter myStreamWriter = new StreamWriter(filePath, false, Encoding.UTF8);
            using (myStreamWriter)
            {
                try
                {
                    myStreamWriter.Write(fileContent);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 验证路径是否存在，不存在则创建
        /// </summary>
        /// <param name="filePath"></param>
        public static void PathExists(string filePath)
        {
            FileInfo myFileInfo = new FileInfo(filePath);
            if (!Directory.Exists(myFileInfo.DirectoryName))
            {
                Directory.CreateDirectory(myFileInfo.DirectoryName);
            }
        }

        /// <summary>
        /// 获取扩展名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetExtension(string filePath)
        {
            var extension = Path.GetExtension(filePath);
            if (extension != null)
            {
                return extension.ToLower();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 确定路径中目录是否存在,是则返回true
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool PathValid(string filePath)
        {
            FileInfo myFileInfo = new FileInfo(filePath);
            return Directory.Exists(myFileInfo.DirectoryName);
        }

        /// <summary>
        /// 删除文件夹或文件
        /// </summary>
        /// <param name="folderName"></param>
        public static void Del(string folderName)
        {
            string myExtension = GetExtension(folderName);
            if (string.IsNullOrEmpty(myExtension))
            {
                if (PathValid(folderName))
                {
                    Directory.Delete(folderName, true);
                }
            }
            else
            {
                if (File.Exists(folderName))
                {
                    File.Delete(folderName);
                }
            }
        }

        /// <summary>
        /// 获取格式化后的文件大小
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SizeFormat(long length)
        {
            if (length > 1024 && length < 1048576)
            {
                return Convert.ToInt32(length / 1024) + "KB";
            }
            else if (length > 1048576 && length < 1073741824)
            {
                return Convert.ToInt32(length / 1024) + "MB";
            }
            else if (length > 1073741824)
            {
                return Convert.ToInt32(length / 1024) + "GB";
            }
            else
            {
                return length + "B";
            }
        }
    }
}