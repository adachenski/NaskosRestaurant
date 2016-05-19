/// <reference path="home-page-animation.js" />
  $(document).ready(function () {

            var distance = $('.container').offset().top,
            $window = $(window);
    
            var closeBtn = $('#close-button');
            var chefAnim = $('#chef-add');
            closeBtn.on('click', function () {

                chefAnim.css("display", "none");

            })

            setTimeout(function () {
                chefAnim.animate({ "left": "0" }, "slow")
            }, 20000);
            if ($window.width() < 768) {
                //reset video src without removing it
                $("#video-background").first().attr('src', '')

            }
            $window.scroll(function () {
                
                if ($window.scrollTop() >= distance && $window.width() > 1700) {
                    $('.scroll').slideDown("slow");
                }
                else {
                    $('.scroll').slideUp("slow");
                }
            });
        })