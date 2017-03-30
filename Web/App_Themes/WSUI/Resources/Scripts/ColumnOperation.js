
function AddColumn()
{
	var lstSelect = document.all.item('lstSelect');
	var lstUnselect = document.all.item('lstUnselect');
	if(lstUnselect.selectedIndex != -1)
	{
		var selectIndex = lstUnselect.selectedIndex;
		var oOption = lstUnselect.options[selectIndex];
		lstUnselect.remove(selectIndex);
		lstSelect.add(oOption);
		lstUnselect.selectedIndex=0;
		//SetTxt();
	}
}
		
function DeleteColumn()
{
	var lstSelect = document.all.item('lstSelect');
	var lstUnselect = document.all.item('lstUnselect');
	if(lstSelect.selectedIndex != -1)
	{
		var selectIndex = lstSelect.selectedIndex;
		var oOption = lstSelect.options[selectIndex];
		lstSelect.remove(selectIndex);
		lstUnselect.add(oOption);
		lstSelect.selectedIndex=0;
		//SetTxt();
	}
}
function UpColumn()
{
	
	if(document.all.item('lstSelect').selectedIndex != -1 && document.all.item('lstSelect').selectedIndex != 0)
	{
	var oOption = document.createElement("OPTION");
	oOption.text=document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex].text;
	oOption.value=document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex].value;
	
	document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex].value=document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex-1].value;
	document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex].text=document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex-1].text;
	document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex-1].text = oOption.text;
	document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex-1].value = oOption.value;
	
	document.all.item('lstSelect').selectedIndex = document.all.item('lstSelect').selectedIndex-1;
	SetTxt();
	}
}
function DownColumn()
{
	if(document.all.item('lstSelect').selectedIndex != -1 && document.all.item('lstSelect').selectedIndex != document.all.item('lstSelect').length-1)
	{
	var oOption = document.createElement("OPTION");
	oOption.text=document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex].text;
	oOption.value=document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex].value;
	
	document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex].value=document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex+1].value;
	document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex].text=document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex+1].text;
	document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex+1].text = oOption.text;
	document.all.item('lstSelect').options[document.all.item('lstSelect').selectedIndex+1].value = oOption.value;
	
	document.all.item('lstSelect').selectedIndex = document.all.item('lstSelect').selectedIndex+1;
	SetTxt();
	}
}

function Reset()
{
	while(document.all.item("lstUnselect").length>0)
	{
	document.all.item("lstUnselect").remove(0);
	}

	var oOption = new Array(8);
	for(var i=0;i < 8;i++)
	{
	oOption[i] = document.createElement("OPTION");
	}
	oOption[0].text = "资源名";
oOption[0].value = "AttachmentFileName";
oOption[1].text = "下载次数";
oOption[1].value ="DownLoadCount";
oOption[2].text = "媒体类型";
oOption[2].value ="MediumType";
oOption[3].text = "更新日期";
oOption[3].value ="ModifyDate";
oOption[4].text = "作者";
oOption[4].value ="Author";
oOption[5].text = "关键字";
oOption[5].value ="Keywords";
oOption[6].text = "对象";
oOption[6].value ="Learner";
oOption[7].text = "年级";
oOption[7].value ="Grade";
for(var i=0;i < 8;i++)
{
document.all.item("lstUnselect").add(oOption[i]);
}			
	//////////////
	while(document.all.item("lstSelect").length>0)
	{
	document.all.item("lstSelect").remove(0);
	}
	
	var mOption = new Array(6);
	for(var i=0;i < 6;i++)
	{
	mOption[i] = document.createElement("OPTION");
	}
	mOption[0].text = "标题";
mOption[0].value = "Title";
mOption[1].text = "学科";
mOption[1].value ="Subject";
mOption[2].text = "类型";
mOption[2].value ="Type";

mOption[3].text = "教育类型";
mOption[3].value ="EducationType";
mOption[4].text = "创建人";
mOption[4].value ="CreatorName";
mOption[5].text = "创建日期";
mOption[5].value ="CreateDate";
for(var i=0;i < 6;i++)
{
document.all.item("lstSelect").add(mOption[i]);
}			
	
}

function SetTxt()
{
	document.all.item("txtColumnID").value="";
	document.all.item("txtColumnName").value="";
	document.all.item("txtUncolumnID").value="";
	document.all.item("txtUncolumnName").value="";
	for(var i =0; i < document.all.item("lstSelect").length; i++)
	{
	document.all.item("txtColumnID").value += document.all.item("lstSelect").options[i].value +","; 
	document.all.item("txtColumnName").value += document.all.item("lstSelect").options[i].text +","; 
	
	}
	for(var i =0; i < document.all.item("lstUnselect").length; i++)
	{
	document.all.item("txtUncolumnID").value += document.all.item("lstUnselect").options[i].value +","; 
	document.all.item("txtUncolumnName").value += document.all.item("lstUnselect").options[i].text +","; 
	}
}