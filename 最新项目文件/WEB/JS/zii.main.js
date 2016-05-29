var iebrowser = $.browser.msie && (($.browser.version == "6.0") || ($.browser.version == "7.0") || ($.browser.version == "8.0"));


//初始化
function pageInit() {
    var windowHeight = $(window).height();
    var mainHeight = windowHeight - $("#header").height() - $("#footer").height();
    var mainBodyHeight = mainHeight - 30; //hd的高度
    $("#mFrame").css({ "height": mainBodyHeight, "width": $("#main").width() });
    $(".menu-inner").height(mainHeight - 5);
    $(".menu-item").each(function () {
        var $this = $(this);
        var num_dt = $this.find('dt').length;
        $this.find('dd').height(mainBodyHeight - 25 * num_dt);
    });
    if (iebrowser) $('#nav li').cornerz({ radius: 5, corners: "tl tr" });
}

//导航切换
function navToggle() {
    $('.menu-item dt').click(function () {
        var $this = $(this);
        if ($this.hasClass('open')) {
            $this.removeClass('open').next('dd').hide();
        } else {
            var $sibdl = $this.parent().siblings('dl');
            $sibdl.find('dd').hide().end().find('dt').removeClass('open');
            $this.addClass('open').next('dd').show();
        }
    });
    $('#nav li').click(function () {
        var $this = $(this);
        var _index = $('#nav li').index($this);
        var _url = $('.menu-item').eq(_index).find("a").attr("href");
        var _title = $('.menu-item').eq(_index).find("a").html().replace(/<[^>]+>/g, '');
        $this.siblings().removeClass('on').end().addClass('on');

        $('.menu-item').hide().eq(_index).show().find('dt').eq(0).removeClass('open').click();
        $('#menu .hd b').html($this.html()).prev('i').attr('class', 'sicon si-' + $this.attr('data-icon'));

        $('#main .hd b').html(_title).prev('i').attr('class', 'sicon si-' + $(this).attr('data-icon'));
        $("#mFrame").attr("src", _url);
    });
    $('#menu li a').click(function () {
        $('#main .hd b').html($(this).html().replace(/<[^>]+>/g, '')).prev('i').attr('class', 'sicon si-' + $(this).attr('data-icon'));
    });

    $("a.top-linkbtn").click(function () {
        $('#main .hd b').html($(this).data("title"));
    });

    $('#nav li').eq(0).click();
    $("#mFrame").attr("src", "DeskTop.aspx");
    $('#menu .hd b').html("我的办公桌");
}

//换肤
function changeSkin() {
    $('#skinbtn').click(function () {
        $('#skinbox').show();
        return false;
    });
    $('#skinbox').mouseleave(function () {
        $(this).hide();
    });
    $('#skinbox ul li').click(function () {
        var $this = $(this);
        if (!$this.hasClass('now')) {
            $('#skinlink').attr('href', '/skin/' + $this.attr('data-skin') + '.css');
            $('#mFrame').contents().find('#skinlink').attr('href', '/skin/' + $this.attr('data-skin') + '.css');
            setCookie('skinname', $this.attr('data-skin'));
            //setSkin();
            $this.addClass('now').siblings('li').removeClass('now');
        }
    });
    var skinName = getCookie('skinname');
    if (skinName) {
        $('#skinlink').attr('href', '/skin/' + skinName + '.css');
        $('#skinbox ul li[data-skin="' + skinName + '"]').addClass('now').siblings('li').removeClass('now');
    }
}

//显示日期信息
function writeDateInfo() {
    var myday, mymonth, myweekday, myyear;
    var week = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六");
    var date = new Date();
    myyear = date.getFullYear();
    mymonth = date.getMonth() + 1;
    myday = date.getDate();
    myweekday = week[date.getDay()];
    $("#dateInfo").html(myyear + "年" + mymonth + "月" + myday + "日 " + myweekday);
}

function MainTip() {
    $.ajax({
        type: "POST",
        url: "Handler/MainHandler.ashx?action=getgonggao",
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function () {
            //alert("正在处理...."); 
        },
        success: function (msg) {
            document.getElementById("sp_gonggao").innerHTML = "新公告(" + msg + ")";
            //TipHt();
        },
        error: function () {
            document.getElementById("sp_gonggao").innerHTML = "公告获取失败";
        }
    });

    var jgcode = $("#HidJgcode").val();
    $.ajax({
        type: "POST",
        url: "Handler/MainHandler.ashx?action=gethtdq&jgcode=" + jgcode,
        dataType: "text", //返回json格式数据
        cache: false,
        beforeSend: function () {
            //alert("正在处理...."); 
        },
        success: function (msg) {
            document.getElementById("sp_htdq").innerHTML = "到期合同提醒(" + msg + ")";
        },
        error: function () {
            document.getElementById("sp_htdq").innerHTML = "到期合同提醒获取失败";
        }
    });
}

pageInit();
navToggle();
changeSkin();
writeDateInfo();
MainTip();

$(window).resize(function () {
    pageInit();
});