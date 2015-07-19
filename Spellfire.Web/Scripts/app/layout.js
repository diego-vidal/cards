var Spellfire = window.Spellfire || {};

Spellfire.Layout =
    (function (module, $) {

        "use strict";

        // Public
        module.init = function () {

            self.initilizeVariables();
            self.attachHandlers();
        };

        // Private
        var self = {

            initilizeVariables: function () {

                self.$logo = $("#logo");
            },

            attachHandlers: function () {

                self.$logo.on("click", self.redirectHome);
            },

            redirectHome: function () {
                window.location.href = "/";
            },

            //displayError: function (message) {

            //    if (message) {
            //        self.$errorMessage.html(message);
            //        self.$errorMessage.removeClass("hidden");
            //    }
            //},
        };

        return module;

    })(Spellfire.Layout || {}, window.jQuery);
