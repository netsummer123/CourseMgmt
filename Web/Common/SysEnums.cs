using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CourseMgmt.Web.Common
{
    /// <summary>
    /// 用户列席
    /// </summary>
    public enum SysUserType
    {
        SysAdmin = 1,
        Teacher = 11,
        Student = 12
    }

    /// <summary>
    /// 性别类型
    /// </summary>
    public enum SexType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        UnKnow = 0,
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Male = 1,
        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Female = 2,
    }

    public enum SysDeptType
    {
        [Description("社会科学教研部")]
        Dept8 = 80,
        [Description("机械工程系")]
        Dept1 = 10,
        [Description("电气工程系")]
        Dept2 = 20,
        [Description("模具技术系")]
        Dept3 = 30,
        [Description("车辆工程系")]
        Dept4 = 40,
        [Description("信息工程系")]
        Dept5 = 50,
        [Description("经济管理系 ")]
        Dept6 = 60,
        [Description("艺术设计系")]
        Dept7 = 70,
        [Description("基础部")]
        Dept9 = 90,
        [Description("体育部")]
        Dept10 = 100,
        [Description("继续教育学院")]
        Dept11 = 110,
    }

    public enum TaskCategory
    {
        [Description("理论教学-作业1")]
        Task1 = 10,

        [Description("理论教学-作业2")]
        Task2 = 20,

        [Description("理论教学-作业3")]
        Task3 = 30,

        [Description("实践教学-公益基地项目1")]
        Task4 = 40,

        [Description("实践教学-公益基地项目2")]
        Task5 = 50,

        [Description("实践教学-校内基地项目")]
        Task6 = 60,

        [Description("期末考查")]
        Task7 = 70,
    }

    public enum TaskStatus
    {
        [Description("待批改")]
        ToCorrect = 10,
        [Description("已批改")]
        Corrected = 20,
    }
}