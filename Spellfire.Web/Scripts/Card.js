var Spellfire = window.Spellfire = window.Spellfire || {};

Spellfire.Card =
    (function (module, $) {

        "use strict";

        // Public
        module.init = function () {

            self.initilizeVariables();
            self.attachHandlers();

            self.$search.click();
        };

        // Private
        var self = {

            initilizeVariables: function () {

                self.$logo = $("#logo");
                self.$container = $("#container");
                self.$search = $("#search");
                self.$searchText = $("#SearchText");
                self.$cardList = $("#cardList");
                self.$cardDetail = $("#cardDetail");
            },

            attachHandlers: function () {

                self.$logo.on("click", self.redirectHome);
                self.$search.click(self.getCardList);
                self.$cardList.on("click", "a.selectable", self.getCardDetails);
                self.$searchText.keypress(self.searchOnEnter);
            },

            redirectHome: function () {
                window.location.href = "/Spellfire";
            },

            getCardDetails: function () {

                var sequence = $(this).data("sequence");
                var searchText = self.$searchText.val();

                Spellfire.Notification.show();

                $.ajax({
                    type: "GET",
                    url: "Spellfire/Card/Details/",
                    data: { id: sequence, searchText: searchText },
                    cache: false
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                })
                .done(function (html) {
                    self.$cardDetail.html(html);
                })
                .always(function () {
                    Spellfire.Notification.hide();
                });
            },

            getCardList: function () {

                self.$cardDetail.html("");
                var searchText = self.$searchText.val();

                Spellfire.Notification.show();

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

                    self.$cardList.html(html);
                    self.selectFirstResult();
                })
                .always(function () {

                    Spellfire.Notification.hide();
                });
            },

            searchOnEnter: function (e) {

                var code = e.keycode ? e.keycode : e.which;

                if (code == 13) { //ENTER
                    e.preventDefault();
                    self.$search.click();
                }
            },

            selectFirstResult: function () {

                $("#cardResults .selectable").first().click();
            }
        };

        return module;

    })(Spellfire.Card || {}, window.jQuery);
