$(function (e) {
    $(".nav-list a").click(function () {
        if ($(this).parent().find("li").length == 0) {
            $(".nav-list li").removeClass("active");
            $(this).parent().addClass("active");
            if (!$(this).parent().parent().parent().hasClass("open")) {
                $(".nav-list li").filter('.open').children("ul").slideUp(200).parent().removeClass("open");
            } else {
                $(this).parent().parent().parent().addClass("active");
            }
        } else {
            if (!$(this).parent().hasClass("open")) {
                $(".nav-list li").filter('.open').children("ul").slideUp(200).parent().removeClass("open");
                $(this).parent().children("ul").slideDown(200);
                $(this).parent().addClass("open");
            } else {
                $(this).parent().children("ul").slideUp(200).parent().removeClass("open");
            }
        }
    });
});