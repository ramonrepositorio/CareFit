using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Machine
{
    public class IndexVM
    {
        public List<Domain.Repository.Equipamentos> Machines { get; set; }
        public List<Domain.Repository.EquipamentoTipos> MachineTypes { get; set; }
        public List<Domain.Repository.Salas> Rooms { get; set; }
    }
}