$(document).ready(function () {
    $("button[data-toggle=tooltip]").tooltip();

    $("button[id*=edit-people-button]").click(function () {
        EditPeople($(this).attr("people-id"));
    });
});
function EditPeople(peopleId)
{
    OpenContent("People", "Edit", { peopleId: peopleId });
}


