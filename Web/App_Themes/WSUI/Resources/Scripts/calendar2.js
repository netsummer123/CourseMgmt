var WSCL_OldBkColor, WSCL_OldFtColor;
var WSCL_TodayDate = new Date();

function WSCL_ReturnData()
{
//	wsCalendar.eventSrc.value = window.event.srcElement.titles;
//	wsCalendar.eventSrc = null;
//	WSCL_HideCalendar();
}
function WSCL_MouseOver()
{
	var obj = window.event.srcElement;
	WSCL_OldBkColor = obj.style.backgroundColor;
	WSCL_OldFtColor = obj.style.color;
	obj.style.backgroundColor = wsCalendar.darkColor;
	obj.style.color = wsCalendar.lightColor;
	obj.className = 'WSCL_Over';
}
function WSCL_MouseOut()
{
	var obj = window.event.srcElement;
	obj.style.backgroundColor = WSCL_OldBkColor;
	obj.style.color = WSCL_OldFtColor;
	obj.className = 'WSCL_Out';
}
function WSCL_ShowYearSelect()	
{
	wsCalendar.WSCL_MonthSelect.style.display = 'none'; 
	wsCalendar.WSCL_YearSelect.style.display = 'none'; 
}
function WSCL_ShowMonthSelect()	
{ 
	wsCalendar.WSCL_MonthSelect.style.display = 'none';
	wsCalendar.WSCL_YearSelect.style.display = 'none'; 
	wsCalendar.WSCL_MonthSelect.value = wsCalendar.thisMonth;
}
function WSCL_HiddenSelect()
{
	wsCalendar.WSCL_YearSelect.style.display = 'none';
	wsCalendar.WSCL_MonthSelect.style.display = 'none';
}
function WSCL_PrevMonth()
{
	with (wsCalendar)
	{
		thisMonth--;
		if (thisMonth < 1)
		{
			thisMonth = 12;
			WSCL_PrevYear();
			return;
		}
	}
	WSCL_SetCalendar();
}
function WSCL_NextMonth()
{
	with (wsCalendar)
	{
		thisMonth++;
		if (thisMonth > 12)
		{
			thisMonth = 1;
			WSCL_NextYear();
			return;
		}
	}
	WSCL_SetCalendar();
}
function WSCL_PrevYear()
{
	with(wsCalendar)
	{
		thisYear--;
		WSCL_YearSelect.options.remove(99)
		var addYear = parseInt(WSCL_YearSelect.options(0).value)-1;
		WSCL_YearSelect.options.add(new Option(addYear+' 年', addYear), 0);
		WSCL_YearSelect.value = thisYear;
	}
	WSCL_SetCalendar();
}
function WSCL_NextYear()
{
	with(wsCalendar)
	{
		thisYear++;
		WSCL_YearSelect.options.remove(0)
		var addYear = parseInt(WSCL_YearSelect.options(98).value)+1;
		WSCL_YearSelect.options.add(new Option(addYear+' 年', addYear), 99);
		WSCL_YearSelect.value = thisYear;
	}
	WSCL_SetCalendar();
}
function WSCL_Reset()
{
	WSCL_ReturnData();
}
function WSCL_HideCalendar() { //wsCalendar.div_frame.style.display = 'none'; 
}
function WSCL_ShowCalendar() { wsCalendar.div_frame.style.display = 'inline'; }
function returnDate() {}
function WSCL_TodayClick()
{
	with (wsCalendar)
	{
		thisYear   = WSCL_TodayDate.getFullYear();
		thisMonth  = WSCL_TodayDate.getMonth()+ 1;
		thisDay    = WSCL_TodayDate.getDate();
	}
	WSCL_SetCalendar();
	WSCL_ReturnData();
}
function WS_Calendar()
{
	this.thisYear	= WSCL_TodayDate.getFullYear();
	this.thisMonth	= WSCL_TodayDate.getMonth()+ 1;
	this.thisDate	= WSCL_TodayDate.getDate();

	this.eventSrc	= null;

	this.darkColor	= '#A2BBD7';
	this.lightColor	= '#FFFFFF';
	this.wordDark	= '#DCDCDC';
	this.todayColor	= '#5784BE';
	this.dateColor	= '#01166F';

	this.div_frame			= document.getElementById('DIV_Calendar');
	this.WSCL_YearHead		= document.getElementById('WSCL_YearHead');
	this.WSCL_MonthHead		= document.getElementById('WSCL_MonthHead');
	this.WSCL_YearSelect	= document.getElementById('WSCL_YearSelect');
	this.WSCL_MonthSelect	= document.getElementById('WSCL_MonthSelect');
	this.WSCL_Today			= document.getElementById('WSCL_Today');

	this.WSCL_Date = new Array();
	for (var i = 0; i < 42; i++)
		this.WSCL_Date[i] = document.getElementById('WSCL_Date' + i);

	this.WSCL_YearHead.onmouseover = WSCL_MouseOver;
	this.WSCL_YearHead.onmouseout = WSCL_MouseOut;
	this.WSCL_YearHead.onclick = WSCL_ShowYearSelect;

//

	this.WSCL_MonthHead.onmouseover = WSCL_MouseOver;
	this.WSCL_MonthHead.onmouseout = WSCL_MouseOut;
	this.WSCL_MonthHead.onclick = WSCL_ShowMonthSelect;

	for(var i = parseInt(this.thisYear)-50; i < parseInt(this.thisYear)+50; i++)
		this.WSCL_YearSelect.options.add(new Option(i+' 年', i));
	this.WSCL_YearSelect.value = this.thisYear;

	for(var i = 1; i < 13; i++)
		this.WSCL_MonthSelect.options.add(new Option(i+' 月', i));
	this.WSCL_MonthSelect.value = this.thisMonth;
}
function WSCL_SetCalendar() 
{
	with(wsCalendar)
	{
		WSCL_YearSelect.style.display = 'none';
		WSCL_MonthSelect.style.display = 'none';
		WSCL_YearHead.innerText = thisYear + ' 年';
		WSCL_MonthHead.innerText = thisMonth + ' 月';
		WSCL_Today.titles = thisYear + '-' + thisMonth + '-' + thisDate;

		var cDate, objDate = new Date();
		var bThisMonth = false;
		objDate.setDate(1);
		objDate.setMonth(thisMonth-1);
		objDate.setYear(thisYear);
		objDate.setDate(1-objDate.getDay());
		cDate = objDate.getDate();
		for (var i = 0; i < 42; i++)
		{
			if (cDate == 1) bThisMonth = !bThisMonth;
			WSCL_Date[i].innerText = cDate;
			WSCL_Date[i].titles = objDate.getFullYear() + '-' + (objDate.getMonth()+ 1) + '-' + objDate.getDate();
			WSCL_Date[i].onmouseover = WSCL_MouseOver;
			WSCL_Date[i].onmouseout = WSCL_MouseOut;
			WSCL_Date[i].onclick = WSCL_ReturnData;
			if (!bThisMonth)
			{
				WSCL_Date[i].style.backgroundColor = lightColor;
				WSCL_Date[i].style.color = wordDark;
			}
			else if (cDate == thisDate && objDate.getMonth() == new Date().getMonth() && objDate.getFullYear() == new Date().getFullYear())
			{
				WSCL_Date[i].style.backgroundColor = todayColor;
				WSCL_Date[i].style.color = lightColor;
			}
			else
			{
				WSCL_Date[i].style.backgroundColor = lightColor;
				WSCL_Date[i].style.color = dateColor;
			}
			objDate.setDate(cDate+1);
			cDate = objDate.getDate();
		}
	}
}
function WSCL_WriteCalendar()
{
//	document.write("<div id='DIV_Calendar' name='DIV_Calendar' style='display: none;position: absolute;'></div>");
	document.write("<select name='WSCL_YearSelect' id='WSCL_YearSelect' style='position:absolute;z-index:1;display:none;font:10px Verdana;' onchange='WSCL_HiddenSelect(); wsCalendar.thisYear=this.value; WSCL_SetCalendar();'></select>");
	document.write("<select name='WSCL_MonthSelect' id='WSCL_MonthSelect' style='position:absolute;z-index:1;display:none;font:10px Verdana;' onchange='WSCL_HiddenSelect(); wsCalendar.thisMonth=this.value; WSCL_SetCalendar();'></select>");
	var div_Calendar = document.getElementById('DIV_Calendar');
	var CalendarString =
	"<table id='WSCL_TableMain' class='WSCL_BG' border='0' cellspacing='1' cellpadding='0'>"
+	"	<tr>"
+	"		<td width='153' height='19' bgcolor='#FFFFFF'>"
+	"			<table width='153' id='WSCL_TableHead' border='0' cellspacing='1' cellpadding='0'>"
+	"				<tr align='center'>"
+	"					<td width='15' height='19' id='WSCL_BG_PrevMonth' class='WSCL_BG' style='cursor: hand'  onclick='WSCL_PrevMonth()'>&lt;</td>"
+	"					<td width='63' id='WSCL_YearHead' class='WSCL_Out'></td>"
+	"					<td width='56' id='WSCL_MonthHead' class='WSCL_Out'></td>"
+	"					<td width='15' id='WSCL_BG_NextMonth' class='WSCL_BG' style='cursor: hand;' onclick='WSCL_NextMonth()'>&gt;</td>"
+	"				</tr>"
+	"			</table>"
+	"		</td>"
+	"	</tr>"
+	"	<tr>"
+	"		<td height='20'>"
+	"			<table id='WSCL_TableWeek' border='1' width='153' cellpadding='0' cellspacing='0' borderColorLight='#A2BBD7' borderColorDark='#FFFFFF'>"
+	"				<tr align='center' height='20'>"
+	"					<td width='21' id='WSCL_Day0'>日</td>"
+	"					<td width='21' id='WSCL_Day1'>一</td>"
+	"					<td width='21' id='WSCL_Day2'>二</td>"
+	"					<td width='21' id='WSCL_Day3'>三</td>"
+	"					<td width='21' id='WSCL_Day4'>四</td>"
+	"					<td width='21' id='WSCL_Day5'>五</td>"
+	"					<td width='21' id='WSCL_Day6'>六</td>"
+	"				</tr>"
+	"			</table>"
+	"		</td>"
+	"	</tr>"
+	"	<tr>"
+	"		<td valign='top' width='153' bgcolor='#FFFFFF'>"
+	"			<table id='WSCL_TableDay' height='120' width='153' border='0' cellspacing='1' cellpadding='0'>"
+	"				<tr>"
+	"					<td class='WSCL_Out' id='WSCL_Date0' width='21'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date1' width='21'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date2' width='21'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date3' width='21'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date4' width='21'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date5' width='21'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date6' width='21'></td>"
+	"				</tr>"
+	"				<tr>"
+	"					<td class='WSCL_Out' id='WSCL_Date7'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date8'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date9'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date10'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date11'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date12'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date13'></td>"
+	"				</tr>"
+	"				<tr>"
+	"					<td class='WSCL_Out' id='WSCL_Date14'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date15'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date16'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date17'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date18'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date19'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date20'></td>"
+	"				</tr>"
+	"				<tr>"
+	"					<td class='WSCL_Out' id='WSCL_Date21'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date22'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date23'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date24'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date25'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date26'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date27'></td>"
+	"				</tr>"
+	"				<tr>"
+	"					<td class='WSCL_Out' id='WSCL_Date28'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date29'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date30'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date31'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date32'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date33'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date34'></td>"
+	"				</tr>"
+	"				<tr>"
+	"					<td class='WSCL_Out' id='WSCL_Date35'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date36'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date37'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date38'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date39'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date40'></td>"
+	"					<td class='WSCL_Out' id='WSCL_Date41'></td>"
+	"				</tr>"
+	"			</table>"
+	"		</td>"
+	"	</tr>"
+	"	<tr>"
+	"		<td height='20' width='153' bgcolor='#FFFFFF'>"
+	"			<table border='0' id='WSCL_TableBottom' cellpadding='1' cellspacing='0' width='153'>"
+	"				<tr>"
+	"					<td><input class='WSCL_Input' titles='上一年' id='WSCL_BTN_PrevYear' onclick='WSCL_PrevYear()' style='width: 20' type='button' value='&lt;&lt;'></td>"
+	"					<td><input class='WSCL_Input' titles='上个月' id='WSCL_BTN_PrevMonth' onclick='WSCL_PrevMonth()' style='width: 20' type='button' value='&lt;&nbsp;'></td>"
+	"					<td><input class='WSCL_Input' name='WSCL_Today' id='WSCL_Today' type='button' value='今 天' style='width: 63; padding-top: 1px;' onclick='WSCL_TodayClick();'></td>"
+	"					<td><input class='WSCL_Input' titles='下个月' id='WSCL_BTN_NextMonth' onclick='WSCL_NextMonth()' style='width: 20' type='button' value='&nbsp;&gt;'></td>"
+	"					<td><input class='WSCL_Input' titles='下一年' id='WSCL_BTN_NextYear' onclick='WSCL_NextYear()' style='width: 20' type='button' value='&gt;&gt;'></td>"
+	"				</tr>"
+	"			</table>"
+	"		</td>"
+	"	</tr>"
+	"</table>";
	div_Calendar.innerHTML = CalendarString;
}
WSCL_WriteCalendar();
var wsCalendar = new WS_Calendar();
function calendar()
{
/*	var srcObj = document.getElementById("calendar");
	wsCalendar.eventSrc = srcObj;

	var t = srcObj.offsetTop,  h = srcObj.clientHeight, l = srcObj.offsetLeft, p = srcObj.type;
	while (srcObj = srcObj.offsetParent){t += srcObj.offsetTop; l += srcObj.offsetLeft;}
	var cw = wsCalendar.div_frame.clientWidth, ch = wsCalendar.div_frame.clientHeight;
	var dw = document.body.clientWidth, dl = document.body.scrollLeft, dt = document.body.scrollTop;

	var left = parseInt(wsCalendar.div_frame.style.left);
	var top = parseInt(wsCalendar.div_frame.style.top);

	if (document.body.clientHeight + dt - t - h >= ch) wsCalendar.div_frame.style.top = (p=="image")? t + h : t + h + 6;
	else wsCalendar.div_frame.style.top  = (t - dt < ch) ? t + h : t - ch;
	if (dw + dl - l >= cw) wsCalendar.div_frame.style.left = l; 
	else wsCalendar.div_frame.style.left = (dw >= cw) ? dw - cw + dl : dl;
*/

	wsCalendar.WSCL_YearSelect.style.left = parseInt(wsCalendar.div_frame.style.left) + 18;	
	wsCalendar.WSCL_YearSelect.style.top = parseInt(wsCalendar.div_frame.style.top) + 3;
	wsCalendar.WSCL_MonthSelect.style.left = parseInt(wsCalendar.div_frame.style.left) + 82;
	wsCalendar.WSCL_MonthSelect.style.top = parseInt(wsCalendar.div_frame.style.top) + 3;
	WSCL_SetCalendar();
	WSCL_ShowCalendar();
	wsCalendar.div_frame.focus();
}
function document.onclick()
{
	var eObj = window.event.srcElement;
	var objID = "ID:" + eObj.id;
	var idKey = objID.substring(0, 8);

//	if(wsCalendar.eventSrc != eObj && objID.substring(0, 8) != 'ID:WSCL_')
//		WSCL_HideCalendar();
}
//calendar();