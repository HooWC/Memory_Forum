$(function () {

    $("#avatar_update_btn").prop("disabled", true);

    $.ajax({
        type: "GET",
        url: `/Ajax/GetFriend_Data`,
        dataType: "json",
        success: function (data) {
            GetData(data, "friendlist");
        }
    })

    $.ajax({
        type: "GET",
        url: `/Ajax/GetFriendRequired_Data`,
        dataType: "json",
        success: function (data) {
            GetRequiredData(data, "friendRequiredlist");
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
					<td class="gender">
						<p>${y.gender}</p>
					</td>
					<td class="callname">
						<p>${y.address}</p>
					</td>
					<td class="level">
						<p>${y.lv}</p>
					</td>
					<td class="tall">
						<p class="open_chai-data">Message (Developing)</p>
					</td>
					<td class="status">
						<p id="${y.id}" class="delete">Delete Friend</p>
					</td>
				</tr>
            `)
        })

        $(".delete").click(function () {
            var cla = $(this).attr("id")

            $.ajax({
                type: "POST",
                url: `/Ajax/RejectFriend`,
                dataType: "json",
                data: {
                    id: cla
                },
                success: function (data) {
                    $("#friendlist").empty();
                    GetData(data, "friendlist");
                }
            })
        })



    }

    function GetRequiredData(data, name) {


        $.each(data, function (x, y) {

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
					<td class="tall">
						<p id="${y.id}" class="accept">Accept Request</p>
					</td>
					<td class="status">
						<p id="${y.id}" class="reject">Reject Friend</p>
					</td>
				</tr>
            `)

        })

        $(".accept").click(function () {
            var cla = $(this).attr("id")

            $.ajax({
                type: "POST",
                url: `/Ajax/AcceptFriend`,
                dataType: "json",
                data: {
                    id: cla
                },
                success: function (data) {
                    $("#friendRequiredlist").empty();
                    GetRequiredData(data, "friendRequiredlist");
                    GetNewData();
                }
            })




        })

        $(".reject").click(function () {
            var cla = $(this).attr("id")

            $.ajax({
                type: "POST",
                url: `/Ajax/RejectFriend`,
                dataType: "json",
                data: {
                    id: cla
                },
                success: function (data) {
                    $("#friendRequiredlist").empty();
                    GetRequiredData(data, "friendRequiredlist");
                    GetNewData();
                }
            })
        })


    }

    function GetNewData() {
        $.ajax({
            type: "GET",
            url: `/Ajax/GetFriend_Data`,
            dataType: "json",
            success: function (data) {
                console.log(12121212121212);
                $("#friendlist").empty();
                GetData(data, "friendlist");
            }
        })
    }




})