using System.IO;
using System.Linq;
using System.Web;

namespace CourseMgmt.BizLogic.Util
{
    public static class FileHelper
    {
        //public static string ToVirtualPath(this UploadFileType filetype)
        //{
        //    return Config.SystemConfig.FileUploadDirectory + filetype.GenerateVirtualPath();
        //}

        /// <summary>
        /// gets the bytes for the posted file
        /// </summary>
        /// <param name="stream">The obj file stream.</param>
        public static byte[] GetFileStream(Stream stream)
        {
            if (stream != null) {
                var filebytes = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(filebytes, 0, filebytes.Length);
                return filebytes;
            }
            return null;
        }

        /// <summary>
        /// 校验附件后缀是否合法
        /// </summary>
        /// <param name="fileName">附件文件名</param>
        public static bool CheckAttachmentExtension(string fileName)
        {
            var denyExtensions = new string[] { ".ade", ".adp", ".bat", ".chm", ".cmd", ".com", ".cpl", ".exe", ".hta", ".ins", ".isp", ".jse", ".lib", ".lnk", ".mde", ".msc", ".msp", ".mst", ".pif", ".scr", ".sct", ".shb", ".sys", ".vb", ".vbe", ".vbs", ".vxd", ".wsc", ".wsf", ".wsh" };
            var fileExt = Path.GetExtension(fileName);
            if (denyExtensions.Any(p => p == fileExt))
                return false;
            return true;
        }

        /// <summary>
        /// 上传文件到服务端
        /// </summary>
        /// <param name="postedFile">上传文件控件</param>
        /// <param name="physicalPath">物理路径</param>
        public static bool UploadFile(HttpPostedFile postedFile, string physicalPath)
        {
            var dir = Path.GetDirectoryName(physicalPath);
            if(dir == null)
                return false;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            postedFile.SaveAs(physicalPath);

            return true;
        }
    }

}