$(document).ready(function () {
    $("#exercise-machine-acessory").selectpicker();
    $("#exercise-machine").selectpicker();
    $("#add-new-exercise").click(function () {
        SaveExercise();
    });

});
function SaveExercise() {
    var formData = SerializeForm("edit-people-form");
    formData.ExercicioEquipamentos = GetAcessories();
    data = { jsonExercise: JSON.stringify(formData) };
    
    var url = "/Exercise/Save";
    var delegate = function (result) {
        alert("Cadastro Atualizado com sucesso");
        $("#exerciseId").val(result);
    }
    AjaxRequest(url, data, "POST", delegate, false);
}
function GetAcessories() {
    var acessories = [];
    var exerciseId = $("#exerciseId").val();
    var exercises = $("#exercise-machine-acessory").val();
    $.each(exercises,function (index, val) {
        acessories.push({ EquipamentoId: val, ExercicioId: exerciseId });
    });
    return acessories;
}