using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Trainig
{
    public class GetDefaultTrainningsVM
    {
        public long? PeopleId { get; set; }
        public List<Domain.Repository.Empresas> Customers { get; set; }
        public List<Domain.Repository.Pessoas> Professors { get; set; }
    }
}