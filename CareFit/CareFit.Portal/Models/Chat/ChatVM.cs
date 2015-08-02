using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Chat
{
    public class ChatVM
    {
        public List<Domain.Repository.PessoaMensagens> Messages { get; set; }
        public long PeopleId { get; set; }
        public long PeopleFromId { get; set; }
        public Domain.Repository.Imagens ImagePeople { get; set; }
        public Domain.Repository.Imagens ImagePeopleFrom { get; set; }

    }
}