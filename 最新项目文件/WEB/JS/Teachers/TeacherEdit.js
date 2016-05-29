function LoginCheck() {
    try {
        var id=$("#txtid").val();
        var name = $("#txtname").val();
        var sex = $("#ddlsex").val();
        var birth = $("#txtbirth").val();
        var school = $("#ddlSchool").val();
          var kc = $("#ddlcourse").val();
        
               
        if (id == "" || id == undefined) {
            alert("教师工号必须填写!");
            $("#txtid").focus();
            return false;
        }

        if (name == "" || name == undefined) {
            alert("姓名必须填写!");
            $("#txtname").focus();
            return false;
        }

        if (sex == "" || sex == undefined) {
            alert("性别必须选择!");
            $("#ddlsex").focus();
            return false;
        }

        if (birth == "" || birth == undefined) {
            alert("出生日期必须填写!");
            $("#txtbirth").focus();
            return false;
        } 
        if (school == "" || school == undefined) {
            alert("所在学校必须选择!");
            $("#ddlSchool").focus();
            return false;
        }
        if (kc == "" || kc == undefined) {
            alert("主教课程必须选择!");
            $("#ddlcourse").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "TeacherList.aspx?page=" + pageindex;
}

function GoEdit() {
    location.href = "TeacherEdit.aspx";
}

function GoEdit(obj) {
    location.href = "TeacherEdit.aspx?getid="+obj;
}

function GoView(obj) {
    location.href = "TeacherEdit.aspx?isview=view&getid="+obj;
}

function GoAdd(pageindex) {
    location.href = "TeacherEdit.aspx?page=" + pageindex;
}

function TeacherSave() {
    if (!LoginCheck()) return;
    var lsh = $("#hidlsh").val();
    var id=$("#txtid").val();
    var name = $("#txtname").val();
    var sex = $("#ddlsex").val();
    var zc = $("#txtzc").val();
    var userphone = $("#txtconnphone").val();
    var cardid = $("#txtcardid").val();
    var birth = $("#txtbirth").val();
    var remark = $("#txtremark").val();
    var picpath=$("#lab_picpath").val();
    var course=$("#ddlcourse").val();
    var schoolno=$("#ddlSchool").val();
    var schoolname =$("#ddlSchool").find("option:selected").text(); 
//    alert(schoolname);

//    lsh!=null&&
    if (lsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }
    
    $.ajax({
    type: "POST",
        url: "../Handler/Teacher/TeacherHandler.ashx?action=tcedit&id=" + escape(id) + "&name="
        + escape(name) +"&sex=" + escape(sex) + "&zc=" + escape(zc) + "&userphone=" 
        + escape(userphone) + "&cardid=" + escape(cardid) +"&birth=" + escape(birth) + "&remark=" 
        + escape(remark) +"&picpath="+escape(picpath)+"&course="+escape(course)
        +"&schoolno="+escape(schoolno)+ "&schoolname=" + escape(schoolname)
        + "&lsh=" + escape(lsh) ,
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
                alert("教师信息保存成功!");
                location.href="TeacherList.aspx"
            }
            else if (msg == "99") {
                alert("【" + name + "】用户已经存在，保存失败");
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

