using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseMgmt.Domain.Entity;
using Wicresoft.Common;

namespace CourseMgmt.BizLogic.Service
{
    public class UserService
    {
        public static bool CheckUserExsit(string username, int userId)
        {
            if (userId <= 0)
            {
                return DataAccess.Count(typeof(SysUser),
                    string.Format("{0}='{1}'", SysUser.SQLCOL_USERNAME, username)) > 0;
            }
            else
            {
                return DataAccess.Count(typeof(SysUser),
                    string.Format("{0}='{1}' AND {2}<>{3}", SysUser.SQLCOL_USERNAME, username, SysUser.SQLCOL_ID, userId)) > 0;
            }
        }

    }
}
