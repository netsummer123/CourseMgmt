/////////////////////////////
// Hint Version 0.02
// 2006-10-18
//////////////////////////////////////////////////////////////////////////////////////////////////////
<!--
if(window.Event){// 修正Event的DOM
    /*
                                IE5        MacIE5        Mozilla        Konqueror2.2        Opera5
    event                        yes        yes            yes            yes                    yes
    event.returnValue            yes        yes            no            no                    no
    event.cancelBubble            yes        yes            no            no                    no
    event.srcElement            yes        yes            no            no                    no
    event.fromElement            yes        yes            no            no                    no
    
    */
    Event.prototype.__defineSetter__("returnValue",function(b){// 
        if(!b)this.preventDefault();
        return b;
        });
    Event.prototype.__defineSetter__("cancelBubble",function(b){// 设置或者检索当前事件句柄的层次冒泡
        if(b)this.stopPropagation();
        return b;
        });
    Event.prototype.__defineGetter__("srcElement",function(){
        var node=this.target;
        while(node.nodeType!=1)node=node.parentNode;
	    return node;
        });
    Event.prototype.__defineGetter__("fromElement",function(){// 返回鼠标移出的源节点
        var node;
        if(this.type=="mouseover")
            node=this.relatedTarget;
        else if(this.type=="mouseout")
            node=this.target;
        if(!node)return;
        while(node.nodeType!=1)node=node.parentNode;
        return node;
        });
    Event.prototype.__defineGetter__("toElement",function(){// 返回鼠标移入的源节点
        var node;
        if(this.type=="mouseout")
            node=this.relatedTarget;
        else if(this.type=="mouseover")
            node=this.target;
        if(!node)return;
        while(node.nodeType!=1)node=node.parentNode;
        return node;
        });
    Event.prototype.__defineGetter__("offsetX",function(){
        return this.layerX;
        });
    Event.prototype.__defineGetter__("offsetY",function(){
        return this.layerY;
        });
    }
if(window.Document){// 修正Document的DOM
    /*
                                IE5        MacIE5        Mozilla        Konqueror2.2        Opera5
    document.documentElement    yes        yes            yes            yes                    no
    document.activeElement        yes        null        no            no                    no
    
    */
    }
if(window.Node){// 修正Node的DOM
    /*
                                IE5        MacIE5        Mozilla        Konqueror2.2        Opera5
    Node.contains                yes        yes            no            no                    yes
    Node.replaceNode            yes        no            no            no                    no
    Node.removeNode                yes        no            no            no                    no
    Node.children                yes        yes            no            no                    no
    Node.hasChildNodes            yes        yes            yes            yes                    no
    Node.childNodes                yes        yes            yes            yes                    no
    Node.swapNode                yes        no            no            no                    no
    Node.currentStyle            yes        yes            no            no                    no
    
    */
    Node.prototype.replaceNode=function(Node){// 替换指定节点
        this.parentNode.replaceChild(Node,this);
        }
    Node.prototype.removeNode=function(removeChildren){// 删除指定节点
        if(removeChildren)
            return this.parentNode.removeChild(this);
        else{
            var range=document.createRange();
            range.selectNodeContents(this);
            return this.parentNode.replaceChild(range.extractContents(),this);
            }
        }
    Node.prototype.swapNode=function(Node){// 交换节点
        var nextSibling=this.nextSibling;
        var parentNode=this.parentNode;
        node.parentNode.replaceChild(this,Node);
        parentNode.insertBefore(node,nextSibling);
        }
    }
if(window.HTMLElement){
    HTMLElement.prototype.__defineGetter__("all",function(){
        var a=this.getElementsByTagName("*");
        var node=this;
        a.tags=function(sTagName){
            return node.getElementsByTagName(sTagName);
            }
        return a;
        });
    HTMLElement.prototype.__defineGetter__("parentElement",function(){
        if(this.parentNode==this.ownerDocument)return null;
        return this.parentNode;
        });
    HTMLElement.prototype.__defineGetter__("children",function(){
        var tmp=[];
        var j=0;
        var n;
        for(var i=0;i<this.childNodes.length;i++){
            n=this.childNodes[i];
            if(n.nodeType==1){
                tmp[j++]=n;
                if(n.name){
                    if(!tmp[n.name])
                        tmp[n.name]=[];
                    tmp[n.name][tmp[n.name].length]=n;
                    }
                if(n.id)
                    tmp[n.id]=n;
                }
            }
        return tmp;
        });
    HTMLElement.prototype.__defineGetter__("currentStyle", function(){
        return this.ownerDocument.defaultView.getComputedStyle(this,null);
        });
    HTMLElement.prototype.__defineSetter__("outerHTML",function(sHTML){
        var r=this.ownerDocument.createRange();
        r.setStartBefore(this);
        var df=r.createContextualFragment(sHTML);
        this.parentNode.replaceChild(df,this);
        return sHTML;
        });
    HTMLElement.prototype.__defineGetter__("outerHTML",function(){
        var attr;
        var attrs=this.attributes;
        var str="<"+this.tagName;
        for(var i=0;i<attrs.length;i++){
            attr=attrs[i];
            if(attr.specified)
                str+=" "+attr.name+'="'+attr.value+'"';
            }
        if(!this.canHaveChildren)
            return str+">";
        return str+">"+this.innerHTML+"</"+this.tagName+">";
        });
    HTMLElement.prototype.__defineGetter__("canHaveChildren",function(){
        switch(this.tagName.toLowerCase()){
            case "area":
            case "base":
            case "basefont":
            case "col":
            case "frame":
            case "hr":
            case "img":
            case "br":
            case "input":
            case "isindex":
            case "link":
            case "meta":
            case "param":
                return false;
            }
        return true;
        });

    HTMLElement.prototype.__defineSetter__("innerText",function(sText){
        //var parsedText=document.createTextNode(sText);
        //alert(parsedText);
        this.innerHTML=sText;
        return sText;//parsedText;
        });
    HTMLElement.prototype.__defineGetter__("innerText",function(){
        var r=this.ownerDocument.createRange();
        r.selectNodeContents(this);
        return r.toString();
        });
    HTMLElement.prototype.__defineSetter__("outerText",function(sText){
       // var parsedText=document.createTextNode(sText);
        this.outerHTML=sText;//parsedText;
        return sText;//parsedText;
        });
    HTMLElement.prototype.__defineGetter__("outerText",function(){
        var r=this.ownerDocument.createRange();
        r.selectNodeContents(this);
        return r.toString();
        });
    HTMLElement.prototype.attachEvent=function(sType,fHandler){
        var shortTypeName=sType.replace(/on/,"");
        fHandler._ieEmuEventHandler=function(e){
            window.event=e;
            return fHandler();
            }
        this.addEventListener(shortTypeName,fHandler._ieEmuEventHandler,false);
        }
    HTMLElement.prototype.detachEvent=function(sType,fHandler){
        var shortTypeName=sType.replace(/on/,"");
        if(typeof(fHandler._ieEmuEventHandler)=="function")
            this.removeEventListener(shortTypeName,fHandler._ieEmuEventHandler,false);
        else
            this.removeEventListener(shortTypeName,fHandler,true);
        }
    HTMLElement.prototype.contains=function(Node){// 是否包含某节点
        do if(Node==this)return true;
        while(Node=Node.parentNode);
        return false;
        }
    HTMLElement.prototype.insertAdjacentElement=function(where,parsedNode){
        switch(where){
            case "beforeBegin":
                this.parentNode.insertBefore(parsedNode,this);
                break;
            case "afterBegin":
                this.insertBefore(parsedNode,this.firstChild);
                break;
            case "beforeEnd":
                this.appendChild(parsedNode);
                break;
            case "afterEnd":
                if(this.nextSibling)
                    this.parentNode.insertBefore(parsedNode,this.nextSibling);
                else
                    this.parentNode.appendChild(parsedNode);
                break;
            }
        }
    HTMLElement.prototype.insertAdjacentHTML=function(where,htmlStr){
        var r=this.ownerDocument.createRange();
        r.setStartBefore(this);
        var parsedHTML=r.createContextualFragment(htmlStr);
        this.insertAdjacentElement(where,parsedHTML);
        }
    HTMLElement.prototype.insertAdjacentText=function(where,txtStr){
        var parsedText=document.createTextNode(txtStr);
        this.insertAdjacentElement(where,parsedText);
        }
    HTMLElement.prototype.attachEvent=function(sType,fHandler){
        var shortTypeName=sType.replace(/on/,"");
        fHandler._ieEmuEventHandler=function(e){
            window.event=e;
            return fHandler();
            }
        this.addEventListener(shortTypeName,fHandler._ieEmuEventHandler,false);
        }
    HTMLElement.prototype.detachEvent=function(sType,fHandler){
        var shortTypeName=sType.replace(/on/,"");
        if(typeof(fHandler._ieEmuEventHandler)=="function")
            this.removeEventListener(shortTypeName,fHandler._ieEmuEventHandler,false);
        else
            this.removeEventListener(shortTypeName,fHandler,true);
        }
    }
//-->
////////////////////////////////////////////////////////////////////////////////////////////////////////

				var oldValue = "";
				var selectedDictionary = "";
				var selectedHintIndex = -1;
				var selectedInput;
				var maxHintCount = 1000;
				var countDown = 0;
				var updateInterval;
				var _event;

				function SearchEvent()
				{
					//IE
					if(document.all)
						return window.event;
						
					var func=SearchEvent.caller;
					while(func!=null)
					{
						var arg0=func.arguments[0];
						if(arg0)
						{
							if(arg0.constructor==Event || arg0.constructor==MouseEvent ||arg0.constructor==KeyboardEvent)
								return arg0;
						}
						func=func.caller;
					}
					return null;
				}
				
				function getEvent()
				{
					 return window.event?window.event:SearchEvent();
				}
							
				function trim(str)
				{
					return str.replace(/^\s*|\s*$/g,"");
				}

				function showLoading()
				{
					var divLoading = document.getElementById("__LOADING__");
					if( !divLoading )
					{
						divLoading = document.createElement("DIV");
						divLoading.id = "__LOADING__";
						divLoading.style.display = "none";
						divLoading.className = "HintTextbox"
						divLoading.style.left = "100px";
						divLoading.style.position = "absolute";
						divLoading.align = "center";
						divLoading.innerText = "载入中...";
						document.body.appendChild(divLoading);
					}
					if(	selectedInput && divLoading ){
						setDivPosition(selectedInput,divLoading);
						divLoading.style.display = "";	
					}
				}
				
				function hideLoading()
				{
					var divLoading = document.getElementById("__LOADING__");
					if(	divLoading )
						divLoading.style.display = "none";
				}
				
				//show hint div
				function showHint()
				{
					hideLoading();
					var divHint = getDivHint();
					setHintPosition(selectedInput);
					divHint.style.height = Math.min(114,21*Math.max(divHint.childNodes.length,1)) +"px";
					divHint.style.display = "";
				}

				//hide hint div	
				function hideHint()
				{
					var divHint = getDivHint();
					divHint.style.display = "none";
					divHint.innerHTML = "";
				}
				
				function startCountDown()
				{
					if( countDown <= 0 ){
						if( oldValue != selectedInput.value )
						{
							updateHint();
						}
						countDown = 0;
					}
					else
						countDown--;
				}
				
				function setIntervalUpdate()
				{
					clearInterval(updateInterval);
					updateInterval = setInterval("startCountDown();",300);
				}
								
				function stopIntervalUpdate()
				{
					clearInterval(updateInterval);
				}
				
				function setDivPosition( varSrcElem, varDiv )
				{
					var srcObj = varSrcElem;
					if( !srcObj || !varDiv )
						return;
					var t = srcObj.offsetTop, l = srcObj.offsetLeft;
					var st = 0, sl = 0;
					while (srcObj = srcObj.offsetParent)
					{
						st = srcObj.scrollTop;
						sl = srcObj.scrollLeft;
						t += srcObj.offsetTop - st;
						l += srcObj.offsetLeft - sl;
					}
					t += st;
					l += sl;
					varDiv.style.width = varSrcElem.clientWidth + "px";
					varDiv.style.left= l + "px";
					varDiv.style.top = t + varSrcElem.offsetHeight - 1 + "px";
				}
				
				//set hint div position(absolute)
				function setHintPosition()
				{
					if( selectedInput ){
						var divHint = getDivHint();
						setDivPosition(selectedInput,divHint);
					}
				}
				
			
				function selectHintItem()
				{
					if( selectedHintIndex.length == 0 ){
						selectedHintIndex = -1;
					}
					
					var hasSelected = false;
						
					for( var i = 0; i < getDivHint().childNodes.length; i++ ){
						var item = document.getElementById("__HINT__"+i);
						if( !item )
							item = document.getElementById("__CACHE__ITEM__"+i);
						if( item ){
							if( i == selectedHintIndex )
							{
								hasSelected = true;
								item.className="HintItemSelect";
								if(item.offsetTop-getDivHint().scrollTop-getDivHint().clientHeight>-18)
									item.scrollIntoView(false);
								if(item.offsetTop-getDivHint().scrollTop<0)
									item.scrollIntoView(true);
							}
							else
								item.className="HintItem";
						}
					}
					return hasSelected
				}
				
				function addItems( responseTxtVal )
				{
					var arrayString = responseTxtVal.split("||");
					var elemCache = document.getElementById(getDivCacheElemId(selectedInput));// get current cache div
					if( !elemCache ){//cache does not exist
						elemCache = document.createElement("DIV");
						elemCache.id = getDivCacheElemId(selectedInput);
						getDivCache().appendChild(elemCache);
					}
					for( var i = 0; i < Math.min(arrayString.length,maxHintCount); i++ ){
						if( trim(arrayString[i]).length > 0 ){
							addCacheItem(elemCache,arrayString[i]);
						}
					}
				}

				//get node element of the cache segement root
				function getDivCache()
				{
					var elem = document.getElementById("__DIV__CACHE__");
					if( !elem ){
						elem = document.createElement("DIV");
						elem.id = "__DIV__CACHE__";
						elem.style.display = "none";
						document.body.appendChild(elem);
					}
					return elem;
				}
				
				//generate cache item element id by current control id
				function getDivCacheElemId( varSrcElem )
				{
					return "__CACHE__" + varSrcElem.id;
				}
				
				//get node element of the hint div
				function getDivHint()
				{
					elem = document.getElementById("__DIV__HINT__");
					if( !elem ){
						elem = document.createElement("DIV");
						elem.id = "__DIV__HINT__";
						elem.className = "HintTextbox";
						elem.style.display = "none";
						elem.style.left = "100px";
						elem.style.height = "114px";
						elem.style.overflow = "auto";
						elem.style.position = "absolute";
						document.body.appendChild(elem);
					}
					return elem;
				}
				
				function getSelectedHintText()
				{
					for( var i = 0; i < getDivHint().childNodes.length; i++ ){
						var item = document.getElementById("__HINT__"+i);
						if( !item )
							item = document.getElementById("__CACHE__ITEM__"+i);
						if( item ){
							if( i == selectedHintIndex )
								return item.innerText;
						}
					}
					return null;
				}
				
				//clear cache of current control
				function clearCache( varSrcElem )
				{
					var elemCache = document.getElementById(getDivCacheElemId(varSrcElem));
					if( elemCache )
						getDivCache().removeChild( elemCache );
				}
				
				//add cache item in to cache segement of current control
				function addCacheItem( varSrcElem, varItem )
				{
					var elemCacheItem = document.createElement("DIV");	//create new cache div
					elemCacheItem.id = "__CACHE__ITEM__" + varSrcElem.childNodes.length;
					elemCacheItem.className="HintItem";
					elemCacheItem.innerText = varItem;
					varSrcElem.appendChild(elemCacheItem);
				}
				
				function setDictionary( name, srcElem )
				{
					var e = getEvent();
					selectedInput=e.srcElement;
 					hideHint();
					selectedDictionary = name;
					selectedHintIndex = -1;
					oldValue = selectedInput.value;
					clearInterval(updateInterval);
					setIntervalUpdate();
					initAttributes(selectedInput);
				}
				
				//init and update hint data
				function updateHint()
				{
					var divHint = getDivHint();
					var divCache = getDivCache();
					var divCacheElem = document.getElementById(getDivCacheElemId(selectedInput));
					if( oldValue != selectedInput.value )
					{
						divHint.innerHTML = "";
						clearCache(selectedInput);
						oldValue = selectedInput.value;
						var URL = "_DictionaryLoader.aspx?DictionaryName="+selectedDictionary+"&InputText="+selectedInput.value+"&nocache="+Math.random(1);
						sendRequest(URL,processRequest);
						showLoading();
					}
					else{
						hideHint();
						if( divCacheElem )//cache available, use cached data
						{
							divHint.innerHTML = divCacheElem.innerHTML;
							divHint.onmouseover = function(){ selectedHintIndex = getEvent().srcElement.id.substr(15);getEvent().srcElement.style.cursor="pointer";selectHintItem();}
							divHint.onmousedown = function(){
								var hintText = getSelectedHintText();
								if( !hintText )
									return;
								selectedInput.value = hintText;
								oldValue = selectedInput.value;
								hideHint();
							}
							divHint.onmouseleave = function(){ selectedHintIndex = -1;selectHintItem();}
							showHint();
						}
						else	//no cache available, get data from server response
						{
							divHint.innerHTML = "";
							var URL = "_DictionaryLoader.aspx?DictionaryName="+selectedDictionary+"&InputText="+selectedInput.value+"&nocache="+Math.random(1);
							oldValue = selectedInput.value;
							sendRequest(URL,processRequest);
							showLoading();
						}
					}
				}
					
				function sendRequest( url, processFunc )
				{
					if (window.XMLHttpRequest) { // Mozilla, Safari, ...
						http_request = new XMLHttpRequest();
					} 
					else if (window.ActiveXObject) { // IE
						http_request = new ActiveXObject("Microsoft.XMLHTTP");
					}
					http_request.onreadystatechange = processFunc;
					http_request.open("GET", url, true);
					http_request.send(null);
				}
					
				function processRequest()
				{
					if (http_request.readyState == 4) { // 判断对象状态
						hideLoading();
						if (http_request.status == 200) { // 信息已经成功返回，开始处理信息
							addItems(http_request.responseText);
							updateHint();
							showHint();
						}
						else { //页面不正常
							alert("字典读取异常。");
							hideHint();
							hideLoading();
						}
					}
					else{
					}
				}
				
				function textboxKeyDown()
				{
					if( selectedInput != getEvent().srcElement )
						return;
					if( getEvent().keyCode == 13 )//enter key
					{
						if( selectedInput && selectedHintIndex >= 0 ){
						alert();
							selectedInput.value = getSelectedHintText();
							selectedHintIndex = -1;
							oldValue = selectedInput.value;
							hideHint();
							return false;
						}
					}
					else if( getEvent().keyCode == 38 )//up-arrow key
					{
						if( selectedHintIndex <= 0 ){
							selectedHintIndex = -1;
							hideHint();
							selectedInput.value = oldValue;
						}
						else{
							selectedHintIndex--;
							showHint();
						}
						selectHintItem();
						selectedInput.focus();
						return false;
					}
					else if( getEvent().keyCode == 40 )//down-arrow key
					{
						if( selectedHintIndex == -1 ){
							selectedHintIndex = 0;
							countDown = 0;
							updateHint();
						}
						else{
							selectedHintIndex = Math.min(getDivHint().childNodes.length-1, selectedHintIndex +1);
						}
						selectHintItem();
						showHint();
						return false;
					}
					else
					{
						countDown = 4;
					}
				}
				
				function textboxKeyUp()
				{
					if( selectedInput != document.activeElement )
						return;
					if( getEvent().keyCode == 27 && selectedHintIndex >= 0 ) //escape key
					{
						if( selectedInput ){
							selectedInput.value = oldValue;
							selectedInput.focus();
						}
					}
					else if( getEvent().keyCode == 13 )//enter key
					{
						countDown = 4;
						return false;
					}
					else if( getEvent().keyCode == 38 || getEvent().keyCode == 40 )//up-arrow key && down-arrow key
					{
						return false;
					}
				}
				
				//initialize attributes for current control
				function initAttributes( varSrcElem )
				{
					document.onkeydown = textboxKeyDown;
					document.onkeyup = textboxKeyUp;
					document.onmousedown = function(){ if(getEvent().srcElement != selectedInput && getEvent().srcElement != getDivHint())hideHint(); }

	//				varSrcElem.onblur = function(){ clearInterval(updateInterval); hideHint();}
	//				window.onscroll = function(){ setHintPosition();}
	//				document.body.onscroll = function(){ setHintPosition();}
					var mainDiv = document.getElementById("MainDiv");
					if( mainDiv ){
						mainDiv.onscroll = function(){ setHintPosition();}
					}
					return false;
				}
				