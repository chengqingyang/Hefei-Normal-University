<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewMail.aspx.cs" Inherits="viewMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看邮件</title>
    <link href="css/SiteStyle.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%">
            <div>
                <asp:Button ID="btn_del" runat="server" Text="删  除" OnClick="btn_del_Click" /><asp:Button ID="btn_del1" runat="server"
                    Text="彻底删除" OnClick="btn_del1_Click" /><a href="sendmail.aspx?to=<%=lab_from.Text%>&sub=<%=lab_sub.Text%>">回&nbsp;&nbsp;复</a></div>
        </div>
        <br style="line-height: 10px" />
        <table style="width: 100%; border: none">
            <tr>
                <td style="border: none; width: 10%; text-align: center;">
                    <b>日 期：</b></td>
                <td style="border: none">
                    <asp:Label ID="lab_date" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="border: none; text-align: center;">
                    <b>发件人：</b></td>
                <td style="border: none">
                    <asp:Label ID="lab_from" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="border: none; text-align: center;">
                    <b>收件人：</b></td>
                <td style="border: none">
                    <asp:Label ID="lab_to" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none;
                    border-bottom-style: none; text-align: center;">
                    <b>主 题：</b></td>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none;
                    border-bottom-style: none">
                    <asp:Label ID="lab_sub" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="border: none; text-align: center;">
                    <b>附件名称：</b></td>
                <td style="border: none">
                    <asp:Label ID="lab_fjname" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="border: none; text-align: center;">
                    <b>附件大小：</b></td>
                <td style="border: none">
                    <asp:Label ID="lab_fjsize" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
        <br style="line-height: 10px" />
        <div id="div_body" runat="server" style="width: 100%">
        </div>
    </form>
</body>
</html>
