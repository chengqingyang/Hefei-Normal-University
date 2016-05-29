function ReSetCar(goodcode, control) {
    var num = $("#" + control).val();
    $.ajax({
        type: "POST",
        url: "Handler/MyCarHandler.ashx?action=resetcar&goodcode=" + escape(goodcode) + "&num=" + escape(num),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //jAlert("正在处理...."); 
        },
        success: function(msg) {
            if (msg != "1") 
            {
                alert("数量更改失败!");
            }
            location.href = "MyCar.aspx";
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}
function DelCarList(goodcode) {
    var obj = confirm("是否确定从购物车删除?");
    if (!obj) return;
    
    $.ajax({
        type: "POST",
        url: "Handler/MyCarHandler.ashx?action=delcar&goodcode=" + escape(goodcode),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //jAlert("正在处理...."); 
        },
        success: function(msg) {
            if (msg != "1") 
            {
                alert("商品删除失败!");
            }
            location.href = "MyCar.aspx";
        },
        error: function() {
            alert("业务处理异常!");
        }
    });}
function GoBuyCenter()
{    //判断是否登录
    var membercode = $("#HidMemberCode").val();
    if (membercode == "" || membercode == undefined)
    {
        //alert("您尚未登录，请先登陆!\n\n如没有注册本站会员，请先注册!");
        //tanchu(); return;
        J('#ljfk').dialog({ id: 'Employee_Move', title: '会员登录', page: 'PopMemberLogin.aspx?keyvalue=1&jgcdoeBefore=2&jgcodeDis=1', width: 450, height: 270, cover: true });
        return;
    }        //成功登录，进入定单中心
    location.href = "MyOrder.aspx";
}
