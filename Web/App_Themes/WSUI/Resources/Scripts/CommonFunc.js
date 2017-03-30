// JScript source code

function OpenWindowWithSize(url, iWidth, iHeight)
{
	var iLeft = (window.screen.width - iWidth)/2;
	var iTop = (window.screen.height - iHeight)/2;
	window.open(url,"","resizable=no,scrollbars=no,top="+ iTop +",left="+ iLeft +",width="+ iWidth +",height="+ iHeight);
}

function OpenDialog(url, iWidth, iHeight)
{
	return window.showModalDialog(url, window, "dialogWidth="+ iWidth +"px;dialogHeight="+ iHeight +"px;scroll=yes");
}

function dgActionConfirm(sAction, sThing, IsConfirm)
{
	var nSelected = 0;
	for (var i=0; i<document.form1.elements.length; i++)
	{
		var e = document.form1.elements[i];
		if (e.type == "checkbox")
		{
			if (e.checked && e.id.indexOf("CBI") > -1)
			{
				nSelected = 1;
				break;
			}
		}
	}
	
	if (nSelected == 0)
	{
		alert("请选择要"+ sAction +"的"+ sThing +".");
		return false;
	}
	else
	{
		if (IsConfirm == "1")
		{
			return confirm("确认要"+ sAction +"选中的"+ sThing +".");
		}
		else
			return true;
	}
}
function ActionConfirm(id, sAction, sThing, IsConfirm)
{
	var chlist = document.getElementById(id);
	var chs = chlist.getElementsByTagName("Input");
	var selCount = 0;
	for (var i=0; i<chs.length; i++)
	{
		if (chs[i].checked)
			selCount = selCount + 1;
	}
	if (selCount == 0)
	{
		alert("请选择要"+ sAction +"的"+ sThing +".");
		return false;
	}
	else
	{
		if (IsConfirm == "1")
		{
			return confirm("确认要"+ sAction +"选中的"+ sThing +".");
		}
		else
			return true;
	}
}

function CompareDate(par1, par2)
{
	var sDate1 = par1.split('-');
	var date1 = new Date(sDate1[0], sDate1[1]-1, sDate1[2]);
	var sDate2 = par2.split('-');
	var date2 = new Date(sDate2[0], sDate2[1]-1, sDate2[2]);
	
	var diff = date2 - date1;
	if (diff < 0)
		return false
	else
		return true;
	
}
