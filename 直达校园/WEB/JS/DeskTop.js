/**
* 桌面布局
* 将容器分成10份，间隔6px，多余像素补到第一列
* 通过data-column属性来指定占几列
*/
function portalInit() {
    var $portal = $('.portal');
    var $portalcolumn = $portal.children('.portal-column');
    var columnNum = $portal.children('.portal-column').length;
    var portalWdith = $portal.parent().width() - 3 - columnNum * 6;
    var columnWidth = Math.floor(portalWdith / 10) + Math.floor(portalWdith % 10 / 10);
    var overWidth = portalWdith - columnWidth * 10 - 3;
    $portalcolumn.each(function (i) {
        if (i == 0) {
            $(this).width(columnWidth * $(this).attr('data-column') + overWidth);
        } else {
            $(this).width(columnWidth * $(this).attr('data-column'));
        }
    });
}


/**
* 桌面布局的常用操作
* 包含拖动排序、收起展开等
*/


function protalControl() {

/*
    $('.portal-item-head .xicon').hide();
    $('.portal-item').hover(function () {
        $(this).find('.xicon').show();
    }, function () {
        $(this).find('.xicon').hide();
    });
    $('.portal-item-head .xi-shou').toggle(function () {
        $(this).addClass('xi-zhan').parent().next().slideUp(300);
    }, function () {
        $(this).removeClass('xi-zhan').parent().next().slideDown(300);
    });
    $(".portal-column").sortable({ connectWith: ".portal-column" });
    $(".portal-column").disableSelection();
    */
}

function DataSave(objflag) {
    var flag = objflag;
    var usercode = $("#HidUserCode").val();
    var macip = $("#MacIP").val();
    var lsh = $("#HidLsh").val();
    //alert(lsh);
    $.ajax({
    type: "POST",
    url: "../Handler/MyAttendance/MyAttendance.ashx?action=setstate&flag=" + escape(flag) + "&usercode=" + escape(usercode) + "&macip=" + escape(macip) + "&lsh=" + lsh,
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function() {
            //alert("正在处理....");
    },
      
        success: function(msg) {
          
            if (msg == "1") {
                switch (objflag) {
                    case "1":
                        alert("上班签到打卡成功!");
                        break;
                    case "2":
                        alert("下班签到打卡成功!");
                        break;
                }
            }
            else if (msg == "99") {

            }
            else {
                alert("签到打卡失败!");
            }
        },
        error: function() {
            alert("签到打卡失败12!");
        }
    });
}
