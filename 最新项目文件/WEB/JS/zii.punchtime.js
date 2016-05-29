ziipunch = {
	init : function(){
		this.Dom = $(".punch-time span");
		var punth = setInterval(function(){
			ziipunch.settime();
		}, 1000);
	},
	settime : function(){
		var now = new Date();
		var hour = now.getHours();
		var minute = now.getMinutes();
		var second = now.getSeconds();
		ziipunch.Dom.eq(0).attr("class", "pt-" + parseInt(hour / 10));
		ziipunch.Dom.eq(1).attr("class", "pt-" + hour % 10);
		ziipunch.Dom.eq(3).attr("class", "pt-" + parseInt(minute / 10));
		ziipunch.Dom.eq(4).attr("class", "pt-" + minute % 10);
		ziipunch.Dom.eq(6).attr("class", "pt-" + parseInt(second / 10));
		ziipunch.Dom.eq(7).attr("class", "pt-" + second % 10);
	}
};
ziipunch.init();