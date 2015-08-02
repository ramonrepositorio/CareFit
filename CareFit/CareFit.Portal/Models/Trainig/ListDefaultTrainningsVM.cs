using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Trainig
{
    public class ListDefaultTrainningsVM
    {
        public List<Domain.Repository.Treinos> Trainnings { get; set; }
        public long? PeopleId { get; set; }
    }
}