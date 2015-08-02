$(document).ready(function(){
    $("#fuFileUploader").uploadify({
        'hideButton': false,       // We use a trick below to overlay a fake html upload button with this hidden flash button                         
        //'wmode': 'transparent',
        'uploader': '/Content/Componentes/Uploadify/uploadify.swf',
        'cancelImg': '/Content/Componentes/Uploadify/cancel.png',
        'buttonText': 'Enviar nova foto',
        'buttonClass': 'btn btn-default',
        'script': '/Images/FileUpload',
        'multi': true,
        'auto': true,
        'fileExt': '*.jpg;*.gif;*.png;*.jpeg',
        'fileDesc': 'Image Files',
        //'scriptData': { RequireUploadifySessionSync: true, SecurityToken: UploadifyAuthCookie, SessionId: UploadifySessionId },
        'onComplete': function (event, ID, fileObj, response, data) {
            response = $.parseJSON(response);
            if (response.Status == 'OK') {                
                $("#avatar-picture-original").attr("src", response.imagePath);
                $("#avatar-picture-preview").attr("src", response.imagePath);
                $('#avatar-picture-original').Jcrop({
                    onChange: showPreview,
                    onSelect: showPreview,
                    aspectRatio: 1
                });
            }
        }
    });
});

function showPreview(coords) {
    var rx = 100 / coords.w;
    var ry = 100 / coords.h;

    $('#avatar-picture-preview').css({
        width: Math.round(rx * 500) + 'px',
        height: Math.round(ry * 370) + 'px',
        marginLeft: '-' + Math.round(rx * coords.x) + 'px',
        marginTop: '-' + Math.round(ry * coords.y) + 'px'
    });
}



