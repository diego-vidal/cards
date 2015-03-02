$(document)
    .ajaxStart($.blockUI)
    .ajaxStop($.unblockUI);

$(document).ready(function () {

    var $reboot = $("#reboot");
    var $search = $("#search");
    var $searchText = $("#SearchText");
    var $cardList = $("#cardList");
    var $cardDetail = $("#cardDetail");

    $reboot.on("click", function () {
        window.location.href = "/Spellfire";
    });

    $cardList.on("click", "a.selectable", function () {

        var sequence = $(this).data("sequence");
        var searchText = $searchText.val();

        $.ajax({
            type: "GET",
            url: "Spellfire/Card/Details/" + sequence,
            data: { id: sequence, searchText: searchText },
            cache: false
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        })
        .done(function (html) {

            $cardDetail.html(html);
        });
    });

    $search.click(function () {

        $cardDetail.html("");
        var searchText = $searchText.val();

        $.ajax({
            type: "GET",
            url: "Spellfire/Card/List",
            data: { searchText: searchText },
            cache: true
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        })
        .done(function (html) {

            $cardList.html(html);
        });
    });

    $searchText.keypress(function (e) {

        var code = e.which;

        if (code == 13) { //ENTER
            e.preventDefault();
            $search.click();
        }
    });

    $search.click();

});