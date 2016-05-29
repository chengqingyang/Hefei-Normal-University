<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZhiRiEdit.aspx.cs" Inherits="BaseSystem.Teacher_ZhiRiEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>

    <script src="../JS/zii.cookie.js" type="text/javascript"></script>

    <script src="../JS/zii.common.js" type="text/javascript"></script>

    <script src="../JS/calendar.js" type="text/javascript"></script>

    <script src="../JS/Teachers/ZhiRiEdit.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidlsh" runat="server" />
    <asp:HiddenField ID="hidschoolno" runat="server" />
    <input type="hidden" id="hidtgh" value="<%=Session["username"].ToString() %>">
    <div class="datadetail">
        <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="title">
                    </td>
                    <td class="operating">
                        <a href="#" onclick="ZhiRiSave()" class="btn btn-toolbar"><span class="icon icon-save">
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
                            <b>*</b>学年：
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlXueNian" runat="server" CssClass="ddt-input ddt-input-l" 
                                Width="208px" AutoPostBack="True" 
                                onselectedindexchanged="ddlXueNian_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <th>
                            值日内容：
                        </th>
                        <td rowspan="9">
                            <textarea id="txtcontent" cols="20" rows="10" runat="server"> </textarea>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <b>*</b>学期：
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlXueQi" runat="server" CssClass="ddt-input ddt-input-l" 
                                Width="208px">
                            </asp:DropDownList>
                        </td>
                        <th rowspan="8"> &nbsp;</th>
                    </tr>
                    <tr>
                        <th>
                            <b>*</b>班级：
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="ddt-input ddt-input-l" 
                                Width="208px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            周次：
                        </th>
                        <td>
                            <input id="txtid" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                                type="text" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            星期一：
                        </th>
                        <td>
                            <input id="txtmon"  maxlength="100"  style="width: 200px" 
                            class="ddt-input ddt-input-l" type="text" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            星期二：
                        </th>
                        <td>
                            <input id="txttue" style="width: 200px" maxlength="100" class="ddt-input ddt-input-l"
                                type="text" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            星期三：
                        </th>
                        <td>
                            <input type="text" id="txtwed" class="ddt-input ddt-input-l" style="width: 200px"
                                runat="server"  maxlength="100"  />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            星期四：
                        </th>
                        <td>
                            <input id="txtthu" style="width: 200px" class="ddt-input ddt-input-l" maxlength="100"
                                type="text" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            星期五：
                        </th>
                        <td>
                            <input id="txtfri" style="width: 200px" class="ddt-input ddt-input-l" maxlength="100"
                                type="text" runat="server" />
                        </td>
                    </tr>
                </table>
        </div>
    </div>
    </form>
</body>
</html>