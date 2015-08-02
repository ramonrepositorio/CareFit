using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class AuthenticationBLL : BaseBLL
    {
        public Repository.Pessoas Authorize(string mail)
        {
            return _ctx.Pessoas.Where(p => p.Email == mail).FirstOrDefault();
        }
        public bool ResetPassword(string email)
        {
            var people = new Domain.BLL.PeopleBLL().GetPeople(email);
            if (people != null)
            {
                var resetNotificationModel = new Notification.Models.ResetPassword();
                var token = GetToken(people.ID,1);

                resetNotificationModel.token = Uri.EscapeUriString(token.Token);
                resetNotificationModel.Email = people.Email;
                resetNotificationModel.Name = people.Nome;
                resetNotificationModel.LastName = people.Sobrenome;
                
                var notificationResponse = new Notification.BLL.NotificationBLL().NotifyMail(resetNotificationModel);
            }


            return false;
        }

        public Repository.PessoaToken GetToken(long peopleId,int validDays)
        {
            var lastToken = _ctx.PessoaToken.Where(pt => pt.PessoaId == peopleId && pt.Cadastro <= DateTime.Now && pt.Vencimento >= DateTime.Now).FirstOrDefault();
            if (lastToken == null)
            {
                lastToken = new Repository.PessoaToken();
                lastToken.PessoaId = peopleId;
                lastToken.Cadastro = DateTime.Now;
                lastToken.Vencimento = DateTime.Now.AddDays(validDays);
                lastToken.Token = new Utils.Cryptography.EncryptMd5().GenerateRandomCode(50);
                _ctx.Entry(lastToken).State = System.Data.EntityState.Added;
                _ctx.SaveChanges();
                lastToken.Pessoas = null;
            }
            return lastToken;
        }

        public Repository.PessoaToken ReLogin(string token, string mail)
        {
            return (from pt in _ctx.PessoaToken
                    join p in _ctx.Pessoas
                    on pt.PessoaId equals p.ID
                    where pt.Token == token
                    && p.Email == mail
                    && pt.Cadastro <= DateTime.Now
                    && pt.Vencimento >= DateTime.Now
                    select pt).FirstOrDefault();
        }
    }
}
