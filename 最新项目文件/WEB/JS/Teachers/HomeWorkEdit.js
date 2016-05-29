function LoginCheck() {
    try {
        var id=$("#txtdate").val();
        var classno=$("#ddlClass").val();
        var courseno=$("#ddlCourse").val();
        var xnno=$("#ddlXueNian").val();
        var xqno=$("#ddlXueQi").val();
            
        if (id == "" || id == undefined) {
            alert("日期必须填写!");
            $("#txtdate").focus();
            return false;
        }
        if (xnno == "" || xnno == undefined) {
            alert("请选择学年!");
            $("#ddlXueNian").focus();
            return false;
        }
        if (xqno == "" || xqno == undefined) {
            alert("请选择学期!");
            $("#ddlXueQi").focus();
            return false;
        }
        if (classno == "" || classno == undefined) {
            alert("请选择班级!");
            $("#ddlClass").focus();
            return false;
        }  
        if (courseno == "" || courseno == undefined) {
            alert("请选择课程!");
            $("#ddlCourse").focus();
            return false;
        }  
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "HomeWorkList.aspx?page=" + pageindex;
}

function GoEdit() {
    location.href = "HomeWorkEdit.aspx";
}

function GoEdit(obj) {
    location.href = "HomeWorkEdit.aspx?getid="+obj;
}

function GoView(obj) {
    location.href = "HomeWorkEdit.aspx?isview=view&getid="+obj;
}

function GoAdd(pageindex) {
    location.href = "HomeWorkEdit.aspx?page=" + pageindex;
}

function HomeWorkSave() {
    if (!LoginCheck()) return;
    var lsh = $("#hidlsh").val();
    var date  = $("#txtdate").val();
    var text = $("#txtbody").val();
    var state= $("#ddlVisible").val();
    var tgh = $("#hidtgh").val();
    var cid = $("#ddlCourse").val();
    var schoolno=$("#hidschool").val();
    var classno=$("#ddlClass").val();
    var xnno=$("#ddlXueNian").val();
    var xqno=$("#ddlXueQi").val();

//    lsh!=null&&
    if (lsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }
    
    $.ajax({
    type: "POST",
        url: "../Handler/Teacher/HomeWorkHandler.ashx?action=zyedit&date=" + escape(date) + "&text="+ escape(text)
        +"&state=" + escape(state)+"&cid=" + escape(cid) +"&schoolno=" + escape(schoolno)
        +"&classno=" + escape(classno)+"&xnno=" + escape(xnno)+"&xqno=" + escape(xqno)
        +"&tgh=" + escape(tgh)+ "&lsh=" + escape(lsh),
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
                alert("作业保存成功!");
            }
            else if (msg == "99") {
                alert("作业【" + date + "】已经存在，保存失败");
            }
            else
            {
                alert("作业保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}