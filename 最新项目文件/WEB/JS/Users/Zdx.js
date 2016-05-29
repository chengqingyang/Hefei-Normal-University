function DataCheck() {
    try {
        var dazx = $("#txtDazx").val();
        var wtbh = $("#txtWtbh").val();
        var wtnr = $("#txtWtnr").val();
        var dabh = $("#txtDabh").val();
        var daxx = $("#txtDaxx").val();
        if (dazx == "" || dazx == undefined) {
            alert("业务编号必须填写!");
            $("#txtDazx").focus();
            return false;
        }

        if (wtbh == "" || wtbh == undefined) {
            alert("字典项目编号必须填写!");
            $("#txtWtbh").focus();
            return false;
        }

        if (wtnr == "" || wtnr == undefined) {
            alert("字典项目名称必须填写!");
            $("#txtWtnr").focus();
            return false;
        }
         if (dabh == "" || dabh == undefined) {
            alert("字典编号必须填写!");
            $("#txtDabh").focus();
            return false;
        }
        if (daxx == "" || daxx == undefined) {
            alert("字典名称必须填写!");
            $("#txtDaxx").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}



function GoAdd(pageindex) {
    location.href = "ZdxEdit.aspx?page=" + pageindex;
}

function GoEdit(pageindex) {
    var keyvalue = "";
    $("[name='selectThis'][checked]").each(function() {
        if (keyvalue == "") {
            keyvalue = $(this).val();
        }
        else {
            keyvalue += "," + $(this).val();
        }
    })

    if (keyvalue == "") {
        alert("请选择要修改的字典项!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的字典项!");
        return;
    }
    location.href = "ZdxEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoList2(pageindex) {
    location.href = "ZdxlList.aspx?page=" + pageindex;
}



function ZdxSave() {
    if (!DataCheck()) return;
    var lsh = $("#hidlsh").val();
    var dazx = $("#txtDazx").val();
    var wtbh = $("#txtWtbh").val();
    var wtnr = $("#txtWtnr").val();
    var dabh = $("#txtDabh").val();
    var daxx = $("#txtDaxx").val();
    var bz = $("#txtBz").val();
    $.ajax({
    type: "POST",
        url: "../Handler/Users/ZdxHandler.ashx?action=zdxedit&dazx=" + escape(dazx) + "&wtbh=" 
        + escape(wtbh) + "&wtnr=" + escape(wtnr)  + "&dabh=" + escape(dabh) +"&daxx="+escape(daxx)+"&bz="+escape(bz)+ "&lsh=" + escape(lsh) ,
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg != "-1" && msg != "99") {
                if (lsh == "" || lsh == undefined) {
                    $("#hidlsh").val(msg);
                }
                alert("字典项保存成功!");
                location.href = "ZdxlList.aspx" ;
            }
            else
            {
                alert("字典项保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}


function ZdxDel(pageindex) {
    var keyvalue = "";
    $("[name='selectThis'][checked]").each(function() {
        if (keyvalue == "") {
            keyvalue = $(this).val();
        }
        else {
            keyvalue += "," + $(this).val();
        }
    })

    if (keyvalue == "") {
        alert("请选择要删除的记录!");
        return;
    }
    
    var obj = confirm("是否确定删除?");
    if (!obj) return;
    $.ajax({
        type: "POST",
        url: "../Handler/Users/ZdxHandler.ashx?action=zdxdel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                alert("字典项删除成功！");
                location.href = "ZdxlList.aspx?page=" + pageindex;
            }
            else {
                alert("字典项删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}


