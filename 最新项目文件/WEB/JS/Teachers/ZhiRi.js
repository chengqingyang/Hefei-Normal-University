function DataCheck() {
    try {
        //alert();
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
    location.href = "ZhiRiList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "ZhiRiEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的值日周次!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的值日周次!");
        return;
    }
    location.href = "ZhiRiEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView(obj) {
    location.href = "ZhiRiEdit.aspx?isview=view&getid="+obj;
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



function ZhiRiDel(pageindex) {
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
        url: "../Handler/Teacher/ZhiRiHandler.ashx?action=zrdel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "ZhiRiList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该值日安排，不允许删除!");
            }
            else {
                alert("值日安排删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}