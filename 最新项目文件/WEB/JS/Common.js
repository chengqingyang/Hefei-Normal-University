function GetClassByJG(obj) {
    var jgdm = $("#" + obj).val();
    var storecode = $("#HidStoreCode").val();
    if (jgdm == "" || jgdm == undefined) {
        document.getElementById("sp_itemlist").innerHTML = "<select id=\"ddlStore\" style=\"width:100px\" class=\"ddt-input ddt-input-l\" onchange=\"SetStoreValue()\"><option value='' selected=\"selected\">请选择地点</option></select>";
        return;
    }
    $.ajax({
    type: "POST",
    url: "../Handler/CommHandler.ashx?action=getstore&keyvalue=" + escape(jgdm) + "&storecode=" + escape(storecode),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            document.getElementById("sp_itemlist").innerHTML = msg;
        },
        error: function() {
            alert("加载班级失败!");
        }
    });
}

function SetStoreValue() {
    var storecode = $("#ddlStore").val();
    $("#HidStoreCode").val(storecode);
}