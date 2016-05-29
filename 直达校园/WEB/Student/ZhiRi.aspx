<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZhiRi.aspx.cs" Inherits="BaseSystem.Student_ZhiRi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/zhiri.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
<div id="div_zhiri">
    <div id="div_top">
        <div class="top_left"><img src="../images/zhiri.png" alt="" width="30" height="30" /></div>
        <div class="top_right">值日安排</div>
    </div>
    <div class="clear"></div>
    <div id="div_main">
        <table style="width: 100%;">
            <tr><td colspan="7" style="height:20px;"></td></tr>
            <tr>
                <td style=" width:60px;"></td>
                <td colspan="6"><div class="tdzhiri">值日安排</div></td>
            </tr>
            <%--<tr><td colspan="7" style="height:20px;"></td></tr>--%>
            <tr>
                <td></td>
                <td colspan="6">
                    <div id="week">
                        <div>
                            <div class="week_head">天次</div>
                            <div class="week_head">星期一</div>
                            <div class="week_head">星期二</div>
                            <div class="week_head">星期三</div>
                            <div class="week_head">星期四</div>
                            <div class="week_head">星期五</div>
                        </div>
                        <div class="clear"></div>
                        <div>
                            <div class="week_middle"> <div class="week_middle_title">值日人员</div> </div>
                            <div runat="Server" id="div_mon" class="week_middle">张三<br/>李四</div>
                            <%--<div runat="server" id="div_mon" class="week_middle">张三<br/>李四</div>--%>
                            <div runat="server" id="div_tue" class="week_middle">张三</div>
                            <div runat="server" id="div_wed" class="week_middle">张三</div>
                            <div runat="server" id="div_thu" class="week_middle">张三</div>
                            <div runat="server" id="div_fri" class="week_middle">张三</div>
                        </div>
                        <div class="clear"> </div>
                        <div>
                            <div class="week_bottom"> 
                                <div class="week_bottom_left">值日内容： </div>
                                <div runat="server" id="div_content" class="week_bottom_right"></div>
                            </div>
                        </div>
                        <div class="clear"> </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
</form>
</body>
</html>
