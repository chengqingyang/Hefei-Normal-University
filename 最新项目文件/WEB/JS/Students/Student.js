function DataCheck() {
    try {
        alert();
        var stuid=$("#txtstuid").val();
        var stuname = $("#txtstuname").val();
        var stusex = $("#ddlsex").val();
        var stuclass = $("#txtclass").val();
        
        if (stuid == "" || stuid == undefined) {
            alert("学生学号必须填写!");
            $("#txtstuid").focus();
            return false;
        }

        if (stuname == "" || stuname == undefined) {
            alert("姓名必须填写!");
            $("#txtstuname").focus();
            return false;
        }

        if (stusex == "" || stusex == undefined) {
            alert("性别必须选择!");
            $("#ddlsex").focus();
            return false;
        }

        if (stuclass == "" || stuclass == undefined) {
            alert("班级必须填写!");
            $("#txtstuclass").focus();
            return false;
        } 
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "StudentList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "StudentEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的学生!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的学生信息!");
        return;
    }
    location.href = "StudentEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView(obj) {
    location.href = "StudentEdit.aspx?isview=view&getid="+obj;
}


function StudentSave() {
    if (!DataCheck()) return;
    var userlsh = $("#hidlsh").val();
    var username = $("#txtusername").val();
    var userpwd = $("#txtuserpwd").val();
    var userrole = $("#ddlrole").val();
    var truename = $("#txtTrueName").val();
    var userphone = $("#txtconnphone").val();
    var cardid = $("#txtcardid").val();
    var address = $("#txtaddress").val();
    var userstate = $("#ddlstate").val();
    
    $.ajax({
    type: "POST",
        url: "../Handler/Users/UserHandler.ashx?action=useredit&username=" + escape(username) + "&userpwd=" + escape(userpwd) +
    "&userrole=" + escape(userrole) + "&truename=" + escape(truename) + "&userphone=" + escape(userphone) + "&cardid=" + escape(cardid) +
    "&address=" + escape(address) + "&userstate=" + escape(userstate) + "&userlsh=" + escape(userlsh) ,
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg != "-1" && msg != "99") {
                if (userlsh == "" || userlsh == undefined) {
                    $("#hidlsh").val(msg);
                }
                alert("用户保存成功!");
            }
            else if (msg == "99") {
                alert("【" + username + "】用户已经存在，保存失败");
            }
            else
            {
                alert("用户保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}



function StudentDel(pageindex) {
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
        url: "../Handler/Student/StudentHandler.ashx?action=studel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                 alert("学生信息删除成功!");
                location.href = "StudentList.aspx?page=" + pageindex;
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


