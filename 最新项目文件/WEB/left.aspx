<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="left" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
        <dt onClick='showHide("items1_1")'><b>基础数据维护</b></dt>
        <dd style='display:block' class='sitem' id='items1_1'>
          <ul class='sitemu'>
            <li><a href='Users/UserList.aspx' target='main'>个人信息维护</a> </li>
            <li><a href='Student/StudentList.aspx' target='main'>学生管理</a> </li>
            <li><a href='Teacher/TeacherList.aspx' target='main'>教师管理</a> </li>
            <li><a href="Users/SchoolList.aspx" target='main'>学校信息维护</a> </li>
            <li><a href="Users/ClassList.aspx" target='main'>班级信息维护</a> </li>
            <li><a href="Users/CourseList.aspx" target='main'>课程信息维护</a> </li>
            <li><a href="Users/CourseFPList.aspx" target='main'>课程分配维护</a> </li>
            <li><a href="Users/XueNianList.aspx" target='main'>学年信息维护</a> </li>
            <li><a href="Users/XueQiList.aspx" target='main'>学期信息维护</a> </li>
            <li><a href="Users/ZdxlList.aspx" target='main'>字典信息维护</a> </li>
          </ul>
        </dd>
      </dl>
      <!-- Item 1 End -->
      <!-- Item 2 Strat -->
      <dl class='bitem'>
        <dt onClick='showHide("items2_1")'><b>班级管理</b></dt>
        <dd style='display:block' class='sitem' id='items2_1'>
          <ul class='sitemu'>
            <li><a href='Teacher/XskqList.aspx' target='main'>日常考勤管理</a></li>
            <li><a href='Teacher/XsQjlList.aspx' target='main'>学生请假管理</a></li>
            <li><a href="Teacher/ZhiRiList.aspx" target='main'>值日安排管理</a></li>
          </ul>
        </dd>
      </dl>
	  
	  <dl class='bitem'>
        <dt onClick='showHide("items3_1")'><b>教学管理</b></dt>
        <dd style='display:block' class='sitem' id='items3_1'>
          <ul class='sitemu'>
            <li><a href="" target='main'>课程安排管理</a></li>
            <li><a href="Teacher/TiaoKeList.aspx" target='main'>教师调课管理</a></li>
            <li><a href="Teacher/KaoShiList.aspx" target='main'>考试安排管理</a></li>
            <li><a href='Teacher/XsCjlList.aspx' target='main'>学生成绩管理</a></li>
            <li><a href="Teacher/HomeWorkList.aspx" target='main'>家庭作业管理</a></li>
            <li><a href="Teacher/PingJiaList.aspx" target='main'>师生互评</a></li>
          </ul>
        </dd>
      </dl>
	  
	  <dl class='bitem'>
        <dt onClick='showHide("items4_1")'><b>其他功能</b></dt>
        <dd style='display:block' class='sitem' id='items4_1'>
          <ul class='sitemu'>
            <li><a href="Teacher/DaYiList.aspx" target='main'>在线答疑</a></li>
            <li><a href="Teacher/ZiLiaoList.aspx" target='main'>资源共享</a></li>
            <li><a href='' target='main'>我的邮箱</a></li>
            <li><a href='' target='main'>校长信箱</a></li>
            <li><a href="Teacher/BeiWangList.aspx" target='main'>备忘录</a></li>
            <li><a href="logout.aspx" target="_top" >退出登录</a></li>
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
