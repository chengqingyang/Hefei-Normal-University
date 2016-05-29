﻿var dg = frameElement.dg;

function LoginCheck() {
    try {
        var username = $("#username").val();
        var userpwd = $("#password").val();
        var varcode = $("#tbx_random").val();

        if (username == "" || username == undefined) {
            alert("会员名称必须填写!");
            $("#username").focus();
            return false;
        }

        if (userpwd == "" || userpwd == undefined) {
            alert("会员密码必须填写!");
            $("#password").focus();
            return false;
        }

        if (varcode == "" || varcode == undefined) {
            alert("验证码必须填写!");
            $("#tbx_random").focus();
            return false;
        }

        return true;

    } catch (ex) {
        return false;
    }
}

/*控件*/
frameElement.dg.addBtn('sure', '登录', function() {
    MemberLogin();
});


function MemberLogin() {
    if (!LoginCheck()) return;
    var username = $("#username").val();
    var userpwd = $("#password").val();
    var varcode = $("#tbx_random").val();
    $.ajax({
        type: "POST",
        url: "../Handler/Member/MemberHandler.ashx?action=loginquery&username=" + escape(username) + "&userpwd=" + escape(userpwd) + "&varcode=" + escape(varcode),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //jAlert("正在处理...."); 
        },
        success: function(msg) {

            if (msg == "1") {
                alert("该用户不存在!");
                $("#username").focus();
            }
            else if (msg == "2") {
                window.parent.location.reload();
            }
            else if (msg == "3") {
                alert("密码错误!");
                $("#password").focus();
            }
            else if (msg == "4") {
                alert("用户被锁定!");
                $("#username").focus();
            }
            else if (msg == "99") {
                alert("验证码错误");
                $("#tbx_random").focus();
            }
            else {
                alert("登录异常!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}

function GetEventCode(evt) {
    if (typeof evt == "undefined" || evt == null) {
        evt = SearchEvent();
        if (typeof evt == "undefined" || evt == null) {
            return null;
        }
    }
    return evt.keyCode || evt.charCode;
}

function checkKey() {
    var code;
    if (document.all) {
        code = event.keyCode;
    } else {
        code = GetEventCode();
    }

    if (code >= 97 && code <= 123) {
        if (document.all) {
            event.keyCode = code - 32;
        } else {
            evt.charCode = code - 32;
        }
    }
}


function changeimg() {
    document.getElementById("img_random").src = "GetImage.aspx?" + Math.random();
}
