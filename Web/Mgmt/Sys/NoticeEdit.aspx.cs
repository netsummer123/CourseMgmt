using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class NoticeEdit : BasePage
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

        public IList<SysNoticeAttach> AttachList
        {
            get
            {
                IList<SysNoticeAttach> list = Session["NoticeEdit.AttachList"] as IList<SysNoticeAttach>;
                if (list == null || (list.Count == 0))
                {
                    var attachs = DataAccess.Select(typeof(SysNoticeAttach),
                        string.Format("{0}='{1}'", SysNoticeAttach.SQLCOL_NOTICEID, NoticeID), true) as
                        IList<SysNoticeAttach>;
                    if (attachs == null || attachs.Count == 0)
                        list = new List<SysNoticeAttach>();
                    else
                        list = attachs.ToList();
                    Session["NoticeEdit.AttachList"] = list;
                }
                return list;
            }
            set { Session["NoticeEdit.AttachList"] = value; }
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
            AttachList = new List<SysNoticeAttach>();
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

        #region 附件

        private void LoadAttachment()
        {
            rpAttachment.DataSource = AttachList;
            if (AttachList == null || AttachList.Count == 0)
                rpAttachment.Visible = false;
            else
                rpAttachment.Visible = true;
            rpAttachment.DataBind();
        }

        protected void rpAttachment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int attachid = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Delete")
            {
                SysNoticeAttach attach = new SysNoticeAttach(attachid);
                attach.Delete();
                AttachList.RemoveAt(e.Item.ItemIndex);

                LoadAttachment();

                RegisterJsAjax("0", "loadCKEDITOR();");
            }
        }

        protected void rpAttachment_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            LinkButton ib = e.Item.FindControl("btDelete") as LinkButton;
            if (ib != null)
            {
                ib.Attributes.Add("onclick", "javascript:return confirm('确实要删除该附件吗？');");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!fuAttach.HasFile)
            {
                Warning("请先选择需要上传的文件");
                return;
            }

            //存储的文件名
            string fileName = Path.GetFileNameWithoutExtension(fuAttach.FileName) +
                              DateTime.Now.ToString("MMddHHmmss")
                              + Path.GetExtension(fuAttach.FileName);
            var relativePath = "Notice/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + fileName;

            //服务端存储路径
            string path = SysConsts.FileUploadDirectory + relativePath;

            if (!FileHelper.UploadFile(fuAttach.PostedFile, Server.MapPath(path)))
            {
                Warning("上传失败，请联系管理员！");
                return;
            }

            SysNoticeAttach attach = new SysNoticeAttach();
            attach.NoticeID = NoticeID;
            attach.DownloadCount = 0;
            attach.FileName = Path.GetFileName(fuAttach.FileName);
            attach.FileSize = fuAttach.PostedFile.ContentLength;
            attach.FilePath = relativePath;
            attach.UploadTime = DateTime.Now;
            AttachList.Add(attach);

            LoadAttachment();

            if (NoticeID > 0)
            {
                attach.Add();
            }
        }

        #endregion

        private bool Check()
        {

            return true;
        }

        private void SetData(SysNotice notice)
        {
            phData.BindControlsToObject(notice, "tbx");

            notice.SenderID = CurrentUser.ID;
            notice.SenderName = CurrentUser.RealName;
            notice.SendTime = DateTime.Now;
            notice.DepartmentID = CurrentUser.DepartmentID;
            notice.DepartmentName = CurrentUser.DepartmentName;

            notice.UpdateTime = DateTime.Now;
        }

        private void SaveData()
        {
            var notice = new SysNotice();
            if (NoticeID > 0)
            {
                notice.LoadByIdentity(NoticeID);
                SetData(notice);
                notice.Update();
            }
            else
            {
                SetData(notice);
                notice.IsPublished = true;
                notice.Add();

                foreach (SysNoticeAttach attach in AttachList)
                {
                    attach.NoticeID = notice.ID;
                    attach.Add();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("NoticeList.aspx");
        }

        protected void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;

            SaveData();

            Success("保存成功");
            Response.Redirect("NoticeList.aspx");
        }

    }
}