function GetClassByJG(obj) {
    var jgdm = $("#" + obj).val();
    var classcode = $("#HidClassCode").val();
    if (jgdm == "" || jgdm == undefined) {
        document.getElementById("sp_itemlist").innerHTML = "<select id=\"ddlClass\" style=\"width:90px\" class=\"ddt-input ddt-input-l\" onchange=\"SetClassValue()\"><option value='' selected=\"selected\">请选择班级</option></select>";
        return;
    }
    $.ajax({
    type: "POST",
    url: "../Handler/CommClassHandler.ashx?action=getstore&keyvalue=" + escape(jgdm) + "&storecode=" + escape(classcode),
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

function SetClassValue() {
    var storecode = $("#ddlClass").val();
    $("#HidClassCode").val(storecode);
}

function ClearClass() {
    $("#HidClassCode").val("");
}