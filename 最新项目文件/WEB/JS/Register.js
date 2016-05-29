function DataCheck() {
    try {
        var member = $("#txt_member").val();
        var mpwd = $("#txtPwd").val();
        var pwdagain = $("#txtRePwd").val();
        var email = $("#txtEmail").val();
        var phone = $("#txtPhone").val();
        var card = $("#txtCard").val();
        var tips = $("#ddl_tips").val();
        var answer = $("#txtAnswer").val();


        if (member == "" || member == undefined) {
            alert("会员名称必须填写!");
            $("#txt_member").focus();
            return false;
        }

        if (mpwd == "" || mpwd == undefined) {
            alert("会员密码必须填写!");
            $("#txtPwd").focus();
            return false;
        }

        if (mpwd != "" && mpwd.length < 6) {
            alert("密码长度必须在6-10位!");
            $("#txtPwd").focus();
            return false;
        }

        if (mpwd != pwdagain) {
            alert("两次密码输入不一致");
            $("#txtPwd").focus();
            return false; 
        }

        if (email == "" || email == undefined) {
            alert("邮箱必须填写!");
            $("#txtEmail").focus();
            return false;
        }
        if (IsEmail(email) == null) {
            alert("邮件格式错误!");
            $("#txtEmail").focus();
            return false;
        }

        var hidemail = $("#HidEmail").val();
        if (hidemail == "1") {
            alert("【" + $("#txtEmail").val() + "】已经存在!");
            $("#txtEmail").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}


function MemberRegister() {
    if (!DataCheck()) return;

    var code = $("#hidlsh").val();
    var member = $("#txt_member").val();
    var mpwd = $("#txtPwd").val();
    var email = $("#txtEmail").val();
    var phone = $("#txtPhone").val();
    var card = $("#txtCard").val();
    var tips = $("#ddl_tips").val();
    var answer = $("#txtAnswer").val();
    var schoolcode = $("#ddl_school").val();

    $.ajax({
    type: "POST",
    url: "Handler/RegisterHandler.ashx?action=registeredit&member=" + escape(member) + "&mpwd=" + escape(mpwd) + "&email=" + escape(email) + "&phone=" + escape(phone) + "&card=" + escape(card) + "&tips=" + escape(tips) + "&answer=" + escape(answer) + "&schoolcode=" + escape(schoolcode) + "&code=" + escape(code),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //jAlert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                alert("恭喜您!注册成功!");
                window.location.href = "MemberCenter.aspx";
            }
            else if (msg == "99") {
                alert("【" + member + "】已经存在，注册失败");
                $("#txt_member").focus();
            }
            else {
                alert("注册异常!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}

function Reload() {
    $("#hidlsh").val("");
    $("#txt_member").val("");
    $("#txtPwd").val("");
    $("#txtRePwd").val("");
    $("#txtEmail").val("");
    $("#txtPhone").val("");
    $("#txtCard").val("");
    $("#ddl_tips").val("");
    $("#txtAnswer").val("");
}

function MemberEmailCheck() {
    var email = $("#txtEmail").val();
    if (email != "" && email != undefined) {
        $.ajax({
            type: "POST",
            url: "Handler/RegisterHandler.ashx?action=emailcheck&email=" + escape(email),
            dataType: "text", //返回json格式数据
            cache: false,
            beforeSend: function() {
                //jAlert("正在处理...."); 
            },
            success: function(msg) {
                if (msg == "1") {
                    //document.getElementById("sp_email").innerHTML = "【" + email + "】已经存在!";
                    alert("【" + email + "】已经存在!");
                    $("#txtEmail").focus();
                    $("#HidEmail").val("1");
                }
                else {
                    document.getElementById("sp_email").innerHTML = "";
                    $("#HidEmail").val("0");
                }
            },
            error: function() {
                alert("业务处理异常!");
            }
        });
    }
    else {
        document.getElementById("sp_email").innerHTML = "";
        $("#HidEmail").val("0");
    }
}

function MemberPhoneCheck() {
    var phone = $("#txtPhone").val();
    if (phone != "" && phone != undefined) {
        $.ajax({
            type: "POST",
            url: "Handler/RegisterHandler.ashx?action=phonecheck&phone=" + escape(phone),
            dataType: "text", //返回json格式数据
            cache: false,
            beforeSend: function() {
                //jAlert("正在处理...."); 
            },
            success: function(msg) {
                if (msg == "1") {
                    document.getElementById("sp_phone").innerHTML = "【" + phone + "】已经存在!";
                    $("#HidPhone").val("1");
                }
                else {
                    document.getElementById("sp_phone").innerHTML = "【" + phone + "】可以注册!";
                    $("#HidPhone").val("0");
                }
            },
            error: function() {
                alert("业务处理异常!");
            }
        });
    }
    else {
        document.getElementById("sp_phone").innerHTML = "";
        $("#HidPhone").val("0");
    }
}

function MemberEdit() {
    if (!DataCheckEdit()) return;
    var code = $("#hidlsh").val();
    var member = $("#txt_member").val();
    var mpwd = $("#txtPwd").val();
    var email = $("#txtEmail").val();
    var phone = $("#txtPhone").val();
    var card = $("#txtCard").val();
    var address = $("#txtAddress").val();
    $.ajax({
    type: "POST",
    url: "../Handler/RegisterHandler.ashx?action=memberinfoedit&mpwd=" + escape(mpwd) + "&member=" + escape(member) + "&email=" + escape(email) + "&phone=" + escape(phone) +
        "&card=" + escape(card) + "&address=" + escape(address) + "&code=" + escape(code),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //jAlert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                alert("您的信息维护成功!");
                $("#username").focus();
            }
            else {
                alert("您的信息维护失败!");
            }
        },
        error: function() {
        alert("业务处理异常!");
        }
    });
}
