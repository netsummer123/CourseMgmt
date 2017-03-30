
var oPopup = window.createPopup();  
oPopup.document.createStyleSheet().addImport("http://oa.jiading.gov.cn/Style1/CSS/Css.css");
var oPopupBody = oPopup.document.body;

var divTemplate = "<div class='_0_' id='div_1_' width='100%'>"+
                "<div class='_2_' style='display:none'><img src='_3_' width='60' height='83' /></div>"+
                "<div class='_4_'>"+
                "<div class='_5_' style='white-space:nowrap;'>_6_</div>"+
                "<div style='white-space:nowrap;'><img src='_13_' />&nbsp;<label id='lblStatus_1_' style='white-space:nowrap;'>_14_</label></div>"+
                "<div class='_7_' style='white-space:nowrap;'>部门:&nbsp;_8_</div>"+
                "<div class='_7_' style='white-space:nowrap;'>Email:&nbsp;<!--a href='#' id=\"emailLink_1_\"-->_9_<!--/a--></div>"+
                "<div class='_7_' style='white-space:nowrap;'>办公室电话:&nbsp;_10_</div>"+
                "<div class='_11_'><span style='display:_17_;'><img src='http://app01.jiading.gov.cn/UI Standard/Icon/Action/mail.gif' width='16' height='16' align='absmiddle' alt='发送EMAIL给他' id=\"imgSendMail_1_\" />"+
                "&nbsp;&nbsp;</span><span style='display:_12_;'><img src='http://app01.jiading.gov.cn/UI Standard/Icon/Action/mobile.gif' width='16' height='16' align='absmiddle' alt='发送短信给他' id=\"imgSendSMS_1_\"/>&nbsp;&nbsp;</span>"+
                "<span style='display:_15_;'><img src='http://app01.jiading.gov.cn/UI Standard/Icon/Action/lcs.gif' width='16' height='16' align='absmiddle' alt='和他在线聊天' id=\"imgSendLCS_1_\"/>&nbsp;&nbsp;</span>"+
                 "<span><img src='http://app01.jiading.gov.cn/UI Standard/Icon/object/Department.gif' width='16' height='16' align='absmiddle' alt='加入个人群组' id=\"imgAddToPersonalGroup_1_\"/>&nbsp;&nbsp;</span></div>"+
                "<div class='_7_' id='divCalendar_1_' style='white-space:nowrap;'></div>"+
                "</div></div>";

function ShowAndHide(id)
{
    GetStatus(id);
    var nameSpan = document.getElementById("imgStatus"+id);
    var status = GetIconStatus(nameSpan.src);
    
    //content
    var tip = divTemplate;
    tip = tip.replace(/_1_/g,id).replace(/_3_/g,nameSpan.photourl).replace(/_6_/g,nameSpan.username).replace(/_8_/g,nameSpan.dept).replace(/_9_/g,nameSpan.email);
    tip = tip.replace(/_10_/g,nameSpan.phone).replace(/_13_/g,nameSpan.src).replace(/_14_/g,status);//.replace(/_16_/g,calendarStatus);
    tip = tip.replace(/_0_/g,cardCss).replace(/_2_/g,photoCss).replace(/_4_/g,infoCss).replace(/_5_/g,nameCss).replace(/_7_/g,otherCss).replace(/_11_/g,contactCss);
    if (nameSpan.mobile == "")
        tip = tip.replace(/_12_/,"none");
    else
        tip = tip.replace(/_12_/,"''");
    
    if (nameSpan.email == "")
        tip = tip.replace(/_17_/,"none");
    else
        tip = tip.replace(/_17_/,"''");
    

    if (status == "离线" || status == "无法获得状态")
        tip = tip.replace(/_15_/g,"none");
    else
        tip = tip.replace(/_15_/g,"''");
            
    //set content
    oPopupBody.innerHTML = tip;  
    
    var imgSendMail = oPopup.document.getElementById("imgSendMail"+id);
    if(imgSendMail != null)
    {
        imgSendMail.onclick = function()
        {
            location = "mailto:" + nameSpan.email;
        }
    }
    
    var imgSendSMS = oPopup.document.getElementById("imgSendSMS"+id);
    if(imgSendSMS != null)
    {
        imgSendSMS.onclick = function()
        {
            window.open('http://app01.jiading.gov.cn/Messages.Web/User/SendSMS.aspx?ReceiverID='+nameSpan.userid);
        }
    }
    
    var imgSendLCS = oPopup.document.getElementById("imgSendLCS"+id);
    if(imgSendLCS != null)
    {
        imgSendLCS.onclick = function()
        {
            location = nameSpan.lcs;
        }
    }
    var imgAddToPersonalGroup = oPopup.document.getElementById("imgAddToPersonalGroup"+id);
    if(imgAddToPersonalGroup != null)
    {
   	imgAddToPersonalGroup.onclick = function()
    	{
        	var myURL = 'http://app01.jiading.gov.cn/AddressBook/PersonalGroupSelector.aspx?UserGuid='+nameSpan.userid;
         	openWin = window.open (myURL,"mywindow","location=0,status=1,scrollbars=0,resizable=0,width=360,height=161");
        }
    } 
    
    //show
    oPopup.show(window.event.screenX, window.event.screenY, 1, 1);
    var width = oPopup.document.getElementById("div"+id).clientWidth;
    var height = oPopup.document.getElementById("div"+id).clientHeight;    
    
    var calendarStatus = GetCalendarStatus(id);
    
    oPopup.hide();
    oPopup.show(window.event.screenX, window.event.screenY, width+2, height+12);
}

function GetStatusIcon(sta)
{
    switch(sta)
    {
        case "Online":
            return "http://oa.jiading.gov.cn/Style1/Images/online.gif";
        case "Offline":
            return "http://oa.jiading.gov.cn/Style1/Images/offline.gif";
        case "Away":
            return "http://oa.jiading.gov.cn/Style1/Images/away.gif";
        case "Busy":
            return "http://oa.jiading.gov.cn/Style1/Images/busy.gif";
        default:
            return "http://oa.jiading.gov.cn/Style1/Images/offline.gif";
    }
}

function GetIconStatus(icon)
{
    switch(icon)
    {
        case "http://oa.jiading.gov.cn/Style1/Images/online.gif":
            return "在线";
        case "http://oa.jiading.gov.cn/Style1/Images/offline.gif":
            return "离线";
        case "http://oa.jiading.gov.cn/Style1/Images/away.gif":
            return "离开";
        case "http://oa.jiading.gov.cn/Style1/Images/busy.gif":
            return "忙碌";
        default:
            return "离线";
    }
}


function GetStatus(id)
{       
	var objHttp = false;
	var bHttp = false;     
    var nameSpan = document.getElementById("imgStatus"+id);
    var url = "http://lcs.jiading.gov.cn/LCSQuery.Web/QueryPresence.aspx?l=en&uri=" + nameSpan.lcs+"&nocache="+Math.random(); 
    var text = "";
    var s = "";
    // Create the XML HTTP object
    var aszHttpProgIDs = [ "MSXML2.XMLHTTP.4.0",
                           "MSXML2.XMLHTTP.3.0",
                           "MSXML2.XMLHTTP",
                           "Microsoft.XMLHTTP" ];
    for (var i = 0; !bHttp && i < aszHttpProgIDs.length; i++) {
      try {
         objHttp = new ActiveXObject(aszHttpProgIDs[i]);
         bHttp = true;
      } catch (objException) {
        // error handling elided for clarity
      }
    }
    
    if (!objHttp && typeof XMLHttpRequest!='undefined')
    {
        try {objHttp = new XMLHttpRequest();}
        catch (e){objHttp=false;}
    }
    if (!objHttp && window.createRequest)
    {
        try {objHttp = window.createRequest();}
        catch (e){objHttp=false;}
    }

    objHttp.open("get", url,false);
    objHttp.onreadystatechange=function()
    {
        if (objHttp.readyState==4) {
             text = objHttp.responseText;
             var iconSrc = GetStatusIcon(text);
             switch(text)
             {
                case "Offline":
                    s="离线";
                    break;
                case "Online":
                    s="在线";
                    break;
                case "Away":
                    s="离开";
                    break;
                case "Busy":
                    s="忙碌";
                    break;
                case "error":
                    s="无法获得状态";
                    break;
                default:
                    s="离线";
                    break;
			}
			try{
				var iconStatus = document.getElementById("imgStatus"+id);
				iconStatus.src = iconSrc;
			}catch(e){}
        }
    }
    objHttp.send();
}


function GetCalendarStatus(id)
{       
	var objHttp = false;
	var bHttp = false;     
    var nameSpan = document.getElementById("imgStatus"+id);
    var url = "http://app01.jiading.gov.cn/Calendar.Web/CalendarUserStatus.aspx?UserID=" + nameSpan.userid+"&nocache="+Math.random(); 

    var text = "";
    // Create the XML HTTP object
    var aszHttpProgIDs = [ "MSXML2.XMLHTTP.4.0",
                           "MSXML2.XMLHTTP.3.0",
                           "MSXML2.XMLHTTP",
                           "Microsoft.XMLHTTP" ];
    for (var i = 0; !bHttp && i < aszHttpProgIDs.length; i++) {
      try {
         objHttp = new ActiveXObject(aszHttpProgIDs[i]);
         bHttp = true;
      } catch (objException) {
        // error handling elided for clarity
      }
    }
    
    if (!objHttp && typeof XMLHttpRequest!='undefined')
    {
        try {objHttp = new XMLHttpRequest();}
        catch (e){objHttp=false;}
    }
    if (!objHttp && window.createRequest)
    {
        try {objHttp = window.createRequest();}
        catch (e){objHttp=false;}
    }

    objHttp.open("get", url,false);
    objHttp.onreadystatechange=function()
    {
        if (objHttp.readyState==4) {
			try{
				text = objHttp.responseText;
				var divCalendar = oPopup.document.getElementById("divCalendar"+id);
    			divCalendar.innerText = text;
			}
			catch(e){}
        }
    }
    objHttp.send();
}
