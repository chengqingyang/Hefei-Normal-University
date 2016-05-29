<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DaYiEdit.aspx.cs" Inherits="BaseSystem.Teacher_DaYiEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/zhiri.css" rel="stylesheet" type="text/css" />  
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>

    <script src="../JS/zii.cookie.js" type="text/javascript"></script>

    <script src="../JS/zii.common.js" type="text/javascript"></script>

    <script src="../JS/calendar.js" type="text/javascript"></script>

    <script src="../JS/Students/DaYiEdit.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div id="div_zhiri">
    <div id="div_top">
        <div class="top_left"><img src="../images/zhiri.png" alt="" width="30" height="30" /></div>
        <div class="top_right">在线答疑</div>
    </div>
    <div class="clear"></div>
    <div id="div_main">
    <asp:HiddenField ID="hidlsh" runat="server" />
    <input type="hidden" id="hiduname" value="<%=Session["username"].ToString() %>" />
    <input type="hidden" id="hidstate" value="1" />
    <input type="hidden" runat="Server" id="ddlCourse" />
    <input type="hidden" runat="Server" id="txttitle" />
    <input type="hidden" runat="Server" id="txtcontent" />
    
    <div class="datadetail">
        <div class="datagrid-header2">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="title">
                    </td>
                    <td class="operating">
                        <a href="#" onclick="DaYiSave()" class="btn btn-toolbar"><span class="icon icon-save">
                        </span>保存</a> 
                        <a href="#" class="btn btn-toolbar" onclick="GoList(<%=Request.QueryString["page"] %>)">
                            <span class="icon icon-print"></span>返回</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line">
            </div>
        </div>
        <div class="datadetail-view">
            <table class="datadetail-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th>
                        课程：
                    </th>
                    <td>
                        <div id="divcourse" runat="Server" class="txttitle" ></div>
                    </td>
                    <td> </td>
                </tr>
                <tr>
                    <th>
                        标题：
                    </th>
                    <td>
                        <div id="divtitle" runat="Server" class="txttitle"  ></div>
                    </td>
                    <td> </td>
                </tr>
                <tr>
                    <th>
                        内容：
                    </th>
                    <td>
                        <div id="divcontent" runat="Server" class="txtcontent" ></div>
                    </td>
                    <td> </td>
                </tr>
                <tr>
                    <th>
                        回复：
                    </th>
                    <td>
                        <input id="txtanswer" type="text" runat="Server" style="width:520px;height:220px;" />
                    </td>
                    <td> </td>
                </tr>
            </table>
        </div>
    </div>
    </div>
</div>
</form>
</body>
</html>