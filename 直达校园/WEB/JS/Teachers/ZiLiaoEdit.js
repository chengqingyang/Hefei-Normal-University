function LoginCheck() {
    try {
        var filename=$("#lab_filename").val();
        var filepath=$("#lab_filepath").val();
               
        if (filename == "" || filename == undefined) {
            alert("请先选择上传文件");
            $("#file_upload").focus();
            return false;
        }
        if (filepath == "" || filepath == undefined) {
            alert("请先选择上传文件");
            $("#file_upload").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "ZiLiaoList.aspx?page=" + pageindex;
}

function GoEdit() {
    location.href = "ZiLiaoEdit.aspx";
}

function GoEdit(obj) {
    location.href = "ZiLiaoEdit.aspx?getid="+obj;
}

function GoView(obj) {
    location.href = "ZiLiaoEdit.aspx?isview=view&getid="+obj;
}

function GoAdd(pageindex) {
    location.href = "ZiLiaoEdit.aspx?page=" + pageindex;
}

function ZiLiaoSave() {    
    if (!LoginCheck()) return;
    var lsh = $("#hidlsh").val();
    var course  = $("#ddlCourse").val();
    var state=$("#ddlVisibie").val();
    var filename = $("#lab_filename").val();
    var filepath = $("#lab_filepath").val();
    var tgh=$("#hidtgh").val();
    var flag=$("#hidflag").val();

//    lsh!=null&&
    if (lsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }
    
    $.ajax({
    type: "POST",
        url: "../Handler/Teacher/ZiLiaoHandler.ashx?action=zledit&course=" + escape(course) + "&filename="
        + escape(filename)+"&filepath=" + escape(filepath) +"&state=" + escape(state)+"&flag=" + escape(flag)
        + "&tgh=" + escape(tgh)+ "&lsh=" + escape(lsh),
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
                alert("资源保存成功!");
            }
            else if (msg == "99") {
                alert("资源已经存在，保存失败");
            }
            else
            {
                alert("资源保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}