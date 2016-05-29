function LoginCheck() {
    try {
        var id=$("#txtid").val();
        var classno=$("#ddlClass").val();
        var xnno=$("#ddlXueNian").val();
        var xqno=$("#ddlXueQi").val();
        
               
        if (id == "" || id == undefined) {
            alert("值日周次必须填写!");
            $("#txtid").focus();
            return false;
        }
        if (classno == "" || classno == undefined) {
            alert("班级必须选择!");
            $("#ddlClass").focus();
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
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "ZhiRiList.aspx?page=" + pageindex;
}

function GoEdit() {
    location.href = "ZhiRiEdit.aspx";
}

function GoEdit(obj) {
    location.href = "ZhiRiEdit.aspx?getid="+obj;
}

function GoView(obj) {
    location.href = "ZhiRiEdit.aspx?isview=view&getid="+obj;
}

function GoAdd(pageindex) {
    location.href = "ZhiRiEdit.aspx?page=" + pageindex;
}

function ZhiRiSave() {
    if (!LoginCheck()) return;
    var lsh = $("#hidlsh").val();
    var id  = $("#txtid").val();
    var mon = $("#txtmon").val();
    var tue = $("#txttue").val();
    var wed = $("#txtwed").val();
    var thu = $("#txtthu").val();
    var fri = $("#txtfri").val();
    var content = $("#txtcontent").val();
    var classno= $("#ddlClass").val();
    var xnno=$("#ddlXueNian").val();
    var xqno=$("#ddlXueQi").val();
    var schoolno=$("#hidschoolno").val();
    var tgh=$("#hidtgh").val();

//    lsh!=null&&
    if (lsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }
    
    $.ajax({
    type: "POST",
        url: "../Handler/Teacher/ZhiRiHandler.ashx?action=zredit&id=" + escape(id) + "&mon="+ escape(mon)
        +"&tue=" + escape(tue) + "&wed=" + escape(wed) + "&thu=" + escape(thu) + "&fri=" + escape(fri)
        + "&content=" + escape(content)+ "&classno=" + escape(classno) + "&tgh=" + escape(tgh)
        + "&schoolno=" + escape(schoolno)+ "&xnno=" + escape(xnno)+ "&xqno=" + escape(xqno)+ "&lsh=" + escape(lsh),
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
                alert("值日安排保存成功!");
            }
            else if (msg == "99") {
                alert("值日安排【" + id + "】已经存在，保存失败");
            }
            else
            {
                alert("值日安排保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}