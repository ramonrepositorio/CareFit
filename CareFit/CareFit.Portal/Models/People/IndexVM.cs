using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CareFit.Domain.Repository;

namespace CareFit.Portal.Models.People
{
    public class IndexVM
    {
        public List<Pessoas> Peoples { get; set; }
        public List<PessoaTipos> PeopleTypes { get; set; }
        public Pessoas LoggedUser { get; set; }
    }
}