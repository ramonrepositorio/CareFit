$(document).ready(function () {
    $("button[data-toggle=tooltip]").tooltip();
    $("button[id*=edit-exercise-button-]").click(function () {
        EditExercise($(this).attr("exercise-id"));
    });
});
function EditExercise(exerciseId) {
    var data = { exerciseId: exerciseId };
    OpenContent("Exercise", "Edit", data, true);
}
