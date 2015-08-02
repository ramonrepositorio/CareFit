using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.People
{
    public class EditVM
    {
        public Domain.Repository.Pessoas People { get; set; }
        public List<Domain.Repository.PessoaTipos> PeopleTypes { get; set; }
        public List<Utils.Cep.Estados> States { get; set; }
        public List<Domain.Repository.PessoaEmpresas> PeopleCustomers { set; get; }
        public Domain.Repository.Imagens Image { get; set; }
    }
}