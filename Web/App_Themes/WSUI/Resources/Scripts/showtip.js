document.onmouseover=show;
document.onmouseout=hide;
document.write("<div id='dypopLayer' style='text-align: left; position:absolute; top:20px; overflow: hidden;z-index:1000; line-height: 150%;' class='cPopText'></div>");

document.write("<style type='text/css'id='defaultPopStyle'>");
document.write(".cPopText { background-color: #FFFFE1; border: 1px solid #333333; padding: 4px; display: none; width: 250px; font-size: 12px; }");
document.write("</style>");

var oInterval;

function show()
{
	var o=event.srcElement;
	
	if (o == null) return;

	if(o.helpkey!=null && o.helpkey!="")
	{
		o.dypop=getHTMLCode(o.helpkey);
		o.helpkey="";
	}

	if (o.dypop == null || o.dypop == "")
		return;

	dypopLayer.style.top = event.clientY + document.body.scrollTop;
	dypopLayer.style.left = event.x + document.body.scrollLeft;
	dypopLayer.innerHTML = o.dypop;

	showmovie();
}

function hide()
{
	dypopLayer.style.display = 'none';
	if (oInterval != null)
	{
		window.clearInterval(oInterval);
		oInterval = null;
	}
}

function getHTMLCode(v)
{
	var xmlDoc = new ActiveXObject("Msxml2.DOMDocument");
	xmlDoc.async = false;
	xmlDoc.resolveExternals = false;
	xmlDoc.load("/resources/scripts/help.xml");
	var nodes = xmlDoc.selectNodes("help/item");
	var nodeCount = nodes.length;

	for (var i=0; i < nodeCount; i++) 
	{
		var node = nodes.item(i);
		var key = node.attributes.getNamedItem("key").value;
		var value = node.text;

		if (key == v)
			return value;
	}

	return "没有帮助";
}


function showmovie()
{
	//dypopLayer.style.width = 0;
	//dypopLayer.style.height = 4;
	dypopLayer.style.left = parseInt(dypopLayer.style.left)-250;
	dypopLayer.style.filter='progid:DXImageTransform.Microsoft.Alpha(Opacity=0)';
	dypopLayer.style.display = 'inline';

	alpha=0;
	oInterval = window.setInterval(effect3, 10);
}


function effect1()
{
	if (parseInt(dypopLayer.style.width) < 250)
	{
		dypopLayer.style.left = parseInt(dypopLayer.style.left) - 20;
		dypopLayer.style.width = parseInt(dypopLayer.style.width) + 20;
		dypopLayer.style.height = parseInt(dypopLayer.style.height) + 5;
	}
	else if (parseInt(dypopLayer.style.height) < 150)
	{
		dypopLayer.style.height = parseInt(dypopLayer.style.height) + 5;
	}
	else
	{
		window.clearInterval(oInterval);
		oInterval = null;
	}
}

function effect2()
{
	if (parseInt(dypopLayer.style.width) < 250)
	{
		dypopLayer.style.left = parseInt(dypopLayer.style.left) - 10;
		dypopLayer.style.width = parseInt(dypopLayer.style.width) + 10;
	}
	else if (parseInt(dypopLayer.style.height) < 150)
	{
		dypopLayer.style.height = parseInt(dypopLayer.style.height) + 5;
	}
	else
	{
		window.clearInterval(oInterval);
		oInterval = null;
	}
}


var alpha;
function effect3()
{
	alpha += 4;
	dypopLayer.style.filter='progid:DXImageTransform.Microsoft.Alpha(Opacity='+alpha+')';
	if (alpha >= 100)
	{
		window.clearInterval(oInterval);
		oInterval = null;
	}
}