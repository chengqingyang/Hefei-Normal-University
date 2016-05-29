<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportStudentEXCEL.aspx.cs" Inherits="ImportUsers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

</head>
<body> 
    <form id="form1" runat="server"> 
    <div> 
        <table style="width: 90%"> 
            <tr> 
                <td style="width: 159px" colspan=2> 
                    <strong><span style="font-size: 10pt">学生个人信息EXCEL文件导入</span></strong></td> 
            </tr> 
            <tr> 
                <td style="width: 600px"> 
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="600px" /></td> 
                <td align=left> 
                    <asp:Button ID="FileUpload_Button" runat="server" Text="上传excel并导入数据库" OnClick="FileUpload_Button_Click" /></td> 
            </tr> 
            <tr> 
                <td colspan=2> 
                    <asp:Label ID="Upload_info" runat="server" ForeColor="Red" Width="767px"></asp:Label></td> 
            </tr> 
        </table>     
    </div> 
    </form> 
</body>
</html>