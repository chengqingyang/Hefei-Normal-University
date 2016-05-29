<%@ Page Language="C#" AutoEventWireup="true" CodeFile="caogaoxiang .aspx.cs" Inherits="caogaoxiang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>邮件列表</title>
    <link href="css/SiteStyle.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%">
            <div>
                <asp:Button ID="btn_del" runat="server" Text="删  除" OnClick="btn_del_Click" />
                <asp:Button ID="btn_del1" runat="server" Text="彻底删除" OnClick="btn_del1_Click" />
                <asp:Button ID="btn_ref" runat="server"  Text="刷  新" />

                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lab_user" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="lb_logout" runat="server" OnClick="lb_logout_Click">退&nbsp;&nbsp;出</asp:LinkButton></div>
            <br style="line-height: 10px" />
            <div style="background-color: #40984C; width: 100%; line-height: 30px">
                选择：<a href="#" onclick="selClick()">全选</a>&nbsp;&nbsp;&nbsp;<a href="#" onclick="selClick()">反选</a>
            </div>
        </div>
        <br style="line-height: 10px" />
        <table id="tab_mails" runat="server" style="width: 100%">
            <tr class="tabTitle">
                <td style="width: 5%; height: 16px; text-align: center">
                    选择</td>
                <td style="width: 15%; height: 16px; text-align: center;">
                    发件人</td>
                <td style="width: 15%; height: 16px; text-align: center;">
                    收件人</td>
                <td style="height: 16px;width: 15%; text-align: center">
                    主题</td>
                <td style="height: 16px;width: 15%; text-align: center">
                    附件名称</td>
                <td style="height: 16px;width: 10%; text-align: center">
                    附件大小</td>
                <td style="width: 15%; height: 16px; text-align: center;">
                    日期</td>
                <td style="width: 20%; height: 16px; text-align: center;">
                    重新发送</td>
                <td style="display: none">
                    id</td>
            </tr>
        </table>
    </form>

    <script type="text/javascript">
        function selClick() 
        {
            var obj;
            var _tab=document.getElementById('tab_mails')
            for(i=1; i<_tab.rows.length; i++)
            {
              obj=document.getElementById("chk_"+i);
              obj.checked = !obj.checked;
            }
        }
    </script>

</body>
</html>
