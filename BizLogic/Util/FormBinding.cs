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
    public static class FormBinding
    {
        /// <summary>
        /// 绑定控件值到实体属性.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="container">控件容器.</param>
        public static void BindControlsToObject(this Control container, object obj)
        {
            container.BindControlsToObject(obj, string.Empty);
        }

        /// <summary>
        /// 绑定控件值到实体属性.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="container">控件容器.</param>
        /// <param name="controlPrefix">控件前缀.</param>
        public static void BindControlsToObject(this Control container, object obj, string controlPrefix)
        {
            foreach (PropertyInfo info in obj.GetType().GetProperties())
            {
                string id = string.IsNullOrEmpty(controlPrefix) ? info.Name : (controlPrefix + info.Name);
                Control control = container.FindControl(id);
                if (control != null)
                {
                    GetControlProperty(control, obj, info);
                }
            }
        }

        /// <summary>
        /// 绑定数据实体属性到控件上.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="obj">The obj.</param>
        public static void BindObjectToControls(this Control container, object obj)
        {
            container.BindObjectToControls(obj, string.Empty);
        }

        /// <summary>
        /// 绑定数据实体属性到控件上.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="obj">The obj.</param>
        /// <param name="controlPrefix">控件前缀.</param>
        public static void BindObjectToControls(this Control container, object obj, string controlPrefix)
        {
            if (obj != null)
            {
                foreach (PropertyInfo info in obj.GetType().GetProperties())
                {
                    string id = string.IsNullOrEmpty(controlPrefix) ? info.Name : (controlPrefix + info.Name);
                    Control control = container.FindControl(id);
                    if (control != null)
                    {
                        SetControlProperty(control, obj, info);
                    }
                }
            }
        }

        /// <summary>
        /// 设置控件属性.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="objProperty">The obj property.</param>
        private static void ClearControlProperty(Control control, PropertyInfo objProperty)
        {
            if (!(control is ListControl))
            {
                if (control is TextBox)
                {
                    ((TextBox) control).Text = "";
                }
                else if (control is Literal)
                {
                    ((Literal) control).Text = "";
                }
                else if (control is Label)
                {
                    ((Label) control).Text = "";
                }
                else if (control is CheckBox)
                {
                    if (objProperty.PropertyType == typeof(bool))
                    {
                        ((CheckBox) control).Checked = false;
                    }
                }
                else if (!(control is Calendar))
                {
                    PropertyInfo[] properties = control.GetType().GetProperties();
                    bool flag = false;
                    if (!FindAndClearControlProperty(control, properties, "Value", typeof(string)))
                    {
                        flag = FindAndClearControlProperty(control, properties, "Text", typeof(string));
                    }
                }
            }
        }

        /// <summary>
        /// 绑定数据实体属性到控件上.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="obj">The obj.</param>
        public static void ClearControlsByObject(this Control container, object obj)
        {
            container.ClearControlsByObject(obj, string.Empty);
        }

        /// <summary>
        /// 绑定数据实体属性到控件上.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="obj">The obj.</param>
        /// <param name="controlPrefix">控件前缀.</param>
        public static void ClearControlsByObject(this Control container, object obj, string controlPrefix)
        {
            if (obj != null)
            {
                foreach (PropertyInfo info in obj.GetType().GetProperties())
                {
                    string id = string.IsNullOrEmpty(controlPrefix) ? info.Name : (controlPrefix + info.Name);
                    Control control = container.FindControl(id);
                    if (control != null)
                    {
                        ClearControlProperty(control, info);
                    }
                }
            }
        }

        /// <summary>
        /// 反射设置控件属性值.
        /// </summary>
        /// <param name="control">控件.</param>
        /// <param name="controlPropertiesArray">控件属性数组.</param>
        /// <param name="propertyName">属性名称.</param>
        /// <param name="type">属性类型.</param>
        /// <returns></returns>
        private static bool FindAndClearControlProperty(Control control, PropertyInfo[] controlPropertiesArray, string propertyName, Type type)
        {
            foreach (PropertyInfo info in controlPropertiesArray)
            {
                if ((info.Name == propertyName) && (info.PropertyType == type))
                {
                    info.SetValue(control, "", null);
                    return true;
                }
            }
            return false;
        }

        private static bool FindAndGetControlProperty(object obj, PropertyInfo objProperty, Control control, PropertyInfo[] controlPropertiesArray, string propertyName, Type type)
        {
            foreach (PropertyInfo info in controlPropertiesArray)
            {
                if ((info.Name == propertyName) && (info.PropertyType == type))
                {
                    try
                    {
                        objProperty.SetValue(obj, Convert.ChangeType(info.GetValue(control, null), objProperty.PropertyType), null);
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
        /// <param name="obj">实体数据.</param>
        /// <param name="objProperty">实体数据属性.</param>
        /// <param name="control">控件.</param>
        /// <param name="controlPropertiesArray">控件属性数组.</param>
        /// <param name="propertyName">属性名称.</param>
        /// <param name="type">属性类型.</param>
        /// <returns></returns>
        private static bool FindAndSetControlProperty(object obj, PropertyInfo objProperty, Control control, PropertyInfo[] controlPropertiesArray, string propertyName, Type type)
        {
            foreach (PropertyInfo info in controlPropertiesArray)
            {
                if ((info.Name == propertyName) && (info.PropertyType == type))
                {
                    info.SetValue(control, Convert.ChangeType(objProperty.GetValue(obj, null), type), null);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取控件值，设置实体属性.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="obj">The obj.</param>
        /// <param name="objProperty">The obj property.</param>
        private static void GetControlProperty(Control control, object obj, PropertyInfo objProperty)
        {
            if (control is ListControl)
            {
                ListControl control2 = (ListControl) control;
                if (control2.SelectedItem != null)
                {
                    object obj2 = Converter.ChangeNullableType(control2.SelectedItem.Value, objProperty.PropertyType);
                    objProperty.SetValue(obj, obj2, null);
                }
            }
            else if (control is TextBox)
            {
                string text = ((TextBox) control).Text;
                objProperty.SetValue(obj, Converter.ChangeNullableType(text, objProperty.PropertyType), null);
            }
            else if (control is Literal)
            {
                objProperty.SetValue(obj, Convert.ChangeType(((Literal) control).Text, objProperty.PropertyType), null);
            }
            else if (control is Label)
            {
                objProperty.SetValue(obj, Convert.ChangeType(((Label) control).Text, objProperty.PropertyType), null);
            }
            else if (control is CheckBox)
            {
                if (objProperty.PropertyType == typeof(bool))
                {
                    objProperty.SetValue(obj, Convert.ChangeType(((CheckBox) control).Checked, objProperty.PropertyType), null);
                }
            }
            else if (control is Calendar)
            {
                if (objProperty.PropertyType == typeof(DateTime))
                {
                    objProperty.SetValue(obj, Convert.ChangeType(((Calendar) control).SelectedDate, objProperty.PropertyType), null);
                }
            }
            else
            {
                PropertyInfo[] properties = control.GetType().GetProperties();
                bool flag = false;
                flag = FindAndGetControlProperty(obj, objProperty, control, properties, "Checked", typeof(bool));
                if (!flag)
                {
                    flag = FindAndGetControlProperty(obj, objProperty, control, properties, "SelectedDate", typeof(DateTime));
                }
                if (!flag)
                {
                    flag = FindAndGetControlProperty(obj, objProperty, control, properties, "Value", typeof(string));
                }
                if (!flag)
                {
                    flag = FindAndGetControlProperty(obj, objProperty, control, properties, "Text", typeof(string));
                }
            }
        }

        /// <summary>
        /// 设置控件属性.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="obj">The obj.</param>
        /// <param name="objProperty">The obj property.</param>
        private static void SetControlProperty(Control control, object obj, PropertyInfo objProperty)
        {
            object obj2 = objProperty.GetValue(obj, null);
            if ((obj2 != null) && ((obj2.ToString() != "00000000-0000-0000-0000-000000000000") || (objProperty.PropertyType != typeof(Guid))))
            {
                if (control is ListControl)
                {
                    ListControl control2 = (ListControl) control;
                    control2.ClearSelection();
                    string str = obj2.ToString();
                    ListItem item = control2.Items.FindByValue(str);
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
                else if (control is TextBox)
                {
                    ((TextBox) control).Text = obj2.ToString();
                }
                else if (control is Literal)
                {
                    ((Literal) control).Text = obj2.ToString();
                }
                else if (control is Label)
                {
                    ((Label) control).Text = obj2.ToString();
                }
                else if (control is CheckBox)
                {
                    if (objProperty.PropertyType == typeof(bool))
                    {
                        ((CheckBox) control).Checked = (bool) objProperty.GetValue(obj, null);
                    }
                }
                else if (control is Calendar)
                {
                    if (objProperty.PropertyType == typeof(DateTime))
                    {
                        ((Calendar) control).SelectedDate = (DateTime) objProperty.GetValue(obj, null);
                    }
                }
                else
                {
                    PropertyInfo[] properties = control.GetType().GetProperties();
                    bool flag = false;
                    flag = FindAndSetControlProperty(obj, objProperty, control, properties, "Checked", typeof(bool));
                    if (!flag)
                    {
                        flag = FindAndSetControlProperty(obj, objProperty, control, properties, "SelectedDate", typeof(DateTime));
                    }
                    if (!flag)
                    {
                        flag = FindAndSetControlProperty(obj, objProperty, control, properties, "Value", typeof(string));
                    }
                    if (!flag)
                    {
                        flag = FindAndSetControlProperty(obj, objProperty, control, properties, "Text", typeof(string));
                    }
                }
            }
        }
    }
}

