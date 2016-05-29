<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left4.aspx.cs" Inherits="left4" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
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
        <dt onClick='showHide("items1_1")'><b>个人资料管理</b></dt>
        <dd style='display:block' class='sitem' id='items1_1'>
          <ul class='sitemu'>
            <li>
              <div class='items'>
                <div class='fllct'><a href='jiachangxinxi_updt2.aspx' target='main'>个人资料管理</a></div>
              </div>
            </li>
            
            <%--<li><a href='yonghuzhuce_list.aspx' target='main'>注册用户管理</a> </li>--%>
            
          </ul>
        </dd>
      </dl>
      <!-- Item 1 End -->
      <!-- Item 2 Strat -->
      <dl class='bitem'>
        <dt onClick='showHide("items2_1")'><b>子女成绩查看</b></dt>
        <dd style='display:block' class='sitem' id='items2_1'>
          <ul class='sitemu'>
           
            <li><a href='xueshengchengji_list3.aspx' target='main'>子女成绩查看</a></li>
          </ul>
        </dd>
      </dl>
	  </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
