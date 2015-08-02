using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Notification.Models
{
    public class ResetPassword : BaseModel
    {
        public ResetPassword()
        {
            TemplateName = "reset-password-mail.html";
            Title = "CareFit - Trocar minha Senha";
        }
        public string token { get; set; }
    }
}
