$(document).ready(function () {
    $("#serch-default-trainning").click(function () {
        SearchDefaultTrainning();
    });
    $("#add-default-trainning").click(function () {
        NewDefaultTrainning();
    });
});

function NewDefaultTrainning() {

    var data = {
        trainningId: 0
    };
    OpenContent("Training", "Edit", data);

}
function SearchDefaultTrainning() {
    var url = "/Training/ListDefaultTrainnings";
    var data = {
        professorId: $("#professor-default-trainnings").val(),
        customerId: $("#customer-default-trainnings").val(),
        peopleId: $("#default-trainning-people-id").val()
    };
    var delegate = function (result) {
        $("#default-trainning-list").html(result);
        $("#panel-default-trainning-list").show();
    };
    AjaxRequest(url, data, "GET", delegate, true, true);
}