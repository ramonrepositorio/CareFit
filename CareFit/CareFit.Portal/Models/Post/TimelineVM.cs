using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Post
{
    public class TimelineVM
    {
        public List<Domain.Repository.PessoaPosts> Posts { get; set; }
    }
}