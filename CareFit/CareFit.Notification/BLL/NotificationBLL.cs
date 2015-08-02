using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Notification.BLL
{
    public class NotificationBLL:SenderBLL
    {
        public Models.NotificationResponse NotifyMail(Models.Welcome welcome) {
            var listReplaces = new List<Models.TextReplaces>();

            var notifyResponse = NotiFy(welcome, listReplaces);
            return notifyResponse;
        }
        public Models.NotificationResponse NotifyMail(Models.ResetPassword resetPassword)
        {
            var listReplaces = new List<Models.TextReplaces>();
            listReplaces.Add(new Models.TextReplaces { Key = "[##TOKEN##]", Value = resetPassword.token });
            var notifyResponse = NotiFy(resetPassword, listReplaces);
            return notifyResponse;
        }
    }
}
