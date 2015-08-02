function InitToolTips(selector) {
    $(selector).tooltip();
}

function CompleteAjaxRequest(url, data, type, delegate, async, showWaitingPanel) {    

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
            //InitEverything();
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

function parseBool(value) {
    return (typeof value === "undefined") ?
           false :
           // trim using jQuery.trim()'s source 
           value.replace(/^\s+|\s+$/g, "").toLowerCase() === "true";
}
function AjaxRequest(url, data, type, delegate, async, showWaitingPanel) {

    $.ajax({
        url: "/Authentication/VerifySection",
        type: "POST",
        async: async,
        success: function (result) {
            if (parseBool(result) == true || url == "/Authentication/ResetPassword") {
                CompleteAjaxRequest(url, data, type, delegate, async, showWaitingPanel);
            }
            else {
                window.location = "/Authentication/Index/";
            }
        }
    });
}




function alert(message, delegate) {
    bootbox.alert(message, function () {
        if (delegate) {
            delegate();
        }
    });
}

function OpenContent(controller, action, data) {
    if (controller == "Home" && action == "Index") {
        ShowWaitingPanel();
        window.location = "/Home/Index";
    } else {
        url = "/" + controller + "/" + action;

        var delegate = function (result) {
            $("#page-wrapper").html(result);
        };
        AjaxRequest(url, data, "GET", delegate, true, true);
    }
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

function SearchField(fieldId, delegateFounded, urlJson) {
    $("#" + fieldId).typeahead({
        onSelect: function (item) {
            delegateFounded(item.value, item.text);
        },
        ajax: {
            url: urlJson,
            timeout: 500,
            displayField: "description",
            triggerLength: 3,
            method: "get",
            valueField: "ID",
            preDispatch: function (query) {
                return {
                    search: query
                }
            }
        }
    });
}