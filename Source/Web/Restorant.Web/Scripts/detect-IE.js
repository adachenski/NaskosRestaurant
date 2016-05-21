var ua = window.navigator.userAgent;
var msie = ua.indexOf('MSIE '),
    trident = ua.indexOf('Trident/'),
    edge = ua.indexOf('Edge/');
if (edge > 0 || msie > 0 || trident > 0) {
    $('#ie-style').attr("href", "Content/IE.css");
    setTimeout(function () {
        $('.scroll').slideDown("slow");
    }, 6000);
}