$(document).ready(function () {
    $("#search-exercise").click(function () {
        LoadExercises();
    });
    $("#add-new-exercise").click(function () {
        OpenContent("Exercise", "Edit", { exerciseId: 0 });
    });
});
function LoadExercises()
{
    var url = "/Exercise/List";
    var data = {
        exerciseMuscleGroup: $("#exercise-mucle-group").val(),
        exerciseTypeId: $("#exercise-type").val(),
        exerciseName: $("#exercise-name").val()
    };
    var delegate = function (result) {
        $("#exercise-list").html(result);
    };
    AjaxRequest(url, data, "GET", delegate, true, true);
    $("#panel-exercise-list").show();
}