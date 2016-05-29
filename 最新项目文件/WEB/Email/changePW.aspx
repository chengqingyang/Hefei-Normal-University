<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changePW.aspx.cs" Inherits="changePW" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <link href="css/SiteStyle.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" border="0" cellpadding="4" cellspacing="0" width="528">
                <tr style="background-color: #40984C">
                    <td align="left">
                        <b>[ 密 码 ]</b></td>
                    <td align="right">
                        <input onclick='javascript:history.back()' type="button" value="返 回" /></td>
                </tr>
            </table>
            <table align="center" border="0" cellpadding="2" cellspacing="1" class="bgcolor5"
                width="528">
                <tr>
                    <td align="right" nowrap="nowrap">
                        </td>
                    <td class="bgcolor1">
                        </td>
                </tr>
                <tr>
                    <td align="right" nowrap="nowrap">
                        新密码：</td>
                    <td class="bgcolor1">
                        <span class="chinese">
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                           
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TextBox2"
                                ControlToValidate="TextBox3" ErrorMessage="两次密码不一致"></asp:CompareValidator></span></td>
                </tr>
                <tr>
                    <td align="right" nowrap="nowrap">
                        再输入一次新密码：</td>
                    <td class="bgcolor1">
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致" ControlToCompare="TextBox3" ControlToValidate="TextBox2"></asp:CompareValidator></td>
                </tr>
                <tr align="middle">
                    <td class="bgcolor3" colspan="2">
                        &nbsp;<asp:Button ID="Button1" runat="server" Text="确  定" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" Text="取  消" OnClick="Button2_Click" CausesValidation="False" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
