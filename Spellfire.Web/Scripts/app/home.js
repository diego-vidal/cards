var Spellfire = window.Spellfire || {};

Spellfire.Home = (function (module, $) {
    "use strict";

    module.init = function () {
        self.initilizeVariables();
        self.attachHandlers();
        self.$search.click();
    };

    var self = {

        initilizeVariables: function () {
            self.$container = $("#container");
            self.$includeOnlineBoosters = $("#includeOnlineBoosters");
            self.$includeOnlineBoostersLabel = $("#includeOnlineBoostersLabel");
            self.$search = $("#search");
            self.$searchText = $("#SearchText");
            self.$errorMessage = $("#errorMessage");
            self.$cardList = $("#cardList");
            self.$cardDetail = $("#cardDetail");
            self.$storedSelections = amplify.store();
            self.renderPreviousSelections();
        },

        attachHandlers: function () {
            self.$container.on("click", ".btn-sequence", self.getCardDetails);
            self.$search.click(self.getCardList);
            self.$includeOnlineBoostersLabel.click(function () {
                self.$includeOnlineBoosters.trigger("click");
            });
            self.$cardList.on("click", "a.selectable", self.getCardDetails);
            self.$searchText.keypress(self.searchOnEnter);
            self.$searchText.click(function () {
                $(this).select();
            });
        },

        renderPreviousSelections: function () {
            self.$searchText.val(self.$searchText.val() || self.$storedSelections.searchText || "spellfire");
            self.$includeOnlineBoosters.prop('checked', self.$storedSelections.includeOnlineBoosters);
        },

        displayError: function (message) {
            if (message) {
                self.$errorMessage.html(message);
                self.$errorMessage.removeClass("hidden");
            }
        },       
        
        hideError: function () {
            self.$errorMessage.addClass("hidden");
        },

        getCardList: function () {
            self.hideError();

            var searchText = self.$searchText.val();
            if (!searchText) {
                return;
            }

            var includeOnlineBoosters = self.$includeOnlineBoosters.is(":checked");

            amplify.store("searchText", searchText);
            amplify.store("includeOnlineBoosters", includeOnlineBoosters);

            self.$cardDetail.html("");

            Spellfire.Notification.show();

            $.ajax({
                type: "GET",
                url: "Card/List",
                data: { search: searchText, includeOnlineBoosters: includeOnlineBoosters },
                cache: true
            })
            .done(function (result) {
                if (result.hasMessage) {
                    self.displayError(result.message);
                    return;
                }
                self.$cardList.html(result);
                self.selectCard(self.$storedSelections.sequence);
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                self.displayError(errorThrown);
            })
            .always(function () {
                Spellfire.Notification.hide();
            });
        },

        getCardDetails: function () {
            var sequence = $(this).data("sequence");

            amplify.store("sequence", sequence);

            $.ajax({
                type: "GET",
                url: "Card/Details/",
                data: { id: sequence },
                datatype: 'json',
                cache: true
            })
            .done(function (result) {
                if (result.hasMessage) {
                    self.displayError(result.message);
                    return;
                }

                self.$cardDetail.html(result);
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                self.displayError(errorThrown);
            })
            .always(function () {
                Spellfire.Notification.hide();
            });
        },

        searchOnEnter: function (e) {
            var code = e.keycode ? e.keycode : e.which;

            if (code === 13) { //ENTER
                e.preventDefault();
                self.$search.click();
            }
        },

        selectCard: function (sequence) {
            var cardSelected = $('#cardResults [data-sequence="' + sequence + '"]');

            if (cardSelected.length) {
                cardSelected.click();
                return;
            }

            // Otherwise select first card
            $("#cardResults .selectable").first().click();
        }
    };

    return module;

})(Spellfire.Home || {}, window.jQuery);
