function LoginCheck() {
    try {
        var date=$("#txtdate").val();
        var js=$("#txtjs").val();
        var zwh=$("#txtzwh").val();
        var classno=$("#ddlClass").val();
        var courseno=$("#ddlCourse").val();
        var xnno=$("#ddlXueNian").val();
        var xqno=$("#ddlXueQi").val();
        
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
            alert("考试班级必须选择!");
            $("#ddlClass").focus();
            return false;
        }      
        if (date == "" || date == undefined) {
            alert("日期必须填写!");
            $("#txtdate").focus();
            return false;
        }
        if (courseno == "" || courseno == undefined) {
            alert("课程名称必须选择!");
            $("#ddlCourse").focus();
            return false;
        }
        if (js == "" || js == undefined) {
            alert("教室必须填写!");
            $("#txtjs").focus();
            return false;
        }
        if (zwh == "" || zwh == undefined) {
            alert("开始座位号必须填写!");
            $("#txtzwh").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "KaoShiList.aspx?page=" + pageindex;
}

function GoEdit() {
    location.href = "KaoShiEdit.aspx";
}

function GoEdit(obj) {
    location.href = "KaoShiEdit.aspx?getid="+obj;
}

function GoView(obj) {
    location.href = "KaoShiEdit.aspx?isview=view&getid="+obj;
}

function GoAdd(pageindex) {
    location.href = "KaoShiEdit.aspx?page=" + pageindex;
}

function KaoShiSave() {
    if (!LoginCheck()) return;
    var lsh = $("#hidlsh").val();
    var date  = $("#txtdate").val();
    var js = $("#txtjs").val();
    var zwh= $("#txtzwh").val();
    var remark= $("#txtremark").val();
    var state= $("#ddlVisible").val();
    var classno=$("#ddlClass").val();
    var cid = $("#ddlCourse").val();
    var type= $("#ddltype").val();
    var tgh = $("#hidtgh").val();
    var schoolno=$("#hidschool").val();
    var xnno=$("#ddlXueNian").val();
    var xqno=$("#ddlXueQi").val();

//    lsh!=null&&
    if (lsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }
    
    $.ajax({
    type: "POST",
        url: "../Handler/Teacher/KaoShiHandler.ashx?action=ksedit&date=" + escape(date) + "&js="+ escape(js)
        +"&zwh=" + escape(zwh)+"&type=" + escape(type) +"&state=" + escape(state)+"&cid=" + escape(cid) 
        +"&schoolno=" + escape(schoolno)+"&xnno=" + escape(xnno)+"&xqno=" + escape(xqno)
        +"&classno=" + escape(classno)+"&remark=" + escape(remark)+"&tgh=" + escape(tgh)+ "&lsh=" + escape(lsh),
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
                alert("考试安排保存成功!");
            }
            else if (msg == "99") {
                alert("该考试安排已经存在，保存失败");
            }
            else
            {
                alert("考试安排保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}