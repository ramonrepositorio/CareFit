using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Trainig
{
    public class PrintTrainningVM
    {
        public Domain.Repository.Treinos Trainning { get; set; }
        public Domain.Repository.PessoaTreino PeopleTrainning { get; set; }
    }
}