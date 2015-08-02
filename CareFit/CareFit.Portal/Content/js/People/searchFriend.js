$(document).ready(function () {
    $("#filter-people-text").focus();
    SearchField("filter-people-text", openNewFriend, "/People/GetPeopleAheadAjax");
    $("#add-friend-cancel-button").click(function () {
        $("#friend-info-panel").hide();
        $("#filter-people-text").val("");
        $("#filter-people-text").focus();
    });
    $("#add-friend-confirm-button").click(function () {
        addFriend();
    });
});

function openNewFriend(id, description) {
    $("#new-friend-id").val(id);
    $("#friend-info-panel").show();
    $("#add-friend-name").text(description);
    $("#add-friend-customers").html("");
    var url = "/People/GetPeopleDetail";    
    var data = { peopleId: id };
    var delegate = function (result) {
        $("#add-friend-img").attr("src", result.picture);
        if (result.customers) {            
            $.each(result.customers, function (index, value) {
                $("#add-friend-customers").append("<p><b>" + value.customer + ": </b><smal> " + value.peopleType + "</smal></p>");
            });
        }

    }
    AjaxRequest(url, data, "GET", delegate, true, false);
}
function addFriend() {
    var friendId = $("#new-friend-id").val();
    var url = "/People/AddFriend";
    var data = { peopleId: friendId }
    var delegate = function (result) {
        $("#add-friend-success-alert").show();
        $("#friend-info-panel").hide();
        $("#add-friend-search-panel").hide();
    }
    AjaxRequest(url, data, "POST", delegate, true, false);
}