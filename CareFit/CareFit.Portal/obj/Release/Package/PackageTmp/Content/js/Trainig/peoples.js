$(document).ready(function () {
    $("#search-people").click(function () {
        LoadTrainingPeople();
    })
});

function LoadTrainingPeople() {
    var url = "/Training/PeoplesList";
    var data = {
        name: $("#people-name").val(),
        cpf: $("#people-cpf").val()        
    };
    var delegate = function (result) {
        $("#people-list").html(result);
        $("#panel-people-list").show();
    };
    AjaxRequest(url, data, "GET", delegate, true, true);
}