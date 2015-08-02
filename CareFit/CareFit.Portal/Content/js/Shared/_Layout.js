$(document).ready(function () {
    $("#change-passwoed-button").click(function () {
        window.location = "/Authentication/ResetPassword";
    });

    setInterval('UpdatePanels()', (60 * 1000)); //1 Minutos
    LoadLayoutInfo();
    LoadNofications(true);
    LoadNewMessages();
});

function UpdatePanels() {
    LoadNofications(false);
    LoadNewMessages();
}

function LoadLayoutInfo() {
    var url = "/People/GetlayoutInfo";
    var data = {};
    var delegate = function (result) {
        $("#user-name-panel").text(result.UserName + " " + result.UserLastName);
        $("#user-name-side").text(result.UserName);
        $("#people-avatar-image").attr("src", result.UrlAvatarImage);
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
function RefreshRequestPanel() {
    $(".people-notification").remove();
    UpdateRequestPanel(true);
}
function LoadNofications(firstCall) {
    var url = "/People/GetPeopleRequestPanel";
    var data = { firstCall: firstCall };
    var delegate = function (result) {
        var unreadMessages = 0;
        $.each(result, function (index, peopleRequest) {
            var requestItem = '<li class="people-notification">';
            requestItem += '<a style="cursor: default;" >';

            if (peopleRequest.ImageUrl) {

                requestItem += "<img  src='" + peopleRequest.ImageUrl + "' class='xs-avatar ava-dropdown' />";
            }

            requestItem += '<strong>' + peopleRequest.Title + '</strong>';
            requestItem += "<br />";
            requestItem += peopleRequest.Description;
            requestItem += "<br />";

            if (peopleRequest.ResponseDate) {
                requestItem += '<small>' + peopleRequest.ResponseDate + '<small>';

            } else {
                unreadMessages++;
                requestItem += '<p><small>' + peopleRequest.RequestDate + '</small></p>';
                requestItem += '<button type="button" class="btn btn-danger btn-xs"  onclick="notificationCheck(' + peopleRequest.ID + ',false)">Rejeitar</button>';
                requestItem += '<button type="button" class="btn btn-success btn-xs pull-right" onclick="notificationCheck(' + peopleRequest.ID + ',true)">Aceitar</button>';
            }

            requestItem += '</a>';
            requestItem += '</li>';
            $("#notification-list .dropdown-footer").before(requestItem);
        });
        if (firstCall) {
            $("#notification-number").text(unreadMessages);
        }
    };
    AjaxRequest(url, data, "GET", delegate, true, false);
}
var lastMessageRequest;
function LoadNewMessages() {
    var url = "/Chat/GetNewChats";
    var data = { lastUpdate: JSON.stringify(lastMessageRequest) };
    var delegate = function (result) {
        lastMessageRequest = new Date(parseInt(result.lastUpdate.replace(/\/Date\((.*?)\)\//gi, "$1")));
        $("#new-messages-alert").text(result.countNewMessages);
        $.each(result.newMessages, function (index, val) {
            var message = '<li>' +
                '<a href="#fakelink">' +
                    '<img src="' + val.imageUrl + '" class="xs-avatar ava-dropdown" alt="Avatar">' +
                    '<strong>' + val.fullName + '</strong><br>' +
                    '<p>' + val.message + '</p>' +
                    '<p><i>' + val.sendDate + '</i></p>' +
                '</a>' +
            '</li>';
            $("#new-messages-list .dropdown-footer").before(message);
        });
    }
    AjaxRequest(url, data, "POST", delegate, true, false);
}


function EditProfile() {
    OpenContent("People", "EditPerfil", null);
}

function SearchFriends() {
    var url = "/People/SearchFriend";
    var data = {};
    var delegate = function (result) {
        $("#add-friend-content").html(result);
    }
    AjaxRequest(url, data, "GET", delegate, false, false);
}