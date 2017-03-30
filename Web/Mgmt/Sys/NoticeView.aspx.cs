using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseMgmt.BizLogic.Service;
using CourseMgmt.Domain.Entity;
using CourseMgmt.Web.Common;
using CourseMgmt.BizLogic.Util;
using Wicresoft.Common;

namespace CourseMgmt.Web.Mgmt.Sys
{
    public partial class NoticeView : BasePage
    {
        #region 属性

        public int NoticeID
        {
            get
            {
                return ViewState["NoticeID"] != null ? (int)ViewState["NoticeID"] : int.MinValue;
            }
            set
            {
                ViewState["NoticeID"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();

                //判断是修改还是新增
                if (!string.IsNullOrEmpty(Request["NoticeID"]))
                {
                    NoticeID = Convert.ToInt32(Request["NoticeID"]);
                    LoadData();
                }
            }
        }

        private void InitData()
        {

        }

        private void LoadData()
        {
            if (NoticeID < 0)
                return;

            var notice = new SysNotice(NoticeID);
            notice.Load();

            phData.BindObjectToControls(notice, "tbx");

            LoadAttachment();
        }

        private void LoadAttachment()
        {
            var attachList = DataAccess.Select(typeof(SysNoticeAttach),
                        string.Format("{0}='{1}'", SysNoticeAttach.SQLCOL_NOTICEID, NoticeID), true) as
                        IList<SysNoticeAttach>;
            rpAttachment.DataSource = attachList;
            if (attachList == null || attachList.Count == 0)
                rpAttachment.Visible = false;
            else
                rpAttachment.Visible = true;
            rpAttachment.DataBind();
        }

    }
}