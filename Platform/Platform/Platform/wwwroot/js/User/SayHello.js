$(function () {


    $.ajax({
        type: "GET",
        url: `/Ajax/GetSayHello_Data`,
        dataType: "json",
        success: function (data) {

            GetData(data, "sayhellotable");

        }
    })

    function GetData(data, name) {


        $.each(data, function (x, y) {

            $("#" + name).append(`
				<tr class="tr">
					<td class="img"><img src="/Img/Avatar/${y.avatar}" /></td>
					<td class="name">
						<p>${y.name}</p>
					</td>
					<td class="call">
						<p>${y.say}~</p>
					</td>
                    <td>
                        <p>${y.date}</p>
                    </td>
				</tr>
            `)


        })
    }



})