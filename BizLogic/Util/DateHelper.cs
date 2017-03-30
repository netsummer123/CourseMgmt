using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseMgmt.BizLogic.Util
{
    /// <summary>
    /// 日期相关通用方法
    /// </summary>
    public class DateHelper
    {
        /// <summary>
        /// 获取今年和去年
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetNowYearAndLastYear()
        {
            var years = new Dictionary<string, string>();
            var nowYear = DateTime.Now.Year;
            years.Add(nowYear.ToString(), nowYear.ToString());
            years.Add((nowYear - 1).ToString(), (nowYear - 1).ToString());

            return years;
        }

        /// <summary>
        /// 获取今年和明年
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetNowYearAndNextYear()
        {
            var years = new Dictionary<string, string>();
            var nowYear = DateTime.Now.Year;
            years.Add(nowYear.ToString(), nowYear.ToString());
            years.Add((nowYear + 1).ToString(), (nowYear + 1).ToString());

            return years;
        }

        /// <summary>
        /// 获取起止年份间的所有年份
        /// </summary>
        public static Dictionary<string, string> GetYearBetween(int startYear, int endYear)
        {
            var years = new Dictionary<string, string>();
            if (startYear > endYear)
            {
                while (startYear >= endYear)
                {
                    years.Add(startYear.ToString(), startYear.ToString());
                    startYear--;
                }
            }
            else
            {
                while (startYear <= endYear)
                {
                    years.Add(startYear.ToString(), startYear.ToString());
                    startYear++;
                }
            }
            return years;
        }


        /// <summary>
        /// 获取12个月
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllMonth()
        {
            var months = new Dictionary<string, string>();
            for (int i = 1; i <= 12; i++)
            {
                months.Add(i.ToString(), i + "月");
            }
            return months;
        }

        /// <summary>
        /// 获取当前服务器时区
        /// </summary>
        public static int GetTimeZone()
        {
            DateTime now = DateTime.Now;
            var utcnow = now.ToUniversalTime();

            var sp = now - utcnow;

            return sp.Hours;
        }
    }
}
