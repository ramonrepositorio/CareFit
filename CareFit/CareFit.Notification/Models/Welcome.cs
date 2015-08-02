using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Notification.Models
{
    public class Welcome : BaseModel
    {
        public Welcome() {
            TemplateName = "welcome-mail.html";
        }        
    }
}
