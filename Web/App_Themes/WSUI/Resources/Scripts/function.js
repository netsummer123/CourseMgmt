/* Template JavaScript */
/* Version: 2.6 || Date: 2006-2-10 || Author: Cyrano */
/* //W3C//DTD XHTML 1.0 Transitional//EN */

/* MenuGen */
function MenuGen() {
		var menuNo = queryString('menuNo');
		for (i=1;i<=7;i++)
		{
		document.all["TrdNav"+i].style.display='none';
		document.all["TrdNavTitle"+i].style.display='none'}
		document.all["TrdNav"+menuNo].style.display='';
		document.all["TrdNavTitle"+menuNo].style.display='';
		}
/* Star Generate */
	function CreateStar(column,num)
	{
		for (var i=1;i<=5;i++){
			var imgId="column"+column+"num"+i;
			if (i<=num)
				document.write("<img id=\""+imgId+"\" src=\"/resources/images/icon/starActive.gif\" border=\"0\" style=\"cursor:hand\" onmouseover=\"OnMouseOverStarPic("+column+","+i+")\" onmouseout=\"OnMouseOutStarPic("+column+")\" onclick=\"OnClickStarPic("+column+","+i+")\">");
			else
				document.write("<img id=\""+imgId+"\" src=\"/resources/images/icon/star.gif\" border=\"0\" style=\"cursor:hand\" onmouseover=\"OnMouseOverStarPic("+column+","+i+")\" onmouseout=\"OnMouseOutStarPic("+column+")\" onclick=\"OnClickStarPic("+column+","+i+")\">");

		}
	}
	
	function CreateStarStatic(column,num)
 	{
 		 for (var i=1;i<=5;i++){
  			 var imgId="column"+column+"num"+i;
 			 if (i<=num)
    			document.write("<img id=\""+imgId+"\" src=\"/resources/images/Icon/starActive.gif\">");
  			 else
   				 document.write("<img id=\""+imgId+"\" src=\"/resources/images/Icon/star.gif\">");
		  }
 	}
	
	function OnClickStarPic(column,num)
		
	{
		try
			{RequestServer(column,num);}
			catch(e){}

		for (var i=1;i<=5;i++)
		{
			var imgId="column"+column+"num"+i;
			if (i<=num)
			document.all[imgId].src='/resources/images/icon/starActive.gif';
			else
			document.all[imgId].src='/resources/images/icon/star.gif';	
		}
		
	}
	function OnMouseOverStarPic(column,num)
	{
		for (var i=1;i<=num;i++)
		{
			var imgId="column"+column+"num"+i;
			OnMouseOverPicSrc(document.all[imgId]);
		}
	}
	function OnMouseOutStarPic(column)
	{	
		for (var i=1;i<=5;i++)
		{
			var imgId="column"+column+"num"+i;
			if (document.all[imgId].src.indexOf("Over") !=-1)
			{OnMouseOutPicSrc(document.all[imgId]);}
		}
	}
	
/* Flash Interface */
	function SetXmlPath(FlashId,Path)
	{
		document.all[FlashId].SetVariable("XmlPath",Path);
	}
	function SetFlashWidth(FlashId)
	{
		if(screen.availWidth<1000)
		FlashWidth = 400;
		else
		FlashWidth = 500;
		document.all[FlashId].SetVariable("StageWidth", FlashWidth);
	}
/* QueryString for JS */
function PageQuery(q) {
	if(q.length > 1) this.q = q.substring(1, q.length);
	else this.q = null;
	this.keyValuePairs = new Array();
	if(q) {
		for(var i=0; i < this.q.split("&").length; i++) {
			this.keyValuePairs[i] = this.q.split("&")[i];
		}
	}
	this.getKeyValuePairs = function() { return this.keyValuePairs; }
	this.getValue = function(s) {
		for(var j=0; j < this.keyValuePairs.length; j++) {
			if(this.keyValuePairs[j].split("=")[0] == s)
				return this.keyValuePairs[j].split("=")[1];
		}
		return false;
	}
	this.getParameters = function() {
		var a = new Array(this.getLength());
		for(var j=0; j < this.keyValuePairs.length; j++) {
			a[j] = this.keyValuePairs[j].split("=")[0];
		}
		return a;
	}
	this.getLength = function() { return this.keyValuePairs.length; }	
}

function queryString(key){
	var page = new PageQuery(window.location.search); 
	return unescape(page.getValue(key)); 
}

function displayItem(key){
	if(queryString(key)=='false') 
	{
	result.innerHTML="you didn't enter a ?name=value querystring item.";
	}else{
	result.innerHTML+=queryString(key)+"<BR>";
	}
}
/* JS for Acticles */
	function doZoom(size){
		document.getElementById('ArticleContent').style.fontSize=size+'px'
	}
	
/* Show & Hide */
	function SwitchTable(ControlId,num)
	{
		for (var i=1;i<num+1;i++)
		{document.all["tbl"+i].style.display = "none";}
		document.all["tbl"+ControlId].style.display="";
	}
	function Switch(ControlId)
	{
		if (document.all[ControlId].style.display == "none")
		document.all[ControlId].style.display="";
		else
		document.all[ControlId].style.display="none";
	}
	function SwitchPic(pic, picsrc1, picsrc2)
	{
      if (pic.src.indexOf(picsrc1) !=-1 )
           pic.src = pic.src.replace(picsrc1,picsrc2);
      else 
           pic.src = pic.src.replace(picsrc2,picsrc1);
	}
	
	/* 用nocache方式打开一个窗口 */
	function OpenWindow (url, target)
	{
		var nocache = Math.random() * 10000;
		window.open(url + (url.indexOf('?') >= 0 ? "&" : "?") + 'nocache='+nocache, target);
	}

	
/* Frame Application */
	function SwitchFrameRows(FrameId)
	{
		if(parent.document.all[FrameId].rows!='*,20')
		parent.document.all[FrameId].rows='*,20';
		else
		parent.document.all[FrameId].rows='*,30%';
	}
	
	function SwitchFrameCols(FrameId)
	{
		if(parent.document.all[FrameId].cols!='*,250')
		parent.document.all[FrameId].cols='*,250';
		else
		parent.document.all[FrameId].cols='*,0';
	}
	
	function GotoFrame(PageName1,PageName2)
	{	
		top.frames["mainFrame"].location.href=PageName1;
		top.frames["Left"].location.href=PageName2;
	}
	function resizeIframe()
	{
		if(window.name != "")
		{
		i = parent.document.all[window.name];
		iHeight = document.body.scrollHeight;
			i.style.height = iHeight + "px";
	}
	}
	
/* OnMouseOver-Out */
	function OnMouseOverPicSrc(pic)
	{
		var picPath = pic.src.substring(0,pic.src.lastIndexOf("."));
		var picExt = pic.src.substring(pic.src.lastIndexOf("."));
		pic.src = picPath + "Over" + picExt;
	}
	
	function OnMouseOutPicSrc(pic)
	{
		var picPath = pic.src.substring(0,pic.src.lastIndexOf("Over"));
		var picExt = pic.src.substring(pic.src.lastIndexOf("."));
		pic.src = picPath + picExt;
	}
	
	function OnMouseChangeClass(obj)
	{
		OnMouseOverClass(obj);
	}
	
	function OnMouseOverClass(obj)
	{
		if(obj.oldClassName == null)
			obj.oldClassName = obj.className + "Over";
		
		var tempClass = obj.oldClassName;
		obj.oldClassName = obj.className;
		obj.className = tempClass;
	}
	
	function OnMouseOutClass(obj)
	{
		var tempClass = obj.oldClassName;
		obj.oldClassName = obj.className;
		obj.className = tempClass;
	}
	
	function OnClickClass(obj)
	{
		if(obj.className == obj.oldClassName)
			return;
		
		var overClass = obj.className.length > obj.oldClassName.length ? obj.className : obj.oldClassName;
		var className = obj.className.length > obj.oldClassName.length ? obj.oldClassName : obj.className;
		
		for(var i=0;i<document.all.length;i++)
		{
			if (document.all(i).name == 'menuitem') //所有元素都要设定name="menuitem"
			{
				document.all(i).className = className;
				document.all(i).oldClassName = overClass;
			}

		}
		
		obj.className = overClass;
		obj.oldClassName = overClass;
	}
	
	function anchorClassActive(obj,anchorClass)
	{
		for (var i=0;i<document.all.length;i++)
		{
			if (document.all(i).name == 'menuitem') //所有元素都要设定name="menuitem"
			document.all(i).className = null;
		}
		obj.className=anchorClass;
	}
/* Window Resize */
	
	function WindowMax()
	{
		window.moveTo(0,0);
		window.resizeTo(screen.availWidth,screen.availHeight);
	}
	function WindowMin()
	{
		screenleft = (screen.availWidth - 800)/2;
		screentop = (screen.availHeight - 570)/2;
		window.moveTo(screenleft,screentop);
		window.resizeTo(800,570);
	}
	
/* WebPart Loading Message */
	function LoadMsgSWF(swfSrc)
    {
		document.write("<center><object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width='80' height='50'>");
		document.write("<param name='movie' value='" + swfSrc + "' />");
        document.write("<param name='quality' value='high' />");
        document.write("<param name='wmode' value='transparent' />");
        document.write("</object></center>");     
    }
	
	function LoadMsgGIF(gifSrc)
    {
		document.write("<center><img src='"+gifSrc+"' border='0' /> ");
		document.write("Loading...</center>");
    }

/* LoadingDiv Behaviour */
function SetLoadingDivHeight()
{
	document.all['LoadingDiv'].style.height = document.documentElement.clientHeight;
	document.all['LoadingContentDiv'].style.top = ( document.documentElement.clientHeight - document.all['LoadingContentDiv'].clientHeight ) / 2 ;
	document.all['LoadingContentDiv'].style.left = ( document.documentElement.clientWidth - document.all['LoadingContentDiv'].clientWidth ) / 2;}

function ShowLoadingDiv( value )
{
	if( value )
	{
		document.getElementById('LoadingDiv').style.visibility='visible';
		document.getElementById('LoadingContentDiv').style.visibility='visible';
	}
	else
	{
		document.getElementById('LoadingDiv').style.visibility='hidden';
		document.getElementById('LoadingContentDiv').style.visibility='hidden';
	}
}

/* Web2.0 Div Auto Height */
function SetDivFrameCenter()
{
	document.all['Frame'].style.marginLeft = ( document.documentElement.clientWidth - 780 ) / 2;
}
function SetHeightMin()
{
	var length = Frame.childNodes.length;
    for(var i=1;i<length-1;i++)
    {
        var cLength = Frame.childNodes[i].childNodes.length;
        /*
        var maxHeight = 0;
        for(var j=0;j<cLength;j++)
        {
            var rcts = Frame.childNodes[i].childNodes[j].getClientRects();
            var height = rcts[0].bottom-rcts[0].top;
            if(height>maxHeight)
                maxHeight = height;
        }*/
        for(var j=0;j<cLength;j++)
            Frame.childNodes[i].childNodes[j].style.height=10+"px"
    }
}

function CheckAutoHeight()
{
    var length = Frame.childNodes.length;
    for(var i=1;i<length-1;i++)
    {
        var cLength = Frame.childNodes[i].childNodes.length;
        var maxHeight = 0;
        for(var j=0;j<cLength;j++)
        {
            var rcts = Frame.childNodes[i].childNodes[j].getClientRects();
            var height = rcts[0].bottom-rcts[0].top;
            if(height>maxHeight)
                maxHeight = height;
        }
        for(var j=0;j<cLength;j++)
            Frame.childNodes[i].childNodes[j].style.height=maxHeight+"px"
    }
}

function SetAutoHeight()
{
    if(document.readyState=="complete")
    {
		SetHeightMin();
        CheckAutoHeight();
    }
    else
        setTimeout("SetAutoHeight();",1000);
}

function SetScrollDiv(ControlId)
{
	while(document.readyState != "complete"){}
	SetScrollDivHeight(ControlId);
}

function SetScrollDivHeight(ControlId)
{
	var control = document.getElementById(ControlId);
	if(control == null)
		return;	

	var h = document.documentElement.clientHeight;
	//document.onresize = ResetDiv(control);
	//document.all[ControlId].style.height = document.documentElement.clientHeight-40;
	//if (document.all[ControlId].clientHeight == document.all[ControlId].scrollHeight)
	//document.all[ControlId].style.marginRight = 0;
	
	var previousSibling = control.previousSibling;
	//Firebox
	while(previousSibling != null)
	{
		
		if(previousSibling.tagName == "DIV")
			break;
		previousSibling = previousSibling.previousSibling;
	}
	
	if(previousSibling != null)
		control.style.height = document.documentElement.clientHeight - previousSibling.clientHeight - 10 + "px";
	else
		control.style.height = document.documentElement.clientHeight - 10 + "px";

	
	if( h > control.scrollHeight)
	{
		control.style.marginRight="0px"
	}
	else
	{
		control.style.marginRight="16px";
	}
	
	for(i = 0; i < control.childNodes.length; i++)
	{	
		if(control.childNodes[i].tagName == "DIV")
			control.childNodes[i].style.marginRight = "-" + control.style.marginRight;
	}
}

/* CheckWidth */
function CheckImgWidth( controlID, width )
{
	if( undefined != document.all[controlID] )
	{
		obj =  document.all[controlID];
		if( obj.width > width )
		{
			obj.width = width;
		}
	}
}