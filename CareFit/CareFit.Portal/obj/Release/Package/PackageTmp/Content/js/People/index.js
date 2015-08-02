$(document).ready(function () {
    $("button[data-toggle=tooltip]").tooltip();
    $("#people-cpf").mask("999.999.999-99");
    $("#serch-people").click(function () {
        loadPeopleList();
    });
    $("#add-new-people").click(function () {
        addNewPeople();
    });
    $("#PeopleCheckNewEmail").click(function () {
        checkNewPeopleEmail();
    });
    $("#cancelPeopleVinculation").click(function () {
        $("#peopleVinculationPanel").hide();
        $("#PeopleNewEmail").val("");
        $("#PeopleNewEmail").focus();
        $("#PeopleNewEmail").attr("disabled", "");
    });
    $("#confirmPeopleVinculation").click(function () {
        PeopleRequestVinculation();
    });
});
function loadPeopleList() {
    var url = "/People/List";
    var data = {
        peopleTypeId: $("#people-type").val(),
        peopleName: $("#people-name").val(),
        peopleCpf: $("#people-cpf").val()
    };
    var delegate = function (result) {
        $("#people-list").html(result)
        $("#panel-people-list").show();
    };
    AjaxRequest(url, data, "GET", delegate, true);
}
function addNewPeople() {
     $("#NewPeopleModal").modal("show");
    $("#PeopleNewEmail").focus();
}

function checkNewPeopleEmail() {
    data = { mail: $("#PeopleNewEmail").val() };
    var url = "/People/VerifeMail";
    var delegate = function (result) {
        if (result.toLowerCase() != "false") {
            $("#NewPeopleModal").modal("hide");
            $(".modal-backdrop").hide();
            OpenContent("People", "Edit", { peopleId: 0, mail: $("#PeopleNewEmail").val() });
        }
        else {
            $("#PeopleNewEmail").attr("disabled", "disabled");
            $("#peopleVinculationPanel").show();
        }
    };
    AjaxRequest(url, data, "GET", delegate, true, false);
}
function PeopleRequestVinculation() {
    var customerId = $("#people-request-customer-id").val();
    if (customerId == "0") {
        alert("Favor escolher empresa ao qual a pessoa será vinculada");
        return;
    }
    else {
        mail = $("#PeopleNewEmail").val();
        var url = "/People/SaveCustomerRequest";
        var data = { customerId: customerId, email: mail };
        var delegate = function (result) {
            $("#NewPeopleModal").modal("hide");
            $("#people-request-customer-id").val("");
            alert("Solicitação enviada e pendente de aprovação");
        };
        AjaxRequest(url, data, "POST", delegate, true);
    }
}
