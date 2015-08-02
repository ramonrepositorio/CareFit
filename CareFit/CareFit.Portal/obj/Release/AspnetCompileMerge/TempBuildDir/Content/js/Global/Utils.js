function InitToolTips(selector) {
    $(selector).tooltip();
}

function AjaxRequest(url, data, type, delegate, async, showWaitingPanel) {

    if (showWaitingPanel != false) {
        ShowWaitingPanel();
    }

    if (!type) {
        type = "GET";
    }
    if (!async) {
        async = true;
    }
    var request = $.ajax({
        url: url,
        type: type,
        data: data,
        async: async,
        success: function (result) {
            if (delegate) {
                delegate(result);
            }
        },
        error: function (request, status, error) {
            HideWaitingModal();
            var exp = new RegExp('<title>(.*)<\/title>', 'i');
            if (exp.exec(request.responseText)) {
                alert(RegExp.lastParen);
            }
            else {
                alert(status);
            }

        }
    });

    request.done(function (msg) {
        HideWaitingModal();
    });

    //request.fail(function (jqXHR, textStatus) {
    //    HideWaitingModal();
    //    alert("Request failed: " + textStatus);
    //});
}

function alert(message,delegate) {
    bootbox.alert(message, function () {
        if (delegate) {
            delegate();
        }
    });
}

function OpenContent(controller, action, data) {
    url = controller + "/" + action;

    var delegate = function (result) {
        $("#page-wrapper").html(result);
    };
    AjaxRequest(url, data, "GET", delegate, true, true);
}

function ShowWaitingPanel() {
    $("#loading").fadeIn(100);
}
function HideWaitingModal() {
    $("#loading").fadeOut(100);
}


function SerializeForm(form) {
    var $form = $("#" + form);
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}