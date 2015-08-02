$(document).ready(function () {
    $("button[id*=bind-professor-button-]").click(function () {
        BindProfessor($(this).attr("people-id"));
    });
    $("button[id*=open-trainning-details-button-]").click(function () {
        OpenTrainningDetails($(this).attr("people-id"));
    });
});
function BindProfessor(peopleId) {
    var data = { peopleId: peopleId };
    var url = "/Training/BindProfessor";
    var delegate = function (result) {
        if (!isNaN(result)) {
            var detailsData = { peopleId: peopleId };
            OpenContent("Training", "PeopleDetails", detailsData);
        }
    }
    AjaxRequest(url, data, "POST", delegate, false);
}
function OpenTrainningDetails(peopleId) {
    var detailsData = { peopleId: peopleId };
    OpenContent("Training", "PeopleDetails", detailsData);
}