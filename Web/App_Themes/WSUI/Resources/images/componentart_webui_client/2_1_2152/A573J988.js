var qzAiw=null,qzby=null,qzqh=null,qzpl=null,qzov=null,qznr=null,qzgq=0;function ComponentArt_Snap(qzaz){this.Id=qzaz;this.RenderOverWindowedObjects=false;this.BringToTopOnClick=true;this.CookieName=null;this.qzpf=0;this.qznq=0;this.qzAcg=false;this.qzAbc=false;this.qzms=false;this.qzup=null;this.qzcf=-1;this.qzpv=null;this.qzvq=-1;this.qzdv=null;this.qznp='';this.qzAaa='';this.UndockedCssClass='';this.qzik='';this.qzAmn='';this.qzak=null;this.qztf=true;this.qzvp=true;this.qzkg=0;this.qzij=0;this.qzte='';this.ResizeThreshold=5;this.qzlb=false;this.qzzz=false;this.qzlo=null;this.qzAkk=null;this.OldScrollHandler=null;this.OldResizeHandler=null;this.qzqg;this.qzqf;this.qzxb=0;this.qzAad=0;this.qzvc='';this.qzpk=1;this.qzAme=null;this.qzAmd=null;this.qzAlx=null;this.qzAlw=null;this.qzAmi=0;this.qzAkr=0;};ComponentArt_Snap.prototype.Expand=function(){qzAkb(this);};ComponentArt_Snap.prototype.Collapse=function(){qzAcj(this);};ComponentArt_Snap.prototype.Dock=function(dockId,qzcf,qzma){qxa(this.Id,dockId,qzcf,qzma);};ComponentArt_Snap.prototype.Undock=function(x,y){qzAfg(this,x,y);};ComponentArt_Snap.prototype.FloatTo=function(x,y){art_AnimateSpan(this.Id,x,y);};ComponentArt_Snap.prototype.StartDragging=function(qzim){qxc(qzim,this);};ComponentArt_Snap.prototype.ToggleExpand=function(){qxb(this);};function art_InitCore(qzaz,qztg){var oPosObj=art_GetInstance(qzaz);eval('oPosObj.RepositionFloater = art_RepositionFloater_'+qzaz+';');oPosObj.Situation=document.getElementById('Art_Situation_'+qzaz);oPosObj.Frame=document.getElementById(qzaz+'_div');oPosObj.Frame.isSnapFrame=true;oPosObj.InnerFrame=document.getElementById(oPosObj.ClientPrefix+'InnerSpan');oPosObj.qztc=document.getElementById('Art_IFrame_'+qzaz);if(oPosObj.qztc)oPosObj.qztc.style.height=oPosObj.Frame.offsetHeight;var qzeo=oPosObj.Frame;oPosObj.qzpf=qzeo.offsetWidth;oPosObj.qznq=qzeo.offsetHeight;if(qzeo.style.zIndex>qzgq){qzgq=qzeo.style.zIndex;};qzeo.style.height='';qzzg(qzaz,qztg);};function qzkb(qzgx){while(qzgx!=document.body){if(qzuq(qzgx)){return qzgx;};qzgx=qzgx.parentNode;};return null;};function qzhs(qzq){var qzaz=qzwg(qzq);if(qzaz){return art_GetInstance(qzaz);}else{return null;};};function qzuq(qzbc){return(qzbc&&qzbc.isSnapFrame);};function qzxt(qzq){for(var qzba=qzq.childNodes.length-1;qzba>=0;qzba--){var qzAfi=qzq.childNodes[qzba];if(qzAfi&&qzAfi.id&&qzAfi.id.indexOf('Art_IFrame_')==0){return qzAfi;};};return null;};function qzwg(qzq){if(qzq&&qzq.id){return qzq.id.substring(0,qzq.id.length-4);}else{return null;};};function art_GetInstance(qzaz){var qzAoc=eval('('+qzaz+'? '+qzaz+' : null)');return qzAoc;};function qzAab(qzbc,qzAgc){for(var qzba=10;qzba>0;qzba--){var qzAik=document.createElement('div'),qzwp=qzAik.style;qzwp.position='absolute';qzwp.left=qzba;qzwp.top=qzba;qzwp.width=Math.max(0,parseInt(qzbc.style.width)-qzba*2);qzwp.height=Math.max(0,parseInt(qzbc.style.height)-qzba*2);qzwp.zIndex=qzbc.style.zIndex-qzba;qzwp.backgroundColor=qzAgc;var opacity=1-qzba/(qzba+1);if(cart_browser_n6||cart_browser_mozilla){qzwp.opacity=opacity;qzwp.setProperty("-moz-opacity",opacity,"");}else{qzwp.filter='alpha(opacity='+(100*opacity)+')';};qzbc.appendChild(qzAik);};};function qzAch(qzbc,qzAhg,qzAgc){var qzAik=document.createElement('div'),qzwp=qzAik.style;qzwp.position='absolute';qzwp.left=0;qzwp.top=0;qzwp.width='100%';qzwp.height='100%';qzwp.zIndex=qzbc.style.zIndex+1;qzwp.backgroundColor=qzAgc;qzwp.borderStyle='solid';qzwp.borderWidth=2;qzwp.borderColor=qzAhg;if(cart_browser_n6||cart_browser_mozilla){qzwp.opacity=0.3;qzwp.setProperty("-moz-opacity",0.3,"");}else{qzwp.filter='alpha(opacity=30)';};qzbc.appendChild(qzAik);};function qzmi(qzg){if(qzg.RenderOverWindowedObjects){return;};if(qzby==null){qzby=document.getElementsByTagName('select');qzpl=new Array(qzby.length);qzqh=new Array(qzby.length);qznr=new Array(qzby.length);qzov=new Array(qzby.length);};for(var qzba=0;qzba<qzby.length;qzba++){qzAbs(qzby[qzba],qzba);};};function qzAbs(qzbc,qzgc){qzqh[qzgc]=qzhf(qzbc);qzpl[qzgc]=qzmh(qzbc);qzov[qzgc]=qzbc.offsetWidth-1;qznr[qzgc]=qzbc.offsetHeight-1;};function qzAii(qzAob,qzAoa,qzAok,qzAoj,qzAnz,qzAny,qzAoi,qzAoh){return(!(qzAob+qzAok<=qzAnz||qzAoa+qzAoj<=qzAny||qzAob>=qzAnz+qzAoi||qzAoa>=qzAny+qzAoh));};function qzym(){if(!qzby){return;};for(var qzba=0;qzba<qzby.length;qzba++){qzby[qzba].style.visibility='inherit';};};function qzgb(qzg,qzAnp,qzAno,qzAnn,qzAnm){if(qzg.RenderOverWindowedObjects){return;};if(qzby==null){qzmi(qzg);};for(var qzba=0;qzba<qzby.length;qzba++){if(qzuq(qzkb(qzby[qzba]))){continue;};if(qzAii(qzpl[qzba],qzqh[qzba],qzov[qzba],qznr[qzba],qzAnp,qzAno,qzAnn,qzAnm)){qzby[qzba].style.visibility='hidden';}else{qzby[qzba].style.visibility='inherit';};};};function qzjg(qzg){var qzq=qzg.Frame;if(!qzq)return;var qzAgs,qzAij;if(qzg.qzlb&&qzg.FloatAlignment=='Default'){qzAgs=qzg.qzqg;qzAij=qzg.qzqf;}else{qzAgs=parseInt(qzq.style.left);qzAij=parseInt(qzq.style.top);};var qzAly=qzq.style.left+','+qzq.style.top+','+qzq.offsetWidth+','+qzq.offsetHeight+','+(qzg.qzup?qzg.qzup:'')+','+qzg.qzcf+','+(qzg.qzpk==0?1:0);qzg.Situation.value=qzAly;if(qzg.CookieName){qzAhf(qzg.CookieName,qzAly,7);};};function qzAhf(cookieName,qzAja,qzAhs){var qzAmy=new Date(),qzAkt=new Date();if(qzAhs==null||qzAhs==0){qzAhs=1;};qzAkt.setTime(qzAmy.getTime()+3600000*24*qzAhs);document.cookie=cookieName+"="+qzAja+";expires="+qzAkt.toGMTString();};function qzAdu(qzbc){if(qzbc){if(cart_browser_ie){qzbc.removeNode(true);}else{qzbc.parentNode.removeChild(qzbc);};};};function qzmh(qzgx){return qzAfx(qzgx);};function qzhf(qzgx){return qzAfw(qzgx);};function qztz(qzim,qzbc){var x=qzim.offsetX,qzgx=qzim.srcElement;while(qzgx!=qzbc&&qzgx!=document.body){x+=qzgx.offsetLeft;qzgx=qzgx.offsetParent;};return x;};function qzty(qzim,qzbc){var y=qzim.offsetY,qzgx=qzim.srcElement;while(qzgx!=qzbc&&qzgx!=document.body){y+=qzgx.offsetTop;qzgx=qzgx.offsetParent;};return y;};var ComponentArt_Snap_Core_Loaded=true,ComponentArt_Snap_Core_Loaded=true;
