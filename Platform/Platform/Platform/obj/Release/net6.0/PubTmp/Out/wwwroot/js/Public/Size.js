var warning = document.getElementById('warning');
var content_id = document.getElementById('content_id');
var initialZoom = window.innerWidth / window.outerWidth;

content_id.style.display = 'none';

var swiper = new Swiper(".mySwiper", {
    spaceBetween: 30,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    autoplay: {
        delay: 2000,
    },
});

var swiper = new Swiper(".mySwiper-vertical", {
    direction: "vertical",
    autoplay: {
        delay: 4000,
    },
});

var swiper = new Swiper(".mySwiper-game", {
    slidesPerView: 3,
    spaceBetween: 30,
    freeMode: true,
    autoplay: {
        delay: 1000,
    },

});


var scrollTopButton = document.getElementById("scrolltop");

if (scrollTopButton) {
    window.onscroll = function () {
        var scrollHeight = window.pageYOffset || document.documentElement.scrollTop;

        if (scrollHeight >= 150) {
            scrollTopButton.style.display = "block";
        } else {
            scrollTopButton.style.display = "none";
        }
    };

    scrollTopButton.onclick = function () {
        window.scrollTo({ top: 0, behavior: "smooth" });
    };
}

window.addEventListener('resize', function () {

    var currentZoom = window.innerWidth / window.outerWidth;

    /*var zoomThreshold = 1.4;*/
    var zoomThreshold1 = 1.5; // 50%
    var zoomThreshold2 = 0.7; // 150%

    if (currentZoom >= zoomThreshold1) {

        warning.style.display = 'block';
        content_id.style.display = 'none';
    } else if (currentZoom <= zoomThreshold2) {

        warning.style.display = 'block';
        content_id.style.display = 'none';
    } else {
        warning.style.display = 'none';
        content_id.style.display = 'block';
    }
});

document.addEventListener("DOMContentLoaded", function () {
    var zoomThreshold1 = 1.5; // 50%
    var zoomThreshold2 = 0.7; // 150%

    //console.log("initialZoom=" + initialZoom);
    //console.log("zoomThreshold1=" + zoomThreshold1);

    //if (initialZoom != Infinity && initialZoom >= zoomThreshold1) {
    //    console.log(11);
    //    warning.style.display = 'block';
    //    content_id.style.display = 'none';
    //} else if (initialZoom <= zoomThreshold2) {
    if (initialZoom <= zoomThreshold2) {
        /*console.log(12);*/
        warning.style.display = 'block';
        content_id.style.display = 'none';
    } else {
        /*console.log(123);*/
        warning.style.display = 'none';
        content_id.style.display = 'block';
    }

});

