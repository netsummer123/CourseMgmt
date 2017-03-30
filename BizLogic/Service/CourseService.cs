using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseMgmt.Domain.Entity;
using Wicresoft.Common;

namespace CourseMgmt.BizLogic.Service
{
    public class CourseService
    {
        public static IList<ViewCourseRel> GetAvailCourseList(int deptId, DateTime time)
        {
            return DataAccess.Select(typeof(ViewCourseRel),
                string.Format("{0}='{1}' AND ({2} <='{3}' AND {4} >= '{5}')", ViewCourseRel.SQLCOL_DEPARTMENTID, deptId,
                    ViewCourseRel.SQLCOL_STARTTIME, time.ToString("yyyy-MM-dd"),
                    ViewCourseRel.SQLCOL_ENDTIME, time.AddDays(-1).ToString("yyyy-MM-dd")), true) as IList<ViewCourseRel>;
        }

        public static IList<ViewCourseRel> GetCourseListByDeptId(int deptId)
        {
            return DataAccess.Select(typeof(ViewCourseRel),
                string.Format("{0}='{1}'", ViewCourseRel.SQLCOL_DEPARTMENTID, deptId), true) as IList<ViewCourseRel>;
        }

    }
}
