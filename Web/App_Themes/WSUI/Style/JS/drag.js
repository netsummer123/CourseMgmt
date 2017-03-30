function StartDrag(obj)
{
	obj.onmousemove = DoDrag;
	obj.setCapture(true);
	
	divResize.style.top = MainTable.offsetTop;
	divResize.style.left = window.event.clientX;
	divResize.style.height = MainTable.height;
}
function DoDrag()
{
	divResize.style.display = "";
    var x = window.event.clientX;
    if(document.body.clientWidth < 100)
    	divResize.style.left = x;
    else if(x > 100 && x < (document.body.clientWidth - 100))
    	divResize.style.left = x;
    else if(x <= 100)
    	divResize.style.left = 100;
    else
    	divResize.style.left = document.body.clientWidth - 100;
}
function EndDrag(obj)
{
    obj.releaseCapture();
    obj.onmousemove = "";
    var x = window.event.clientX;
    if(document.body.clientWidth < 100)
    	TdLeftIFrame.width = 100;
    else if(x > 100 && x < (document.body.clientWidth - 100))
    	TdLeftIFrame.width = x;
    else if(x <= 100)
    	TdLeftIFrame.width = 100;
    else
    	TdLeftIFrame.width = document.body.clientWidth - 100;
    divResize.style.display = "none";  
    SetPercentage();
}

var percentage = 0.5;
function SetPercentage()
{
	percentage = TdLeftIFrame.offsetWidth / document.body.clientWidth;
}
SetPercentage();

function FrameResize()
{
    var height = document.body.clientHeight;
    var width = document.body.clientWidth;
    document.getElementById("MainTable").height = height;
    document.getElementById("List").height = height;    
    document.getElementById("Main").height = height;   
    
    TdLeftIFrame.width = width * percentage;
}
window.onresize = FrameResize;
FrameResize();