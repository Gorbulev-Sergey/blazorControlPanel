var Show_album = function (modal) {
    document.getElementById(modal).requestFullscreen();
    //$("#"+ modal).modal('show');
};
var Hidden_album = function (modal) {
    document.exitFullscreen();
    //$("#" + modal).modal('hide');
};
$(document).on('fullscreenchange', function () {
    if (!document.fullscreenElement) {
        Hidden_album();
    }
});