function DataCheck() {
    try {
        var schoolname = $("#ddlSchool").val();
        var name = $("#txtxuenianname").val();
        var startdate = $("#txtdatestart").val();
        var enddate = $("#txtdateend").val();

        if (schoolname == "" || schoolname == undefined) {
            alert("所属学校必须选择!");
            $("#ddlSchool").focus();
            return false;
        }
        if (name == "" || name == undefined) {
            alert("学年名称必须填写!");
            $("#txtxuenianname").focus();
            return false;
        }
        if (startdate == "" || startdate == undefined) {
            alert("开始日期必须填写!");
            $("#txtdatestart").focus();
            return false;
        }
        if (enddate == "" || enddate == undefined) {
            alert("结束日期必须填写!");
            $("#txtdateend").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "XueNianList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "XueNianEdit.aspx?page=" + pageindex;
}

function GoEdit(pageindex) {
    var keyvalue = "";
    $("[name='selectThis'][checked]").each(function() {
        if (keyvalue == "") {
            keyvalue = $(this).val();
        }
        else {
            keyvalue += "," + $(this).val();
        }
    })

    if (keyvalue == "") {
        alert("请选择要修改的学年信息!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的学年信息!");
        return;
    }
    location.href = "XueNianEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView2(obj) {
    location.href = "XueNianEdit.aspx?isview=view&getid="+obj;
}
function GoList2(pageindex) {
    location.href = "XueNianList.aspx?page=" + pageindex;
}

function GoEdit2() {
    location.href = "XueNianEdit.aspx";
}

function GoEdit2(obj) {
    location.href = "XueNianEdit.aspx?getid="+obj;
}


function XueNianSave() {
    if (!DataCheck()) return;
    var lsh = $("#hidlsh").val();    
    var schoolno = $("#ddlSchool").val();
    var name = $("#txtxuenianname").val();
    var startdate = $("#txtdatestart").val();
    var enddate = $("#txtdateend").val();
    var state= $("#ddlState").val();
    var username= $("#hidusr").val();
    $.ajax({
    type: "POST",
        url: "../Handler/Users/XueNianHandler.ashx?action=xnedit&name=" + escape(name) +  "&schoolno=" 
        + escape(schoolno) + "&sdate=" + escape(startdate)  + "&edate=" + escape(enddate) 
        + "&state=" + escape(state)+ "&username=" + escape(username) + "&lsh=" + escape(lsh) ,
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
                alert("学年信息保存成功!");
            }
            else if (msg == "99") {
                alert("【" + name + "】已经存在，保存失败");
            }
            else
            {
                alert("学年信息保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}

function XueNianDel(pageindex) {
    var keyvalue = "";
    $("[name='selectThis'][checked]").each(function() {
        if (keyvalue == "") {
            keyvalue = $(this).val();
        }
        else {
            keyvalue += "," + $(this).val();
        }
    })

    if (keyvalue == "") {
        alert("请选择要删除的记录!");
        return;
    }
    
    var obj = confirm("是否确定删除?");
    if (!obj) return;
    $.ajax({
        type: "POST",
        url: "../Handler/Users/XueNianHandler.ashx?action=xndel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "XueNianList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该学年信息有发布的信息，不允许删除!");
            }
            else {
                alert("学年信息删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}