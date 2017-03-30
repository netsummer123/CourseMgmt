namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// 
    /// </summary>
    public static class SearchBinding
    {
        private static bool FindAndGetControlProperty(Control control, PropertyInfo[] controlPropertiesArray, string propertyName, Type type, ref string value)
        {
            foreach (PropertyInfo info in controlPropertiesArray)
            {
                if ((info.Name == propertyName) && (info.PropertyType == type))
                {
                    try
                    {
                        object obj2 = info.GetValue(control, null);
                        if (obj2 != null)
                        {
                            value = obj2.ToString();
                        }
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 反射设置控件属性值.
        /// </summary>
        /// <param name="control">控件.</param>
        /// <param name="controlPropertiesArray">控件属性数组.</param>
        /// <param name="propertyName">属性名称.</param>
        /// <param name="type">属性类型.</param>
        /// <param name="value">控件属性值.</param>
        /// <returns></returns>
        private static bool FindAndSetControlProperty(Control control, PropertyInfo[] controlPropertiesArray, string propertyName, Type type, string value)
        {
            foreach (PropertyInfo info in controlPropertiesArray)
            {
                if ((info.Name == propertyName) && (info.PropertyType == type))
                {
                    info.SetValue(control, Convert.ChangeType(value, type), null);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取控件值，设置实体属性.
        /// </summary>
        /// <param name="control">The control.</param>
        private static string GetControlPropertyValue(Control control)
        {
            if (control is ListControl)
            {
                ListControl control2 = (ListControl)control;
                if (control2.SelectedItem != null)
                {
                    return control2.SelectedItem.Value;
                }
            }
            else
            {
                if (control is TextBox)
                {
                    return ((TextBox)control).Text;
                }
                if (control is Literal)
                {
                    return ((Literal)control).Text;
                }
                if (control is Label)
                {
                    return ((Label)control).Text;
                }
                if (control is CheckBox)
                {
                    return ((CheckBox)control).Checked.ToString();
                }
                if (control is Calendar)
                {
                    return ((Calendar)control).SelectedDate.ToString("yyyy-MM-dd");
                }
                PropertyInfo[] properties = control.GetType().GetProperties();
                string str = string.Empty;
                bool flag = false;
                flag = FindAndGetControlProperty(control, properties, "Checked", typeof(bool), ref str);
                if (!flag)
                {
                    flag = FindAndGetControlProperty(control, properties, "SelectedDate", typeof(DateTime), ref str);
                }
                if (!flag)
                {
                    flag = FindAndGetControlProperty(control, properties, "Value", typeof(string), ref str);
                }
                if (!flag)
                {
                    flag = FindAndGetControlProperty(control, properties, "Text", typeof(string), ref str);
                }
            }
            return "";
        }

        /// <summary>
        /// 从Cookie中获取查询条件.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        public static SearchData GetSearchData(this Control container)
        {
            string str = CookieHelper.Get("SearchCondition");
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            SearchData data = str.DeJson<SearchData>();
            if (data == null)
            {
                return null;
            }
            string str2 = container.Page.ToString();
            if (data.PageName != str2)
            {
                return null;
            }
            return data;
        }

        /// <summary>
        /// 从Cookie加载查询条件.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="controlPrefix">The control prefix.</param>
        /// <param name="pagername">The pagername.</param>
        /// <returns></returns>
        public static SearchData LoadSearchCondition(this Control container, string controlPrefix, string pagername)
        {
            string str = CookieHelper.Get("SearchCondition");
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            SearchData data = str.DeJson<SearchData>();
            if (data == null)
            {
                return null;
            }
            string str2 = container.Page.ToString();
            if (data.PageName != str2)
            {
                return null;
            }
            foreach (Control control in container.Controls)
            {
                if (((control.ID != null) && control.ID.StartsWith(controlPrefix)) && data.Conditions.ContainsKey(control.ID))
                {
                    SetControlProperty(control, data.Conditions[control.ID]);
                }
            }
            if (!string.IsNullOrEmpty(pagername))
            {
                Control control2 = container.Parent.FindControl(pagername);
                if (control2 != null)
                {
                    control2.GetType().GetProperty("RecordCount").SetValue(control2, data.RecordCount, null);
                    control2.GetType().GetProperty("CurrentPageIndex").SetValue(control2, data.PageIndex, null);
                }
            }
            return data;
        }

        /// <summary>
        /// 保存查询条件至Cookie.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="controlPrefix">The control prefix.</param>
        /// <param name="pagername">The pagername.</param>
        public static void PersistSearchCondition(this Control container, string controlPrefix, string pagername)
        {
            SearchData data = new SearchData();
            foreach (Control control in container.Controls)
            {
                if ((control.ID != null) && control.ID.StartsWith(controlPrefix))
                {
                    data.Conditions.Add(control.ID, GetControlPropertyValue(control));
                }
            }
            if (!string.IsNullOrEmpty(pagername))
            {
                Control control2 = container.Parent.FindControl(pagername);
                if (control2 != null)
                {
                    object obj2 = control2.GetType().GetProperty("CurrentPageIndex").GetValue(control2, null);
                    data.PageIndex = (int)obj2;
                    obj2 = control2.GetType().GetProperty("RecordCount").GetValue(control2, null);
                    data.RecordCount = (int)obj2;
                }
            }
            string str = container.Page.ToString();
            data.PageName = str;
            CookieHelper.Add("SearchCondition", data.ToJson());
        }

        /// <summary>
        /// 设置控件属性.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="value">The value.</param>
        private static void SetControlProperty(Control control, string value)
        {
            if (control is ListControl)
            {
                ListControl control2 = (ListControl)control;
                control2.ClearSelection();
                ListItem item = control2.Items.FindByValue(value);
                if (item != null)
                {
                    item.Selected = true;
                }
            }
            else if (control is TextBox)
            {
                ((TextBox)control).Text = value;
            }
            else if (control is Literal)
            {
                ((Literal)control).Text = value;
            }
            else if (control is Label)
            {
                ((Label)control).Text = value;
            }
            else if (control is CheckBox)
            {
                ((CheckBox)control).Checked = value.ToBoolean();
            }
            else if (control is Calendar)
            {
                ((Calendar)control).SelectedDate = value.ToDateTime();
            }
            else
            {
                PropertyInfo[] properties = control.GetType().GetProperties();
                bool flag = false;
                flag = FindAndSetControlProperty(control, properties, "Checked", typeof(bool), value);
                if (!flag)
                {
                    flag = FindAndSetControlProperty(control, properties, "SelectedDate", typeof(DateTime), value);
                }
                if (!flag)
                {
                    flag = FindAndSetControlProperty(control, properties, "Value", typeof(string), value);
                }
                if (!flag)
                {
                    flag = FindAndSetControlProperty(control, properties, "Text", typeof(string), value);
                }
            }
        }

        /// <summary>
        /// 保存查询条件至Cookie.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="searchData">The search data.</param>
        public static void SetSearchData(this Control container, SearchData searchData)
        {
            CookieHelper.Add("SearchCondition", searchData.ToJson());
        }
    }
}

