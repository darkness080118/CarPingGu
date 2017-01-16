function SelfAdaption() {
    var htmlwidth = $("html").width();
    if(htmlwidth >= 640) {
        $("html").css({
            "font-size": "40px"
        });
        $(".wrap, .header, .footer").css({
            "width": "640px"
        });
        $(".brand_1 ,.cars_1 ,.car_1").css({
            "width": "650px",
            "left": " -11em !important;"
        });
    }
    else {
        if(htmlwidth <= 320) {
            $("html").css({
                "font-size": "20px"
            });
            $(".wrap").css({
                "width": "320px"
            });
            $(".brand_1 ,.cars_1 ,.car_1").css({
                "width": htmlwidth + 35 + "px",
                "left": " -7em !important;"
            });
        }else {
            if (htmlwidth <= 400 &&htmlwidth > 320) {
                $("html").css({
                    "font-size": "20px"
                });
                $(".wrap").css({
                    "width": htmlwidth
                });
                $(".brand_1 ,.cars_1 ,.car_1").css({
                    "width": htmlwidth + 27 + "px",
                    "left": " -7em !important;"
                });
            }

        else {
                $("html").css({
                    "font-size": htmlwidth * 40 / 640 + "px"
                });
                $(".wrap, .header, .footer").css({
                    "width": htmlwidth
                });
                $(".brand_1 ,.cars_1 ,.car_1").css({
                    "width": htmlwidth + 17 + "px",
                    "left": " -7em !important;"
                });
            }
    }
}
}SelfAdaption();
$(window).resize(function() {
    SelfAdaption();
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

function brandBtn() {
    var brandID = $("#brandID").val();
    if (brandID != "请选择品牌") {
        document.getElementById('carsID').disabled = false;
        document.getElementById('carID').disabled = false;
    }
    else {
        document.getElementById('carsID').disabled = true;
        document.getElementById('carID').disabled = true
    }
}

