$(document).ready(function () {
    $("#header-check-trainning-modal").text($("#header-check-trainning").val());
    $("#confirm-trainning").click(function () {
        CheckThisTrainnig();
    });
});

function CheckThisTrainnig() {
    var url = "/Training/ConfirmCheckTrainning";
    var data = { peopleTrainningId: $("#people-trainning-value-id").val() };
    var delegate = function (result) {
        $("#alert-confirm-trainning").hide();
        $("#alert-confirm-success").show();
        $("#confirm-trainning").hide();
        $("#cancel-trainning-button").hide();
    }
    AjaxRequest(url, data, "POST", delegate, true, true);
}