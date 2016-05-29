function GetJfdh(code,num) {
    var membercode = $("#HidMemberCode").val();
    if (membercode == "" || membercode == undefined) {
        alert("积分兑换商品前请先登录!");
        return;
    }
    window.location.href = "MyJfOrder.aspx?getid=" + code + "&num=" + escape(num);
}