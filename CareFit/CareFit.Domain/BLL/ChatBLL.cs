using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class ChatBLL : BaseBLL
    {
        public List<Repository.Pessoas> GetFriendsWithMessage(long peopleId)
        {
            return (from pm in _ctx.PessoaMensagens
                    join p in _ctx.Pessoas
                    on pm.PessoaRemetenteId equals p.ID
                    where pm.PessoaDestinatarioId == peopleId
                    select p).Distinct().ToList();
        }

        public List<Repository.PessoaMensagens> GetMessages(long PeopleFrom, long peopleId)
        {
            return _ctx.PessoaMensagens.Where(pm => (pm.PessoaRemetenteId == peopleId && pm.PessoaDestinatarioId == PeopleFrom) || (pm.PessoaRemetenteId == PeopleFrom && pm.PessoaDestinatarioId == peopleId)).ToList();
        }

        public Repository.PessoaMensagens PeopleMessageSave(Repository.PessoaMensagens peopleMessage)
        {
            if (peopleMessage.ID == 0)
            {
                _ctx.PessoaMensagens.Add(peopleMessage);
            }
            else
            {
                _ctx.PessoaMensagens.Attach(peopleMessage);
                _ctx.Entry(peopleMessage).State = System.Data.EntityState.Modified;
            }
            _ctx.SaveChanges();
            return peopleMessage;
        }

        public List<Repository.PessoaMensagens> GetNewMessages(long peopleId, DateTime? lastUpdate)
        {
            var query = (from pm in _ctx.PessoaMensagens.Include("Pessoas1")
                         where pm.PessoaDestinatarioId == peopleId
                         && pm.DataVisualizado.HasValue == false
                         select pm);
            if (lastUpdate.HasValue)
            {
                query = query.Where(pm => pm.DataEnvio >= lastUpdate);
            }
            var messages = query.ToList();
            if (messages != null)
            {
                var imageBll = new BLL.ImagesBLL();
                foreach (var msg in messages)
                {
                    msg.Pessoas1.Imagens = imageBll.GetPeopleAvatar(msg.Pessoas1.ID);
                }
            }

            return messages;
        }

        public void ReadyMessages(long peopleId, long friendId)
        {
            var unreadMessages = _ctx.PessoaMensagens.Where(pm => pm.PessoaDestinatarioId == peopleId && pm.PessoaRemetenteId == friendId).ToList();
            if (unreadMessages != null && unreadMessages.Count > 0)
            {
                foreach (var msg in unreadMessages)
                {
                    msg.DataVisualizado = DateTime.Now;
                    PeopleMessageSave(msg);
                }
            }
        }

        public int GetNewMessagesCount(long peopleId)
        {
            return (from pm in _ctx.PessoaMensagens
                    where pm.PessoaDestinatarioId == peopleId
                    && pm.DataVisualizado.HasValue == false
                    select pm).Count();
        }
    }
}
