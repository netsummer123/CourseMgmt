using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Cells;
using Aspose.Words;
using CourseMgmt.Web.Extend;
using SaveFormat = Aspose.Words.SaveFormat;

namespace KDSoft.ckeditor.plugins.KD_importWord.aspx
{
    public partial class UploadWordFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpLoadBt_Click(object sender, EventArgs e)
        {
            Msg.Text = string.Empty;
            //获取上传的文件
            if (FileUploadWord.HasFile)
            {
                try
                {
                    var fileName = FileUploadWord.FileName.ToLower();
                    var saveFileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string filePath = FilePathExt.CombineToPhysicalPath(Server.MapPath("~/Upload/WordToHtml/"),
                                                                        saveFileName + ".html");
                    if (fileName.Contains(".doc") || fileName.Contains(".docx"))
                    {
                        Document doc = new Document(FileUploadWord.FileContent);
                        FilePathExt.PathExists(filePath);
                        doc.Save(filePath, SaveFormat.Html);
                    }
                    else if (fileName.Contains(".xls") || fileName.Contains(".xlsx"))
                    {
                        Workbook workbook = new Workbook(FileUploadWord.FileContent);
                        workbook.Save(filePath, Aspose.Cells.SaveFormat.Html);
                    }
                    else
                    {
                        Msg.Text = "请选择word或者Excel文件！";
                        return;
                    }

                    //读取文件
                    var html = FilePathExt.ReadFile(filePath);

                    //替换图片路径
                    html = html.Replace(string.Format(@"src=""{0}", saveFileName),
                                        string.Format(@"src=""{0}/Upload/WordToHtml/{1}", Request.ApplicationPath,
                                                      saveFileName)
                        );

                    //将内容写入,并显示在页面上
                    FilePathExt.WriteFile(filePath, html);
                    HtmlTextBox.Text = html;
                    Msg.Text = "转换成功！";
                }
                catch (Exception)
                {
                    Msg.Text = "转换失败！";
                }
            }
            else
            {
                Msg.Text = "没有选择文件";
            }

        }
    }
}