

function GoList(pageindex) {
    location.href = "UserList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "UserEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的用户!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的用户!");
        return;
    }
    location.href = "UserEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView(obj) {
    location.href = "UserEdit.aspx?isview=view&getid="+obj;
}


function UserDel(pageindex) {
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
        url: "../Handler/Users/UserHandler.ashx?action=userdel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                alert("管理员信息删除成功！");
                location.href = "UserList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该用户有发布的信息，不允许删除!");
            }
            else {
                alert("用户删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}


