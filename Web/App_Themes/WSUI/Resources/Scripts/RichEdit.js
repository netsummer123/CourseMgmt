var KEY_BACKSPACE = 8;
var KEY_TAB = 9;
var KEY_ENTER = 13;
var KEY_SHIFT = 16;
var KEY_CTRL = 17;
var KEY_ALT = 18;
var KEY_PAUSEBREAK = 19;
var KEY_CAPLOCK = 20;
var KEY_ESC = 27;
var KEY_PAGEUP = 33;
var KEY_PAGEDOWN = 34;
var KEY_END = 35;
var KEY_HOME = 36;
var KEY_LEFT = 37;
var KEY_UP = 38;
var KEY_RIGHT = 39;
var KEY_DOWN = 40;
var KEY_INSERT = 45;
var KEY_DELETE = 46;
var KEY_1 = 49;
var KEY_2 = 50;
var KEY_3 = 51;
var KEY_4 = 52;
var KEY_5 = 53;
var KEY_6 = 54;
var KEY_7 = 55;
var KEY_8 = 56;
var KEY_9 = 57;
var KEY_0 = 48;
var KEY_A = 65;
var KEY_B = 66;
var KEY_C = 67;
var KEY_D = 68;
var KEY_E = 69;
var KEY_F = 70;
var KEY_G = 71;
var KEY_H = 72;
var KEY_I = 73;
var KEY_J = 74;
var KEY_K = 75;
var KEY_L = 76;
var KEY_M = 77;
var KEY_N = 78;
var KEY_O = 79;
var KEY_P = 80;
var KEY_Q = 81;
var KEY_R = 82;
var KEY_S = 83;
var KEY_T = 84;
var KEY_U = 85;
var KEY_V = 86;
var KEY_W = 87;
var KEY_X = 88;
var KEY_Y = 89;
var KEY_Z = 90;
var KEY_L_WINDOW = 91;
var KEY_R_WINDOW = 92;
var KEY_MENU = 93;
var KEY_NUM_0 = 96;
var KEY_NUM_1 = 97;
var KEY_NUM_2 = 98;
var KEY_NUM_3 = 99;
var KEY_NUM_4 = 100;
var KEY_NUM_5 = 101;
var KEY_NUM_6 = 102;
var KEY_NUM_7 = 103;
var KEY_NUM_8 = 104;
var KEY_NUM_9 = 105;
var KEY_NUM_MUL = 106;
var KEY_NUM_ADD = 107;
var KEY_NUM_SUB = 109;
var KEY_NUM_RADIX = 110;
var KEY_NUM_SPLASH = 111;
var KEY_F1 = 112;
var KEY_F2 = 113;
var KEY_F3 = 114;
var KEY_F4 = 115;
var KEY_F5 = 116;
var KEY_F6 = 117;
var KEY_F7 = 118;
var KEY_F8 = 119;
var KEY_F9 = 120;
var KEY_F10 = 121;
var KEY_F11 = 122;
var KEY_F12 = 123;
var KEY_NUMLOCK = 144;
var KEY_SCROLLLOCK = 145;
var KEY_COLON = 186;
var KEY_EQUAL = 187;
var KEY_COMMA = 188;
var KEY_SUB = 189;
var KEY_RADIX = 190;
var KEY_SPALSH = 191;
var KEY_POINT = 192;
var KEY_L_BRACKET = 219;
var KEY_ANTI_SPLASH = 220;
var KEY_R_BRACKET = 221;
var KEY_QUOT = 222;


var itbedit;

function keydown()
{
	switch (itbedit.event.keyCode)
	{
		case KEY_ENTER:
			keyEnter();
			break;
		case KEY_TAB:
			keyTab();
			break;
	}
}

function cancelEvent()
{
	itbedit.event.cancelBubble = true;
	itbedit.event.returnValue = false;
}

function getSelectRange()
{
	var sel = itbedit.document.selection;
	if (sel.type == 'Control') 
		return null;

	return sel.createRange();
}

function replaceSelectionHTML(val)
{
	cancelEvent();
	var r = getSelectRange();
	if (r == null)
		return;
	r.pasteHTML(val);
	r.select();
	r.collapse(false);
}

function keyEnter()
{
	replaceSelectionHTML('<br>');
}

function keyTab()
{
	replaceSelectionHTML('&nbsp;&nbsp;&nbsp;&nbsp;');
}

function setColor(color)
{
	var r = getSelectRange();
	r.execCommand('ForeColor', false, color);
	r.collapse(false);
}

function formatText()
{
	var r = getSelectRange();
	var txt = r.text;
	txt = txt.replace("\n", "<br>");
	txt = txt.replace(" ", "&nbsp;");

	var fontSize=fSize.value;
	var fontName=fName.value;
	var fontColor=fColor.value;

	var code = "<span style='";
	if (fontSize.length>0)
		code += "font-size:"+fontSize+";";
	if (fontColor.length>0)
		code += "color:"+fontColor+";";
	if (fontName.length>0)
		code += "font-family:"+fontName+";";
	code += "'>" + txt + "</span>";

	r.pasteHTML(code);
	r.select();
}

var content = 
'<html>'
+'	<style>'
+'		body {font: 15pt ËÎÌו; margin:3px;}'
+'	</style>'
+'	<body></body>'
+'</html>';

function InitEdit(edit)
{
	itbedit = edit;
	var doc = itbedit.document;
	doc.designMode='On';
	doc.contentEditable='True';
	doc.open();
	doc.writeln(content);
	doc.close();
	doc.body.onkeydown=keydown;
	
}
