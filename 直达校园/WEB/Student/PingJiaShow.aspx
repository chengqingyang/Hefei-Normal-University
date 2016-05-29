<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PingJiaShow.aspx.cs" Inherits="BaseSystem.Student_PingJiaShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/zhiri.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
<div id="div_zhiri">
    <div id="div_top">
        <div class="top_left"><img src="../images/zhiri.png" alt="" width="30" height="30" /></div>
        <div class="top_right">师生互评</div>
        <div class="top_right2"><a href="PingJiaList.aspx">返回</a></div>
    </div>
    <div class="clear"></div>
    <div id="div_main">
        <table style="width: 100%;">
            <tr>
                <td colspan="7" class="operating"> </td>
            </tr>
            <tr><td colspan="7" style="height:20px;"></td></tr>
            <%--<tr>
                <td style=" width:60px;"></td>
                <td colspan="6"><div class="tdzhiri">家庭作业</div></td>
            </tr>--%>
            <tr>
                <td style="width:100px;"></td>
                <td colspan="6">
                    <div id="tiaoke" style="width:80%" >                        
                        <div class="tiaoke_date"> 
                            <div class="tiaoke_date_left" style="width:0px;"> </div>
                            <div runat="server" id="div_info" class="tiaoke_date_right" style="width: 100%;"></div>
                        </div>
                        <div class="tiaoke_text"> 
                            <div class="tiaoke_text_left" style="width:0px;"></div>
                            <div runat="server" id="div_content" class="tiaoke_text_right" style="width: 100%;"></div>
                        </div>
                        <div class="tiaoke_date"> 
                            <div class="tiaoke_date_left" style="width:0px;"> </div>
                            <div runat="server" id="div_tcsign" class="sign"></div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
</form>
</body>
</html>
