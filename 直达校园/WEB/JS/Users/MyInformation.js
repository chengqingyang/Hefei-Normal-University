function LoginCheck() {
    try {
        var username = $("#txtusername").val();
        var userpwd = $("#txtuserpwd").val();
        var userrole = $("#ddlrole").val();
        var usersxqy = $("#txtSzdq").val();
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
        return true;

    } catch (ex) {
        return false;
    }
}


function UserSave() {
    if (!LoginCheck()) return;
    var userlsh = $("#hidlsh").val();
    var username = $("#txtusername").val();
    var oldusername = $("#hidusername").val();
    var userpwd = $("#txtuserpwd").val();
    var userrole = $("#ddlrole").val();
    var useremp = $("#HidEmpCode").val();
    var userphone = $("#txtconnphone").val();
    var cardid = $("#txtcardid").val();
    var address = $("#txtaddress").val();
    var userstate = $("#ddlstate").val();

    $.ajax({
    type: "POST",
        url: "../Handler/Users/UserHandler.ashx?action=useredit&username=" + escape(username) +"&oldusername="+escape(oldusername)+ "&userpwd=" + escape(userpwd) +
    "&userrole=" + escape(userrole) + "&useremp=" + escape(useremp) + "&userphone=" + escape(userphone) + "&cardid=" + escape(cardid) +
    "&address=" + escape(address) + "&userstate=" + escape(userstate) + "&userlsh=" + escape(userlsh) ,
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                alert("用户保存成功!");
            }
            else if (msg == "98") {
                alert("员工已经被别的口令绑定，保存失败");
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
