using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class BaseBLL
    {
        public Repository.CareFitEntities _ctx { get; set; }
        public BaseBLL()
        {
            _ctx = new Repository.CareFitEntities();
        }
    }
}
