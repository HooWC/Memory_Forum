var id = document.getElementById('otherID').innerHTML;

$(function () {


    $.ajax({
        type: "POST",
        url: `/Ajax/GetOtherFriend_Data`,
        dataType: "json",
        data: {
            id: id
        },
        success: function (data) {
            GetData(data, "otherfriendlist");
        }
    })

    function GetData(data, name) {


        $.each(data, function (x, y) {

            var showdata = "";
            if (y.show) {
                showdata = `
                <td class="tall">
                    <a href="/OtherProfile/Index?id=${y.userid}" id="${y.id}" class="open_chai-data">View Profile</a>
                </td>
                `;
            }

            $("#" + name).append(`
				<tr class="tr">
					<td class="img"><img src="/Img/Avatar/${y.avatar}" /></td>
					<td class="name">
						<p>${y.name}</p>
					</td>
					<td class="gender">
						<p>${y.gender}</p>
					</td>
					<td class="callname">
						<p>${y.address}</p>
					</td>
					<td class="level">
						<p>${y.lv}</p>
					</td>
					${showdata}
				</tr>
            `)
        })

        $(".open_chai-data").click(function () {
            var cla = $(this).attr("id")

            var url = `/OtherProfile/Index?id=${cla}`;
            var target = "_blank";

            window.open(url, target);
        })



    }




})