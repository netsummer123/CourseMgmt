<%@ Page language="c#" %>
<link href="Style/css.css" type="text/css" rel="stylesheet" />
<script runat="server">

// Messages
private string NoFileMessage = "您没有选择要上传的文件。";
private string UploadSuccessMessage = "上传文件成功。";
private string UploadFailureMessage = "上传文件失败。";
private string NoImagesMessage = "该文件夹不存在或者是空的。";
private string HaveImagesMessage = "该文件夹不为空。";
private string NoFolderSpecifiedMessage = "您要上传到的文件夹不存在。";
private string NoFileToDeleteMessage = "您没有选中要删除的文件。";
private string NoFolderToDeleteMessage = "您没有选中要删除的文件夹。";
private string InvalidFileTypeMessage = "您无法上传这种类型的文件。";
private string NullFolderName = "文件夹名称不能为空。";
private string[] AcceptedFileTypes = new string[] {"jpg","JPG","Jpg","jPg","jpG","JPg","JpG","jPG"
												  ,"jpeg","JPEG","Jpeg","jPeg","jpEg","jpeG","JPeg","JpEg","JpeG","jPEg","jPeG","jpEG","JPEg","JPeG","JpEG"
												  ,"jpe","JPE","Jpe","jPe","jpE","JPe","JpE","jPE"
												  ,"gif","GIF","Gif","gIf","giF","GIf","GiF","gIF"
												  ,"png","PNG","Png","pNg","pnG","PNg","PnG","pNG"
												  ,"swf","SWF","Swf","sWf","swF","SWf","SwF","sWF"
												  ,"doc","DOC","Doc","dOc","doC","DOc","DoC","dOC"
												  ,"xls","XLS","Xls","xLs","xlS","XLs","XlS","xLS"
												  ,"ppt","PPT","Ppt","pPt","ppT","PPt","PpT","pPT"
												  ,"zip","ZIP","Zip","zIp","ziP","ZIp","ZiP","zIP"
												  ,"rar","RAR","Rar","rAr","raR","RAr","RaR","rAR"
												  ,"pdf","PDF","Pdf","pDf","pdF","PDf","PdF","pDF"
												  ,"txt","TXT","Txt","tXt","txT","TXt","TxT","tXT"};
private string[] ImageFileTypes = new string[] {"bmp","jpg","jpeg","jpe","gif","png"};

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
			RootImagesUrl.Value = rif;
			CurrentImagesUrl.Value = cif;
		} else {
			RootImagesUrl.Value = DefaultImageFolder;
			CurrentImagesUrl.Value = DefaultImageFolder;	
		}
		
		string rPath = "" + Request["rPath"];
		string cPath = "" + Request["cPath"];
		
		if (cPath != "" && rPath != "") {
			RootImagesFolder.Value = rPath;
			CurrentImagesFolder.Value = cPath;
		} else {
			RootImagesFolder.Value = DefaultImageFolder;
			CurrentImagesFolder.Value = DefaultImageFolder;	
		}

		string fType ="" + Request["fType"];
		
		if (fType != "")
			FileType.Value = fType;

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

public void NewFolder_OnClick(object sender, EventArgs e) {
	if (Page.IsValid) {
		if (CurrentImagesFolder.Value != "") {
			if (NewFolderName.Value.Trim() == "")
				ResultsMessage.Text = NullFolderName;
			else
				System.IO.Directory.CreateDirectory(CurrentImagesFolder.Value +"\\"+ NewFolderName.Value.Trim());
			DisplayImages();
		}
	}
}

public void DelFolder_OnClick(object sender, EventArgs e) {
	if (FolderToDelete.Value != "" && FolderToDelete.Value != "undefined") {
		string ImageFolderPath = CurrentImagesFolder.Value +"\\"+ FolderToDelete.Value;
		if (System.IO.Directory.GetDirectories(ImageFolderPath,"*").Length > 0 || System.IO.Directory.GetFiles(ImageFolderPath,"*").Length > 0)
			ResultsMessage.Text = HaveImagesMessage;
		else
		{
			try {
				System.IO.Directory.Delete(ImageFolderPath);
				ResultsMessage.Text = "已删除: " + FolderToDelete.Value;
			} catch (Exception ex) {
				ResultsMessage.Text = "删除失败。";
			}
		}
	}
	else
		ResultsMessage.Text = NoFolderToDeleteMessage;

	DisplayImages();
	FolderToDelete.Value = "";
	FileToDelete.Value = "";
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
						//UploadFileDestination = HttpContext.Current.Request.PhysicalApplicationPath;
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
			//System.IO.File.Delete(AppPath  + CurrentImagesFolder.Value + "\\" + FileToDelete.Value);
			System.IO.File.Delete(CurrentImagesFolder.Value + "\\" + FileToDelete.Value);
			ResultsMessage.Text = "已删除: " + FileToDelete.Value;
		} catch(Exception ex) {			
			ResultsMessage.Text = "删除失败。";
		}
	} else {
		ResultsMessage.Text = NoFileToDeleteMessage;
	}
	DisplayImages();
	FolderToDelete.Value = "";
	FileToDelete.Value = "";
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

private bool IsImageFileType(string FileName) {
	string ext = FileName.Substring(FileName.LastIndexOf(".")+1,FileName.Length-FileName.LastIndexOf(".")-1).ToLower();
	for (int i=0; i<ImageFileTypes.Length; i++) {
		if (ext == ImageFileTypes[i]) {
			return true;
			
		}	
	}
	return false;
}

private string[] ReturnFilesArray() {
	if (CurrentImagesFolder.Value != "") {
		try {
			string ImageFolderPath = CurrentImagesFolder.Value;
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
			string CurrentFolderPath = CurrentImagesFolder.Value;
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
	if (CurrentImagesFolder.Value != RootImagesFolder.Value) {

		System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
		myHtmlImage.Src = "~/ftb/folder.up.gif";
		myHtmlImage.Attributes["unselectable"]="on"; 
		myHtmlImage.Attributes["align"]="absmiddle"; 
		myHtmlImage.Attributes["vspace"]="36"; 

		string ParentFolder = CurrentImagesFolder.Value.Substring(0,CurrentImagesFolder.Value.LastIndexOf("/"));
		string ParentFolderUrl = CurrentImagesUrl.Value.Substring(0,CurrentImagesUrl.Value.LastIndexOf("/"));

		System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();					
		myImageHolder.CssClass = "imageholder";
		myImageHolder.Attributes["unselectable"]="on"; 
		myImageHolder.Attributes["onclick"]="divClick(this,'');";  
		myImageHolder.Attributes["ondblclick"]="gotoFolder('" + RootImagesFolder.Value + "','" +  ParentFolder + "','" + RootImagesUrl.Value + "','" + ParentFolderUrl +"', '"+ FileType.Value +"');";  
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

	if ( (FilesArray == null || FilesArray.Length == 0) && (DirectoriesArray == null || DirectoriesArray.Length == 0) ) {
		return;
		
	} else {
		string FileName = "";
		string ExtendName = "";
		string FileLocation = "";
		string FileVirturlLocation = "";

		int thumbWidth = 94;
		int thumbHeight = 94;
		
		foreach (string _Directory in DirectoriesArray) {
			
			try {
				string DirectoryName = _Directory.ToString();
				

				System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
				myHtmlImage.Src = "~/ftb/folder.big.gif";
				myHtmlImage.Attributes["unselectable"]="on"; 
				myHtmlImage.Attributes["align"]="absmiddle"; 
				myHtmlImage.Attributes["vspace"]="29"; 

				System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();					
				myImageHolder.CssClass = "imageholder";
				myImageHolder.Attributes["unselectable"]="on"; 
				myImageHolder.Attributes["onclick"]="divClick(this,'"+ DirectoryName.Replace(CurrentImagesFolder.Value + "\\","") +"','Folder');";  
				myImageHolder.Attributes["ondblclick"]="gotoFolder('" + RootImagesFolder.Value + "','" +  CurrentImagesFolder.Value + "/" + DirectoryName.Replace(CurrentImagesFolder.Value + "\\","")  + "','" + RootImagesUrl.Value + "','" + CurrentImagesUrl.Value + "/" + DirectoryName.Replace(CurrentImagesFolder.Value + "\\","") +"', '"+ FileType.Value +"');";  
				myImageHolder.Controls.Add(myHtmlImage);

				System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
				myMainHolder.CssClass = "imagespacer";
				myMainHolder.Controls.Add(myImageHolder);

				System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
				myTitleHolder.CssClass = "titleHolder";
				//myTitleHolder.Controls.Add(new LiteralControl(DirectoryName.Replace(AppPath + CurrentImagesFolder.Value + "\\","")));
				myTitleHolder.Controls.Add(new LiteralControl(DirectoryName.Replace(CurrentImagesFolder.Value + "\\","")));
				myMainHolder.Controls.Add(myTitleHolder);

				GalleryPanel.Controls.Add(myMainHolder);		
			} catch {
				// nothing for error
			}
		}
		
		if (FilesArray != null)
		{
			foreach (string file in FilesArray) {

				try {

					FileName = file.ToString();
					FileName = FileName.Substring(FileName.LastIndexOf("\\")+1);
					ExtendName = FileName.Substring(FileName.LastIndexOf(".")+1).ToLower();
					
					FileLocation = CurrentImagesFolder.Value;
					FileLocation += "/";
					FileLocation += FileName;
					FileLocation = FileLocation.Replace("/" , "\\\\");
					
					FileVirturlLocation = CurrentImagesUrl.Value;
					FileVirturlLocation += "/";
					FileVirturlLocation += FileName;

					if (FileType.Value == "all")
					{
						if (ExtendName == "swf")
						{
							string myFlash = "<OBJECT classid=\"clsid:D27CDB6E-AE6D-11CF-96B8-444553540000\" width=\""+ thumbWidth +"\" height=\""+ thumbHeight +"\">"
								+ "<PARAM NAME=\"_cx\" VALUE=\"\">"
								+ "<PARAM NAME=\"_cy\" VALUE=\"\">"
								+ "<PARAM NAME=\"FlashVars\" VALUE=\"\">"
								+ "<PARAM NAME=\"Movie\" VALUE=\""+ FileVirturlLocation.Replace("\\","/") +"\">"
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
							myTransparentHolder.Attributes["onclick"]="divClick(this,'"+ FileName +"');";
							myTransparentHolder.Attributes["ondblclick"]="returnFlash('" + FileVirturlLocation.Replace("\\","/") + "','"+ thumbWidth +"','"+ thumbHeight +"');";  
							//string myImage = "<img src=\""+ AppUrl +"/images/dot.gif\" width=\"94\" height=\"94\" style=\"background-color: Transparent\">";
							//myTransparentHolder.Controls.Add(new LiteralControl(myImage));

							System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
							myMainHolder.CssClass = "imagespacer";
							myMainHolder.Controls.Add(myTransparentHolder);
							myMainHolder.Controls.Add(myImageHolder);

							System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
							myTitleHolder.CssClass = "titleHolder";
							myTitleHolder.Controls.Add(new LiteralControl(FileName));
							myMainHolder.Controls.Add(myTitleHolder);

							GalleryPanel.Controls.Add(myMainHolder);
							nFlashCount++;
						}
						else if (IsImageFileType(file))
						{
							System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
							myHtmlImage.Src = FileVirturlLocation.Replace("\\","/");
							myHtmlImage.Attributes["unselectable"]="on";  

							System.Drawing.Image myImage = System.Drawing.Image.FromFile(FileLocation);
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
							myImageHolder.Attributes["onclick"]="divClick(this,'" + FileName + "');";  
							myImageHolder.Attributes["ondblclick"]="returnImage('" + FileVirturlLocation.Replace("\\","/") + "','" + myImage.Width.ToString() + "','" + myImage.Height.ToString() + "');";  
							myImageHolder.Controls.Add(myHtmlImage);


							System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
							myMainHolder.CssClass = "imagespacer";
							myMainHolder.Controls.Add(myImageHolder);

							System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
							myTitleHolder.CssClass = "titleHolder";
							myTitleHolder.Controls.Add(new LiteralControl(FileName + "<BR>" + myImage.Width.ToString() + "x" + myImage.Height.ToString()));
							myMainHolder.Controls.Add(myTitleHolder);
							myImage.Dispose();

							GalleryPanel.Controls.Add(myMainHolder);
						}
						else
						{
							FileLocation = "~/images/FileType/"+ ExtendName +".gif";
							System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
							myHtmlImage.Src = FileLocation;
							myHtmlImage.Attributes["unselectable"]="on";  

							System.Drawing.Image myImage = System.Drawing.Image.FromFile(Server.MapPath(FileLocation));
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
							myImageHolder.Attributes["onclick"]="divClick(this,'" + FileName + "');";  
							myImageHolder.Attributes["ondblclick"]="returnFile('" + FileVirturlLocation.Replace("\\","/") + "','" + FileName + "');";  
							myImageHolder.Controls.Add(myHtmlImage);


							System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
							myMainHolder.CssClass = "imagespacer";
							myMainHolder.Controls.Add(myImageHolder);

							System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
							myTitleHolder.CssClass = "titleHolder";
							myTitleHolder.Controls.Add(new LiteralControl(FileName + "<BR>" + myImage.Width.ToString() + "x" + myImage.Height.ToString()));
							myMainHolder.Controls.Add(myTitleHolder);
							myImage.Dispose();

							GalleryPanel.Controls.Add(myMainHolder);
						}
					}
					else if (FileType.Value == "image")
					{
						if (IsImageFileType(file))
						{
							System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
							myHtmlImage.Src = FileVirturlLocation.Replace("\\","/");
							myHtmlImage.Attributes["unselectable"]="on";  

							System.Drawing.Image myImage = System.Drawing.Image.FromFile(FileLocation);
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
							myImageHolder.Attributes["onclick"]="divClick(this,'" + FileName + "');";  
							myImageHolder.Attributes["ondblclick"]="returnImage('" + FileVirturlLocation.Replace("\\","/") + "','" + myImage.Width.ToString() + "','" + myImage.Height.ToString() + "');";  
							myImageHolder.Controls.Add(myHtmlImage);


							System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
							myMainHolder.CssClass = "imagespacer";
							myMainHolder.Controls.Add(myImageHolder);

							System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
							myTitleHolder.CssClass = "titleHolder";
							myTitleHolder.Controls.Add(new LiteralControl(FileName + "<BR>" + myImage.Width.ToString() + "x" + myImage.Height.ToString()));
							myMainHolder.Controls.Add(myTitleHolder);
							myImage.Dispose();

							GalleryPanel.Controls.Add(myMainHolder);
						}					
					}				
				} catch {
				}
			}
		}
	}
}
</script>
<asp:panel id="MainPage" runat="server" visible="false">
<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD>
	<META HTTP-EQUIV="Expires" CONTENT="0">
	<title>个人资源库</title>
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
function divClick(theDiv,filename,divType) {
	if (lastDiv) {
		lastDiv.style.border = "1 solid #CCCCCC";
	}
	lastDiv = theDiv;
	theDiv.style.border = "2 solid #316AC5";

	document.getElementById("FolderToDelete").value = "";
	document.getElementById("FileToDelete").value = "";
	if (divType == "Folder")
		document.getElementById("FolderToDelete").value = filename;
	else
		document.getElementById("FileToDelete").value = filename;

}
function gotoFolder(rootfolder,newfolder,rootfolderUrl,newfolderUrl,filType) {
	window.navigate("cute.imagegallery.aspx?frame=1&rif="+ encodeURI(rootfolderUrl) +"&cif="+ encodeURI(newfolderUrl) +"&rPath="+ encodeURI(rootfolder) +"&cPath="+ encodeURI(newfolder) +"&fType="+ filType );
}

function returnImage(imageUrl,width,height) {
	var arr = new Array();
	arr[0] = "<img src='"+ imageUrl +"' width='"+ width +"' height='"+ height +"'><br>";
	arr[1] = imageUrl;
	window.parent.returnValue = arr;
	window.parent.close();	
}
function returnFlash(flashUrl,width,height) {
	var arr = new Array();
	arr[0] = "<OBJECT classid='clsid:D27CDB6E-AE6D-11CF-96B8-444553540000' width='"+ width +"' height='"+ height +"'>"
							+ "<PARAM NAME='_cx' VALUE=''>"
							+ "<PARAM NAME='_cy' VALUE=''>"
							+ "<PARAM NAME='FlashVars' VALUE=''>"
							+ "<PARAM NAME='Movie' VALUE='"+ flashUrl +"'>"
							+ "<PARAM NAME='Src' VALUE='"+ flashUrl +"'>"
							+ "<PARAM NAME='WMode' VALUE='Transparent'>"
							+ "<PARAM NAME='Play' VALUE='-1'>"
							+ "<PARAM NAME='Loop' VALUE='-1'>"
							+ "<PARAM NAME='Quality' VALUE='High'>"
							+ "<PARAM NAME='SAlign' VALUE=''>"
							+ "<PARAM NAME='Menu' VALUE='-1'>"
							+ "<PARAM NAME='Base' VALUE=''>"
							+ "<PARAM NAME='AllowScriptAccess' VALUE='always'>"
							+ "<PARAM NAME='Scale' VALUE='ShowAll'>"
							+ "<PARAM NAME='DeviceFont' VALUE='0'>"
							+ "<PARAM NAME='EmbedMovie' VALUE='0'>"
							+ "<PARAM NAME='BGColor' VALUE=''>"
							+ "<PARAM NAME='SWRemote' VALUE=''>"
							+ "<PARAM NAME='MovieData' VALUE=''>"
							+ "<PARAM NAME='SeamlessTabbing' VALUE='1'>"
							+ "</OBJECT><br>";
	arr[1] = flashUrl;
	window.parent.returnValue = arr;
	window.parent.close();	
}
function returnFile(fileUrl, fileName)
{
	var arr = new Array();
	arr[0] = "<a href='"+ fileUrl +"' target='_blank'>"+ fileName +"</a><br>";
	arr[1] = fileUrl;
	window.parent.returnValue = arr;
	window.parent.close();
}
</script>		
</HEAD>
<body>
	<form encType="multipart/form-data" runat="server">
		<table width="100%" height="100%" cellpadding="4" cellspacing="0" border="0">
			<tr>
				<td>
					<div id="galleryarea" style="width=100%; height:100%; overflow: auto;">
						<div style="height:22px" 
						<asp:panel id="GalleryPanel" runat="server"></asp:panel>
					</div>
				</td>
			</tr>
			<asp:Panel id="UploadPanel" runat="server">
			<tr>
				<td height="42" style="padding-left:10px; border-top: solid 1px #e6e6e6; background-color:#f2f2f2;">
					<table cellpadding="0" cellspacing="0" border="0" height="22">
						<tr>
							<td valign="top">文件操作:<input id="UploadFile" type="file" name="UploadFile" class="TextBox" runat="server" style="width:250;"/>
								<asp:button id="UploadImage" Text="上 传" runat="server" Width="60px" CssClass="InputBtn" onclick="UploadImage_OnClick" />
								<asp:button id="DeleteImage" Text="删 除" runat="server" Width="60px" CssClass="InputBtn" onclick="DeleteImage_OnClick" /></td>
							<td width="30">&nbsp;</td>
							<td valign="top">文件夹操作:<input id="NewFolderName" type="text" name="NewFolderName" class="TextBox" runat="server" style="width:200;"/>
								<asp:button id="NewFolder" Text="新 建" runat="server" Width="60px" CssClass="InputBtn" onclick="NewFolder_OnClick" />
								<asp:button id="DelFolder" Text="删 除" runat="server" Width="60px" CssClass="InputBtn" onclick="DelFolder_OnClick" /></td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:RegularExpressionValidator runat="server" ControlToValidate="UploadFile" id="FileValidator" display="dynamic"/>
								<asp:literal id="ResultsMessage" runat="server" />
							</td>
						</tr>
					</table>
					<input type="hidden" id="FolderToDelete" Value="" runat="server" />
					<input type="hidden" id="FileToDelete" Value="" runat="server" />
					<input type="hidden" id="RootImagesFolder" Value="images" runat="server" />
					<input type="hidden" id="CurrentImagesFolder" Value="images" runat="server" />
					<input type="hidden" id="RootImagesUrl" Value="images" runat="server" />
					<input type="hidden" id="CurrentImagesUrl" Value="images" runat="server" />
					<input type="hidden" id="FileType" value="all" runat="server" />
				</td>
			</tr>
			</asp:panel>
		</table>
	</form>
</body>
</HTML>
</asp:panel>
<asp:panel id="iframePanel" runat="server" >
<html> 
	<head><title>个人资源库</title></head>
<style>
body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff;
	overflow:hidden;
}
</style>
<body>
	<iframe style="width:100%;height:100%;border:0;" border=0 frameborder=0 src="cute.imagegallery.aspx?frame=1&<%=Request.QueryString%>"></iframe>
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
