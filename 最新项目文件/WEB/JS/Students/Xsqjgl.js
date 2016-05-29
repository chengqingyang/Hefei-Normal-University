function DataCheck() {
    try {
        if ($("#txtQjjs").val() == "" || $("#txtQjjs").val() == undefined) {
            alert("请添加请假简述!");
            $("#txtQjjs").focus();
            return false;
        }

        if ($("#txtQjsj").val() == "" || $("#txtQjsj").val() == undefined) {
            alert("请假时间段必须填写!");
            $("#txtQjsj").focus();
            return false;
        }

        if ($("#txtQjsy").val() == "" || $("#txtQjsy").val() == undefined) {
            alert("请填写请假事由!");
            $("#txtQjsy").focus();
            return false;
        }
         if ($("#txtXsqz").val() == "" || $("#txtXsqz").val() == undefined) {
            alert("请签字!");
            $("#txtXsqz").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function Savecheck() {
    if($("#hiddqzt").val()!="0" && $("#hiddqzt").val()!="")
    {
         alert("请假条已进入审批流程，无法保存!");
         return false;
    }
    return true;
}


function Shcheck() {
    if($("#hiddqzt").val()!="0" && $("#hiddqzt").val()!="")
    {
         alert("请假条已提交审核，不要重复提交!");
         return false;
    }

    if (confirm("此操作为不可逆操作，一旦提交，无法修改！是否确认？")) {
        return true;

    }
    else {
        return false;
    }
    return true;
}





function Jsspcheck() {
        if ($("#txtJsqz").val() == "" || $("#txtJsqz").val() == undefined) {
            alert("教师签字必须填写!");
            $("#txtJsqz").focus();
            return false;
        }
     return true;
}



function GoAdd(pageindex) {
    location.href = "GrQjEdit.aspx?page=" + pageindex;
}

function GoEdit(pageindex) {
    var keyvalue = "";
    var spzt = "";
    $("[name='selectThis'][checked]").each(function() {
        if (keyvalue == "") {
            keyvalue = $(this).val();
        }
        else {
            keyvalue += "," + $(this).val();
        }
    })

    if (keyvalue == "") {
        alert("请选择要修改的请假记录!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要修改的请假记录!");
        return;
    }
    location.href = "GrQjEdit.aspx?getid=" + arr[0] + "&page=" + pageindex; 
}


function GoSpEdit(pageindex) {
    var keyvalue = "";
    var spzt = "";
    $("[name='selectThis'][checked]").each(function() {
        if (keyvalue == "") {
            keyvalue = $(this).val();
        }
        else {
            keyvalue += "," + $(this).val();
        }
    })

    if (keyvalue == "") {
        alert("请选择要审批的请假记录!");
        return;
    }

    var arr = new Array;
    arr = keyvalue.split(',');
    if (arr.length > 1) {
        alert("请选择一条要审批的请假记录!");
        return;
    }
    location.href = "XsQjEdit.aspx?getid=" + arr[0] + "&page=" + pageindex; 
}

function GoList5(pageindex) {
    location.href = "XsQjlList.aspx?page=" + pageindex;
}



function GoList2(pageindex) {
    location.href = "GrQjlList.aspx?page=" + pageindex;
}



function QjtSave() {
    if (!DataCheck()||!Savecheck()) return;
    var lsh = $("#hidlsh").val();
    var qjjs = $("#txtQjjs").val();
    var qjsj = $("#txtQjsj").val();
    var qjsy = $("#txtQjsy").val();
    var xsqz = $("#txtXsqz").val();
    var dqzt = "0";
    $.ajax({
    type: "POST",
    url: "../Handler/Student/XsqjHandler.ashx?action=xsqjedit&qjjs=" + escape(qjjs) + "&qjsj="
        + escape(qjsj) + "&qjsy=" + escape(qjsy) + "&xsqz=" + escape(xsqz) + "&lsh=" + escape(lsh) + "&dqzt=" + escape(dqzt),
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
                alert("请假条保存成功!");
                location.href = "GrQjlList.aspx" ;
            }
            else
            {
                alert("请假条保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}

//提交审核操作
function TjshSave() {
    if (!DataCheck() || !Shcheck()) return;
    var lsh = $("#hidlsh").val();
    var qjjs = $("#txtQjjs").val();
    var qjsj = $("#txtQjsj").val();
    var qjsy = $("#txtQjsy").val();
    var xsqz = $("#txtXsqz").val();
    var dqzt = "1";
    $.ajax({
    type: "POST",
        url: "../Handler/Student/XsqjHandler.ashx?action=xsqjedit&qjjs=" + escape(qjjs) + "&qjsj=" 
        + escape(qjsj) + "&qjsy=" + escape(qjsy)  + "&xsqz=" + escape(xsqz)+ "&lsh=" + escape(lsh)+ "&dqzt=" + escape(dqzt) ,
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
                alert("提交审核成功，请假条处于【待审批】状态，请耐心等待!");
                location.href = "GrQjlList.aspx";
            }
            else
            {
                alert("提交审核失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}


//请假条审核操作
function JtspSave() {
    if (!Jsspcheck()) return;
    var lsh = $("#hidlsh").val();
    var dqzt = $("#dlJsyj").val();
    var jsqz = $("#txtJsqz").val();
    $.ajax({
    type: "POST",
        url: "../Handler/Student/XsqjHandler.ashx?action=qjshedit&dqzt=" + escape(dqzt)+ "&lsh="+ escape(lsh)+ "&jsqz=" + escape(jsqz),
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
                alert("请假条审批成功！");
                location.href = "XsQjlList.aspx";
            }
            else
            {
                alert("请假条审批失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}








function XSqjDel(pageindex) {
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
        url: "../Handler/Student/XsqjHandler.ashx?action=xsqjdel&keyvalue=" + escape(keyvalue),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            if (msg == "1") {
                alert("请假条删除成功！");
                location.href = "GrQjlList.aspx?page=" + pageindex;
            }
            else {
                alert("请假条删除失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}


