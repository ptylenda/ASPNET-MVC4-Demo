var SlideShowModule = function ($) {
    var percentIncrement;
    var percentCurrent = 100;

    var init = function () {
        window.setInterval(function () {
            SlideShowModule.animate();
        }, 5000);
    };

    var animate = function () {
        var activeCard = $("#slide-show > div.active-card");
        if (!activeCard.length) {
            activeCard = $("#slide-show > div.slide-show-card").last();
        }

        var nextCard = activeCard.next();
        if (!nextCard.length) {
            nextCard = $("#slide-show > div.slide-show-card").first();
        }

        activeCard.addClass("last-active-card");
        nextCard.css({ opacity: 0.0 });
        nextCard.addClass("active-card");

        nextCard.animate(
            { opacity: 1.0 },
            2000,
            "linear",
            function () {
                activeCard.removeClass("active-card last-active-card");
            });
    };

    return {
        init: init,
        animate: animate
    }
} (jQuery);