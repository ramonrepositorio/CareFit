using System.Net.Mail;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text;

namespace CareFit.Notification.BLL
{
    public abstract class SenderBLL
    {
        public Models.NotificationResponse NotiFy(Models.BaseModel mailBase, List<Models.TextReplaces> replaces)
        {

            var textBody = GetHtmlTeamplate(mailBase.TemplateName);
            foreach (var replaceItem in replaces)
            {
                textBody = textBody.Replace(replaceItem.Key, replaceItem.Value);
            }
            textBody = MakeBaseReplaces(textBody, mailBase);

            var mail = MakeMail(mailBase, textBody);
            var mailResponse = SendEmail(mail);

            var notifyResponse = new Models.NotificationResponse();
            return notifyResponse;
        }

        private MailMessage MakeMail(Models.BaseModel mailBase, string mailBody)
        {
            var mail = new MailMessage();
            mail.To.Add(new MailAddress(mailBase.Email, mailBase.Name + " " + mailBase.LastName));
            mail.Subject = mailBase.Title;
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("noreply@carefit.com.br", "CareFit [Não Responda]");
            
            return mail;
        }

        private string MakeBaseReplaces(string textBody, Models.BaseModel mailBase)
        {
            textBody = textBody.Replace("[##NAME##]", mailBase.Name);
            textBody = textBody.Replace("[##LASTNAME##]", mailBase.LastName);
            textBody = textBody.Replace("[##EMAIL##]", mailBase.Email);
            return textBody;
        }

        public string GetHtmlTeamplate(string teamplateName)
        {
            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("CareFit.Notification.Teamplates." + teamplateName)))
            {
                return reader.ReadToEnd();
            }
        }

        private string SendEmail(MailMessage mail)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            var smtp = new SmtpClient
            {
                Host = "mail.carefit.com.br",
                Port = 587,                
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("noreply@carefit.com.br", "E29GpW2n5v"),
                //Credentials = new System.Net.NetworkCredential("ramon.quirino@carefit.com.br", "Senha@123"),
                EnableSsl = true
            };

            {
                smtp.Send(mail);
            }

            return "";
        }



        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }
            else
            {
                //ServiceFault.WriteLog("Invalid SSL");
                return true;
            }
        }
    }
}