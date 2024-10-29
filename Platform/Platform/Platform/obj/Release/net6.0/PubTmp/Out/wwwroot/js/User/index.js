$(function () {

    $("#avatar_update_btn").prop("disabled", true);

})

function chooseImg(file) {
    var selectedFile = file.files[0];

    if (selectedFile) {
        var reader = new FileReader();

        reader.readAsDataURL(selectedFile);

        reader.onload = function () {
            var img = document.getElementById("img");
            img.src = this.result;
        };

        document.getElementById("avatar_update_btn").disabled = false;
    } else {
        document.getElementById("avatar_update_btn").disabled = true;
    }
}