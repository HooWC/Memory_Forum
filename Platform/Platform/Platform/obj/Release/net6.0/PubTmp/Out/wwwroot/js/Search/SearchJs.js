var value = document.getElementById("value");
console.log(value.innerHTML)

var totalpage = 0;
var shownpage = 16;
var numtotalpage = 0;

$(function () {


    $.ajax({
        type: "POST",
        url: `/Ajax/GetSearchData`,
        dataType: "json",
        data: {
            value: value.innerHTML
        },
        success: function (data) {

            if (data == false) {
                $(".click-function").css("display", "none");
                GetNothing(data, "tbody_t1");
            }
            else {
                GetData(data, "tbody_t1");
                totalpage = $("#tbody_t1 .show").length;
                numtotalpage = totalpage / shownpage;
                $("#tbody_t1 .show").slice(0, 16).show();

                initializePagination(numtotalpage, 3, 1);
            }

        }
    })

    $("#search_btn").click(function () {

        var inputValue = $("#search").val();
        if (inputValue.length > 0) {
            window.location.href = `/Search/Search?value=${inputValue}`;
        }

    })

})

function prevF(page) {
    $.ajax({
        type: "POST",
        url: `/Ajax/GetAllTypeData`,
        dataType: "json",
        data: {
            Type: Type.innerHTML
        },
        success: function (data) {

            window.scrollTo('0', '0')
            $("#tbody_t1").empty();
            GetData(data, "tbody_t1");
            totalpage = $("#tbody_t1 .show").length;
            numtotalpage = totalpage / shownpage;
            var startItem = (page - 1) * shownpage;
            var endItem = startItem + shownpage;

            $("#tbody_t1 .show").slice(startItem, endItem).show();
        }
    })
}

function nextF(page) {
    $.ajax({
        type: "POST",
        url: `/Ajax/GetAllTypeData`,
        dataType: "json",
        data: {
            Type: Type.innerHTML
        },
        success: function (data) {

            window.scrollTo('0', '0')
            $("#tbody_t1").empty();
            GetData(data, "tbody_t1");
            totalpage = $("#tbody_t1 .show").length;
            numtotalpage = totalpage / shownpage;
            var startItem = (page - 1) * shownpage;
            var endItem = startItem + shownpage;
            $("#tbody_t1 .show").slice(startItem, endItem).show();

        }
    })
}

function clickF(page) {
    $.ajax({
        type: "POST",
        url: `/Ajax/GetAllTypeData`,
        dataType: "json",
        data: {
            Type: Type.innerHTML
        },
        success: function (data) {

            window.scrollTo('0', '0')
            $("#tbody_t1").empty();
            GetData(data, "tbody_t1");
            totalpage = $("#tbody_t1 .show").length;
            numtotalpage = totalpage / shownpage;
            var startItem = (page - 1) * shownpage;
            var endItem = startItem + shownpage;
            $("#tbody_t1 .show").slice(startItem, endItem).show();

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

function GetData(data, name) {
    $.each(data, function (x, y) {

        var img = "";
        if (y.img == true) {
            img = `<img src="/Img/pictureIcon.png" alt="a" title="picture" />`
        }

        var word = "";
        if (y.color.includes("black")) {
            word = `<a href="/Content/PageTurn?id=${y.postId}&&type=${y.typedata}"
								   class="xst" style="color:rgb(82, 82, 82);"
								   onmouseover="this.style.textDecoration='underline rgb(82, 82, 82)';"
									onmouseout="this.style.textDecoration='none';"
								   >[${y.postType}] ${y.title}</a>${img}`;

        } else if (y.color.includes("blue")) {
            word = `<a href="/Content/PageTurn?id=${y.postId}&&type=${y.typedata}"
								   class="xst" style="color:rgb(42, 108, 229);"
								   onmouseover="this.style.textDecoration='underline rgb(42, 108, 229)';"
									onmouseout="this.style.textDecoration='none';"
								   >[${y.postType}] ${y.title}</a>${img}`;
        } else if (y.color.includes("green")) {
            word = `<a href="/Content/PageTurn?id=${y.postId}&&type=${y.typedata}"
								   class="xst" style="color:rgb(12, 189, 95);"
								   onmouseover="this.style.textDecoration='underline rgb(12, 189, 95)';"
									onmouseout="this.style.textDecoration='none';"
								   >[${y.postType}] ${y.title}</a>${img}`;
        } else if (y.color.includes("orange")) {
            word = `<a href="/Content/PageTurn?id=${y.postId}&&type=${y.typedata}"
								   class="xst" style="color:rgb(237, 154, 21);"
								   onmouseover="this.style.textDecoration='underline rgb(237, 154, 21)';"
									onmouseout="this.style.textDecoration='none';"
								   >[${y.postType}] ${y.title}</a>${img}`;
        }

        var data = `
					<tr class="show">
							<td class="icn"><a href="#" target="_blank"><img src="/Img/cusfileIcon.png" /></a></td>
							<td class="p_pre_td">&nbsp;</td>
							<th class="lock">
							${word}
							</th>
								
							<td class="by">
								<p><a href="space-uid-5.html" c="1">${y.username}</a></p>
								<p><span>${y.date_post}</span></p>
							</td>

							<td class="num">
								<p class="xi2 ppop"><img src="/Img/viewIcon.png" style="width:15px;"/></p>
								<p>${y.view}</p>
							</td>

							<td class="by">
								<p>
								<p class="ppop" c="1"><img src="/Img/commentIcon.png" style="width:15px;"/></p>
								</p>
								<p>
								<p>${y.comment}</p>
								</p>
							</td>

						</tr>
				`

        $("#" + name).append(`
                ${data}
            `)

    })

}

function GetNothing(data, name) {

    $("#" + name).append(`
       <tr style="border:none;">
           <td>
               <img style="margin: 30px auto;display: flex;justify-content: center;" src="/Img/Icon/nothingIcon.png">
           </td>
       </tr>
    `)

}