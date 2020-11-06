var Show_album = function (modal) {
    document.getElementById(modal).requestFullscreen();
    $("#"+ modal).modal('show');
};
var Hidden_album = function (modal) {
    document.exitFullscreen();
    $("#" + modal).modal('hide');
};
$(document).ready(function () {
    if (document.fullscreenElement) {
        Hidden_album();
    }
});
document.addEventListener('fullscreenchange', (event) => {
    if (!document.fullscreenElement) {
        document.exitFullscreen();
    }
});