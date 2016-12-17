
function GetAllStatistics() {
    jQuery.support.cors = true;
    $.ajax({
        url: 'api/statistics',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponseS(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function WriteResponseS(statistics) {
    var strResult = "<table class='col-sm-8'><tr><th>Zwycięzca</th><th>Nazwa</th><th>Ostatnio</th></tr>";
    $.each(statistics, function (index, statistics) {
        strResult += "<tr><td>" + statistics.Plays[0].Winner + "</td>"
        strResult += "<td>" + statistics.Plays[0].BoardGameID + "</td>"
        strResult += "<td>" + statistics.Plays[0].Date + "</td></tr>";
    });
    strResult += "</table>";
    $("#divBody").html(strResult);
}