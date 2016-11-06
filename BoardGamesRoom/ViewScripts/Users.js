
function GetAllUsers() {
    jQuery.support.cors = true;
    $.ajax({
        url: 'api/users',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponseU(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function WriteResponseU(users) {
    var strResult = "<table><th>Nazwa użytkownika</th>";
    $.each(users, function (index, user) {
        strResult += "<tr><td>" + user.Login + "</td></tr>";
    });
    strResult += "</table>";
    $("#divBody").html(strResult);
}