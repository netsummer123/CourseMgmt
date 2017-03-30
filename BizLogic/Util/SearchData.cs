namespace CourseMgmt.BizLogic.Util
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    /// <summary>
    /// 列表页面状态记录
    /// </summary>
    [DataContract]
    public class SearchData
    {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, string> conditions;

        /// <summary>
        /// Gets or sets the conditions.
        /// </summary>
        /// <value>The conditions.</value>
        [DataMember]
        public Dictionary<string, string> Conditions
        {
            get
            {
                if (this.conditions == null)
                {
                    this.conditions = new Dictionary<string, string>();
                }
                return this.conditions;
            }
            set
            {
                this.conditions = value;
            }
        }

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        [DataMember]
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the name of the page.
        /// </summary>
        /// <value>The name of the page.</value>
        [DataMember]
        public string PageName { get; set; }

        /// <summary>
        /// Gets or sets the record count.
        /// </summary>
        /// <value>The record count.</value>
        [DataMember]
        public int RecordCount { get; set; }
    }
}

