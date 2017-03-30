<script language="javascript">
			function CLASS_MSN_MESSAGE(id,width,height,caption,title,message,target,action,notify)   
					{   
						this.id     = id;   
						this.title  = title;   
						this.caption= caption;   
						this.message= message;   
						this.target = target;   
						this.action = action;   
						this.width  = width?width:200;   
						this.height = height?height:120;   
						this.timeout= 3000;   
						this.speed  = 20;  
						this.step   = 1;
						if (notify != "")
						{
							this.notify = notify;
						}
						else
						{
							this.notify = "";
						}
						this.more	= "更多..";
						
						this.notifyURL ="";
						this.moreURL = "";
						this.messageURL = "";
						this.confirmURL = "";
					  
						this.left   = 0;  
						this.right  = screen.availWidth -1;   
						this.top    = 0;  
						this.bottom = screen.availHeight;  
						this.autoHideTimeOut = 0; 
						
					}   
 
					CLASS_MSN_MESSAGE.prototype.hide = function()   
					{   
						if(this.onunload())       
						{   
							this.Pop.hide();   
							if(this.timer)   
							{   
								window.clearInterval(this.timer);   
							}   
						}   
					}   
 
					CLASS_MSN_MESSAGE.prototype.onunload = function()   
					{   

						return true;   
					}   
					CLASS_MSN_MESSAGE.prototype.on_btNotify_Click = function()   
					{   
						
						document.all.scriptB.src=this.confirmURL;
						if (this.notify == "[开始聊天]")
						window.open(this.notifyURL,'_blank', 'height=480, width=540, toolbar=no, menubar=no, scrollbars=no,resizable=no, location=no,status=no');
						else
						window.open(this.notifyURL);
						this.hide();   
					}   
					
					CLASS_MSN_MESSAGE.prototype.on_btMore_Click = function()   
					{   
						
						window.open(this.moreURL);
						this.hide();   
					}   
					CLASS_MSN_MESSAGE.prototype.on_btMessage_Click = function()   
					{   
						
						window.open(this.messageURL,'_blank', 'height=510, width=680, toolbar=no, menubar=no, scrollbars=no,resizable=no, location=no,status=no');
						
						this.hide();   
					}  

					CLASS_MSN_MESSAGE.prototype.show = function()   
					{   
						var oPopup = window.createPopup(); //IE5.5+   
			   
						this.Pop = oPopup;   
			   
						var w = this.width;   
						var h = this.height;   
					   
						var str = "<DIV style='BORDER-RIGHT: #455690 1px solid; BORDER-TOP: #a6b4cf 1px solid; Z-INDEX: 99999; LEFT: 0px; BORDER-LEFT: #a6b4cf 1px solid; WIDTH: " + w + "px; BORDER-BOTTOM: #455690 1px solid; POSITION: absolute; TOP: 0px; HEIGHT: " + h + "px; BACKGROUND-COLOR: #c9d3f3'>"   
						str += "<embed name='MM_controlSound1' src='images/newalert.wav' loop='false' autostart='true' hidden='true' width='0' height='0'></embed>"
						str += "<TABLE style='BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid' cellSpacing=0 cellPadding=0 width='100%' bgColor=#DBEEFF border=0>"   
						str += "<TR>"   
						str += "<TD style='FILTER: progid:DXImageTransform.Microsoft.Gradient(gradientType=0,startColorStr=#ffffff,endColorStr=#DBEEFF);' width=30 height=24></TD>"   
						str += "<TD style='FILTER: progid:DXImageTransform.Microsoft.Gradient(gradientType=0,startColorStr=#ffffff,endColorStr=#DBEEFF); PADDING-LEFT: 4px; FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #1f336b; PADDING-TOP: 4px' vAlign=center width='100%'>" + this.title + "</TD>"   
						str += "<TD style='FILTER: progid:DXImageTransform.Microsoft.Gradient(gradientType=0,startColorStr=#ffffff,endColorStr=#DBEEFF); PADDING-RIGHT: 2px; PADDING-TOP: 2px' vAlign=center align=right width=19>"   
						str += "<SPAN title=关闭 style='FONT-WEIGHT: bold; FONT-SIZE: 12px; CURSOR: hand; COLOR: black; MARGIN-RIGHT: 4px' id='btSysClose' >×</SPAN></TD>"   
						str += "</TR>"   
						str += "<TR>"   
						str += "<TD style='PADDING-RIGHT: 1px;PADDING-BOTTOM: 1px' colSpan=3 height=" + (h-28) + ">"   
						str += "<DIV style='BORDER-RIGHT: #b9c9ef 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #728eb8 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px; PADDING-BOTTOM: 8px; BORDER-LEFT: #728eb8 1px solid; WIDTH: 100%; COLOR: #1f336b; PADDING-TOP: 8px; BORDER-BOTTOM: #b9c9ef 1px solid; HEIGHT: 100%'>"   
						str += "<DIV style='WORD-BREAK: break-all' align=left><A href='javascript:void(0)' hidefocus=true id='btMessage'><FONT color=#ff0000>" + this.message + "</FONT></A></DIV><BR>"
						str += "<DIV align=right><A href='javascript:void(0)' hidefocus=true id='btNotify'><FONT color=#000000>" + this.notify + "</FONT></A></DIV><BR>"   
						str += "<DIV style='WORD-BREAK: break-all' align=right><A href='javascript:void(0)' hidefocus=true id='btMore'><FONT color=#0000ff>" + this.more + "</FONT></A></DIV>"   
						str += "</DIV>"   
						str += "</TD>"   
						str += "</TR>"   
						str += "</TABLE>"   
						str += "</DIV>"    
					   
						oPopup.document.body.innerHTML = str;   
					   
						var docWidth    = this.right;   
						var docHeight   = this.bottom-h;   
						var offset      = screen.height - screen.availHeight;   
					  
						var me          = this;   
						var timer;   
					  
						var fun = function()   
						{   
							oPopup.show(docWidth-w, docHeight + offset, w, h);     
							if(offset <= 0)   
							{   
								window.clearInterval(timer);   
								if(me.autoHideTimeOut>0) 
								{ 
									window.setTimeout(function(){me.hide()},me.autoHideTimeOut); 
								} 
							}   
							offset = offset - me.step;   
					   
						}   
					 
						if(typeof(this.speed)!="number"||this.speed<=0) 
						{ 
							this.speed = 20; 
						} 
					 
						timer = window.setInterval(fun,this.speed)       
					   
					      
					   
						var btClose = oPopup.document.getElementById("btSysClose");   
					   
						btClose.onclick = function()   
						{   
							me.hide();   
						}   
					   
						var btNotify = oPopup.document.getElementById("btNotify");   
						btNotify.onclick = function()   
						{   
							me.on_btNotify_Click();   
						}   
					   
						var btMore = oPopup.document.getElementById("btMore");   
						btMore.onclick = function()   
						{   
							me.on_btMore_Click();   
						}   
						var btMessage = oPopup.document.getElementById("btMessage");   
						btMessage.onclick = function()   
						{   
							me.on_btMessage_Click();   
						}   
					   
						this.timer = timer;   
					   
					}   

					CLASS_MSN_MESSAGE.prototype.rect = function(left,right,top,bottom)  
					{  
						try  
						{  
							this.left   = left    ?left    :0;  
							this.right  = right    ?right    :screen.availWidth -1;  
							this.top    = top    ?top    :0;  
							this.bottom = bottom?bottom    :screen.availHeight;  
						}  
						catch(e)  
						{}  
					}  
					
		</script>
<script id="scriptB" src=''>
		</script>
<script id="scriptA" src='/Wicresoft.SOA.Message.WebService/MessageReceiverWeb.aspx'>
		</script>
<script>
				j=0;
			setTimeout("start()", 20000)
			function start()
			{
				document.all.scriptA.src="/Wicresoft.SOA.Message.WebService/MessageReceiverWeb.aspx?DSAFDAS=" + Math.random();
				setTimeout("al()", 5000);
			}
			function al()
			{
				var i = getStatus();
				if (i != j) 
				{
					if (i != 0)
					{
						j=i;
						var msg1 = new CLASS_MSN_MESSAGE("aa",200,120,"消息提示：","你有"+ j +"条新提示",getTitle(),"","",getContent());
						msg1.speed = 20; 
						msg1.autoHideTimeOut = 10000; 
						msg1.notifyURL = getURL();
						msg1.messageURL = "/Wicresoft.SOA.Message.WebService/ReadMessagePublic.aspx?ID="+getID()+"&Confirm=On";
						msg1.moreURL = "/Wicresoft.SOA.Message.WebService/AppMessageListPublic.aspx?List=Inbox"; 
						msg1.confirmURL = "/Wicresoft.SOA.Message.WebService/MessageReceiverWeb.aspx?ID=" + getID() + "&Confirm=On&DSAFDAS=" + Math.random();
						msg1.show();  
						
					}
					else
					{
						j=i;
					}
				}
				
				document.all.m.innerText="你有" + i + "条新提示。";
				document.all.scriptA.src="/Wicresoft.SOA.Message.WebService/MessageReceiverWeb.aspx?&DSAFDAS=" + Math.random();
				
				setTimeout("al()", 5000);
 			}
		</script>