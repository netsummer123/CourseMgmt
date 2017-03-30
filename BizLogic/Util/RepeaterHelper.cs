namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Web.UI.WebControls;

    /// <summary>
    /// RepeaterHelper
    /// </summary>
    public static class RepeaterHelper
    {
        /// <summary>
        /// 获取选中项的ID和Name集合,并清除选择 
        /// </summary>
        /// <param name="repeater">The repeater.</param>
        /// <returns></returns>
        public static IList<string>[] GetSelectedIDAndNameListAndClearSeledted(this Repeater repeater)
        {
            IList<string> list = new List<string>();
            IList<string> list2 = new List<string>();
            foreach (RepeaterItem item in repeater.Items)
            {
                CheckBox box = item.FindControl("cbID") as CheckBox;
                if ((box != null) && box.Checked)
                {
                    list.Add(box.ToolTip);
                    box.Checked = false;
                    Label label = item.FindControl("lbName") as Label;
                    if (label != null)
                    {
                        list2.Add(label.Text);
                    }
                }
            }
            return new IList<string>[] { list, list2 };
        }

        /// <summary>
        /// 获取选中项的ID和Name集合 
        /// </summary>
        /// <param name="repeater">The repeater.</param>
        /// <returns></returns>
        public static string[] GetSelectedIDAndNames(this Repeater repeater)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            foreach (RepeaterItem item in repeater.Items)
            {
                CheckBox box = item.FindControl("cbID") as CheckBox;
                if ((box != null) && box.Checked)
                {
                    str = str + "," + box.ToolTip;
                    Label label = item.FindControl("lbName") as Label;
                    if (label != null)
                    {
                        str2 = str2 + "," + label.Text;
                    }
                }
            }
            if (str != string.Empty)
            {
                str = str.Substring(1);
                str2 = str2.Substring(1);
            }
            return new string[] { str, str2 };
        }

        /// <summary>
        /// 获取选中项的ID集合,并清除选择 
        /// </summary>
        /// <param name="repeater">The repeater.</param>
        /// <returns></returns>
        public static IList<string> GetSelectedIDListAndClearSeledted(this Repeater repeater)
        {
            IList<string> list = new List<string>();
            foreach (RepeaterItem item in repeater.Items)
            {
                CheckBox box = item.FindControl("cbID") as CheckBox;
                if ((box != null) && box.Checked)
                {
                    list.Add(box.ToolTip);
                    box.Checked = false;
                }
            }
            return list;
        }

        /// <summary>
        /// 获取选中项的ID集合 
        /// </summary>
        /// <param name="repeater">The repeater.</param>
        /// <returns></returns>
        public static string GetSelectedIDs(this Repeater repeater)
        {
            string str = string.Empty;
            foreach (RepeaterItem item in repeater.Items)
            {
                CheckBox box = item.FindControl("cbID") as CheckBox;
                if ((box != null) && box.Checked)
                {
                    str = str + "," + box.ToolTip;
                }
            }
            if (str != string.Empty)
            {
                str = str.Substring(1);
            }
            return str;
        }

        /// <summary>
        /// 获取选中项的数据项名称.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Web.UI.WebControls.RepeaterCommandEventArgs" /> instance containing the event data.</param>
        /// <returns></returns>
        public static string GetSelectedName(RepeaterCommandEventArgs e)
        {
            Label label = e.Item.FindControl("lbName") as Label;
            if (label != null)
            {
                return label.Text;
            }
            return "";
        }
    }
}

