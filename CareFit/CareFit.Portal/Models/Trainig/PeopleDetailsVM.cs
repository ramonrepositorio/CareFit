using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Trainig
{
    public class PeopleDetailsVM
    {
        public Domain.Repository.Pessoas People { get; set; }
        public Domain.Repository.Pessoas Professor { get; set; }
        public List<Domain.Repository.PessoaTreino> Trainnings { get; set; }
    }
}