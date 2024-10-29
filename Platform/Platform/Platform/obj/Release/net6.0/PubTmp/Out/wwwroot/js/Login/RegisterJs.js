var username = false;
var password = false;
var phone = false;
var email = false;
var answer = false;

var code = false;

if (username == false || password == false || phone == false || email == false || answer == false || code == false) {
    $("#stb").prop("disabled", true)
}

$(function () {

    $("#username").keyup(function () {

        $.ajax({

            type: "POST",
            url: "/Ajax/Checking_username_Register",
            dataType: "json",
            data: {
                username: $(this).val()
            },
            success: function (data) {

                if (data == true) {
                    $(this).css("border", "2px solid green")
                    $("#username-error").html("")
                    username = true
                } else if (data == false) {
                    $(this).css("border", "2px solid red")
                    $("#username-error").html("")
                    username = false
                } else if (data == "more") {
                    $(this).css("border", "2px solid red")
                    $("#username-error").html("Must be more than 5 digits")
                    username = false
                }
                else if (data == "Repeat") {
                    $(this).css("border", "2px solid red")
                    $("#username-error").html("This username is already in use")
                    username = false
                }

                sub(username, password, phone, email, answer, code)

            }
        })

        if ($(this).val() == "") {
            $(this).css("border", "2px solid red")
            username = false
        }
        else {
            $(this).css("border", "2px solid green")
            username = true
        }
        sub(username, password, phone, email, answer, code)
    })

    $("#password").keyup(function () {

        $.ajax({

            type: "POST",
            url: "/Ajax/Checking_Password_Register",
            dataType: "json",
            data: {
                password: $(this).val()
            },
            success: function (data) {

                if (data == true) {
                    $("#password").css("border", "2px solid green")
                    $("#password-error").html("")
                    password = true
                } else if (data == false) {
                    $("#password").css("border", "2px solid red")
                    $("#password-error").html("")
                    password = false
                } else if (data == "Repeat") {
                    $("#password").css("border", "2px solid red")
                    $("#password-error").html("Must be more than 8 characters")
                    password = false
                }

                sub(username, password, phone, email, answer, code)

            }
        })

    })

    $("#gmail").keyup(function () {

        $.ajax({

            type: "POST",
            url: "/Ajax/Checking_Email_Registerl",
            dataType: "json",
            data: {
                email: $(this).val()
            },
            success: function (data) {

                if (data == true) {
                    $("#gmail").css("border", "2px solid green")
                    $("#email-error").html("")
                    email = true
                } else if (data == false) {
                    $("#gmail").css("border", "2px solid red")
                    $("#email-error").html("")
                    email = false
                } else if (data == "Repeat") {
                    $("#gmail").css("border", "2px solid red")
                    $("#email-error").html("Email has been used")
                    email = false
                }

                sub(username, password, phone, email, answer, code)
            }
        })


    })

    $("#vcode").click(function () {

        var codedata = $("#gmail").val();
        if (email == true) {
            $.ajax({

                type: "POST",
                url: "/Ajax/Post_Email_Code",
                dataType: "json",
                data: {
                    email: codedata
                },
                success: function (data) {

                    if (data == true) {
                        $("#hiddenGmail").val($("#gmail").val());
                        $("#gmail").prop("disabled", true)
                    }

                }
            })
        }




    })

    $("#code").keyup(function () {

        $.ajax({

            type: "POST",
            url: "/Ajax/Checking_Code_Registerl",
            dataType: "json",
            data: {
                vercode: $(this).val()
            },
            success: function (data) {

                if (data == true) {
                    $("#code").css("border", "2px solid green")
                    code = true
                } else if (data == false) {
                    $("#code").css("border", "2px solid red")
                    code = false
                }

                sub(username, password, phone, email, answer, code)
            }
        })


    })

    $("#phone").keyup(function () {
        if ($(this).val() == "") {
            $(this).css("border", "2px solid red")
            $("#phone-error").html("")
            phone = false
        }
        else if (containsLetter($(this).val())) {
            $(this).css("border", "2px solid red")
            $("#phone-error").html("Cannot contain letters")
            phone = false
        }
        else if ($(this).val().length < 10) {
            $(this).css("border", "2px solid red")
            $("#phone-error").html("Please enter the correct phone number")
            phone = false
        }
        else if (!isMalaysianPhoneNumber($(this).val())) {
            $(this).css("border", "2px solid red")
            $("#phone-error").html("Please enter the correct phone number")
            phone = false
        }
        else {
            $(this).css("border", "2px solid green")
            $("#phone-error").html("")
            phone = true
        }

        sub(username, password, phone, email, answer, code)
    })

    $("#security_question_answers").keyup(function () {
        if ($(this).val() == "") {
            $(this).css("border", "2px solid red")
            answer = false
        }
        else {
            $(this).css("border", "2px solid green")
            answer = true
        }

        sub(username, password, phone, email, answer, code)
    })



})

function isMalaysianPhoneNumber(phoneNumber) {
    var malaysiaPhonePattern = /^(01[0-9]{1}|011[0-9]{2})[0-9]{7,8}$/;

    return malaysiaPhonePattern.test(phoneNumber);
}

function containsLetter(text) {
    var letterPattern = /[a-zA-Z]/;

    return letterPattern.test(text);
}

function sub(username, password, phone, email, answer, code) {

    if (username == false || password == false || phone == false || email == false || answer == false || code == false) {
        $("#stb").prop("disabled", true)
    }
    else if (username == true && password == true && phone == true && email == true && answer == true && code == true) {
        $("#stb").prop("disabled", false)
    }
}