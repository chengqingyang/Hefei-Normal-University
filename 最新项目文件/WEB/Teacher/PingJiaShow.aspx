<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PingJiaShow.aspx.cs" Inherits="BaseSystem.Teacher_PingJiaShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/zhiri.css" rel="stylesheet" type="text/css" />    
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />
    
    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../JS/zii.cookie.js" type="text/javascript"></script>
    <script src="../JS/zii.common.js" type="text/javascript"></script>
    
    <script src="../JS/Teachers/PingJia.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div id="div_zhiri">
    <div id="div_top">
        <div class="top_left"><img src="../images/zhiri.png" alt="" width="30" height="30" /></div>
        <div class="top_right">师生互评</div>
        <div class="top_right2"><a href="PingJiaList.aspx">评价学生</a></div>
        <div class="top_right2"><a href="PingJiaShow.aspx">学生评价</a></div>
    </div>
    <div class="clear"></div>
    <div id="div_main">
         <div id="div_pingjia">
            <div class="pingjia_head">
                <div>对教师评价分：<span runat="Server" id="sp_avg"></span></div>
                <div>参评学生人数：<span runat="Server" id="sp_totalStu"></span></div>
            </div>
            <div class="pingjia_head">
                <div>学生评语汇总：</div>
                <div class="pingjia_sum">
                    <asp:ListBox ID="lbox_scanPY" runat="server" Enabled="False">
                    </asp:ListBox>
                </div>
            </div>
            <div class="clear"></div>        
        </div>
    </div>
</div>
</form>
</body>
</html>
