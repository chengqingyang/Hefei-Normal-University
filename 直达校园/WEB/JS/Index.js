function GetUrlPath() {
    var path = window.location.pathname;
    window.location.href = "MemberLogin.aspx?getpath=" + path;
}

function AddCar(objid, objname, objprice, type, num) {
    if (num == "xxx") {
        num = $("#txtNum").val();
    }
    $.ajax({
    type: "POST",
        url: "Handler/MyCarHandler.ashx?action=addcar&objid=" + escape(objid) + "&objname=" + escape(objname) + "&objprice=" + escape(objprice) + "&type=" + escape(type) + "&num=" + escape(num),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            var res = msg.split(",");
            if (res[0] == "99") {
                alert("购物车已经存在您要的宝贝!");
            }
            else if (res[0] == "1") {
                alert("宝贝成功加入到购物车!");
            }
            else {
                alert("操作失败,购物车出故障了!");
            }
            try
            {
                document.getElementById("Top1_div_gwc").innerHTML = "购物车(" + res[1] + ")";
            }catch(e)
            {}
            try
            {
                document.getElementById("Top1_div_gwc1").innerHTML = "购物车(" + res[1] + ")";
            }catch(e){}
        },
        error: function() {
            alert("操作异常,购物车出故障了!");
        }
    });
}


//-----明细页
function AddCar_Zf(objid, objname, objprice, type, num) {
    if (num == "xxx") {
        num = $("#txtNum").val();
    }

    $.ajax({
        type: "POST",
        url: "Handler/MyCarHandler.ashx?action=addcar&objid=" + escape(objid) + "&objname=" + escape(objname) + "&objprice=" + escape(objprice) + "&type=" + escape(type) + "&num=" + escape(num),
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理...."); 
        },
        success: function(msg) {
            var res = msg.split(",");
            if (res[0] == "99") {
                window.location.href = "MyOrder.aspx";
            }
            else if (res[0] == "1") {
                window.location.href = "MyOrder.aspx";
            }
            else {
                alert("立即支付失败!");
            }
        },
        error: function() {
            alert("立即支付异常!");
        }
    });
}


function CssSet(obj) {
    switch (obj) {
        case 1:
            //$("#h_1").
            document.getElementById("h_1").className = 'navhover';
            document.getElementById("h_2").className = '';
            document.getElementById("h_3").className = '';
            document.getElementById("h_4").className = '';
            document.getElementById("h_5").className = '';
            document.getElementById("h_6").className = '';
            break;
        case 2:
            //$("#h_1").
            document.getElementById("h_1").className = '';
            document.getElementById("h_2").className = 'navhover';
            document.getElementById("h_3").className = '';
            document.getElementById("h_4").className = '';
            document.getElementById("h_5").className = '';
            document.getElementById("h_6").className = '';
            break;
        case 3:
            //$("#h_1").
            document.getElementById("h_1").className = '';
            document.getElementById("h_2").className = '';
            document.getElementById("h_3").className = 'navhover';
            document.getElementById("h_4").className = '';
            document.getElementById("h_5").className = '';
            document.getElementById("h_6").className = '';
            break;
        case 4:
            //$("#h_1").
            document.getElementById("h_1").className = '';
            document.getElementById("h_2").className = '';
            document.getElementById("h_3").className = '';
            document.getElementById("h_4").className = 'navhover';
            document.getElementById("h_5").className = '';
            document.getElementById("h_6").className = '';
            break;
        case 5:
            //$("#h_1").
            document.getElementById("h_1").className = '';
            document.getElementById("h_2").className = '';
            document.getElementById("h_3").className = '';
            document.getElementById("h_4").className = '';
            document.getElementById("h_5").className = 'navhover';
            document.getElementById("h_6").className = '';
            break;
        case 6:
            //$("#h_1").
            document.getElementById("h_1").className = '';
            document.getElementById("h_2").className = '';
            document.getElementById("h_3").className = '';
            document.getElementById("h_4").className = '';
            document.getElementById("h_5").className = '';
            document.getElementById("h_6").className = 'navhover';
            break;
    }
}