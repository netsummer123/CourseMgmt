使用 hint 的步骤


Step 1:
	<LINK href="/resources/scripts/hint/hint.css" type="text/css" rel="stylesheet">
	<script language="javascript" src="/resources/scripts/hint/hint.js"></script>
Step 2:
	将hint.js和hint.css复制到相应的路径下（"/resources/scripts/hint/"）

Step 3:
	将需要使用dropdownlist的控件的onfocus attribute设为setDictionary('字典名称')
	(注意此处字典名称是Name，而不是DisplayName)
	 例如：
		<asp:textbox id="tbTextBox1" onfocus="setDictionary('ZXZKM')" runat="server"></asp:textbox>

Step 4:
	可使用Util里的TranslateNameToCode函数将控件的内容转成字典值

当前版本: 	0.02
支持浏览器:	IE 6.0 / Mozilla Firefox 1.5.0.7

使用过程中有建议、疑问或bug请马上通知我(陆佳杰/jeffery Lu/ws-i-jjlu) 谢谢~