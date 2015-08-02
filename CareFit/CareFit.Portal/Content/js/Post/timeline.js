$(document).ready(function () {
    $("#add-new-post").click(function () {
        addNewPost();
    });
});

function addNewPost() {
    post = $("#add-new-post-text").val();
    var data = {
        postText: post
    }
    var url = "/Post/AddNew";
    var delegate = function (result) {
        OpenContent("Home", "Index", null);
    }
    AjaxRequest(url, data, "POST", delegate, true);
}