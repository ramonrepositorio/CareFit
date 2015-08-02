$(document).ready(function () {
    InitToolTips("#authentication-index-login");
    $("#forget-my-password-button").click(function () {
        ResetMyPassword();
    });

});
function validAuthenticationForm() {
    if (!$("#people-mail").val()) {
        alert("Email em branco !");
        event.preventDefault();
        return false;
    }
    if (!$("#people-pass").val()) {
        alert("Senha em branco !");
        event.preventDefault();
        return false;
    }    
    return true;
}



function ResetMyPassword() {
    var mail = $("#people-mail").val();
    if (mail) {
        var url = "/Authentication/ResetPassword";
        var data = { mail: mail };
        var delegate = function (result) {
            if (Boolean(result)) {
                alert("Tudo certo, Enviamos um email para você com o procedimento da troca de senha.  favor verificar se o email noreply@carefit.com.br está em sua lista de emails conhecidos");
            }
            else {
                alert("Infelismente não conseguimos resetar sua senha");
            }
        };
        
        AjaxRequest(url, data, "POST", delegate, true, true);
        event.preventDefault();
        return false;
    }
    else {
        alert("Email não preenchido");        
        event.preventDefault();
        return false;
    }
}