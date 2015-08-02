$(document).ready(function () {
    
});

function postMessage(friendId)
{    
    if (friendId) {
        var message = $("#chat-message-" + friendId).val();
        if (message) {
            var data = {
                friendId: friendId,
                message: message
            }
            var url = "/Chat/Post";
            var delegate = function (result) {
                updateChatContent(friendId);
            }
            AjaxRequest(url, data, "POST", delegate, true, false);
        }
        else {
            $("#chat-message-" + friendId).focus();
            alert("Mensagem em branco!");
        }
    }
}