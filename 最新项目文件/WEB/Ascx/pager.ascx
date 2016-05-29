<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pager.ascx.cs" Inherits="Page_pager" EnableViewState="false" %>
<script src="../JS/Check.js" type="text/javascript"></script>
<script type="text/javascript">
    function CheckNum() 
    {
        try {
            var num = document.getElementById("Pager_txtPage").value;
        } catch (e) { }
        if (num == "" || num == undefined) {
            alert("请输入页码!");
            return false;
        }
        return true;
    }
</script>
<table class="pager" width="100%">
    <tr>
        <td style="height:30px; padding-left:20px;">
            <asp:Button ID="lb_first" CssClass="pager-btn" OnClick="lb_first_Click" runat="server" Text="首页" />
            <asp:Button ID="lb_pre" CssClass="pager-btn" OnClick="lb_pre_Click" runat="server" Text="上一页" />
            <asp:Button ID="lb_next" CssClass="pager-btn" OnClick="lb_next_Click" runat="server" Text="下一页" />
            <asp:Button ID="lb_last" CssClass="pager-btn" OnClick="lb_last_Click" runat="server" Text="末页" />
            <input id="txtPage" class="pager-goto" onkeypress="KeyPressNum(this)" type="text" runat="server" />
            <asp:Button ID="btnNext" CssClass="pager-btn" runat="server" Text="跳转" OnClientClick="return CheckNum()" onclick="btnNext_Click" />
        </td>
        <td style="text-align:right; padding-right:20px;">
            共 <span class="SystemPageNum"><asp:Literal ID="lbl_records" runat="server"></asp:Literal></span>
            条数据，当前 <asp:Literal ID="lbl_pages" runat="server"></asp:Literal> 页
        </td>
    </tr>
</table>