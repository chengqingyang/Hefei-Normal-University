<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left3.aspx.cs" Inherits="left3" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�ޱ���ҳ</title>
    <link rel="stylesheet" href="skin/css/base.css" type="text/css" />
<link rel="stylesheet" href="skin/css/menu.css" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<script language='javascript'>var curopenItem = '1';</script>
<script language="javascript" type="text/javascript" src="skin/js/frame/menu.js"></script>
<base target="main" />
</head>
<body target="main">
    <form id="form1" runat="server">
    <div>
    <table width='99%' height="100%" border='0' cellspacing='0' cellpadding='0'>
  <tr>
    <td style='padding-left:3px;padding-top:8px' valign="top">
	<!-- Item 1 Strat -->
      <dl class='bitem'>
        <dt onClick='showHide("items1_1")'><b>��������ά��</b></dt>
        <dd style='display:block' class='sitem' id='items1_1'>
          <ul class='sitemu'>
            <li>
              <div class='items'>
                <div class='fllct'><a href="Student/StudentEdit.aspx?getid=<%=Session["lsh"].ToString() %>"
                     target='main'>������Ϣ����</a></div>
              </div>
            </li>
            
          </ul>
        </dd>
      </dl>
      <dl class='bitem'>
        <dt onClick='showHide("items2_1")'><b>�༶����</b></dt>
        <dd style='display:block' class='sitem' id='items2_1'>
          <ul class='sitemu'>
             <li><a href='Student/XskqList.aspx' target='main'>�ճ����ڲ�ѯ</a></li>
            <li><a href='Student/GrQjlList.aspx' target='main'>ѧ����ٲ�ѯ</a></li>
            <li><a href="Student/ZhiRi.aspx" target='main'>ֵ�հ��Ų�ѯ</a></li>
          </ul>
        </dd>
      </dl>
	  <dl class='bitem'>
        <dt onClick='showHide("items3_1")'><b>��ѧ����</b></dt>
        <dd style='display:block' class='sitem' id='items3_1'>
          <ul class='sitemu'>
            <li><a href="" target='main'>�ҵĿγ̱�</a></li>
            <li><a href="Student/TiaoKeList.aspx" target='main'>��ʦ���β�ѯ</a></li>
            <li><a href="Student/KaoShiShow.aspx" target='main'>���԰��Ų�ѯ</a></li>
            <li><a href='Student/XsCjlList.aspx' target='main'>ѧ���ɼ���ѯ</a></li>
            <li><a href="Student/HomeWorkList.aspx" target='main'>��ͥ��ҵ��ѯ</a></li>
            <li><a href="Student/PingJiaList.aspx" target='main'>ʦ������</a></li>
          </ul>
        </dd>
      </dl>
      <dl class='bitem'>
        <dt onClick='showHide("items4_1")'><b>��������</b></dt>
        <dd style='display:block' class='sitem' id='items4_1'>
          <ul class='sitemu'>
            <li><a href="Student/DaYiList.aspx" target='main'>���ߴ���</a></li>
            <li><a href="Teacher/ZiLiaoList.aspx" target='main'>��Դ����</a></li>
            <li><a href='' target='main'>�ҵ�����</a></li>
            <li><a href='' target='main'>У������</a></li>
            <li><a href="Teacher/BeiWangList.aspx" target='main'>����¼</a></li>
             <li><a href="logout.aspx" target="_top" >�˳���¼</a></li>
          </ul>
        </dd>
      </dl>
      <!-- Item 1 End -->
	  </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
