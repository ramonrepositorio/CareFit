$(document).ready(function () {
    $("button[data-toggle=tooltip]").tooltip();
    $("button[id*=edit-exercise-button-]").click(function () {
        EditMachine($(this).attr("machine-id"));
    });
});
function EditMachine(machineId) {
    OpenContent("Machine", "Edit", { machineId: machineId });
}
