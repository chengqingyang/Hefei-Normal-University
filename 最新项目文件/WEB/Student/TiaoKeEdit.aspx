<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TiaoKeEdit.aspx.cs" Inherits="BaseSystem.Student_TiaoKeEdit" %>

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
        <div class="top_right">课程安排</div>
        <div class="top_right2"><a href="TiaoKeList.aspx">课程调整</a></div>
        <div class="top_right2"><a href="#" title="暂未开通">课程表</a></div>
    </div>
    <div class="clear"></div>
    <div id="div_main">
        <table style="width: 100%;">
            <tr>
                <td colspan="7" class="operating"></td>
            </tr>
            <tr><td colspan="7" style="height:20px;"></td></tr>
            <tr>
                <td style=" width:60px;"></td>
                <td colspan="6"><div class="tdzhiri">课程调整</div></td>
            </tr>
            <tr>
                <td></td>
                <td colspan="6">
                    <div id="tiaoke">
                        <div class="tiaoke_date"> 
                            <div class="tiaoke_date_left">日期： </div>
                            <div runat="server" id="div_date" class="tiaoke_date_right"></div>
                        </div>
                        <div class="tiaoke_text"> 
                            <div class="tiaoke_text_left">正文： </div>
                            <div runat="server" id="div_content" class="tiaoke_text_right"></div>
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
