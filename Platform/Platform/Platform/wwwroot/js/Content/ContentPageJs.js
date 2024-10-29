lightGallery(document.getElementById('lightgallery'));


var swiper = new Swiper(".imgswiper", {
    slidesPerView: 3,
    spaceBetween: 10,
    freeMode: true,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
});

var totalpage = 0;
var shownpage = 10;
var numtotalpage = 0;

var id = document.getElementById('postid').innerHTML;
var postUserID = document.getElementById('postUserID').innerHTML;
var dbid = document.getElementById('dbid').innerHTML;
var typeName = document.getElementById('typeName').innerHTML;


$(function () {


    $.ajax({
        type: "POST",
        url: `/Ajax/GetComment_Data`,
        dataType: "json",
        data: {
            id: id
        },
        success: function (data) {
            GetData(data, "coment_data_list");
            totalpage = $("#coment_data_list .show").length;
            numtotalpage = totalpage / shownpage;
            $("#coment_data_list .show").slice(0, 10).show();

            initializePagination(numtotalpage, 3, 1);
        }
    })

    $("#search_btn").click(function () {

        var inputValue = $("#search").val();
        if (inputValue.length > 0) {
            window.location.href = `/Search/Search?value=${inputValue}`;
        }

    })

    function GetData(data, name) {


        $.each(data, function (x, y) {

            var frienddata = ``;
            var hellodata = ``;
            if (y.friend == true) {
                frienddata = `
				<a href="#" id="makefriend"><img src="/Img/Icon/friendIcon.png" style="width:16px;height:16px;" /> Friends<span style="color:red; margin-left:3px; text-decoration: none;">✓</span></a>
				`
            }
            else {
                frienddata = `
				<a href="/OtherProfile/MakeFriend?id=${postUserID}&&dbid=${dbid}&&type=${typeName}" id="makefriend"><img src="/Img/Icon/friendIcon.png" style="width:16px;" /> Friends</a>
				`
            }

            if (y.sayhello == true) {
                hellodata = `
				<a href="/OtherProfile/Hello?id=${postUserID}&&dbid=${dbid}&&type=${typeName}" id="sayhello"><img src="/Img/Icon/handIcon.png" style="width:20px;" /> Say Hello</a>
				`
            }
            else {
                hellodata = `
					<a href="#" id="sayhello">
						<img src="/Img/Icon/handIcon.png" style="width:20px;" />
						Say Hello
						<span style="color:red; margin-left:3px; text-decoration: none;">✓</span>
					</a>
				`
            }

            var same = ``;
            if (y.sameuser == false) {
                same = `
					<div class="row-type-community">
						<a href="/OtherProfile/Index?id=${postUserID}" target="_blank"><img src="/Img/Icon/HomefriendIcon.png" style="width:20px;" /> Profile</a>
						${frienddata}
					</div>
					<div class="row-type-community">
						${hellodata}
					</div>
				`
            }


            $("#" + name).append(`
				<div class="content-comment-body show">
					<div class="hr-title-comment_post"></div>

					<div class="showtitle-name-post">
						<div class="username">
							<p>Hoo Weng Chin</p>
							<div class="dais"></div>
						</div>
						<div class="time-name-post">
							<p>Published on ${y.date}</p>
							<div class="dais"></div>
						</div>
					</div>

					<div class="comment_post">

						<div class="left-comment_post">
							<div class="avatar" style="width:100px;">
								<img src="/Img/Avatar/${y.avatar}" />
							</div>
							<div class="level">
								<p class="name-position">${y.address}</p>
								<p class="exple">(<span class="me">${y.experience}</span> / <span class="all">${y.max}</span>)</p>
							</div>
							<div class="Tzi">
								<div>
									<p>Posts</p>
									<p>Friends</p>
								</div>
								<div>
									<p>${y.postcount}</p>
									<p>${y.friendcount}</p>
								</div>
							</div>
							<div class="community">
								${same}
							</div>
						</div>

						<div class="right-comment_post">
							<p class="text_info">
								<img src="/Img/Icon/SuperIcon.png" style="width:18px;" /> Don’t trust other
								people’s
								information easily, and be cautious about content that
								requires payment!
							</p>


							<section class="title-kf">${y.comment}</section>

						</div>

					</div>
				</div>

            `)
        })


    }

    $.ajax({
        type: "GET",
        url: `/Ajax/GetZoneLatestData`,
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

    function prevF(page) {
        $.ajax({
            type: "POST",
            url: `/Ajax/GetComment_Data`,
            dataType: "json",
            data: {
                id: id
            },
            success: function (data) {

                window.scrollTo('0', '0')
                $("#coment_data_list").empty();
                GetData(data, "coment_data_list");
                totalpage = $("#coment_data_list .show").length;
                numtotalpage = totalpage / shownpage;
                var startItem = (page - 1) * shownpage;
                var endItem = startItem + shownpage;

                $("#coment_data_list .show").slice(startItem, endItem).show();
            }
        })
    }

    function nextF(page) {
        $.ajax({
            type: "POST",
            url: `/Ajax/GetComment_Data`,
            dataType: "json",
            data: {
                id: id
            },
            success: function (data) {
                window.scrollTo('0', '0')
                $("#coment_data_list").empty();
                GetData(data, "coment_data_list");
                totalpage = $("#coment_data_list .show").length;
                numtotalpage = totalpage / shownpage;
                var startItem = (page - 1) * shownpage;
                var endItem = startItem + shownpage;
                $("#coment_data_list .show").slice(startItem, endItem).show();

            }
        })
    }

    function clickF(page) {
        $.ajax({
            type: "POST",
            url: `/Ajax/GetComment_Data`,
            dataType: "json",
            data: {
                id: id
            },
            success: function (data) {

                window.scrollTo('0', '0')
                $("#coment_data_list").empty();
                GetData(data, "coment_data_list");
                totalpage = $("#coment_data_list .show").length;
                numtotalpage = totalpage / shownpage;
                var startItem = (page - 1) * shownpage;
                var endItem = startItem + shownpage;
                $("#coment_data_list .show").slice(startItem, endItem).show();

            }
        })
    }

    function initializePagination(size, page, step) {


        var Pagination = {

            code: '',

            Extend: function (data) {
                data = data || {};
                Pagination.size = data.size || size;
                Pagination.page = data.page || 1;
                Pagination.step = data.step || 3;
            },

            Add: function (s, f) {
                for (var i = s; i < f; i++) {
                    Pagination.code += '<a class="back">' + i + '</a>';
                }
            },

            Last: function () {
                Pagination.code += '<i>...</i><a>' + Pagination.size + '</a>';
            },

            First: function () {
                Pagination.code += '<a class="back">1</a><i>...</i>';
            },


            Click: function () {
                Pagination.page = +this.innerHTML;


                clickF(Pagination.page);

                Pagination.Start();
            },

            Prev: function () {
                Pagination.page--;

                if (Pagination.page < 1) {
                    Pagination.page = 1;
                } else {
                    prevF(Pagination.page);
                    Pagination.Start();
                }
            },

            Next: function () {
                Pagination.page++;

                if (Pagination.page > Math.ceil(Pagination.size)) {
                    Pagination.page = Math.ceil(Pagination.size);
                } else {
                    nextF(Pagination.page);
                    Pagination.Start();
                }
            },

            Bind: function () {
                var a = Pagination.e.getElementsByTagName('a');
                for (var i = 0; i < a.length; i++) {
                    if (+a[i].innerHTML === Pagination.page) a[i].className = 'current';
                    a[i].addEventListener('click', Pagination.Click, false);
                }
            },

            // write pagination
            Finish: function () {
                Pagination.e.innerHTML = Pagination.code;
                Pagination.code = '';
                Pagination.Bind();
            },

            // find pagination type
            Start: function () {
                if (Pagination.size < Pagination.step * 2 + 6) {
                    Pagination.Add(1, Pagination.size + 1);
                }
                else if (Pagination.page < Pagination.step * 2 + 1) {
                    Pagination.Add(1, Pagination.step * 2 + 4);
                    Pagination.Last();
                }
                else if (Pagination.page > Pagination.size - Pagination.step * 2) {
                    Pagination.First();
                    Pagination.Add(Pagination.size - Pagination.step * 2 - 2, Pagination.size + 1);
                }
                else {
                    Pagination.First();
                    Pagination.Add(Pagination.page - Pagination.step, Pagination.page + Pagination.step + 1);
                    Pagination.Last();
                }
                Pagination.Finish();
            },


            Buttons: function (e) {
                var nav = e.getElementsByTagName('a');
                nav[0].addEventListener('click', Pagination.Prev, false);
                nav[1].addEventListener('click', Pagination.Next, false);
            },

            // create skeleton
            Create: function (e) {

                var html = [
                    '<a class="pn">&#9668; Previous</a>', // previous button
                    '<span></span>',  // pagination container
                    '<a class="pn">Next &#9658;</a>'  // next button
                ];

                e.innerHTML = html.join('');
                Pagination.e = e.getElementsByTagName('span')[0];
                Pagination.Buttons(e);
            },

            // init
            Init: function (e, data) {
                Pagination.Extend(data);
                Pagination.Create(e);
                Pagination.Start();
            }
        };


        var init = function () {
            Pagination.Init(document.getElementById('pagination'), {
                size: size, // pages size
                page: 1,  // selected page
                step: 3   // pages before and after current
            });
        };

        init();



    }







})



