var qzhq=false,qzu,qzw,qzfo,qzge;function art_InitResizing(qzaz,qzkg,qzij,qzxi){var qzg=art_GetInstance(qzaz);if(cart_browser_ie){qzg.Frame.onmousemove=qzkr;};qzg.Frame.onmousedown=qzkt;qzg.Frame.onmouseout=qzlj;qzg.qzkg=qzkg;qzg.qzij=qzij;qzg.qzte=qzxi;};function qzmr(resizeThreshold,offsetX,offsetY,qzhd,qzga){var qzjt='';if(offsetY<=resizeThreshold){qzjt='n';}else if(offsetY>=qzga-resizeThreshold){qzjt='s';};if(offsetX<=resizeThreshold){qzjt+='w';}else if(offsetX>=qzhd-resizeThreshold){qzjt+='e';};return qzjt;};function qzeg(){if(qzw!=''){document.body.style.cursor=qzw+'-resize';}else{document.body.style.cursor='default';};};function qzkt(qzim){if(cart_browser_ie){event.cancelBubble=true;}else{qzim.preventDefault();qzim.stopPropagation();};if(qzu==null||qzw==''){return true;};qzhq=true;qzu.Frame.onmousemove=null;qzfo=document.body.onmousemove;qzge=document.body.onmouseup;document.body.onmousemove=qzks;document.body.onmouseup=qzlu;qzmi(qzu);return false;};function qzks(){if(cart_browser_ie){var qzAei=qzmh(event.srcElement),qzAeh=qzhf(event.srcElement),qzp=event.offsetX+qzAei,qzf=event.offsetY+qzAeh;}else{var qzp=qzim.pageX,qzf=qzim.pageY;};var qzq=qzu.Frame,qzAaz=qzmh(qzq),qzAay=qzhf(qzq),qzhd=qzq.offsetWidth,qzga=qzq.offsetHeight,qzij=qzu.qzij,qzkg=qzu.qzkg,qzze=qzAaz,qzzd=qzAay,qzdh=qzga,qzgj=qzhd;if(qzw.indexOf('n')>=0){qzzd=qzf;qzdh=qzAay-qzf+qzga;}else if(qzw.indexOf('s')>=0){qzdh=qzf-qzAay;};if(qzw.indexOf('e')>=0){qzgj=qzp-qzAaz;}else if(qzw.indexOf('w')>=0){qzze=qzp;qzgj=qzAaz-qzp+qzhd;};qzdh=Math.max(qzij,qzdh);qzgj=Math.max(qzkg,qzgj);var qzAax=qzq.offsetHeight-qzdh,qzAcc=qzu.InnerFrame.offsetHeight;qzu.InnerFrame.style.height=qzAcc-qzAax;qzq.style.left=qzze;qzq.style.top=qzzd;qzq.style.height=qzdh;qzq.style.width=qzgj;qzgb(qzu,qzze,qzzd,qzgj,qzdh);return false;};function qzlu(qzim){if(cart_browser_ie){document.body.onmousemove=qzfo;document.body.onmouseup=qzge;qzu.Frame.onmousemove=qzkr;}else{document.onmousemove=qzfo;document.onmouseup=qzge;qzu.Frame.onmouseover=qzwn;};qzu.Frame.style.height=qzu.Frame.offsetHeight;qzu.InnerFrame.style.height=qzu.InnerFrame.offsetHeight;qzu.qzpf=qzu.Frame.offsetWidth;qzu.qznq=qzu.Frame.offsetHeight;qzjg(qzu);qzhq=false;qzw='';qzeg();if(qzu.qzlb){art_RepositionFloater(qzu);};return false;};function qzwn(qzim){var qzq=qzkb(qzim.target),qzaz=qzwg(qzq),qzg=qzhs(qzq);if(!qzaz||qzhq||qztd||qzg.qzms||qzg.qzpk==0){return true;};qzw='';qzu=qzg;var offsetX=qzim.layerX,offsetY=qzim.layerY,qzhd=qzq.offsetWidth,qzga=qzq.offsetHeight,resizeThreshold=qzg.ResizeThreshold;qzw=qzmr(resizeThreshold,offsetX,offsetY,qzhd,qzga);var qzku=qzg.qzte;if(qzku=='FreeStyle'||(qzku=='Corners'&&qzw.length==2)||(qzku=='Vertical'&&(qzw=='n'||qzw=='s'))||(qzku=='Horizontal'&&(qzw=='w'||qzw=='e'))){}else{qzw='';};qzeg();};function qzkr(){var qzq=qzkb(event.srcElement),qzg=null;if(qzq){qzg=qzhs(qzq);};if(!qzg||qzhq||qztd||qzg.qzms||qzg.qzpk==0){return true;};qzw='';qzu=qzg;var offsetX=qztz(event,qzq),offsetY=qzty(event,qzq),qzhd=qzq.offsetWidth,qzga=qzq.offsetHeight,resizeThreshold=qzg.ResizeThreshold;qzw=qzmr(resizeThreshold,offsetX,offsetY,qzhd,qzga);var qzku=qzg.qzte;if(qzku=='FreeStyle'||(qzku=='Corners'&&qzw.length==2)||(qzku=='Vertical'&&(qzw=='n'||qzw=='s'))||(qzku=='Horizontal'&&(qzw=='w'||qzw=='e'))){}else{qzw='';};qzeg();};function qzlj(qzim){if(!qzhq&&qzu!=null){qzw='';qzeg();};};var ComponentArt_Snap_Resize_Loaded=true;
