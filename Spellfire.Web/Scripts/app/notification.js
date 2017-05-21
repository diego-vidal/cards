var Spellfire = window.Spellfire || {};

Spellfire.Notification = (function (module, $) {
    "use strict";

    module.init = function () {
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
    };

    module.show = function (htmlMessage) {
        if (!htmlMessage) {
            htmlMessage = '<img src="/Images/worlds/tsr.png" class="spin-infinite" alt="" height="100" width="100" />';
        }
        $.blockUI({ message: htmlMessage })
    };

    module.hide = function () {
        $.unblockUI();
    };

    var self = {
    };

    return module;

})(Spellfire.Notification || {}, window.jQuery);
