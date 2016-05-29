function LoginCheck() {
    try {
        var stuid=$("#txtstuid").val();
        var stuname = $("#txtstuname").val();
        var stusex = $("#ddlsex").val();
        var stuclass = $("#ddlClass").val();
        var stuschool = $("#ddlSchool").val();
               
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
        
        if (stuschool == "" || stuschool == undefined) {
            alert("学校必须选择!");
            $("#txtclass").focus();
            return false;
        } 
        if (stuclass == "" || stuclass == undefined) {
            alert("班级必须选择!");
            $("#txtclass").focus();
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

function GoEdit() {
    location.href = "StudentEdit.aspx";
}

function GoEdit(obj) {
    location.href = "StudentEdit.aspx?getid="+obj;
}

function GoView(obj) {
    location.href = "StudentEdit.aspx?isview=view&getid="+obj;
}

function GoAdd(pageindex) {
    location.href = "StudentEdit.aspx?page=" + pageindex;
}

function StudentSave() {
    if (!LoginCheck()) return;
    var stulsh = $("#hidlsh").val();
    var stuid=$("#txtstuid").val();
    var stuname = $("#txtstuname").val();
    var stusex = $("#ddlsex").val();
    var stuclass = $("#ddlClass").val();
    var classname = $("#ddlClass").find("option:selected").text(); 
    var stuschool = $("#ddlSchool").val();
    var schoolname =$("#ddlSchool").find("option:selected").text(); 
    var userphone = $("#txtconnphone").val();
    var cardid = $("#txtcardid").val();
    var address = $("#txtaddress").val();
    var remark = $("#txtremark").val();
    var picpath=$("#lab_picpath").val();

//    stulsh!=null&&
    if (stulsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }
    
    $.ajax({
    type: "POST",
        url: "../Handler/Student/StudentHandler.ashx?action=stuedit&stuid=" + escape(stuid) + "&stuname="
        + escape(stuname) +"&stusex=" + escape(stusex) + "&stuclass=" + escape(stuclass) + "&userphone=" 
        + escape(userphone) + "&cardid=" + escape(cardid) +"&address=" + escape(address) + "&remark=" 
        + escape(remark) +"&picpath="+escape(picpath)+ "&stuschool=" + escape(stuschool)
        +  "&schoolname=" + escape(schoolname) +  "&classname=" + escape(classname)
        + "&stulsh=" + escape(stulsh) ,
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg != "-1" && msg != "99") {
                if (stulsh == "" || stulsh == undefined) {
                    $("#hidlsh").val(msg);
                }
                alert("学生信息保存成功!");
                location.href = "StudentList.aspx"
            }
            else if (msg == "99") {
                alert("【" + stuname + "】用户已经存在，保存失败");
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
        url: "../Handler/Users/UserHandler.ashx?action=userdel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                alert("学生信息删除成功!");
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