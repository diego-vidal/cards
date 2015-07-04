$.blockUI.defaults.css = {
    padding: 0,
    margin: 0,
    width: '30%',
    top: '40%',
    left: '35%',
    textAlign: 'center',
    color: '#000',
    backgroundColor: '#fff',
    cursor: 'wait'
};

$(document)
    .ajaxStart($.blockUI({ message: '<img src="/Images/tsr.png" class="spin-infinite" alt="" height="100" width="100" />' }))
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

        $.blockUI({ message: '<img src="/Images/tsr.png" class="spin-infinite" alt="" height="100" width="100" />' })

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
        })
        .always(function () {
            $.unblockUI();
        });
    });

    $search.click(function () {

        $cardDetail.html("");
        var searchText = $searchText.val();

        $.blockUI({ message: '<img src="/Images/tsr.png" class="spin-infinite" alt="" height="100" width="100" />' })

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
        })
        .always(function () {
            $.unblockUI();
        });
    });

    $searchText.keypress(function (e) {

        var code = e.keycode ? e.keycode : e.which;

        if (code == 13) { //ENTER
            e.preventDefault();
            $search.click();
        }
    });

    $search.click();

});