$(document).ready(function () {
    $("#add-new-machine").click(function () {
        UpdateMachine(0);
    });
    $("#search-machine").click(function () {
        LoadMachines();
    });

    

});
function LoadMachines() {
    var url = "/Machine/List";
    var data = {
        roomId: $("#machine-room").val(),
        machineTypeId: $("#machine-type").val(),
        machineName: $("#machine-name").val()
    };
    var delegate = function (result) {
        $("#machine-list").html(result);
    };
    AjaxRequest(url, data, "GET", delegate, true, true);
    $("#panel-machine-list").show();
}

function UpdateMachine(machineId) {
    OpenContent("Machine", "Edit", { machineId: machineId });
}