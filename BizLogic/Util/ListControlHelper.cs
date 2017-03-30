namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Runtime.CompilerServices;
    using System.Web.UI.WebControls;

    /// <summary>
    /// 
    /// </summary>
    public static class ListControlHelper
    {
        /// <summary>
        /// 绑定列表.
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="datasource">The datasource.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="valueField">The value field.</param>
        public static void BindData(this ListControl listControl, object datasource, string textField, string valueField)
        {
            if (listControl != null)
            {
                listControl.DataSource = datasource;
                listControl.DataTextField = textField;
                listControl.DataValueField = valueField;
                listControl.DataBind();
            }
        }

        /// <summary>
        /// 绑定列表，首项插入new ListItem("全部", "").
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="datasource">The datasource.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="valueField">The value field.</param>
        public static void BindDataAppendAllItem(this ListControl listControl, object datasource, string textField, string valueField)
        {
            if (listControl != null)
            {
                listControl.BindData(datasource, textField, valueField);
                listControl.Items.Insert(0, new ListItem("全部", ""));
            }
        }

        /// <summary>
        /// 绑定列表，首项插入new ListItem("", "").
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="datasource">The datasource.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="valueField">The value field.</param>
        public static void BindDataAppendEmptyItem(this ListControl listControl, object datasource, string textField, string valueField)
        {
            if (listControl != null)
            {
                listControl.BindData(datasource, textField, valueField);
                listControl.Items.Insert(0, new ListItem("", ""));
            }
        }

        /// <summary>
        /// 绑定列表，首项插入new ListItem("", "0").
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="datasource">The datasource.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="valueField">The value field.</param>
        public static void BindDataAppendEmptyZeroItem(this ListControl listControl, object datasource, string textField, string valueField)
        {
            if (listControl != null)
            {
                listControl.BindData(datasource, textField, valueField);
                listControl.Items.Insert(0, new ListItem("", "0"));
            }
        }

        /// <summary>
        /// 绑定列表，首项插入new ListItem(allItemTitle, "").
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="datasource">The datasource.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="valueField">The value field.</param>
        /// <param name="allItemTitle">All item title.</param>
        public static void BindDataAppendTitleAllItem(this ListControl listControl, object datasource, string textField, string valueField, string allItemTitle)
        {
            if (listControl != null)
            {
                listControl.BindData(datasource, textField, valueField);
                listControl.Items.Insert(0, new ListItem(allItemTitle, ""));
            }
        }

        /// <summary>
        /// 为列表框的选项加上长标题显示.
        /// </summary>
        /// <param name="listControl">The list control.</param>
        public static void BindListItemsTitleAttribute(this ListControl listControl)
        {
            foreach (ListItem item in listControl.Items)
            {
                item.Attributes.Add("title", item.Text);
            }
        }

        /// <summary>
        /// 获取List控件的选取值列表，逗号分隔
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <returns></returns>
        public static string GetListSelectedTextCommaString(this ListControl listControl)
        {
            if ((listControl == null) || (listControl.Items.Count == 0))
            {
                return string.Empty;
            }
            string str = string.Empty;
            foreach (ListItem item in listControl.Items)
            {
                if (item.Selected)
                {
                    str = str + item.Text + ",";
                }
            }
            if (str != string.Empty)
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        /// <summary>
        /// 获取List控件的选取值列表，逗号分隔
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <returns></returns>
        public static string GetListSelectedValueCommaString(this ListControl listControl)
        {
            if ((listControl == null) || (listControl.Items.Count == 0))
            {
                return string.Empty;
            }
            string str = string.Empty;
            foreach (ListItem item in listControl.Items)
            {
                if (item.Selected)
                {
                    str = str + item.Value + ",";
                }
            }
            if (str != string.Empty)
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        /// <summary>
        /// 获取List控件的选取值列表，逗号分隔
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <returns></returns>
        public static string GetListValueState(this ListControl listControl)
        {
            if ((listControl == null) || (listControl.Items.Count == 0))
            {
                return string.Empty;
            }
            string str = string.Empty;
            foreach (ListItem item in listControl.Items)
            {
                if (item.Selected)
                {
                    str = str + item.Value + ",";
                }
            }
            if (str != string.Empty)
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        /// <summary>
        /// 绑定Dictionary数据集至ListControl.
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="data">The data.</param>
        public static void LoadData(this ListControl listControl, Dictionary<string, string> data)
        {
            listControl.DataSource = data;
            listControl.DataTextField = "Value";
            listControl.DataValueField = "Key";
            listControl.DataBind();
        }

        /// <summary>
        /// 绑定Dictionary数据项，并在首项插入ListItem("全部", "").
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="data">The data.</param>
        public static void LoadDataAppendAllItem(this ListControl listControl, Dictionary<string, string> data)
        {
            listControl.LoadData(data);
            listControl.Items.Insert(0, new ListItem("全部", ""));
        }

        /// <summary>
        /// 绑定Dictionary数据项，并在首项插入ListItem("", "").
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="data">The data.</param>
        public static void LoadDataAppendEmptyItem(this ListControl listControl, Dictionary<string, string> data)
        {
            listControl.LoadData(data);
            listControl.Items.Insert(0, new ListItem("", ""));
        }

        /// <summary>
        /// 绑定Dictionary数据项，并在首项插入ListItem("", "0").
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="data">The data.</param>
        public static void LoadDataAppendEmptyZeroItem(this ListControl listControl, Dictionary<string, string> data)
        {
            listControl.LoadData(data);
            listControl.Items.Insert(0, new ListItem("", "0"));
        }

        /// <summary>
        /// 绑定Dictionary数据项，并在首项插入指定标题的ListItem("指定标题", "").
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="data">The data.</param>
        /// <param name="allItemTitle">All item title.</param>
        public static void LoadDataAppendTitleAllItem(this ListControl listControl, Dictionary<string, string> data, string allItemTitle)
        {
            listControl.LoadData(data);
            listControl.Items.Insert(0, new ListItem(allItemTitle, ""));
        }

        /// <summary>
        /// 绑定字符串序列至ListControl(字符串序列用","号分隔,如1:国土局,2:发改局)
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="valueRange">The value range.</param>
        public static void LoadStringValueRange(this ListControl listControl, string valueRange)
        {
            if (!string.IsNullOrEmpty(valueRange))
            {
                string[] strArray = valueRange.SplitWithComma();
                if (valueRange.IndexOf(":") > 0)
                {
                    NameValueCollection values = new NameValueCollection();
                    foreach (string str in strArray)
                    {
                        string[] strArray2 = str.SplitWithSeparator(':');
                        values.Add(strArray2[1], strArray2[0]);
                    }
                    for (int i = 0; i < values.Count; i++)
                    {
                        listControl.Items.Add(new ListItem(values.Keys[i], values[i]));
                    }
                }
                else
                {
                    listControl.DataSource = strArray;
                    listControl.DataBind();
                }
            }
        }

        /// <summary>
        /// 根据项值移除Item.
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="itemvalue">The itemvalue.</param>
        public static void RemoveItem(this ListControl listControl, string itemvalue)
        {
            foreach (ListItem item in listControl.Items)
            {
                if (item.Value == itemvalue)
                {
                    listControl.Items.Remove(item);
                    break;
                }
            }
        }

        /// <summary>
        /// 根据文字选中下拉框中的选项.
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="text">The text.</param>
        public static void SelectItemByText(this ListControl listControl, string text)
        {
            if ((listControl != null) && (listControl.Items.Count != 0))
            {
                foreach (ListItem item in listControl.Items)
                {
                    if (item.Text.Trim() == text.Trim())
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        item.Selected = false;
                    }
                }
            }
        }

        /// <summary>
        /// 根据数值选中下拉框中的选项.
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="val">The val.</param>
        public static void SelectItemByValue(this ListControl listControl, string val)
        {
            if ((listControl != null) && (listControl.Items.Count != 0))
            {
                foreach (ListItem item in listControl.Items)
                {
                    if (item.Value == val)
                    {
                        item.Selected = true;
                        break;
                    }
                    item.Selected = false;
                }
            }
        }

        /// <summary>
        /// 绑定数值序列到List控件上
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="values">值列表，逗号分隔.</param>
        public static void SetListValueState(this ListControl listControl, string values)
        {
            if (((listControl != null) && (listControl.Items.Count != 0)) && !string.IsNullOrEmpty(values))
            {
                values = "," + values + ",";
                foreach (ListItem item in listControl.Items)
                {
                    item.Selected = values.IndexOf("," + item.Value + ",") >= 0;
                }
            }
        }
    }
}

