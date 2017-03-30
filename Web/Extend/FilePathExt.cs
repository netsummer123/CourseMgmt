using System;
using System.IO;
using System.Text;

namespace CourseMgmt.Web.Extend
{
    public class FilePathExt
    {
        /// <summary>
        /// ���Ӷ��·��
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
        /// ��֤·���Ƿ���ڣ��������򴴽�
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
        /// ��ȡ��չ��
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
        /// ȷ��·����Ŀ¼�Ƿ����,���򷵻�true
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool PathValid(string filePath)
        {
            FileInfo myFileInfo = new FileInfo(filePath);
            return Directory.Exists(myFileInfo.DirectoryName);
        }

        /// <summary>
        /// ɾ���ļ��л��ļ�
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
        /// ��ȡ��ʽ������ļ���С
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