$(document).ready(function () {
    $("button[id*=edit-default-trainning-button-]").click(function () {
        var trainningId = $(this).attr("trainning-id");
        EditDefaultTrainning(trainningId);
    });

    $("button[id*=choose-default-trainning-button-]").click(function () {
        var trainningId = $(this).attr("trainning-id");
        ChooseDefaultTrainning(trainningId);
    });
});
function EditDefaultTrainning(trainningId) {
    var detailsData = { trainningId: trainningId };
    var peopleId = $("#default-trainning-people-id").val();
    OpenContent("Training", "Edit", detailsData);
}
function ChooseDefaultTrainning(trainningId) {
    var peopleId = $("#default-trainning-people-id").val();
    var data = {
        trainningId: trainningId,
        peopleId: peopleId
    }
    var url = "/Training/UseDefaultTrainning";
    var delegate = function (result) {
        alert("Treino incluido com sucesso!");
        $(".modal-backdrop").hide();
        OpenContent("Training", "PeopleDetails", { peopleId: peopleId });
    }
    AjaxRequest(url, data, "POST", delegate, true, true);
}