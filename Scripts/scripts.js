function UserLoginModel() {
    this.Username = "";
    this.Password = "";
}
var currentIndex = 1;
var totalCount = 3;

setInterval(function () {
    if (currentIndex > totalCount)
        currentIndex = 1;

    $('body').css('background-image', 'url(/Images/' + currentIndex + '.jpg)');
    currentIndex++
}, 15000);

window.onload = function () {
    var error = window.location.search.indexOf("error=true");
    if (error > -1) {
        if (window.location.search.indexOf("tab=login") > -1) {            
            $("#loginError").show();
            
        }
        else {
            $("#registerError").show();
            toRegisterTab();            
        }
    }    
}

function loginUser()
{
    $.ajax({
        type: "GET",
        url: "Index.aspx/Test",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.hasOwnProperty("d")) {
                data = data.d;
            }
            document.getElementById("loginError").textContent = JSON.stringify(data);
        },
        error: function (data) { alert("fail"); }
    });
    var user = new UserLoginModel();
    user.Username = $("#username").val();
    user.Password = $("#password").val();
    var jsonUser = JSON.stringify({ user: user });
    $.ajax({
        type: "POST",
        url: "Index.aspx/Login",
        contentType: "application/json; charset=utf-8",
        data: jsonUser,
        dataType:"json",
        success: function (message) {
            if (data.hasOwnProperty("d")) {
                data = data.d;
                $("#loginError").textContent = message;
            }            
        },
        error: function (data) { alert("fail"); }
    });
}

function changeColor() {
    document.getElementById("securityQuestion").style.color = "#333";
}

function removeHighlightIcon() {
    document.getElementById("selectIcon").style.background = "#ddd";
}
function highlightIcon() {
    document.getElementById("selectIcon").style.background = "#333";
    document.getElementById("selectIcon").style.outline = "none";
}
function toRegisterTab() {
    document.getElementById("login").checked = false;
    document.getElementById("register").checked = true;
}