function LoginCheck() {
    try {
        var username = $("#txtusername").val();
        var userpwd = $("#txtuserpwd").val();
        var userrole = $("#ddlrole").val();
        var truename = $("#txtTrueName").val();
        var empname = $("#txtEmpName").val();
        var usersxqy = $("#txtSzdq").val();
        var school = $("#ddlSchool").val();

        if (username == "" || username == undefined) {
            alert("用户口令必须填写!");
            $("#txtusername").focus();
            return false;
        }

        if (userpwd == "" || userpwd == undefined) {
            alert("用户密码必须填写!");
            $("#txtuserpwd").focus();
            return false;
        }

        if (userrole == "" || userrole == undefined) {
            alert("用户角色必须选择!");
            $("#ddlrole").focus();
            return false;
        }

        if (truename == "" || truename == undefined ) {
            alert("用户姓名必须填写!");
            $("#txttruename").focus();
            return false;
        } 
        if (school == "" || school == undefined) {
            alert("所在学校必须选择!");
            $("#ddlSchool").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "UserList.aspx?page=" + pageindex;
}

function GoEdit() {
    location.href = "UserEdit.aspx";
}

function GoEdit(obj) {
    location.href = "UserEdit.aspx?getid="+obj;
}

function GoView(obj) {
    location.href = "UserEdit.aspx?isview=view&getid="+obj;
}


function UserSave() {
    if (!LoginCheck()) return;
    var userlsh = $("#hidlsh").val();
    var username = $("#txtusername").val();
    var userpwd = $("#txtuserpwd").val();
    var userrole = $("#ddlrole").val();
    var truename = $("#txtTrueName").val();
    var userphone = $("#txtconnphone").val();
    var cardid = $("#txtcardid").val();
    var address = $("#txtaddress").val();
    var userstate = $("#ddlstate").val();
    var schoolno=$("#ddlSchool").val();
    var schoolname =$("#ddlSchool").find("option:selected").text(); 

    if (userlsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }

    $.ajax({
        type: "POST",
        url: "../Handler/Users/UserHandler.ashx?action=useredit&username=" + escape(username) +  "&userpwd=" + escape(userpwd) +
    "&userrole=" + escape(userrole) + "&truename=" + escape(truename) + "&userphone=" + escape(userphone) + "&cardid=" + escape(cardid) +
    "&address=" + escape(address) + "&userstate=" + escape(userstate) +"&schoolno="+escape(schoolno)+ "&schoolname=" + escape(schoolname)
    + "&userlsh=" + escape(userlsh),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
        if (msg != "-1" && msg != "99") 
            {
                if (userlsh == "" || userlsh == undefined) {
                    $("#hidlsh").val(msg);
                }
                alert("管理员信息保存成功!");
                location.href = "UserList.aspx"
            }
            else if (msg == "99") 
            {
               alert("该学校管理员【" + username + "】用户已经存在，保存失败");
            }
            else {
                alert("用户保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}


