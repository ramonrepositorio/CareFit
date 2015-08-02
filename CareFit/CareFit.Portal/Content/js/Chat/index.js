$(document).ready(function () {
    $("button[id*=friend-new-chat-]").click(function () {
        var peopleId = $(this).attr("friend-id");
        var fullName = $(this).attr("friend-name");
        openChat(peopleId, fullName);
    });
    $("li[id*=chat-header-]").click(function () {
        var peopleId = $(this).attr("friend-id");
        OpenMenu(peopleId);
    });
    initChat();
    verifyNewMessages();
    setInterval("verifyNewMessages()", 1000 * 5);//5 Segundos
});


function OpenMenu(peopleId) {
    $("li.active").removeClass("active");
    $(".tab-pane.active").removeClass("active");
    $("#chat-header-" + peopleId).addClass("active");
    $("#friend-chat-" + peopleId).addClass("active");
    $("#alert-friend-message-" + peopleId).hide();
    ReadyMessages(peopleId);
}
function ReadyMessages(peopleId) {
    var data = { friendId: peopleId };
    var url = "/Chat/ReadyMessages";
    var delegate = function (result) {

    }
    AjaxRequest(url, data, "POST", delegate, true, false);

}
function scroolBotton() {
    $('.chat-widget').each(function (index, val) {
        $(val).slimScroll({ scrollTo: $(val).height() + 100 });
    });
}

var lastChatVerification;
function verifyNewMessages() {
    var url = "/Chat/GetNewChats";
    var data = { lastUpdate: JSON.stringify(lastChatVerification) };
    var delegate = function (result) {
        lastChatVerification = new Date(parseInt(result.lastUpdate.replace(/\/Date\((.*?)\)\//gi, "$1")));
        $.each(result.newMessages, function (index, val) {
            updateChatContent(val.friendId, val.fullName);
            var alertLabel = $("#alert-friend-message-" + val.friendId);
            alertLabel.addClass("label label-success new-circle animated double shake span-left");
            alertLabel.text(parseInt(alertLabel.text()) + 1);
            alertLabel.show();
        });
    }

    AjaxRequest(url, data, "POST", delegate, true, false);
}

function openChat(peopleId, fullName) {
    updateChatContent(peopleId, fullName);
}
function peopleChatIsOpened(peopleId) {
    if ($("#chat-header-" + peopleId).length != 0) {
        return true;
    }
    else {
        return false;
    }
}
function addNewChatItens(peopleId, fullName) {
    var header = '<li id="chat-header-' + peopleId + '" friend-id="' + peopleId + '">' +
                    '<a href="#friend-chat-' + peopleId + '" data-toggle="tab">' + fullName +
                    '<span class="" id="alert-friend-message-' + peopleId + '" style="display:none">0</span>' +
                    '</a>' +
                 '</li>';
    $("#chat-header").append(header);
    var content = '<div class="tab-pane" id="friend-chat-' + peopleId + '" friend-id="' + peopleId + '" title="Iniciar bate papo com Nome ' + fullName + '">' +
                  '</div> ';
    $("#chat-no-message-alert").hide();
    $("#chats-content").append(content);
    $("#chat-header-" + peopleId).click(function () {
        openChat(peopleId);
    });
}
function updateChatContent(peopleId, fullName) {
    var data = { peopleFromId: peopleId };
    var url = "/Chat/Chat";
    var delegate = function (result) {
        if (!peopleChatIsOpened(peopleId)) {
            addNewChatItens(peopleId, fullName);
        }
        $("#friend-chat-" + peopleId).html(result);
        //scroolBotton();
        setTimeout("scroolBotton()", 1);
    }
    AjaxRequest(url, data, "GET", delegate, false, false);
}
function initChat() {
    var firstHeader = $("#chat-header li:first");
    if (firstHeader.length != null) {
        $("#chat-no-message-alert").hide();
        var peopleId = firstHeader.attr("friend-id");
        if (peopleId) {
            updateChatContent(peopleId);
        }
    }

}