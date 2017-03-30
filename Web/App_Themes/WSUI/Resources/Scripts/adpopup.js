var gt = unescape('%3e');
var popup = null;
var over = "Launch Pop-up Navigator";
function showadpopup(img, link, winWidth, winHeight){
	var iLeft = (window.screen.width - winWidth)/2;
	var iTop = (window.screen.height - winHeight)/2;
	popup = window.open(link, '', 'width='+ winWidth +'px,height='+ winHeight +'px,top='+ iTop +'px,left='+ iLeft +'px,resizable=0,scrollbars=no');
/*if (popup != null) {
	if (popup.opener == null) {
		popup.opener = self;
	}
	popup.location.href = link;
}*/
}