using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Configuration;

namespace CourseMgmt.Web.Common
{
    public static class SysConsts
    {
        public static readonly string SystemName = ConfigurationManager.AppSettings["SystemName"];
        public static readonly string AccountKey = ConfigurationManager.AppSettings["AccountKey"];
        public static readonly string SignInPath = ConfigurationManager.AppSettings["SignInPath"];
        public static readonly int RootMenuID = Convert.ToInt32(ConfigurationManager.AppSettings["RootMenuID"]);
        public static readonly int RootDeptID = Convert.ToInt32(ConfigurationManager.AppSettings["RootDeptID"]);
        public static readonly int TeacherDeptID = Convert.ToInt32(ConfigurationManager.AppSettings["TeacherDeptID"]);
        public static readonly int StartYear = Convert.ToInt32(ConfigurationManager.AppSettings["StartYear"]);
        public static readonly string InitPassword = ConfigurationManager.AppSettings["InitPassword"];
        public static readonly string FileUploadDirectory = ConfigurationManager.AppSettings["FileUploadDirectory"];
    }
}