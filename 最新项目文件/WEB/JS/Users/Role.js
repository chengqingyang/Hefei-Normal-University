function LoginCheck() {
    try {
        var rolename = $("#txtrolename").val();

        if (rolename == "" || rolename == undefined) {
            alert("角色名称必须填写!");
            $("#txtrolename").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "RoleList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "RoleEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的角色!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的角色!");
        return;
    }
    location.href = "RoleEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView(obj) {
    location.href = "RoleEdit.aspx?isview=view&getid="+obj;
}

function RoleSave() {
    if (!LoginCheck()) return;
    var rolelsh = $("#hidlsh").val();
    var rolename = $("#txtrolename").val();
    var oldrolename = $("#hidoldrolename").val();
    var roledemo = $(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html();

    if (rolelsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }

    $.ajax({
        type: "POST",
        url: "../Handler/Users/RoleHandler.ashx?action=roleedit&rolename=" + escape(rolename) + "&oldrolename=" + escape(oldrolename) + "&roledemo=" + escape(roledemo) + "&rolelsh=" + escape(rolelsh),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg != "-1" && msg != "99") {
                if (rolelsh == "" || rolelsh == undefined) {
                    $("#hidlsh").val(msg);
                }           
                alert("角色保存成功!");
            }
            else if (msg == "99") {
                alert("【" + rolename + "】角色已经存在，保存失败");
            }
            else {
                alert("角色保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}


function RoleDel(pageindex) {
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
        url: "../Handler/Users/RoleHandler.ashx?action=roledel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "RoleList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该角色已经绑定用户，不允许删除!");
            }
            else {
                alert("角色删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}