function DataCheck() {
    try {
        var schoolname = $("#ddlSchool").val();
        var name = $("#txtcoursename").val();

        if (schoolname == "" || schoolname == undefined) {
            alert("所属学校必须选择!");
            $("#ddlSchool").focus();
            return false;
        }
        if (name == "" || name == undefined) {
            alert("课程名称必须填写!");
            $("#txtcoursename").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "CourseList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "CourseEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的课程!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的课程!");
        return;
    }
    location.href = "CourseEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView2(obj) {
    location.href = "CourseEdit.aspx?isview=view&getid="+obj;
}
function GoList2(pageindex) {
    location.href = "CourseList.aspx?page=" + pageindex;
}

function GoEdit2() {
    location.href = "CourseEdit.aspx";
}

function GoEdit2(obj) {
    location.href = "CourseEdit.aspx?getid="+obj;
}


function CourseSave() {
    if (!DataCheck()) return;
    var lsh = $("#hidlsh").val();
    var username=$("#hiduser").val();
    var schoolno = $("#ddlSchool").val();
    var name = $("#txtcoursename").val();
    var remark= $("#txtremark").val();
    $.ajax({
    type: "POST",
        url: "../Handler/Users/CourseHandler.ashx?action=courseedit&name=" + escape(name) +  "&schoolno=" 
        + escape(schoolno) + "&username=" + escape(username)  + "&remark=" + escape(remark) + "&lsh=" + escape(lsh) ,
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
                alert("课程保存成功!");
            }
            else if (msg == "99") {
                alert("该学校【" + name + "】课程已经存在，保存失败");
            }
            else
            {
                alert("课程保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}

function CourseDel(pageindex) {
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
        url: "../Handler/Users/CourseHandler.ashx?action=coursedel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "CourseList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该课程有发布的信息，不允许删除!");
            }
            else {
                alert("课程删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}


