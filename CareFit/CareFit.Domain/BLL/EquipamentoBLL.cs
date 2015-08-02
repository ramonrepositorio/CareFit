using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class EquipamentoBLL : BaseBLL
    {
        public Repository.Equipamentos Save(Repository.Equipamentos machine)
        {
            if (machine.ID == 0)
            {
                _ctx.Equipamentos.Add(machine);
            }
            else
            {
                _ctx.Equipamentos.Attach(machine);
                _ctx.Entry(machine).State = System.Data.EntityState.Modified;
            }
            _ctx.SaveChanges();
            return machine;
        }
    }
}
