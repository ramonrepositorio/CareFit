using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Home
{
    public class TopItensVM
    {
        public int OpenTrainnings { get; set; }
        public int TotalTrainningsSessions { get; set; }
        public int DoneTrainningsSessions { get; set; }
    }
}