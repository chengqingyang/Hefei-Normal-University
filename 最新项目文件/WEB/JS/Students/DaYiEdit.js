function LoginCheck() {
    try {
        var title=$("#txttitle").val();
        var content=$("#txtcontent").val();
        var answer= $("#txtanswer").val();
              
        if (title == "" || title == undefined) {
            alert("标题必须填写!");
            $("#txttitle").focus();
            return false;
        }
        if (content == "" || content == undefined) {
            alert("正文必须填写!");
            $("#txtcontent").focus();
            return false;
        }
        if (answer != undefined&&answer == "" ) {
            alert("回复不能为空!");
            $("#txtanswer").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "DaYiList.aspx?page=" + pageindex;
}

function GoEdit() {
    location.href = "DaYiEdit.aspx";
}

function GoEdit(obj) {
    location.href = "DaYiEdit.aspx?getid="+obj;
}

function GoView(obj) {
    location.href = "DaYiEdit.aspx?isview=view&getid="+obj;
}

function GoAdd(pageindex) {
    location.href = "DaYiEdit.aspx?page=" + pageindex;
}

function DaYiSave() {    
    if (!LoginCheck()) return;
    var lsh = $("#hidlsh").val();
    var course  = $("#ddlCourse").val();
    var title=$("#txttitle").val();
    var content = $("#txtcontent").val();
    var uname=$("#hiduname").val();
    var answer=$("#txtanswer").val();
    var state=$("#hidstate").val();


//    lsh!=null&&
    if (lsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }
    
    $.ajax({
    type: "POST",
        url: "../Handler/Student/DaYiHandler.ashx?action=dyedit&course=" + escape(course) + "&title="
        + escape(title)+"&content=" + escape(content) +"&answer=" + escape(answer) +"&state=" + escape(state) 
        + "&uname=" + escape(uname)+ "&lsh=" + escape(lsh),
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
                alert("提问保存成功!");
            }
            else if (msg == "99") {
                alert("提问已经存在，保存失败");
            }
            else
            {
                alert("提问保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}