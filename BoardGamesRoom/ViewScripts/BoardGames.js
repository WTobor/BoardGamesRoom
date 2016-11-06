
function GetAllBoardGames() {
    jQuery.support.cors = true;
    $.ajax({
        url: 'api/boardGames',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponseBG(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function WriteResponseBG(boardGames) {
    var strResult = "<table><th>Nazwa gry</th>";
    $.each(boardGames, function (index, boardGame) {
        strResult += "<tr><td>" + boardGame.Name + "</td></tr>";
    });
    strResult += "</table>";
    $("#divBody").html(strResult);
}