
function SchoolLogin(obj1,obj2) {
    $.ajax({
        type: "POST",
        url: "Handler/School/SchoolHandler.ashx?action=schoollogin&schoolcode=" + escape(obj1),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = obj2;
            }
            else {
                alert("学校选择失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}
