$(document).ready(function () {
    $("button[id*=edit-exercise-button-]").click(function () {
        var trainningId = $(this).attr("trainning-id");
        var peopleId = $("#people-id").val();
        var data = {
            trainningId: trainningId,
            peopleId: peopleId
        };
        OpenContent("Training", "Edit", data);
    });
    $("#add-new-trainning").click(function () {
        var peopleId = $("#people-id").val();
        editTrainning(0, peopleId);
    });
});
function editTrainning(trainningId, peopleId) {
    var data = {
        trainningId: trainningId,
        peopleId: peopleId
    };
    OpenContent("Training", "Edit", data);
}