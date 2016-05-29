/*
* 设置皮肤
* 
*/
function setSkin() {
    var skinName = getCookie('skinname');
    if (skinName) {
        $('#skinlink').attr('href', '/skin/' + skinName + '.css');
        //if(iebrowser) $('.btn').cornerz({radius:5});
    }
}

$(document).ready(function() {
    setSkin();
    if ($.browser.msie && $.browser.version == "6.0" && $("html")[0].scrollHeight > $("html").height()) $("html").css("overflowY", "scroll");
    $(".datagrid-main").css({
        "marginTop": $(".datagrid-header").height()
    });

    $("table.datagrid-main-table tr:odd").addClass("row-even");

    $("table.datagrid-main-table tr").hover(function() {
        $(this).addClass("row-hover");
    }, function() {
        $(this).removeClass("row-hover");
    });
    $('#selectAll').click(function() {
        if (this.checked) {
            $('input[name="selectThis"]').attr("checked", 'true');
            $("table.datagrid-main-table").find('tr').addClass('row-select');
        } else {
            $('input[name="selectThis"]').removeAttr("checked").parent().parent().removeClass('row-select');
            $("table.datagrid-main-table").find('tr').removeClass('row-select');
        }
    });
    $('input[name="selectThis"]').click(function() {
        var $this = $(this);
        var index = $this.parent().parent().index();
        if (this.checked) {
            $(this).attr('checked', 'true').parent().parent().addClass('row-select');
            $("table.datagrid-main-table").find('tr').eq(index).addClass('row-select');
        } else {
            $(this).removeAttr('checked').parent().parent().removeClass('row-select');
            $("table.datagrid-main-table").find('tr').eq(index).removeClass('row-select');
        }
    });

    $("table tr:nth-child(even)").addClass("even");
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
    /*
    datagrid2Init();
    datagrid2Event();
    datagridInit();
    datagridEvent();
    datadetailInit();
    */
});
