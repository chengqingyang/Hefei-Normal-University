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

function LoginCheck() {
    try {
        var username = $("#username").val();
        var userpwd = $("#userpwd").val();
        var varcode = $("#tbx_random").val();

        if (username == "" || username == undefined) {
            alert("用户名必须填写!");
            $("#username").focus();
            return false;
        }

        if (userpwd == "" || userpwd == undefined) {
            alert("用户密码必须填写!");
            $("#userpwd").focus();
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

function UserLogin() {
    if (!LoginCheck()) return;
    var username = $("#username").val();
    var userpwd = $("#userpwd").val();
    var varcode = $("#tbx_random").val();
    $.ajax({
    type: "POST",
    url: "Handler/LoginHandler.ashx?action=loginquery&username=" + escape(username) + "&userpwd=" + escape(userpwd) + "&varcode=" + escape(varcode),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
        if (msg == "1") {
                alert("该用户不存在!");
                $("#username").focus();
            }
            else if (msg == "2") {
                location.href = "Main.aspx";
            }
            else if (msg == "3") {
                alert("密码错误!");
                $("#userpwd").focus();
            }
            else if (msg == "4") {
                alert("用户被锁定!");
                $("#username").focus();
            }
            else if (msg == "99") {
                alert("验证码错误");
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

function changeimg() {
    document.getElementById("img_random").src = "GetImage.aspx?" + Math.random();
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