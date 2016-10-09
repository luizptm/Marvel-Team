$(document).ready(function () {
    $('#sel1').click(function () {
        var personagem = $("#ListBox1 option:selected").text();
        var text = "<span id='personagem'>" + personagem + "</span>";
        var key = $("#ListBox1").val();
        var img = getImage(key);
        $("#listaSelecionada").append(text);
        var selecionados = $("#selecionados").val() + "-" + product;
        $("#selecionados").append(selecionados);
    });
});
function getImage(key) {
    var img = "";
    var url = "http://gateway.marvel.com:80/v1/public/characters/" + key + "?apikey=6d208f29a49730c185d8ebb6ed1363c7";
    $.getJSON(url, {
        tagmode: "any", format: "json"
    }).done(function (data) {
        $.each(data.items, function (i, item) {
            img = $("<img>").attr("src", item.results.thumbnail.path + "." + item.results.thumbnail.extension);
        });
    });
    return img;
}

function getCharacters() {
    var request = $.ajax({ url: "", type: "GET", data: {} });
    request.done(function (data) {
        $("#state").html("");
        $("#state").append(data);
        $("#state").show();
        $("#divError").html("");
    });
    request.fail(function (jqXHR, textStatus) {
        $("#divError").html("<pan style='display: none;'>Request failed in 'getCharacters'</span>");
        $("#divError").append(msgError);
    });
}

function showWinners(key) {
    var img = "";
    var url = "http://gateway.marvel.com:80/v1/public/characters/" + key + "?apikey=6d208f29a49730c185d8ebb6ed1363c7";
    $.getJSON(url, {
        tagmode: "any", format: "json"
    }).done(function (data) {
        $.each(data.items, function (i, item) {
            img = $("<img>").attr("src", item.results.thumbnail.path + "." + item.results.thumbnail.extension);
        });
    });
    return img;
}