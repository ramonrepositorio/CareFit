using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Trainig
{
    public class DefaultTrainningREQ
    {
        public bool Professor { get; set; }
        public List<int> Customers { get; set; }
    }
}