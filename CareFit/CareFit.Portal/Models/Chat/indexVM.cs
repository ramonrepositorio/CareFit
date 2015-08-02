using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Chat
{
    public class indexVM
    {
        public List<Domain.Repository.Pessoas> Friends { get; set; }
        public List<Domain.Repository.Pessoas> FriendsChat { get; set; }
    }
}