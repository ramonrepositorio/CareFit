$(document).ready(function () {
    $("#trainning-print-cancel-button").click(function () {
        window.location = "/";
    });
    $("#trainning-print-confirm-button").click(function () {
        window.print();
    });
    
});
