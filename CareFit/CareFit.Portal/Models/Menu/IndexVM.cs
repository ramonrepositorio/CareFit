using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Menu
{
    public class IndexVM
    {
        public Domain.Repository.Pessoas LoggedUser { get; set; }
        public List<Domain.Repository.PessoaTreino> PepleTrainnings { get; set; }
    }
}