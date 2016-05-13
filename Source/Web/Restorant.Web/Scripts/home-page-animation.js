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
            }, 10000);

            $window.scroll(function () {
                if ($window.scrollTop() >= distance && $window.width() > 1700) {
                    console.log($window.width())
                    $('.scroll').slideDown("slow");

                }
                else {
                    $('.scroll').slideUp("slow");
                }
            });
        })