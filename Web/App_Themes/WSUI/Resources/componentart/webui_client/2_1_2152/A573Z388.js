var qqPa=null,qqPc=new Array();function qqPf(oControl,qzyb,qznv){this.Control=oControl;this.qztk=qzyb;this.qznv=qznv;};function qqPd(oControl,qzyb){for(var qzba=0;qzba<qqPc.length;qzba++){if(qqPc[qzba].Control==oControl&&qqPc[qzba].qztk==qzyb){eval(qqPc[qzba].qznv);return true;};};return false;};if(document.layers){document.captureEvents(Event.KEYPRESS);};function ComponentArt_HandleKeyPress(qzim){ComponentArt_ProcessKeyPress(qzim);};function ComponentArt_ProcessKeyPress(qzim){if(!qqPa||!qqPa.KeyboardEnabled){return true;};if(document.activeElement&&(document.activeElement.nodeName=='INPUT'||document.activeElement.nodeName=='SELECT'||document.activeElement.nodeName=='TEXTAREA')){return true;};var qztk;if(document.all){qzim=window.event;qztk=qzim.keyCode;}else{qztk=qzim.which;};var qzAbi=String.fromCharCode(qztk);if(qztk>111&&qztk<123)qzAbi="F"+(qztk-111);else if(qztk==13)qzAbi="Enter";var qzlk="";if(qzim.shiftKey)qzlk+="Shift+";if(qzim.ctrlKey)qzlk+="Ctrl+";if(qzim.altKey)qzlk+="Alt+";qzlk+=qzAbi;if(!qqPd(qqPa,qzlk)){return true;};if(document.all){qzim.cancelBubble=true;qzim.returnValue=false;}else{qzim.preventDefault();qzim.stopPropagation();};return false;};function ComponentArt_RegisterKeyHandler(oControl,qzyb,qznv){qqPc[qqPc.length]=new qqPf(oControl,qzyb,qznv);};var ComponentArt_Keyboard_Loaded=true;