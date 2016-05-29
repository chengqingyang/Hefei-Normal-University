function DataCheck() {
    try {
        var schoolname = $("#ddlSchool").val();
        var xuenianname = $("#ddlXueNian").val();
        var xueqino = $("#txtxueqino").val();
        var xueqiname = $("#txtxueqiname").val();
        var startdate = $("#txtdatestart").val();
        var enddate = $("#txtdateend").val();

        if (schoolname == "" || schoolname == undefined) {
            alert("所属学校必须选择!");
            $("#ddlSchool").focus();
            return false;
        }
        if (xuenianname == "" || xuenianname == undefined) {
            alert("学年名称必须选择!");
            $("#ddlXueNian").focus();
            return false;
        }
        if (xueqino == "" || xueqino == undefined) {
            alert("学期编号必须填写!");
            $("#txtxueqino").focus();
            return false;
        }
        if (xueqiname == "" || xueqiname == undefined) {
            alert("学期名称必须填写!");
            $("#txtxueqiname").focus();
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
    location.href = "XueQiList.aspx?page=" + pageindex;
}

function GoAdd(pageindex) {
    location.href = "XueQiEdit.aspx?page=" + pageindex;
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
        alert("请选择要修改的学期信息!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的学期信息!");
        return;
    }
    location.href = "XueQiEdit.aspx?getid=" + arr[0] + "&page=" + pageindex;
}

function GoView2(obj) {
    location.href = "XueQiEdit.aspx?isview=view&getid="+obj;
}
function GoList2(pageindex) {
    location.href = "XueQiList.aspx?page=" + pageindex;
}

function GoEdit2() {
    location.href = "XueQiEdit.aspx";
}

function GoEdit2(obj) {
    location.href = "XueQiEdit.aspx?getid="+obj;
}


function XueQiSave() {
    if (!DataCheck()) return;
    var lsh = $("#hidlsh").val();    
    var schoolno = $("#ddlSchool").val();
    var xuenianno = $("#ddlXueNian").val();
    var xueqino = $("#txtxueqino").val();
    var xueqiname = $("#txtxueqiname").val();
    var startdate = $("#txtdatestart").val();
    var enddate = $("#txtdateend").val();
    var state= $("#ddlState").val();
    $.ajax({
    type: "POST",
        url: "../Handler/Users/XueQiHandler.ashx?action=xqedit&xuenianno=" + escape(xuenianno) +  "&schoolno=" 
        + escape(schoolno) + "&xueqino=" + escape(xueqino)  + "&xueqiname=" + escape(xueqiname)+ "&sdate=" 
        + escape(startdate)  + "&edate=" + escape(enddate) 
        + "&state=" + escape(state) + "&lsh=" + escape(lsh) ,
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
                alert("学期信息保存成功!");
            }
            else if (msg == "99") {
                alert("【" + xueqiname + "】已经存在，保存失败");
            }
            else
            {
                alert("学期信息保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}

function XueQiDel(pageindex) {
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
        url: "../Handler/Users/XueQiHandler.ashx?action=xqdel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                location.href = "XueQiList.aspx?page=" + pageindex;
            }
            else if (msg == "99") {
                alert("该学期信息有发布的信息，不允许删除!");
            }
            else {
                alert("学期信息删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}