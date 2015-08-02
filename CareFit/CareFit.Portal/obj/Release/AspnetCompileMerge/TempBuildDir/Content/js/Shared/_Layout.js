$(document).ready(function () {

    UpdatePanels(true);
    setInterval('UpdatePanels(false)', (60 * 1000)); //1 Minutos
});
function UpdatePanels(firstCall) {
    UpdateRequestPanel(firstCall);
    LoadLayoutInfo();
}
function LoadLayoutInfo() {
    var url = "/People/GetlayoutInfo";
    var data = {};
    var delegate = function (result) {
        $("#user-name-panel").text(result.UserName + " " + result.UserLastName);
        $("#user-name-side").text(result.UserName);
    }
    AjaxRequest(url, data, "GET", delegate, true, false);
}
function notificationCheck(requestId, answer) {
    var message = "Deseja aceitar a solicitação?";
    if (!answer) {
        message = "Deseja rejeitar a solicitação?";
    }
    bootbox.confirm(message, function (result) {
        if (result) {
            var data = { requestId: requestId, answer: answer };
            var url = "/People/RespondRequest";
            var delegate = function (result) {
                if (result) {
                    RefreshRequestPanel();
                } else {
                    Alert("Opss, A Operação não foi finalizada devido a restrições internas");
                }
            };
            AjaxRequest(url, data, "POST", delegate, true, true);
        }
    });
}
function RefreshRequestPanel()
{
    $(".people-notification").remove();
    UpdateRequestPanel(true);
}
function UpdateRequestPanel(firstCall) {
    var url = "/People/GetPeopleRequestPanel";
    var data = { firstCall: firstCall };
    var delegate = function (result) {
        var unreadMessages = 0;

        $.each(result, function (index, peopleRequest) {
            var requestItem = '<li class="people-notification">' +
                              '<a style="cursor: default;">' +
                              '<p><strong>' + peopleRequest.Title + '</strong></p>' +
                              '<p>' + peopleRequest.Description + '</p>';
                
            if (peopleRequest.ResponseDate) {
                requestItem += '<p><small>' + peopleRequest.ResponseDate + '<small></p>';
               
            } else {
                unreadMessages++;
                requestItem += '<button type="button" class="btn btn-danger btn-xs">Rejeitar</button>';
                requestItem += '<button type="button" class="btn btn-success btn-xs pull-right">Aceitar</button>';
                requestItem += '<p><small>' + peopleRequest.RequestDate + '</small></p>';
            }            
          
            requestItem += '</a></li>';
            $("#notification-list .dropdown-footer").before(requestItem);
        });
        if (firstCall) {
            $("#notification-number").text(unreadMessages);
        }
    };
    AjaxRequest(url, data, "GET", delegate, true, false);
}


function EditProfile()
{
    OpenContent("People", "EditPerfil", null);
}