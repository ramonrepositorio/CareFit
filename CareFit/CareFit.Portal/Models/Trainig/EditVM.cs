using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Trainig
{
    public class EditVM
    {
        public long PeopleId { get; set; }
        public Domain.Repository.Treinos Trainning { get; set; }
        public List<Domain.Repository.TreinoTipos> TrainnigTypes { get; set; }
        public bool Professor { get; set; }
        public List<Domain.Repository.Empresas> Coordinator { get; set; }
        public Models.Trainig.DefaultTrainningREQ DefaultTrainnings { get; set; }
    }
}