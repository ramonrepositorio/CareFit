$(document).ready(function () {
    $("#open-print-people-trainng").click(function () {
        openPrintPage();
    });


    $("#open-check-modal-button").click(function () {
        var url = "/Training/CheckTrainning";
        var data = { peopleTrainningId: $("#people-trainning-id").val() };
        var delegate = function (result) {
            $("#check-trainning-dialog-body").html(result);
        }
        AjaxRequest(url, data, "GET", delegate, true, true);
    });
});
function openPrintPage() {
    var peopleTrainningId = $("#people-trainning-id").val();
    var url = "/Training/PrintTrainning?peopleTrainningId=" + peopleTrainningId;
    window.location = url;
}