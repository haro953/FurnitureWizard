$(document).ready(function () {
    // jQuery methods go here...

    $(window).scroll(function () {
        if ($(this).scrollTop() >= 100) {
            $('.backtotop').fadeIn(200);
        }
        else {
            $('.backtotop').fadeOut(200);
        }
    });

    $('.backtotop').click(function () {
        $('body,html').animate({
            scrollTop: 0
        }, 500);
        return false;
    });
});