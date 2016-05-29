function DataCheck() {
    try {
        var name = $("#txtschoolname").val();
        var xzname = $("#txtxzname").val();
        var addr = $("#txtschooladdr").val();

        if (name == "" || name == undefined) {
            alert("学校名称必须填写!");
            $("#txtschoolname").focus();
            return false;
        }

        if (xzname == "" || xzname == undefined) {
            alert("学校校长必须填写!");
            $("#txtxzname").focus();
            return false;
        }

        if (addr == "" || addr == undefined) {
            alert("学校地址必须选择!");
            $("#txtschooladdr").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "SchoolList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "SchoolEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的学校!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的学校!");
        return;
    }
    location.href = "SchoolEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView2(obj) {
    location.href = "SchoolEdit.aspx?isview=view&getid="+obj;
}
function GoList2(pageindex) {
    location.href = "SchoolList.aspx?page=" + pageindex;
}

function GoEdit2() {
    location.href = "SchoolEdit.aspx";
}

function GoEdit2(obj) {
    location.href = "SchoolEdit.aspx?getid="+obj;
}


function SchoolSave() {
    if (!DataCheck()) return;
    var lsh = $("#hidlsh").val();
    var name = $("#txtschoolname").val();
    var xzname = $("#txtxzname").val();
    var addr = $("#txtschooladdr").val();
    var remark= $("#txtremark").val();
    $.ajax({
    type: "POST",
        url: "../Handler/Users/SchoolHandler.ashx?action=schooledit&name=" + escape(name) + "&xzname=" 
        + escape(xzname) + "&addr=" + escape(addr)  + "&remark=" + escape(remark) + "&lsh=" + escape(lsh) ,
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
                alert("学校保存成功!");
            }
            else if (msg == "99") {
                alert("【" + name + "】已经存在，保存失败");
            }
            else
            {
                alert("学校保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}

function SchoolDel(pageindex) {
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
        url: "../Handler/Users/SchoolHandler.ashx?action=schooldel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "SchoolList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该学校有发布的信息，不允许删除!");
            }
            else {
                alert("学校删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}


