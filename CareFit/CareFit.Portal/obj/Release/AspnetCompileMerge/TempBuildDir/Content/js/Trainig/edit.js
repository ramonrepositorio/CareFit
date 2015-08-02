$(document).ready(function () {
    InitExerciseSearchField();
    InitSliderFields();
    SetDefaultSeries(false);
    InitColpick();
    $("#set-default-series-button").change(function () {
        SetDefaultSeries($(this).is(":checked"));
    });
    $("#cancel-new-trainning-exercise").click(function () {
        CancelEditTrainningExercise();
    });
    $("#save-edited-trainning-exercise").click(function () {
        addNewTrainningExercise();
    });
    $("button[id*=edit-exercise-button-]").click(function () {
        var rowId = $(this).parent().parent().attr("trainning-exercise-id");        
        EditRow(rowId);
    });
    $("#add-new-people").click(function () {
        SaveTrainning();
    });

   


});

function InitColpick() {

    $("#trainning-color").colpick({
        layout: 'hex',
        submit: 0,
        colorScheme: 'dark',
        onChange: function (hsb, hex, rgb, el, bySetColor) {
            $(el).css('border-color', '#' + hex);
            // Fill the text box just if the color was set using the picker, and not the colpickSetColor function.
            if (!bySetColor) $(el).val(hex);
        },
        onSubmit: function (hsb, hex, rgb, el) {
            $('#trainning-color').colpickHide();
        }
    }).keyup(function () {
        $(this).colpickSetColor(this.value);
    });


}
function InitTableButtons(rowId) {
    $("#edit-exercise-button-" + rowId).click(function () {
        var rowId = $(this).parent().parent().attr("trainning-exercise-id");
        EditRow(rowId);
    });
}

function InitExerciseSearchField() {
    $("#trainning-exercise-search").typeahead({
        onSelect: function (item) {
            EditTrainningExercise(item.value, item.text);
        },
        ajax: {
            url: "/Exercise/GetTypeAheadAjax",
            timeout: 500,
            displayField: "description",
            triggerLength: 3,
            method: "get",
            //loadingClass: "loading-circle",
            valueField: "exerciseId",
            preDispatch: function (query) {
                //showLoadingMask(true);
                return {
                    search: query
                }
            }
        }
    });
}

function InitSliderFields() {

}
function CancelEditTrainningExercise() {
    $("#trainning-exercise-search").val("");
    $("#trainning-exercise-name").val("");
    $("#trainning-exercise-edit-panel").hide();
    $("#trainning-exercise-search-panel").show();
    $("#trainning-exercise-search").focus();

    $("#trainning-exercise-repetions").val("");
    $("#trainning-exercise-interval").val("");
    $("#trainning-exercise-weigh").val("");
    $("#trainning-exercise-ciclo").val("");
    VerifyTable();
}

function EditRow(rowId) {
    $("#trainning-editing-exercise-id").val(rowId);
    $("#trainning-exercise-id").val(rowId);
    $("#trainning-exercise-search").val($("#lbl-exercise-name-" + rowId).text());
    $("#trainning-exercise-repetions").val($("#lbl-exercise-repetions-" + rowId).text());
    $("#trainning-exercise-interval").val($("#lbl-exercise-interval-" + rowId).text());
    $("#trainning-exercise-weigh").val($("#lbl-exercise-weigh-" + rowId).text());
    $("#trainning-exercise-ciclo").val($("#lbl-exercise-ciclo-" + rowId).text());
    EditTrainningExercise();
}

function VerifyTable() {
    if ($("#trainning-exercises-table tbody tr").length > 0) {
        $("#trainning-exercise-table-panel").show();
        $("#trainning-exercise-no-data-alert").hide();
    }
    else {
        $("#trainning-exercise-table-panel").hide();
        $("#trainning-exercise-no-data-alert").show();
    }
}

function EditTrainningExercise(exerciseId, exerciseName) {
    if (exerciseName) {
        $("#trainning-exercise-name").val(exerciseName);
        $("#trainning-exercise-id").val("");
    }
    $("#trainning-editing-exercise-id").val(exerciseId);
    $("#trainning-exercise-edit-panel").show();
    $("#trainning-exercise-search-panel").hide();
    $("#trainning-exercise-table-panel").hide();
}

function SetDefaultSeries(ableFields) {
    if (ableFields == true) {
        $("#default-series-alert-panel").show();
        $("#default-trainning-interval").removeAttr("disabled");
        $("#default-trainning-ciclos").removeAttr("disabled");
        $("#default-trainning-times").removeAttr("disabled");

        $("#trainning-exercise-repetions").attr("disabled", "true");
        $("#trainning-exercise-ciclo").attr("disabled", "true");
        $("#trainning-exercise-interval").attr("disabled", "true");
        $("#trainning-exercise-weigh").attr("disabled", "true");

    }
    else {

        $("#default-series-alert-panel").hide();
        $("#default-trainning-interval").attr("disabled", "true");
        $("#default-trainning-ciclos").attr("disabled", "true");
        $("#default-trainning-times").attr("disabled", "true");

        $("#trainning-exercise-repetions").removeAttr("enable");
        $("#trainning-exercise-ciclo").removeAttr("enable");
        $("#trainning-exercise-interval").removeAttr("enable");
        $("#trainning-exercise-weigh").removeAttr("enable");

    }
}
var newLineId = -1;
function addNewTrainningExercise() {
    var exerciseName = $("#trainning-exercise-name").val()
    var exerciseMachine = "";
    var exerciseRepetions = $("#trainning-exercise-repetions").val();
    var exerciseInterval = $("#trainning-exercise-interval").val();
    var exerciseWeigh = $("#trainning-exercise-weigh").val();
    var exerciseCiclo = $("#trainning-exercise-ciclo").val();
    var exerciseId = $("#trainning-editing-exercise-id").val();
    var rowId = $("#trainning-exercise-id").val();
    if (rowId) {
        $("#trainning-exercise-id").val("");
        $("#lbl-exercise-name-" + rowId).text($("#trainning-exercise-search").val());
        $("#lbl-exercise-repetions-" + rowId).text($("#trainning-exercise-repetions").val());
        $("#lbl-exercise-interval-" + rowId).text($("#trainning-exercise-interval").val());
        $("#lbl-exercise-weigh-" + rowId).text($("#trainning-exercise-weigh").val());
        $("#lbl-exercise-ciclo-" + rowId).text($("#trainning-exercise-ciclo").val());
    }
    else {
        var newLine = '<tr id="trainning-exercise-row-id-' + newLineId + '" trainning-exercise-id="' + newLineId + '">' +
                            '<td>' +
                            '<input type="hidden" id="trainning-exercise-exercise-id-' + newLineId + '" value="' + exerciseId + '" />' +
                            '<label id="lbl-exercise-name-' + newLineId + '">' + exerciseName + '</label></td>' +
                            '<td><label id="lbl-exercise-repetions-' + newLineId + '">' + exerciseRepetions + '</label></td>' +
                            '<td><label id="lbl-exercise-ciclo-' + newLineId + '">' + exerciseCiclo + '</label></td>' +
                            '<td><label id="lbl-exercise-weigh-' + newLineId + '">' + exerciseWeigh + '</label></td>' +
                            '<td><label id="lbl-exercise-interval-' + newLineId + '">' + exerciseInterval + '</label></td>' +
                            '<td>' +
                                '<button type="button" class="btn btn-default" title="Alterar Exercicio" id="edit-exercise-button-' + newLineId + '">' +
                                    '<span class="glyphicon glyphicon-edit"></span>' +
                                '</button>' +
                                '<button type="button" class="btn btn-default"  title="Remover Exercicio" id="remove-exercise-button-' + newLineId + '">' +
                                    '<span class="glyphicon glyphicon-remove"></span>' +
                                '</button>' +
                            '</td>' +
                        '</tr>';

        $("#trainning-exercises-table tbody").prepend(newLine);
        InitTableButtons(newLineId);
        newLineId--;
    }
    CancelEditTrainningExercise();
}
function SaveTrainning() {
    var trainningId = $("#trainning-id").val();
    var trainningTitle = $("#trainning-title").val();
    var trainningRest = $("#trainning-rest").val();
    var trainningType = $("#trainning-types").val();
    var trainningRepetions = $("#trainning-repetions").val();
    var trainningColor = $("#trainning-color").val();

    var trainningDefaultExercises = {};
    if ($("#set-default-series-button").is(":checked")) {
        var defaultTrainningTimes = $("#default-trainning-times").val();
        var defaultTrainningCiclos = $("#default-trainning-ciclos").val();
        var defaultTrainningInterval = $("#default-trainning-interval").val();
        trainningDefaultExercises = {
            DefaultTrainningTimes: defaultTrainningTimes,
            DefaultTrainningCiclos: defaultTrainningCiclos,
            DefaultTrainningInterval: defaultTrainningInterval
        }
    }
    var trainningExercises = GetTrainningExercises();

    var trainning = {
        ID: trainningId,
        Titulo: trainningTitle,
        RepousoMinimo: trainningRest,
        TreinoExercicios: trainningExercises,
        TreinoTipoId: trainningType,
        Repeticoes: trainningRepetions,
        Cor: trainningColor
    };
    var peopleId = $("#people-id").val();
    var data = {
        jsonTrainning: JSON.stringify(trainning),
        jsonDefaultTrainningExercises: JSON.stringify(trainningDefaultExercises),
        peopleId: peopleId
    }
    var url = "/Training/Save";
    var delegate = function (result) {
        OpenContent("Training", "PeopleDetails", { peopleId: peopleId });
    }
    AjaxRequest(url, data, "POST", delegate, false);
}
function GetTrainningExercises() {
    var trainningExercises = [];
    var trainningId = $("#trainning-id").val();
    $("#trainning-exercises-table tbody tr").each(function (index, val) {
        var id = $(val).attr("trainning-exercise-id");
        var exerciseId = $("#trainning-exercise-exercise-id-" + id).val();

        var machineId = $("#lbl-exercise-machine-" + id).val();
        var repetions = $("#lbl-exercise-repetions-" + id).text();
        var ciclo = $("#lbl-exercise-ciclo-" + id).text();
        var weigh = $("#lbl-exercise-weigh-" + id).text();
        var interval = $("#lbl-exercise-interval-" + id).text();
        var exercise = {
            ID: id,
            ExercicioId: exerciseId,
            TreinoId: trainningId,
            Repeticoes: repetions,
            Ciclos: ciclo,
            Carga: weigh,
            Descanso: interval
        }
        trainningExercises.push(exercise);
    });
    return trainningExercises;
}