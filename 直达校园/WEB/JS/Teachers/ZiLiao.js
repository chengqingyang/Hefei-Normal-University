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
    location.href = "ZiLiaoList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "ZiLiaoEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的资源!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的资源!");
        return;
    }
    location.href = "ZiLiaoEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView(obj) {
    location.href = "ZiLiaoEdit.aspx?isview=view&getid="+obj;
}


function PersonSave() {
    var userlsh = $("#hidlsh").val();
    var useremp = $("#txttruename").val();
    var userphone = $("#txtconnphone").val();
    var cardid = $("#txtcardid").val();
    var address = $("#txtaddress").val();
    $.ajax({
        type: "POST",
        url: "../Handler/Users/UserHandler.ashx?action=personedit&useremp=" + escape(useremp) + "&userphone=" + escape(userphone) + "&cardid=" + escape(cardid) +
    "&address=" + escape(address) +  "&userlsh=" + escape(userlsh),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                alert("个人设置成功!");
            }
            else {
                alert("个人设置失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}



function ZiLiaoDel(pageindex) {
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
        url: "../Handler/Teacher/ZiLiaoHandler.ashx?action=zldel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "ZiLiaoList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该资源不允许删除!");
            }
            else {
                alert("资源删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}