$(document).ready(function () {
    $("#carousel-example-generic").carousel();
    InitTrainningCalendar();
    $("button[id*=view-trainning-button-]").click(function () {
        var trainningId = $(this).attr("people-trainning-id");
        ViewTrainning(trainningId);
    });
});

function ViewTrainning(trainningId) {
    OpenContent("Training", "ViewTrainning", { trainningId: trainningId });
}

function InitTrainningCalendar() {
    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    $('#trainningCalendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,basicWeek,basicDay'
        },
        contentHeight: 600,
        editable: true,        
        events: {
            url: '/Training/DoneTrainings',
           
        },
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb'],
        buttonText: {
            prev: '&nbsp;&#9668;&nbsp;',
            next: '&nbsp;&#9658;&nbsp;',
            prevYear: '&nbsp;&lt;&lt;&nbsp;',
            nextYear: '&nbsp;&gt;&gt;&nbsp;',
            today: 'hoje',
            month: 'mês',
            week: 'semana',
            day: 'dia'
        },
        titleFormat: {
            month: 'MMMM yyyy',
            week: "d [ yyyy]{ '&#8212;'[ MMM] d MMM yyyy}",
            day: 'dddd, d MMM, yyyy'
        },
        columnFormat: {
            month: 'ddd',
            week: 'ddd d/M',
            day: 'dddd d/M'
        },
        allDayText: 'dia todo',
        axisFormat: 'H:mm',
        timeFormat: {
            '': 'H(:mm)',
            agenda: 'H:mm{ - H:mm}'
        },

    });
}