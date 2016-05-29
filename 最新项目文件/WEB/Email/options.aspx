<%@ Page Language="C#" AutoEventWireup="true" CodeFile="options.aspx.cs" Inherits="options" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选项</title>
    <link href="css/SiteStyle.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" border="0" cellpadding="2" cellspacing="0" class="bgcolor5"
                width="97%">
                <tr style="background-color: #40984C">
                    <td class="f14w">
                        <b>[ 邮箱选项 ]</b></td>
                    <td align="right">
                        <input name="goback" onclick='javascript:history.back()' type="button" value="返 回" /></td>
                </tr>
            </table>
            <table align="center" border="0" cellpadding="5" cellspacing="1" class="bgcolor5"
                width="97%">
                <tr>
                    <td colspan="2">
                        个人信息</td>
                </tr>
                <tr>
                    <td align="center">
                        <a href="editArc.aspx" target="mainFrame">个人资料</a></td>
                    <td class="bgcolor1">
                        查看并修改您的个人信息。</td>
                </tr>
                <tr>
                    <td align="center">
                        <a href="changePW.aspx" target="mainFrame">修改密码</a></td>
                    <td class="bgcolor1">
                        要设置新密码，请务必提供您目前的密码。</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
