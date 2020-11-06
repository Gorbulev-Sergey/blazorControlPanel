var _modal;

var Show_album = function (modal) {
    _modal = modal;
    document.getElementById(modal).requestFullscreen();
    $("#"+ modal).modal('show');
};
var Hidden_album = function (modal) {
    document.exitFullscreen();
    $("#" + modal).modal('hide');
};
$(document).on('fullscreenchange', function () {
    if (!document.fullscreenElement) {
        document.exitFullscreen();
        Hidden_album(_modal);
    }
});




var Show_Ask_remove_album = function (modal_remove) {
    $("#" + modal_remove).modal('show');
};
var Hide_Ask_remove_album = function (modal_remove) {
    $("#" + modal_remove).modal('hide');
}