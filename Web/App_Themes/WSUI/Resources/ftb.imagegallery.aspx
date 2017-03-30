<%@ Page language="c#" %>
<LINK href="css.css" type="text/css" rel="stylesheet">
<script runat="server">

// Messages
private string NoFileMessage = "您没有选择文件。";
private string UploadSuccessMessage = "上传成功";
private string UploadFailureMessage = "上传失败。";
private string NoImagesMessage = "该文件夹不存在或者是空的";
private string NoFolderSpecifiedMessage = "您要上传到的文件夹不存在。";
private string NoFileToDeleteMessage = "您没有选中要删除的文件。";
private string InvalidFileTypeMessage = "您无法上传这种类型的文件。";
private string[] AcceptedFileTypes = new string[] {"jpg","jpeg","jpe","gif","png","swf"};

// Configuration
private bool	UploadIsEnabled = true;         // 是否允许上传文件
private bool	DeleteIsEnabled = true;         // 是否允许删除文件
private string	DefaultImageFolder = "images";  // 默认的起始文件夹

public int nFlashCount = 0;

private void Page_Load(object sender, System.EventArgs e) {
	string isframe = "" + Request["frame"];
	
	if (isframe != "") {
		MainPage.Visible = true;
		iframePanel.Visible = false;
	
		string rif = "" + Request["rif"];
		string cif = "" + Request["cif"];	

		if (cif != "" && rif != "") {
			RootImagesFolder.Value = rif;
			CurrentImagesFolder.Value = cif;
		} else {
			RootImagesFolder.Value = DefaultImageFolder;
			CurrentImagesFolder.Value = DefaultImageFolder;	
		}

		UploadPanel.Visible = UploadIsEnabled;
		DeleteImage.Visible = DeleteIsEnabled;

		string FileErrorMessage = "";
		string ValidationString = ".*(";
		//[\.jpg]|[\.jpeg]|[\.jpe]|[\.gif]|[\.png])$"
		for (int i=0;i<AcceptedFileTypes.Length; i++) {
			ValidationString += "[\\." + AcceptedFileTypes[i] + "]";
			if (i < (AcceptedFileTypes.Length-1)) ValidationString += "|";
			FileErrorMessage += AcceptedFileTypes[i];
			if (i < (AcceptedFileTypes.Length-1)) FileErrorMessage += ", ";
		}
		FileValidator.ValidationExpression = ValidationString+")$";
		FileValidator.ErrorMessage=InvalidFileTypeMessage;

		if (!IsPostBack) {
			DisplayImages();
		}
	} else {
		
	}
}

public void UploadImage_OnClick(object sender, EventArgs e) {	
	if (Page.IsValid) {
		if (CurrentImagesFolder.Value != "") {
			if (UploadFile.PostedFile.FileName.Trim() != "") {
				if (IsValidFileType(UploadFile.PostedFile.FileName)) {
					try {
						string UploadFileName = "";
						string UploadFileDestination = "";
						UploadFileName = UploadFile.PostedFile.FileName;
						UploadFileName = UploadFileName.Substring(UploadFileName.LastIndexOf("\\")+1);
						UploadFileDestination = HttpContext.Current.Request.PhysicalApplicationPath;
						UploadFileDestination += CurrentImagesFolder.Value;
						UploadFileDestination += "\\";
						if(!System.IO.Directory.Exists(UploadFileDestination))
							System.IO.Directory.CreateDirectory(UploadFileDestination);
						UploadFile.PostedFile.SaveAs(UploadFileDestination + UploadFileName);
						ResultsMessage.Text = UploadSuccessMessage;
					} catch(Exception ex) {
						//ResultsMessage.Text = "Your file could not be uploaded: " + ex.Message;
						ResultsMessage.Text = UploadFailureMessage;
					}
				} else {
					ResultsMessage.Text = InvalidFileTypeMessage;
				}
			} else {
				ResultsMessage.Text = NoFileMessage;
			}
		} else {
			ResultsMessage.Text = NoFolderSpecifiedMessage;
		}
	} else {
		ResultsMessage.Text = InvalidFileTypeMessage;
		
	}
	DisplayImages();
}

public void DeleteImage_OnClick(object sender, EventArgs e) {
	if (FileToDelete.Value != "" && FileToDelete.Value != "undefined") {
		try {
			string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
			System.IO.File.Delete(AppPath  + CurrentImagesFolder.Value + "\\" + FileToDelete.Value);
			ResultsMessage.Text = "已删除: " + FileToDelete.Value;
		} catch(Exception ex) {			
			ResultsMessage.Text = "删除失败。";
		}
	} else {
		ResultsMessage.Text = NoFileToDeleteMessage;
	}
	DisplayImages();
}

private bool IsValidFileType(string FileName) {
	string ext = FileName.Substring(FileName.LastIndexOf(".")+1,FileName.Length-FileName.LastIndexOf(".")-1).ToLower();
	for (int i=0; i<AcceptedFileTypes.Length; i++) {
		if (ext == AcceptedFileTypes[i]) {
			return true;
			
		}	
	}
	return false;
}


private string[] ReturnFilesArray() {
	if (CurrentImagesFolder.Value != "") {
		try {
			string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
			string ImageFolderPath = AppPath + CurrentImagesFolder.Value;
			string[] FilesArray = System.IO.Directory.GetFiles(ImageFolderPath,"*");
			return FilesArray;
			
			
		} catch {
		
			return null;
		}
	} else {
		return null;
	}

}

private string[] ReturnDirectoriesArray() {
	if (CurrentImagesFolder.Value != "") {
		try {
			string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
			string CurrentFolderPath = AppPath + CurrentImagesFolder.Value;
			string[] DirectoriesArray = System.IO.Directory.GetDirectories(CurrentFolderPath,"*");
			return DirectoriesArray ;
		} catch {
			return null;
		}
	} else {
		return null;
	}
}

public void DisplayImages() {
	string[] FilesArray = ReturnFilesArray();
	string[] DirectoriesArray = ReturnDirectoriesArray();
	string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
	string AppUrl;
	
	//Get the application's URL
	if (Request.ApplicationPath == "/")
		AppUrl = Request.ApplicationPath;
	else
		AppUrl = Request.ApplicationPath + "/";
	
	GalleryPanel.Controls.Clear();
	if ( (FilesArray == null || FilesArray.Length == 0) && (DirectoriesArray == null || DirectoriesArray.Length == 0) ) {
		gallerymessage.Text = NoImagesMessage + ": " + RootImagesFolder.Value;
	} else {
		string ImageFileName = "";
		string ImageExtendName = "";
		string ImageFileLocation = "";

		int thumbWidth = 94;
		int thumbHeight = 94;
		
		if (CurrentImagesFolder.Value != RootImagesFolder.Value) {

			System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
			myHtmlImage.Src = AppUrl + "images/ftb/folder.up.gif";
			myHtmlImage.Attributes["unselectable"]="on"; 
			myHtmlImage.Attributes["align"]="absmiddle"; 
			myHtmlImage.Attributes["vspace"]="36"; 

			string ParentFolder = CurrentImagesFolder.Value.Substring(0,CurrentImagesFolder.Value.LastIndexOf("\\"));

			System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();					
			myImageHolder.CssClass = "imageholder";
			myImageHolder.Attributes["unselectable"]="on"; 
			myImageHolder.Attributes["onclick"]="divClick(this,'');";  
			myImageHolder.Attributes["ondblclick"]="gotoFolder('" + RootImagesFolder.Value + "','" + ParentFolder.Replace("\\","\\\\") + "');";  
			myImageHolder.Controls.Add(myHtmlImage);

			System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
			myMainHolder.CssClass = "imagespacer";
			myMainHolder.Controls.Add(myImageHolder);

			System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
			myTitleHolder.CssClass = "titleHolder";
			myTitleHolder.Controls.Add(new LiteralControl("向上"));
			myMainHolder.Controls.Add(myTitleHolder);

			GalleryPanel.Controls.Add(myMainHolder);		
			
		}
		
		foreach (string _Directory in DirectoriesArray) {
			
			try {
				string DirectoryName = _Directory.ToString();
				

				System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
				myHtmlImage.Src = AppUrl + "images/ftb/folder.big.gif";
				myHtmlImage.Attributes["unselectable"]="on"; 
				myHtmlImage.Attributes["align"]="absmiddle"; 
				myHtmlImage.Attributes["vspace"]="29"; 

				System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();					
				myImageHolder.CssClass = "imageholder";
				myImageHolder.Attributes["unselectable"]="on"; 
				myImageHolder.Attributes["onclick"]="divClick(this);";  
				myImageHolder.Attributes["ondblclick"]="gotoFolder('" + RootImagesFolder.Value + "','" + DirectoryName.Replace(AppPath,"").Replace("\\","\\\\") + "');";  
				myImageHolder.Controls.Add(myHtmlImage);

				System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
				myMainHolder.CssClass = "imagespacer";
				myMainHolder.Controls.Add(myImageHolder);

				System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
				myTitleHolder.CssClass = "titleHolder";
				myTitleHolder.Controls.Add(new LiteralControl(DirectoryName.Replace(AppPath + CurrentImagesFolder.Value + "\\","")));
				myMainHolder.Controls.Add(myTitleHolder);

				GalleryPanel.Controls.Add(myMainHolder);		
			} catch {
				// nothing for error
			}
		}
		
		foreach (string ImageFile in FilesArray) {

			try {

				ImageFileName = ImageFile.ToString();
				ImageFileName = ImageFileName.Substring(ImageFileName.LastIndexOf("\\")+1);
				ImageExtendName = ImageFileName.Substring(ImageFileName.LastIndexOf(".")+1).ToLower();
				
				ImageFileLocation = AppUrl;
				ImageFileLocation = ImageFileLocation.Substring(ImageFileLocation.LastIndexOf("\\")+1);
				ImageFileLocation += CurrentImagesFolder.Value;
				ImageFileLocation += "/";
				ImageFileLocation += ImageFileName;

				if (ImageExtendName == "swf")
				{
					string myFlash = "<OBJECT classid=\"clsid:D27CDB6E-AE6D-11CF-96B8-444553540000\" width=\""+ thumbWidth +"\" height=\""+ thumbHeight +"\">"
						+ "<PARAM NAME=\"_cx\" VALUE=\"\">"
						+ "<PARAM NAME=\"_cy\" VALUE=\"\">"
						+ "<PARAM NAME=\"FlashVars\" VALUE=\"\">"
						+ "<PARAM NAME=\"Movie\" VALUE=\""+ ImageFileLocation +"\">"
						+ "<PARAM NAME=\"Src\" VALUE=\"\">"
						+ "<PARAM NAME=\"WMode\" VALUE=\"Transparent\">"
						+ "<PARAM NAME=\"Play\" VALUE=\"-1\">"
						+ "<PARAM NAME=\"Loop\" VALUE=\"-1\">"
						+ "<PARAM NAME=\"Quality\" VALUE=\"High\">"
						+ "<PARAM NAME=\"SAlign\" VALUE=\"\">"
						+ "<PARAM NAME=\"Menu\" VALUE=\"-1\">"
						+ "<PARAM NAME=\"Base\" VALUE=\"\">"
						+ "<PARAM NAME=\"AllowScriptAccess\" VALUE=\"always\">"
						+ "<PARAM NAME=\"Scale\" VALUE=\"ShowAll\">"
						+ "<PARAM NAME=\"DeviceFont\" VALUE=\"0\">"
						+ "<PARAM NAME=\"EmbedMovie\" VALUE=\"0\">"
						+ "<PARAM NAME=\"BGColor\" VALUE=\"\">"
						+ "<PARAM NAME=\"SWRemote\" VALUE=\"\">"
						+ "<PARAM NAME=\"MovieData\" VALUE=\"\">"
						+ "<PARAM NAME=\"SeamlessTabbing\" VALUE=\"1\">"
						+ "</OBJECT>";
					

					System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();
					myImageHolder.CssClass = "imageholder";
					myImageHolder.ID = "divObj"+ nFlashCount.ToString();
					myImageHolder.Style["z-index"] = "-1";
					myImageHolder.BorderStyle = BorderStyle.None;
					myImageHolder.Controls.Add(new LiteralControl(myFlash));

					System.Web.UI.WebControls.Panel myTransparentHolder = new System.Web.UI.WebControls.Panel();
					myTransparentHolder.ID = "div"+ nFlashCount.ToString();;
					myTransparentHolder.Style["position"] = "absolute";
					myTransparentHolder.Style["background-color"] = "Transparent";
					myTransparentHolder.Style["z-index"] = "101";
					myTransparentHolder.Style["width"] = thumbWidth.ToString();
					myTransparentHolder.Style["height"] = thumbHeight.ToString();
					myTransparentHolder.Attributes["onclick"]="divClick(this,'"+ ImageFileName +"');";
					myTransparentHolder.Attributes["ondblclick"]="returnImage('" + ImageFileLocation.Replace("\\","/") + "','0','0');";  
					string myImage = "<img src=\""+ AppUrl +"/images/dot.gif\" width=\"94\" height=\"94\" style=\"background-color: Transparent\">";
					myTransparentHolder.Controls.Add(new LiteralControl(myImage));

					System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
					myMainHolder.CssClass = "imagespacer";
					myMainHolder.Controls.Add(myTransparentHolder);
					myMainHolder.Controls.Add(myImageHolder);

					System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
					myTitleHolder.CssClass = "titleHolder";
					myTitleHolder.Controls.Add(new LiteralControl(ImageFileName));
					myMainHolder.Controls.Add(myTitleHolder);

					GalleryPanel.Controls.Add(myMainHolder);
					nFlashCount++;
				}
				else
				{
					System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
					myHtmlImage.Src = ImageFileLocation;
					myHtmlImage.Attributes["unselectable"]="on";  

					System.Drawing.Image myImage = System.Drawing.Image.FromFile(Server.MapPath(ImageFileLocation));

					// landscape image
					if (myImage.Width > myImage.Height) {
						if (myImage.Width > thumbWidth) {
							myHtmlImage.Width = thumbWidth;
							myHtmlImage.Height = Convert.ToInt32(myImage.Height * thumbWidth/myImage.Width);						
						} else {
							myHtmlImage.Width = myImage.Width;
							myHtmlImage.Height = myImage.Height;
						}
					// portrait image
					} else {
						if (myImage.Height > thumbHeight) {
							myHtmlImage.Height = thumbHeight;
							myHtmlImage.Width = Convert.ToInt32(myImage.Width * thumbHeight/myImage.Height);
						} else {
							myHtmlImage.Width = myImage.Width;
							myHtmlImage.Height = myImage.Height;
						}
					}
					
					if (myHtmlImage.Height < thumbHeight) {
						myHtmlImage.Attributes["vspace"] = Convert.ToInt32((thumbHeight/2)-(myHtmlImage.Height/2)).ToString(); 
					}

					System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();					
					myImageHolder.CssClass = "imageholder";
					myImageHolder.Attributes["onclick"]="divClick(this,'" + ImageFileName + "');";  
					myImageHolder.Attributes["ondblclick"]="returnImage('" + ImageFileLocation.Replace("\\","/") + "','" + myImage.Width.ToString() + "','" + myImage.Height.ToString() + "');";  
					myImageHolder.Controls.Add(myHtmlImage);


					System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
					myMainHolder.CssClass = "imagespacer";
					myMainHolder.Controls.Add(myImageHolder);

					System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
					myTitleHolder.CssClass = "titleHolder";
					myTitleHolder.Controls.Add(new LiteralControl(ImageFileName + "<BR>" + myImage.Width.ToString() + "x" + myImage.Height.ToString()));
					myMainHolder.Controls.Add(myTitleHolder);
					myImage.Dispose();

					GalleryPanel.Controls.Add(myMainHolder);
				}
			} catch {
			}
		}
		gallerymessage.Text = "";
	}
}
</script>
<asp:panel id="MainPage" runat="server" visible="false">
<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD>
<META HTTP-EQUIV="Expires" CONTENT="0">
<title>插入图片</title>
<style>

body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff; 
	width: 100%;
	overflow:hidden;
	border: 0;
}

body,tr,td {
	color: #000000;
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 10pt;
}

div.imagespacer {
	width: 120;
	height: 126;
	text-align: center;			
	float: left;
	font: 10pt verdana;
	margin: 5px;
	overflow: hidden;
}
div.imageholder {
	margin: 0px;
	padding: 0px;
	border: 1 solid #CCCCCC;
	width: 100;
	height: 100;
}

div.titleholder {
	font-family: ms sans serif, arial;
	font-size: 8pt;
	width: 100;
	text-overflow: ellipsis;
	overflow: hidden;
	white-space: nowrap;			
}		

</style>


<script language="javascript">
lastDiv = null;
function divClick(theDiv,filename) {
	if (lastDiv) {
		lastDiv.style.border = "1 solid #CCCCCC";
	}
	lastDiv = theDiv;
	theDiv.style.border = "2 solid #316AC5";
	
	document.getElementById("FileToDelete").value = filename;

}
function gotoFolder(rootfolder,newfolder) {
	window.navigate("ftb.imagegallery.aspx?frame=1&rif=" + rootfolder + "&cif=" + newfolder);
}		
function returnImage(imagename,width,height) {
	var arr = new Array();
	arr["filename"] = imagename;  
	arr["width"] = width;  
	arr["height"] = height;			 
	window.parent.returnValue = arr;
	window.parent.close();	
}		
</script>		
</HEAD>
<body>
	<table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">
<FORM encType="multipart/form-data" runat="server">

<tr><td>
	<div id="galleryarea" style="width=100%; height:100%; overflow: auto;">
		<asp:label id="gallerymessage" runat="server"></asp:label>
		<asp:panel id="GalleryPanel" runat="server"></asp:panel>
	</div>
</td></tr>
<asp:Panel id="UploadPanel" runat="server">
<tr><td height=16 style="padding-left:10px; border-top: solid 1px #e6e6e6; background-color:#f2f2f2;">
	
	<table>
	<tr>
		<td valign=top><input id="UploadFile" type="file" name="UploadFile" class="TextBox" runat="server" style="width:300;"/></td>
		<td valign=top><asp:button id="UploadImage" Text="上 传" runat="server" Width="60px" CssClass="InputBtn" onclick="UploadImage_OnClick" /></td>
		<td valign=top><asp:button id="DeleteImage" Text="删 除" runat="server" Width="60px" CssClass="InputBtn" onclick="DeleteImage_OnClick" /></td>
		<td valign=middle>		
	</tr>
	<tr>
		<td colspan=3>
			<asp:RegularExpressionValidator runat="server" 
				ControlToValidate="UploadFile" 
				id="FileValidator" display="dynamic"/>
			<asp:literal id="ResultsMessage" runat="server" />		
		</td>		
	</tr></table>	
	<input type="text" id="FileToDelete" Value="" runat="server" />
	<input type="text" id="RootImagesFolder" Value="images" runat="server" />
	<input type="text" id="CurrentImagesFolder" Value="images" runat="server" />
</td></tr>
</asp:panel>
</form>
</table>
</body>
</HTML>
</asp:panel>
<asp:panel id="iframePanel" runat="server" >
<html> 
<head><title>插入图片</title></head>
<style>
body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff;
	overflow:hidden;
}
</style>
<body>
	<iframe style="width:100%;height:100%;border:0;" border=0 frameborder=0 src="ftb.imagegallery.aspx?frame=1&<%=Request.QueryString%>"></iframe>
</body>
</html>
<script language="javascript">
var nCount = "<%=nFlashCount%>";
for (var i=0; i<Number(nCount); i++)
{
	document.getElementById("div"+i).style.top = document.getElementById("divObj"+i).style.top;
	document.getElementById("div"+i).style.left = document.getElementById("divObj"+i).style.left;
}
</script>
</asp:panel>
