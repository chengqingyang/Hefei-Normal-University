var windowWdith = $(window).width();
var windowHeight = $(window).height();

/*
* 设置皮肤
* 
*/
function setSkin() {
    var skinName = getCookie('skinname');
    if (skinName) {
        $('#skinlink').attr('href', '/skin/' + skinName + '.css');
    }
}

/**
 * 数据表格
 * 
 */
function datagridInit(){
	var $datagrid = $('#datagrid-report');
	var $fixed = $datagrid.find('.datagrid-fixed');
	var $scroll = $datagrid.find('.datagrid-scroll');

	var headHeight = $(".datagrid-header").eq(0).height();
	var footHeight = $(".datagrid-footer").eq(0).height();
	var fixedHeadHeight = $(".datagrid-scroll-head").eq(0).height();
	var totalWidth = 0;

	var fixWidth = $fixed.length > 0 ? $fixed.width() : 0;

	$scroll.css({ marginLeft: fixWidth });
	$(".datagrid-scroll-body, .datagrid-fixed-body").css({
	    "height": windowHeight - headHeight - footHeight - fixedHeadHeight,
	    "top": fixedHeadHeight
    });

	//自动生成选择框固定列
	if ($datagrid.hasClass('datagrid-auto-check') && !$datagrid.hasClass('auto-checked')) {
	    $datagrid.addClass('auto-checked');
		var checkstr = '';
		$('.datagrid-scroll-body tr').each(function () {
			checkstr += '<tr><td><input type="checkbox" name="selectThis" id="checkbox' + $(this).find('td').first().attr('data-id') + '" /></td></tr>';
		});
        $(checkstr).appendTo($('.datagrid-fixed-body table').eq(0));
    }

    //滚动区域高宽
    if ($(".datagrid-scroll-head col").length) {
        $(".datagrid-scroll-head col").each(function (i) {
            totalWidth += parseInt($(this).attr('width')) + 1;
            //$('.datagrid-scroll-body td').eq(i).width($(this).attr('width'));
        });
    } else {
        $(".datagrid-scroll-head th").each(function (i) {
            totalWidth += parseInt($(this).attr('width')) + 1;
            $('.datagrid-scroll-body td').eq(i).width($(this).attr('width'));
        });
    }

    $(".datagrid-scroll-head-inner, .datagrid-scroll-head table, .datagrid-scroll-body table").width(totalWidth);


    if (/msie/.test(navigator.userAgent.toLowerCase())) {
        if ((jQuery.browser && jQuery.browser.version && jQuery.browser.version == '6.0') || (!$.support.leadingWhitespace)) {
            $(".datagrid-scroll-head, .datagrid-scroll-body").width(windowWdith - fixWidth);
        }
    }
}

function datagridEvent(){
	var _scrollTop;
	var _scrollLeft;
	var $datagrid = $('#datagrid-report');
	var $scrollHead = $datagrid.find('.datagrid-scroll-head');
	var $scrollSelect = $datagrid.find('.datagrid-fixed-body');
	var $scrollBody = $datagrid.find('.datagrid-scroll-body');
	var $dgBtable = $datagrid.find('.datagrid-btable');

    //响应换色
	$dgBtable.find('tr').hover(function(){
		var index = $(this).index();
		$dgBtable.each(function(){
			$(this).find('tr').eq(index).addClass('row-hover');
		});
	},function(){
		var index = $(this).index();
		$dgBtable.each(function(){
			$(this).find('tr').eq(index).removeClass('row-hover');
		});
	});
	
	//全选
	$('#selectAll').click(function(){
		if (this.checked) {
			$('input[name="selectThis"]').attr("checked",'true');
			$dgBtable.find('tr').addClass('row-select');
        } else {
            $('input[name="selectThis"]').removeAttr("checked").parent().parent().removeClass('row-select');
			$dgBtable.find('tr').removeClass('row-select');
        }
	});
	$('input[name="selectThis"]').click(function(){
		var $this = $(this);
		var index = $this.parent().parent().index();
		if (this.checked) {
			$(this).attr('checked','true').parent().parent().addClass('row-select');
			$scrollBody.find('tr').eq(index).addClass('row-select');
		}else{
			$(this).removeAttr('checked').parent().parent().removeClass('row-select');
			$scrollBody.find('tr').eq(index).removeClass('row-select');
		}
	});

    //监听滚动 
    $scrollBody.scroll(actionEvent);  
          
	//响应事件     
	function actionEvent(){
	    $scrollSelect.scrollTop($scrollBody.scrollTop());
	    $scrollHead.scrollLeft($scrollBody.scrollLeft());
    }
}

$(document).ready(function () {
    setSkin();

    datagridInit();
    datagridEvent();

    var btnrolelist = $("#HidBtnRoleList").val();
    if (btnrolelist) {
        var arr = btnrolelist.split(",");
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == "1") {
                $("#btnAdd").show();
            }
            else if (arr[i] == "2") {
                $("#btnEdit").show();
            }
            else if (arr[i] == "3") {
                $("#btnDel").show();
            }
        }
    }
});
