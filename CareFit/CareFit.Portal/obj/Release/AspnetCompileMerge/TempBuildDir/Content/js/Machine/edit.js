$(document).ready(function () {
});
function SaveMachine(){
    var formData = SerializeForm("edit-machine-form");    
    data = { jsonMachine: JSON.stringify(formData) };
    var url = "/Machine/Save";
    var delegate = function (result) {
        alert("Cadastro Atualizado com sucesso");
        $("#machineId").val(result);
    }
    AjaxRequest(url, data, "POST", delegate, false);
}