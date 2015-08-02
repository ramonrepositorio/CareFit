var jcrop_api;
$(document).ready(function () {
    StartJcrop();

    $("#image-crop-button").click(function () {
        CropImage();
    });


    $("#image-input-file").change(function () {
        //$("#image-input-text-files").val($(this).val());
        if ($(this).val()) {
            $("#image-send-button").removeAttr("disabled");
            $("#image-crop-button").removeAttr("disabled");
            $('#form-upload-image').submit();
        }
        else {
            $("#image-send-button").attr("disabled", "true");
            $("#image-crop-button").attr("disabled", "true");
        }
    });
    var bar = $('#image-upload-bar');
    var percentVal = 0;

    $('#form-upload-image').ajaxForm({
        beforeSend: function () {

            bar.width(percentVal)
            $("#image-progress-panel").show();
        },
        uploadProgress: function (event, position, total, percentComplete) {
            percentVal = percentComplete;
            bar.width(percentVal)
            //percent.html(percentVal);
        },
        success: function () {
            bar.width(percentVal)
        },
        complete: function (xhr) {

            cropData.imagePath = "/Uploads/Temp/" + xhr.responseText;
            jcrop_api.setImage(cropData.imagePath);
            $("#image-progress-panel").hide();
        }
    });
});
var cropData = {
    x: 0,
    y: 0,
    w: 0,
    h: 0,
    imagePath: ""
};
function saveCoords(c) {
    cropData.x = c.x;
    cropData.y = c.y;
    cropData.h = c.h;
    cropData.w = c.w;
}
function CropImage() {
    //cropData.imagePath = $("#image-input-file").val();
    var url = "/Images/CropImage";
    var delegate = function (result) {
        cropData.imagePath = "/Uploads/Temp/" + result;
        jcrop_api.setImage(cropData.imagePath);
    };
    AjaxRequest(url, cropData, "POST", delegate, true, false);
}
function SaveImage(externalDelegate) {
    var data = {
        fileName: cropData.imagePath
    };
    var delegate = function (result) {
        var externalResult = {
            ID: result,
            ImagePath: cropData.imagePath
        }
        if (externalDelegate) {
            externalDelegate(externalResult);
        }
    }
    var url = "/Images/SaveImage";
    AjaxRequest(url, data, "POST", delegate, true, false);
}
function StartJcrop() {
    var opt = {
        onChange: saveCoords,
        onSelect: saveCoords
    }
    jcrop_api = $.Jcrop($('#image-image'), opt);

}