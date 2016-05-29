function DataCheck() {
    try {
        var schoolno = $("#ddlSchool").val();
        var courseno = $("#ddlCourse").val();
        var classno=$("#ddlClass").val();
        var teacherno=$("#ddlTeacher").val();

        if (schoolno == "" || schoolno == undefined) {
            alert("所属学校必须选择!");
            $("#ddlSchool").focus();
            return false;
        }
        if (courseno == "" || courseno == undefined) {
            alert("课程必须选择!");
            $("#ddlCourse").focus();
            return false;
        }
        if (classno == "" || classno == undefined) {
            alert("班级必须选择!");
            $("#ddlClass").focus();
            return false;
        }
        if (teacherno == "" || teacherno == undefined) {
            alert("教师必须选择!");
            $("#ddlTeacher").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "CourseFPList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "CourseFPEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的课程分配!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的课程分配!");
        return;
    }
    location.href = "CourseFPEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView2(obj) {
    location.href = "CourseFPEdit.aspx?isview=view&getid="+obj;
}
function GoList2(pageindex) {
    location.href = "CourseFPList.aspx?page=" + pageindex;
}

function GoEdit2() {
    location.href = "CourseFPEdit.aspx";
}

function GoEdit2(obj) {
    location.href = "CourseFPEdit.aspx?getid="+obj;
}


function CourseFPSave() {
    if (!DataCheck()) return;
    var lsh = $("#hidlsh").val();
    var schoolno = $("#ddlSchool").val();
    var courseno = $("#ddlCourse").val();
    var classno=$("#ddlClass").val();
    var teacherno=$("#ddlTeacher").val();
    var state=$("#ddlState").val();
    var username=$("#hiduser").val();
    
    $.ajax({
    type: "POST",
        url: "../Handler/Users/CourseFPHandler.ashx?action=fpedit&courseno=" + escape(courseno) +  "&schoolno=" 
        + escape(schoolno) + "&classno=" + escape(classno)  + "&teacherno=" + escape(teacherno) 
        + "&state=" + escape(state)+ "&username=" + escape(username)+ "&lsh=" + escape(lsh) ,
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
                alert("课程分配保存成功!");
            }
            else if (msg == "99") {
                alert("【" + name + "】已经存在，保存失败");
            }
            else
            {
                alert("课程分配保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}

function CourseFPDel(pageindex) {
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
        url: "../Handler/Users/CourseFPHandler.ashx?action=fpdel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "CourseFPList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该课程分配有发布的信息，不允许删除!");
            }
            else {
                alert("课程分配删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}