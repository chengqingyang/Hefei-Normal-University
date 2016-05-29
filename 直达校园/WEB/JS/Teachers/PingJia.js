function DataCheck() {
    try {
        var xnno=$("#ddlXueNian").val();
//        var xqno=$("#ddlXueQi").val();
//        var classno=$("#ddlClass").val();
        
        if (xnno == "" || xnno == undefined) {
            alert("请选择学年!");
            $("#ddlXueNian").focus();
            return false;
        }
//        if (xqno == "" || xqno == undefined) {
//            alert("请选择学期!");
//            $("#ddlXueQi").focus();
//            return false;
//        }
//        if (classno == "" || classno == undefined) {
//            alert("请选择班级!");
//            $("#ddlClass").focus();
//            return false;
//        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "PingJiaList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "PingJiaEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的评价信息!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的评价信息!");
        return;
    }
    location.href = "PingJiaEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView(obj) {
    location.href = "PingJiaEdit.aspx?isview=view&getid="+obj;
}

function PingJiaDel(pageindex) {
    var keyvalue = "";
    //selectThis
    $("[name='selectThis'][checked]").each(function() {
        if (keyvalue == "") {
            //keyvalue = $(this).("#selectKSNO").val();
            keyvalue = $(this).val();
            //keyvalue = $(this).find("name='selectKSNO'").val();
        }
        else {
            //keyvalue += "," + $(this).("#selectKSNO").val();
            keyvalue += "," + $(this).val();
            //keyvalue += "," + $(this).find("name='selectKSNO'").val();
        }
    })
//alert(keyvalue);
    if (keyvalue == "") {
        alert("请选择要删除的记录!");
        return;
    }
    
    var obj = confirm("是否确定删除?");
    if (!obj) return;
    $.ajax({
        type: "POST",
        url: "../Handler/Teacher/PingJiaHandler.ashx?action=pjdel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "PingJiaList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该评价信息，不允许删除!");
            }
            else {
                alert("评价信息删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}