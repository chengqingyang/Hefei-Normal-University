function LoginCheck() {
    try {
        var date=$("#txtdate").val();
        var title=$("#txttitle").val();
        var text=$("#txtbody").val();
               
        if (date == "" || date == undefined) {
            alert("提醒日期必须填写!");
            $("#txtdate").focus();
            return false;
        }
        if (text == "" || text == undefined) {
            alert("备忘内容不能为空!");
            $("#txtbody").focus();
            return false;
        }
        return true;

    } catch (ex) {
        return false;
    }
}

function GoList(pageindex) {
    location.href = "BeiWangList.aspx?page=" + pageindex;
}

function GoEdit() {
    location.href = "BeiWangEdit.aspx";
}

function GoEdit(obj) {
    location.href = "BeiWangEdit.aspx?getid="+obj;
}

function GoView(obj) {
    location.href = "BeiWangEdit.aspx?isview=view&getid="+obj;
}

function GoAdd(pageindex) {
    location.href = "BeiWangEdit.aspx?page=" + pageindex;
}

function BeiWangSave() {
    if (!LoginCheck()) return;
    var lsh = $("#hidlsh").val();
    var date  = $("#txtdate").val();
    var text = $("#txtbody").val();
    var title=$("#txttitle").val();
    var type=$("#hidtype").val();
    var tgh = $("#hidtgh").val();

//    lsh!=null&&
    if (lsh != "") {
        if (confirm("是否确定修改?") == false) return false;
    }
    
    $.ajax({
    type: "POST",
        url: "../Handler/Teacher/BeiWangHandler.ashx?action=bwedit&date=" + escape(date) + "&text="+ escape(text)
        +"&title=" + escape(title)+"&type=" + escape(type) +"&tgh=" + escape(tgh)+ "&lsh=" + escape(lsh),
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
                alert("备忘保存成功!");
            }
            else if (msg == "99") {
                alert("备忘已经存在，保存失败");
            }
            else
            {
                alert("备忘保存失败!");
            }
        },
        error: function() {
            alert("业务处理异常!");
        }
    });
}