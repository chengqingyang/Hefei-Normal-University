<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="left" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
            <li><a href='Users/UserList.aspx' target='main'>������Ϣά��</a> </li>
            <li><a href='Student/StudentList.aspx' target='main'>ѧ������</a> </li>
            <li><a href='Teacher/TeacherList.aspx' target='main'>��ʦ����</a> </li>
            <li><a href="Users/SchoolList.aspx" target='main'>ѧУ��Ϣά��</a> </li>
            <li><a href="Users/ClassList.aspx" target='main'>�༶��Ϣά��</a> </li>
            <li><a href="Users/CourseList.aspx" target='main'>�γ���Ϣά��</a> </li>
            <li><a href="Users/CourseFPList.aspx" target='main'>�γ̷���ά��</a> </li>
            <li><a href="Users/XueNianList.aspx" target='main'>ѧ����Ϣά��</a> </li>
            <li><a href="Users/XueQiList.aspx" target='main'>ѧ����Ϣά��</a> </li>
            <li><a href="Users/ZdxlList.aspx" target='main'>�ֵ���Ϣά��</a> </li>
          </ul>
        </dd>
      </dl>
      <!-- Item 1 End -->
      <!-- Item 2 Strat -->
      <dl class='bitem'>
        <dt onClick='showHide("items2_1")'><b>�༶����</b></dt>
        <dd style='display:block' class='sitem' id='items2_1'>
          <ul class='sitemu'>
            <li><a href='Teacher/XskqList.aspx' target='main'>�ճ����ڹ���</a></li>
            <li><a href='Teacher/XsQjlList.aspx' target='main'>ѧ����ٹ���</a></li>
            <li><a href="Teacher/ZhiRiList.aspx" target='main'>ֵ�հ��Ź���</a></li>
          </ul>
        </dd>
      </dl>
	  
	  <dl class='bitem'>
        <dt onClick='showHide("items3_1")'><b>��ѧ����</b></dt>
        <dd style='display:block' class='sitem' id='items3_1'>
          <ul class='sitemu'>
            <li><a href="" target='main'>�γ̰��Ź���</a></li>
            <li><a href="Teacher/TiaoKeList.aspx" target='main'>��ʦ���ι���</a></li>
            <li><a href="Teacher/KaoShiList.aspx" target='main'>���԰��Ź���</a></li>
            <li><a href='Teacher/XsCjlList.aspx' target='main'>ѧ���ɼ�����</a></li>
            <li><a href="Teacher/HomeWorkList.aspx" target='main'>��ͥ��ҵ����</a></li>
            <li><a href="Teacher/PingJiaList.aspx" target='main'>ʦ������</a></li>
          </ul>
        </dd>
      </dl>
	  
	  <dl class='bitem'>
        <dt onClick='showHide("items4_1")'><b>��������</b></dt>
        <dd style='display:block' class='sitem' id='items4_1'>
          <ul class='sitemu'>
            <li><a href="Teacher/DaYiList.aspx" target='main'>���ߴ���</a></li>
            <li><a href="Teacher/ZiLiaoList.aspx" target='main'>��Դ����</a></li>
            <li><a href='' target='main'>�ҵ�����</a></li>
            <li><a href='' target='main'>У������</a></li>
            <li><a href="Teacher/BeiWangList.aspx" target='main'>����¼</a></li>
            <li><a href="logout.aspx" target="_top" >�˳���¼</a></li>
          </ul>
        </dd>
      </dl>

      <!-- Item 2 End -->
	  </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
