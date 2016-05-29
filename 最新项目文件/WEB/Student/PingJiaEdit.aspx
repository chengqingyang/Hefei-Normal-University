<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PingJiaEdit.aspx.cs" Inherits="BaseSystem.Student_PingJiaEdit" %>

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
    
    <script src="../JS/Students/PingJiaEdit.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:HiddenField ID="hidlsh" runat="Server" />
<input type="hidden" id="hidtgh" value="<%#Eval("TGH") %>" />
<input type="hidden" id="hidsno" value="<%=Session["username"].ToString() %>">
<div id="div_zhiri">
    <div id="div_top">
        <div class="top_left"><img src="../images/zhiri.png" alt="" width="30" height="30" /></div>
        <div class="top_right">师生互评</div>
        <div class="top_right2"><a href="PingJiaList.aspx">查看评价</a></div>
        <div class="top_right2"><a href="PingJiaEdit.aspx">提交评价</a></div>
    </div>
    <div class="clear"></div>
    <div id="div_main">
        <asp:HiddenField ID="HiddenField1" Value="评价管理" runat="server" />
        <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td class="title">
                </td>
                <td class="operating" style="width:90%;">
                    <div runat="Server" id="save">
                        <a href="#" onclick="PingJiaSave()" class="btn btn-toolbar"><span class="icon icon-save">
                        </span>保存</a> 
                    </div>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <div id="div_pingjia">
            <div class="pingjia">
                <div class="pingjia_left">任课教师姓名
                    <div class="pingjia_left_head"></div>
                    <asp:Repeater ID="rpt_tname" runat="server">
                    <ItemTemplate>                
                        <div class="pingjia_left_tname" runat="Server">
                            <a href="PingJiaEdit.aspx?getid=<%#Eval("LSH") %>"
                               title="评价老师" >
                                <%#Eval("TNAME")%>&nbsp;
                            </a>
                        </div>
                        <div class="pingjia_left_tname" id="div_state" runat="Server">
                            <%#Eval("STATE").ToString().Trim() == "1"?"<i>已评价</i>":"<b>未评价</b>"%> 
                        </div>
                        <div class="clear"></div>
                    </ItemTemplate>
                    </asp:Repeater>
                
                </div>
                <div class="pingjia_right">
                    <table style="width: 100%;">
                        <tr>
                            <td></td>
                            <th></th>
                            <td>
                                <div id="div_info" runat="Server"></div>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <th><b>*</b>学生评分：</th>
                            <td>
                                <input id="txtpf" type="text" style="width:400px;" runat="Server" />(满分100分)
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <th><b>*</b>学生评语：</th>
                            <td colspan="2">
                                <input id="txtpy" type="text" style=" width:500px; height:220px;" runat="Server" />
                            </td>
                            <td></td>
                        </tr>
                    </table>
                
                    
                    <%--<div class="pingjia_right_head">
                        
                    </div>
                    <div class="pingjia_right_main">
                    
                    </div>--%>
                </div>
            </div>
            <div class="clear"></div>        
        </div>
    </div>
</div>



</form>
</body>
</html>