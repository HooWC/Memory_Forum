$(function () {


    $.ajax({
        type: "GET",
        url: `/Ajax/GetPortList_Data`,
        dataType: "json",
        success: function (data) {
            GetData(data, "userpostlist");
        }
    })

    function GetData(data, name) {


        $.each(data, function (x, y) {

            var img = "";
            if (y.img == true) {
                img = `<img src="/Img/pictureIcon.png" alt="a" title="picture" />`
            }

            var word = "";
            if (y.color.includes("black")) {
                word = `<a href="/Content/PageTurn?id=${y.postId}&&type=${y.typeMain}"
								   class="xst" style="color:rgb(82, 82, 82);"
								   onmouseover="this.style.textDecoration='underline rgb(82, 82, 82)';"
									onmouseout="this.style.textDecoration='none';"
								   >[${y.postType}] ${y.title}</a>${img}`;

            } else if (y.color.includes("blue")) {
                word = `<a href="/Content/PageTurn?id=${y.postId}&&type=${y.typeMain}"
								   class="xst" style="color:rgb(42, 108, 229);"
								   onmouseover="this.style.textDecoration='underline rgb(42, 108, 229)';"
									onmouseout="this.style.textDecoration='none';"
								   >[${y.postType}] ${y.title}</a>${img}`;
            } else if (y.color.includes("green")) {
                word = `<a href="/Content/PageTurn?id=${y.postId}&&type=${y.typeMain}"
								   class="xst" style="color:rgb(12, 189, 95);"
								   onmouseover="this.style.textDecoration='underline rgb(12, 189, 95)';"
									onmouseout="this.style.textDecoration='none';"
								   >[${y.postType}] ${y.title}</a>${img}`;
            } else if (y.color.includes("orange")) {
                word = `<a href="/Content/PageTurn?id=${y.postId}&&type=${y.typeMain}"
								   class="xst" style="color:rgb(237, 154, 21);"
								   onmouseover="this.style.textDecoration='underline rgb(237, 154, 21)';"
									onmouseout="this.style.textDecoration='none';"
								   >[${y.postType}] ${y.title}</a>${img}`;
            }

            data = `
					<tr>
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


})