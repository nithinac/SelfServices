function registerUser() {
    alert("ol");
    $("registerErrorMsg").show()
    var customerId = $("customerid").val();
    var username = $("#username").val();
    var password = $("password").val();
    var securityQuestion = $("secQuestion").val();
    var securityAnswer = $("secAnswer").val();
    $.ajax(
        {
            type: "post",
            url: "/Pages/Register.aspx/CheckAvailability",
            data: { customerId: customerId, username: username, password: password, securityQuestion: securityQuestion, securityAnswer: securityAnswer },
            success: function (redirectUrl) {                
                
                    $("registerErrorMsg").show()
                
            },
            error: function () {                
                $("registerErrorMsg").show()
            }

        });
}