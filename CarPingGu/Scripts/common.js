function SelfAdaption() {
    var htmlwidth = $("html").width();
    if(htmlwidth >= 640) {
        $("html").css({
            "font-size" : "40px"
        })
        $(".wrap, .header, .footer").css({
            "width": "640px"
        })
        $(".brand_1 ,.cars_1 ,.car_1").css({
            "width":"650px"
            , "left": " -11em !important;"
        })
    }
    else {
        if(htmlwidth <= 320) {
            $("html").css({
                "font-size" : "20px"
            })
            $(".wrap").css({
                "width": "320px"
            })
            $(".brand_1 ,.cars_1 ,.car_1").css({
                "width": htmlwidth + 35 + "px"
                  , "left": " -7em !important;"
            })
        }else {
            if (htmlwidth <= 400 &&htmlwidth > 320) {
                $("html").css({
                    "font-size": "20px"
                })
                $(".wrap").css({
                    "width": htmlwidth
                })
                $(".brand_1 ,.cars_1 ,.car_1").css({
                    "width": htmlwidth + 27+ "px"
               , "left": " -7em !important;"
                })
            }

        else {
			$("html").css({
			    "font-size" : htmlwidth * 40 / 640 + "px"
			})
            $(".wrap, .header, .footer").css({
                "width": htmlwidth
            })
            $(".brand_1 ,.cars_1 ,.car_1").css({
                "width": htmlwidth + 17+ "px"
                , "left": " -7em !important;"
            })
        }
    }
}
}SelfAdaption();
$(window).resize(function(){
    SelfAdaption()
});

$(function(){
    $(".header a").each(function (index) {
        $(this).mouseover(function () {
            $(".header a.active").removeClass("active");
            $(this).addClass("active");
        }).mouseout(function () {


        });
    });
});


//$("#brandID").click(function () {
//    $("#carsID").removeAttr("disabled")
//    $("#carID").removeAttr("disabled")
//    $("#icon2").removeClass("hidden");
//    $(".brand_1").removeClass("hidden");
//    $(".cars_1").removeClass("hidden");
//    $(".car_1").removeClass("hidden");
//})
$("#brandID").mousedown(function () {
//    $("#carsID").removeAttr("disabled")
//    $("#carID").removeAttr("disabled")
    $("#icon2").removeClass("hidden");
//    $(".brand_1").removeClass("hidden");
//    $(".cars_1").removeClass("hidden");
//    $(".car_1").removeClass("hidden");
})

//$("#carsID").click(function () {
//	var value = $("input[name='brand_id']").val();
//	if(value == null || value == "" || value =="0" ){
//		event.preventDefault();
//		return ;
//	}
    //$("#icon2").removeClass("hidden");
//})

$("#carsID").mousedown(function () {
	var value = $("input[name='brand_id']").val();
	if(value == null || value == "" || value =="0" ){
		event.preventDefault();
		return ;
	}
    $("#icon2").removeClass("hidden");
})

//$("#carID").click(function () {	
//	var value = $("input[name='series_id']").val();
//	if(value == null || value == "" || value =="0" ){
//		event.preventDefault();
//		return ;
//	}
    //$("#icon2").removeClass("hidden");
//})

$("#carID").mousedown(function () {	
	var value = $("input[name='series_id']").val();
	if(value == null || value == "" || value =="0"){
		event.preventDefault();
		return ;
	}
    $("#icon2").removeClass("hidden");
})


$("#icon2").click(function () {
	var brand_flag = $("#vehicle-brand");
	if(brand_flag.hasClass("active")){
		brand_flag.removeClass("active");
	}
	var series_flag = $("#vehicle-series");
	if(series_flag.hasClass("active")){
		series_flag.removeClass("active");
	}
	var model_flag = $("vehicle-model");
	if(model_flag.hasClass("active")){
		model_flag.removeClass("active");
	}
    //$(".brand_1").addClass("hidden");
    //$(".cars_1").addClass("hidden");
    //$(".car_1").addClass("hidden");
    $("#icon2").addClass("hidden");
})

$(function () {
   $(".car_1").each(function () {
        $(this).click(function () {
           $("#icon2").addClass("hidden");
        })
    })
})




$(function () {
    $(".province ul li a").each(function () {
        $(this).click(function () {
//            $("#province").attr("disabled", "disabled");
            $("#city").removeAttr("disabled")
        })
    })
})


//$(function () {
//    $(".city ul li a").each(function () {
//        $(this).click(function () {
//            $("#province").removeAttr("disabled")
//            $("#city").attr("disabled", "disabled");
//        })
//    })
//})



$("#province").click(function () {
	var flag = $("#city_flag").css("display");
	if(flag != "none"){
		$("#city_flag").css("display","none");
	}
//    $("#city").removeAttr("disabled")
//    $("#province").attr("disabled", "disabled");
})

$("#city").click(function () {
	var value = $("input[name='province']").val();
	var flag = $("#province_flag").css("display");
	if(flag != "none"){
		$("#province_flag").css("display","none");
	}
//    $("#province").removeAttr("disabled")
//    $("#city").attr("disabled", "disabled");
})
