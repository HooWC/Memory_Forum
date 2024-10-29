$(function () {


    $.ajax({

        type: "GET",
        url: "/Ajax/Get_SignIn_Data",
        dataType: "json",
        success: function (data) {

            if (data != null) {
                GetData(data, "td_signIn_data");
            } else {
                GetData_Null(data, "td_signIn_data");
            }


        }





    })

    function GetData(data, name) {


        $.each(data, function (x, y) {

            var result = new Date(y.signInDate)
                .toLocaleString('en-GB', {
                    hour12: false,
                    hour: '2-digit',
                    minute: '2-digit',
                    year: 'numeric',
                    month: '2-digit',
                    day: '2-digit'
                })
                .replace(/\//g, '-');

            $("#" + name).append(`
				<tr>
					<td class="name-th">${y.username}</td>
					<td class="other-th">${y.continuous_check_day}</td>
					<td class="other-th">[LV.${y.level}]</td>
					<td class="other-th">${y.total_day}</td>
					<td class="other-th">${result}</td>
				</tr>
            `)


        })
    }

    function GetData_Null(data, name) {
        $("#" + name).append(`
				<tr>
					<td class="name-th">No Data</td>
					<td class="other-th">No Data</td>
					<td class="other-th">No Data</td>
					<td class="other-th">No Data</td>
					<td class="other-th">No Data</td>
				</tr>
            `)
    }


})