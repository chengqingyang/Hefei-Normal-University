function DataCheck() {
    try {
        var schoolname = $("#ddlSchool").val();
        var name = $("#txtclassname").val();
        var bzrname = $("#txtbzrname").val();

        if (schoolname == "" || schoolname == undefined) {
            alert("所属学校必须选择!");
            $("#ddlSchool").focus();
            return false;
        }
        if (name == "" || name == undefined) {
            alert("班级名称必须填写!");
            $("#txtclassname").focus();
            return false;
        }

        if (bzrname == "" || bzrname == undefined) {
            alert("班级校长必须填写!");
            $("#txtbzrname").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "ClassList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "ClassEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的班级!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的班级!");
        return;
    }
    location.href = "ClassEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView2(obj) {
    location.href = "ClassEdit.aspx?isview=view&getid="+obj;
}
function GoList2(pageindex) {
    location.href = "ClassList.aspx?page=" + pageindex;
}

function GoEdit2() {
    location.href = "ClassEdit.aspx";
}

function GoEdit2(obj) {
    location.href = "ClassEdit.aspx?getid="+obj;
}


function ClassSave() {
    if (!DataCheck()) return;
    var lsh = $("#hidlsh").val();
    var schoolno = $("#ddlSchool").val();
    var name = $("#txtclassname").val();
    var bzrname = $("#txtbzrname").val();
    var remark= $("#txtremark").val();
    $.ajax({
    type: "POST",
        url: "../Handler/Users/ClassHandler.ashx?action=classedit&name=" + escape(name) + "&bzrname=" 
        + escape(bzrname) + "&schoolno=" + escape(schoolno)  + "&remark=" + escape(remark) + "&lsh=" + escape(lsh) ,
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
                alert("班级保存成功!");
                 location.href = "ClassList.aspx"
            }
            else if (msg == "99") {
                alert("该学校【" + name + "】已经存在，保存失败");
            }
            else
            {
                alert("班级保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}

function ClassDel(pageindex) {
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
        url: "../Handler/Users/ClassHandler.ashx?action=classdel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "ClassList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该班级有发布的信息，不允许删除!");
            }
            else {
                alert("班级删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}


