function LoginCheck() {
    try {
        var pf=$("#txtpf").val();
        var py=$("#txtpy").val();
        
        if (pf == "" || pf == undefined) {
            alert("评分不能为空!");
            $("#txtpf").focus();
            return false;
        }       
        if (py == "" || py == undefined) {
            alert("评语不能为空!");
            $("#txtpy").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "PingJiaList.aspx?page=" + pageindex;
}

function GoEdit() {
    location.href = "PingJiaEdit.aspx";
}

function GoEdit(obj) {
    location.href = "PingJiaEdit.aspx?getid="+obj;
}

function GoView(obj) {
    location.href = "PingJiaEdit.aspx?isview=view&getid="+obj;
}

function GoAdd(pageindex) {
    location.href = "PingJiaEdit.aspx?page=" + pageindex;
}

function PingJiaSave() {
    if (!LoginCheck()) return;
    var lsh = $("#hidlsh").val();
    var py = $("#txtpy").val();
    var pf=$("#txtpf").val();
    var tgh = $("#hidtgh").val();

//    lsh!=null&&
    if (lsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }
    else{
        alert("请先选择要评价的老师");
        return;
    }
    
    $.ajax({
    type: "POST",
        url: "../Handler/Student/PingJiaHandler.ashx?action=pjedit&&py="+ escape(py)
        +"&pf=" + escape(pf)+"&tgh=" + escape(tgh)+ "&lsh=" + escape(lsh),
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
                alert("评语保存成功!");
            }
            else if (msg == "99") {
                alert("评价不存在，保存失败");
            }
            else
            {
                alert("评语保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}