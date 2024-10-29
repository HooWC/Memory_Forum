$(function () {

    $.ajax({
        type: "GET",
        url: `/Ajax/GetLatestData`,
        dataType: "json",
        success: function (data) {
            GetLatestData(data, "right-top");
        }
    })

    function GetLatestData(data, name) {

        $.each(data, function (x, y) {

            $("#" + name).append(`
				<a href="/Content/PageTurn?id=${y.postId}&&type=${y.type}" class="right-container">
					<p class="right-container-xw">[Latest]</p>
					<p class="right-container-contain">${y.title}</p>
					<p class="right-container-date">${y.date}</p>
				</a>
            `)
        })
    }

    $("#search_btn").click(function () {

        var inputValue = $("#search").val();
        if (inputValue.length > 0) {
            window.location.href = `/Search/Search?value=${inputValue}`;
        }

    })

});

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


const items = document.querySelectorAll(".accordion button");

function toggleAccordion() {
    const itemToggle = this.getAttribute('aria-expanded');

    for (i = 0; i < items.length; i++) {
        items[i].setAttribute('aria-expanded', 'false');
    }

    if (itemToggle == 'false') {
        this.setAttribute('aria-expanded', 'true');
    }
}

items.forEach(item => item.addEventListener('click', toggleAccordion));

document.addEventListener("DOMContentLoaded", function () {
    var modal = document.getElementById("open-modal");
    var agreeBtn = document.getElementById("agree-btn");

    agreeBtn.addEventListener("click", function () {
        modal.style.display = "none";
    });
});

