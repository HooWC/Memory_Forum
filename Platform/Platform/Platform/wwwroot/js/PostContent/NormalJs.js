$(function () {

    var pagename = document.getElementById("pagename").innerHTML;

    var List = "";

    $("#typeData").val(List)
    $("#page").val(pagename)
    $("#stb").prop("disabled", true);


    $("#Discussion").change(function () {
        var x = document.getElementById("Discussion")
        if (x.checked) {
            $("#Discussion").prop("checked", true)
            List = $("#Discussion").val() + "|";
            $("#Sharing").prop("checked", false);
            $("#Info").prop("checked", false);
            $("#Notice").prop("checked", false);
        } else {
            $("#Discussion").prop("checked", false)
            List = List.replace("Discussion|", "");
        }
        Ck()
    })

    $("#Sharing").change(function () {
        var x = document.getElementById("Sharing")
        if (x.checked) {
            $("#Sharing").prop("checked", true)
            List = $("#Sharing").val() + "|";
            $("#Discussion").prop("checked", false);
            $("#Info").prop("checked", false);
            $("#Notice").prop("checked", false);
        } else {
            $("#Sharing").prop("checked", false)
            List = List.replace("Sharing|", "");
        }
        Ck()
    })

    $("#Info").change(function () {
        var x = document.getElementById("Info")
        if (x.checked) {
            $("#Info").prop("checked", true)
            List = $("#Info").val() + "|";
            $("#Discussion").prop("checked", false);
            $("#Sharing").prop("checked", false);
            $("#Notice").prop("checked", false);
        } else {
            $("#Info").prop("checked", false)
            List = List.replace("Info|", "");
        }
        Ck()
    })

    $("#Notice").change(function () {

        var x = document.getElementById("Notice")
        if (x.checked) {
            $("#Notice").prop("checked", true)
            List = $("#Notice").val() + "|";
            $("#Discussion").prop("checked", false);
            $("#Info").prop("checked", false);
            $("#Sharing").prop("checked", false);
        } else {
            $("#Notice").prop("checked", false)
            List = List.replace("Notice|", "");
        }
        Ck()
    })

    function Ck() {
        if (List == "") {
            console.log("a");
            $("#stb").prop("disabled", true);
            /*$("#stb").css("background", "#673ab7");*/
            $("#typeData").val(List)
            $("#page").val(pagename)
        }
        else if (List != "") {
            console.log("b");

            $("#stb").prop("disabled", false);
            /*$("#stb").css("background", "red");*/
            $("#typeData").val(List)
            $("#page").val(pagename)
        }
    }


})