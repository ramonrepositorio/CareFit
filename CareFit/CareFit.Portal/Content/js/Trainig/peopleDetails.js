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
    $("#add-new-default-trainning").click(function () {
        chooseDefaultTrainning();
    });
});
function editTrainning(trainningId, peopleId) {
    var data = {
        trainningId: trainningId,
        peopleId: peopleId
    };
    OpenContent("Training", "Edit", data);
}

function chooseDefaultTrainning() {
    var url = "/Training/GetDefaultTrainnings";
    var delegate = function (result) {        
        $("#chose-default-trainning").html(result);        
    }
    var data = {
        peopleId: $("#people-id").val()
    }
    AjaxRequest(url, data, "GET", delegate, true, false);
}
