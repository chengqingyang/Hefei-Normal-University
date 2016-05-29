function MainTip() {
    $.ajax({
        type: "POST",
        url: "Handler/MainHandler.ashx?action=getgonggao",
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            document.getElementById("sp_gonggao").innerHTML = "新公告(" + msg + ")";
        },
        error: function() {
            document.getElementById("sp_gonggao").innerHTML = "公告获取失败";
        }
    });

    var jgcode = $("#HidJgcode").val();
    $.ajax({
        type: "POST",
        url: "Handler/MainHandler.ashx?action=gethtdq&jgcode=" + jgcode,
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            document.getElementById("sp_htdq").innerHTML = "到期合同提醒(" + msg + ")";
        },
        error: function() {
            document.getElementById("sp_htdq").innerHTML = "到期合同提醒获取失败";
        }
    });
}
