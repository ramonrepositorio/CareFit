$(document).ready(function () {
    $("#image-save-button").click(function () {
        ExternalSaveImage();
    });

    $("#people-back").click(function () {
        OpenContent("People", "index", null);
    });

    $("#edit-people-form").submit(function (event) {
        if (!$('#peopleCpf').val()) {
            alert("CPF Em Branco");
            event.preventDefault();
        }
        return;
    });
    $("#edit-people-image").click(function () {
        EditPeopleImage();
    });
    var optionsCep = {
        onComplete: function (cep) {
            UpdateCep(cep);
        },
        onKeyPress: function (cep, event, currentField, options) {
            ///sem utilização
        },
        onChange: function (cep) {
            //Caso precise validar se o cep realmente mudou
        }
    };

    $('#peopleCelPhone').mask('(99) 9999-9999');
    $('#peopleCelPhone').keyup(function () {
        var valor = $(this).val();

        if (valor[1] == '1' && valor[2] >= '1' && valor[5] == '9') {
            $(this).mask('(99) 99999-9999');
        } else {
            $(this).mask('(99) 9999-9999');
        }
    });

    $("button[data-toggle=tooltip]").tooltip();
    $('#peopleCpf').mask('999.999.999-99');
    $('#peopleBirthday').mask('99/99/9999');
    $('#peopleZipCode').mask('99999-999', optionsCep);
    $("#peoplePhone").mask("(99) 9999-9999")
    $("#peopleRg").mask("99.999.999-9");

});
function SavePeople() {
    var formData = SerializeForm("edit-people-form");
    formData.PessoaEmpresas = GetPeopleCustomers();
    data = { jsonPeople: JSON.stringify(formData) };
    var url = "/People/Save";
    var delegate = function (result) {
        alert("Cadastro Atualizado com sucesso");
        $("#peopleId").val(result);
    }
    AjaxRequest(url, data, "POST", delegate, false);
}
function UpdateCep(cep) {
    var data = { cep: cep };
    var url = "/Cep/GetCep";
    var delegate = function (result) {
        if (result.Resultado > 0) {
            $("#peopleAddress").val(result.TipoLagradouro + " " + result.Lagradouro);
            $("#peopleAddressCity").val(result.Cidade);
            $("#peopleState").val(result.UF);
            $("#peopleAddressBairro").val(result.Bairro);
        }
        else {
            alert("Cep não encontrado");
        }
    }
    AjaxRequest(url, data, "POST", delegate, false);
}

function GetPeopleCustomers() {
    var customerPeoples = [];
    $("div[id*=people-customer-painel]").each(function (index, val) {
        var peopleCustomerId = $(this).attr("people-customer-id");
        var active = $("#people-active-" + peopleCustomerId).is(":checked");
        var peopleCustomerTypeId = $("#peopleType-" + peopleCustomerId).val();
        var customerId = $("#customer-id-" + peopleCustomerId).val();
        var peopleId = $("#peopleId").val();
        var customerPeople = { ID: peopleCustomerId, PessoaId: peopleId, EmpresaId: customerId, PessoaTipoId: peopleCustomerTypeId, Ativo: active };
        customerPeoples.push(customerPeople);
    });
    return customerPeoples;
}

function ExternalSaveImage() {
    var delegateExt = function (ImageData) {
        $("#people-avatar-img").attr("src", ImageData.ImagePath);
        $("#image-id").val(ImageData.ID);
    };
    SaveImage(delegateExt);
}

function EditPeopleImage() {
    var url = "/Images/Edit";
    var data = { imageId: $("#image-id").val() };
    var delegate = function (result) {
        $("#image-dialog-body").html(result);
    }
    AjaxRequest(url, data, "GET", delegate, true, true);
}