<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AutoRefreshQueueAllSend.aspx.cs"
    Inherits="Page_AutoRefreshQueueAllSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-CN">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="Content-Language" content="zh-CN" />
    <meta content="all" name="robots" />
    <meta name="Copyright" content="վ������,��Ȩ����,δ��ͬ�ⲻ��ת��" />
    <meta name="description" content="վ������" />
    <title>ͨѶ��-�ͻ��ַ����</title>
    <link href="../App_Themes/Default/Style/Css/Css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../DatePicker/WdatePicker.js"></script>

</head>
<body class="Center">
    <form id="form1" runat="server">
        <table cellspacing="0" cellpadding="0" border="0" class="Tab_List01" id="Tab_List01">
            <tr>
                <th width="0" class="TabHeader_Left" style="width: 2px">&nbsp;
                </th>
                <th class="TabHeader_Center">
                    <table cellspacing="0" cellpadding="0" border="0" class="TableAdd" width="99.9%">
                        <tr>
                            <td class="Add">��ǰλ�ã�&nbsp;<a href="#">ͨѶ��</a>&nbsp;>>&nbsp;����������
                            </td>
                            <td width="162" align="right">
                                <div class="Stock">
                                </div>
                            </td>
                            <td width="40"></td>
                            <td width="80" class="RightToolBtn"></td>
                        </tr>
                    </table>
                </th>
                <th width="10" class="TabHeader_Right">&nbsp;
                </th>
            </tr>
            <tr>
                <td width="0" class="TabCenter_Left">&nbsp;
                </td>
                <td class="TabCenter_Center" id="TabCenter2" valign="top" style="padding: 10px 16px 10px 0">
                    <table cellspacing="0" cellpadding="0" border="0" class="Table04" valign="top" width="100%">
                        <tr>
                            <td align="left" class="SearchBg01">
                                <table cellspacing="0" cellpadding="0" border="0" class="TableFormA">
                                    <tr>
                                        <td>&nbsp;&nbsp; �ͻ��˺ţ�<asp:TextBox runat="server" ID="tbxAccount" CssClass="TextBox04"
                                            Style="width: 80px;" />
                                            &nbsp;&nbsp;
                                                    <asp:Button runat="server" ID="btnSearch" CssClass="Button03" Style="width: 44px;"
                                                        Text="����" OnClick="btnSearch_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" border="0" class="InfolistA2" width="100%">
                                    <tr>
                                        <th width="15%">�ͻ��˺�
                                        </th>
                                        <th width="20%">�ͻ�����
                                        </th>
                                        <th width="15%">�ͻ��ȼ�
                                        </th>
                                        <th width="15%">�ѷַ���
                                        </th>
                                        <th width="15%">δ�ַ���
                                        </th>
                                        <th width="20%">���ַ�ʱ��
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align="left" width="15%">���������������� 
                                        </td>
                                        <td width="20%" align="center">����ɳ�����
                                        </td>
                                        <td width="15%" align="center">��ɳ��
                                        </td>
                                        <td width="15%" align="center">����ɳ��ɳ��
                                        </td>
                                        <td width="15%" align="center">��ɳ��
                                        </td>
                                        <td width="20%" align="center">��ɳ��ɳ��
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="15%">���������������� 
                                        </td>
                                        <td width="20%" align="center">����ɳ�����
                                        </td>
                                        <td width="15%" align="center">��ɳ��
                                        </td>
                                        <td width="15%" align="center">����ɳ��ɳ��
                                        </td>
                                        <td width="15%" align="center">��ɳ��
                                        </td>
                                        <td width="20%" align="center">��ɳ��ɳ��
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="15%">���������������� 
                                        </td>
                                        <td width="20%" align="center">����ɳ�����
                                        </td>
                                        <td width="15%" align="center">��ɳ��
                                        </td>
                                        <td width="15%" align="center">����ɳ��ɳ��
                                        </td>
                                        <td width="15%" align="center">��ɳ��
                                        </td>
                                        <td width="20%" align="center">��ɳ��ɳ��
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="15%">���������������� 
                                        </td>
                                        <td width="20%" align="center">����ɳ�����
                                        </td>
                                        <td width="15%" align="center">��ɳ��
                                        </td>
                                        <td width="15%" align="center">����ɳ��ɳ��
                                        </td>
                                        <td width="15%" align="center">��ɳ��
                                        </td>
                                        <td width="20%" align="center">��ɳ��ɳ��
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="10" class="TabCenter_Right">&nbsp;
                </td>
            </tr>
            <tr>
                <td width="16" class="TabFoot_Left"></td>
                <td class="TabFoot_Center"></td>
                <td width="10" class="TabFoot_Right"></td>
            </tr>
        </table>
        <script>

            function PageResize1() {
                var height = document.documentElement.clientHeight;
                var MainFrame = document.getElementById("TabCenter2");
                if (height > 10)
                    MainFrame.style.height = height - 65 + "px";
                try { document.frames["TabCenter2"].PageResize(); } catch (e) { }
            }

            function PageResize2() {
                var width = document.documentElement.clientWidth;
                var MainFrame = document.getElementById("Tab_List01");
                if (width > 10)
                    MainFrame.style.width = width - 18 + "px";
                try { document.frames["Tab_List01"].PageResize(); } catch (e) { }
            }

            function PageResize3() {
                var height = document.documentElement.clientHeight;
                var MainFrame = document.getElementById("MainTabDiv");
                if (height > 10)
                    MainFrame.style.height = height - 90 + "px";
                try { document.frames["MainTabDiv"].PageResize(); } catch (e) { }
            }

            function PageResize4() {
                var height = document.documentElement.clientHeight;
                var MainFrame = document.getElementById("TabCenter4");
                if (height > 10)
                    MainFrame.style.height = height - 173 + "px";
                try { document.frames["TabCenter4"].PageResize(); } catch (e) { }
            }


            function PageResize() {
                PageResize1();
                PageResize2();
                PageResize4();
            }

            PageResize();
            window.onresize = PageResize;

        </script>

    </form>
</body>
</html>
