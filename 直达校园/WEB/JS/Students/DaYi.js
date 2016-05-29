function DataCheck() {
    try {
        //alert();
        var title=$("#txttitle").val();
        var content=$("#txtcontent").val();
        
        if (title == "" || title == undefined) {
            alert("标题必须填写!");
            $("#txttitle").focus();
            return false;
        }
        if (content == "" || content == undefined) {
            alert("正文必须填写!");
            $("#txtcontent").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "DaYiList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "DaYiEdit.aspx?page=" + pageindex;
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
        alert("请选择要回复的答疑!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要回复的答疑!");
        return;
    }
    location.href = "DaYiEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView(obj) {
    location.href = "DaYiEdit.aspx?isview=view&getid="+obj;
}

function DaYiDel(pageindex) {
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
        url: "../Handler/Student/DaYiHandler.ashx?action=dydel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "DaYiList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该答疑不允许删除!");
            }
            else {
                alert("答疑删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}