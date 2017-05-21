var Spellfire = window.Spellfire || {};

Spellfire.Layout = (function (module, $) {
    "use strict";

    module.init = function () {
        self.initilizeVariables();
        self.attachHandlers();
    };

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
    };

    return module;

})(Spellfire.Layout || {}, window.jQuery);
