using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Machine
{
    public class EditVM
    {
        public List<Domain.Repository.EquipamentoTipos> MachineTypes { get; set; }
        public Domain.Repository.Equipamentos Machine { get; set; }
        public List<Domain.Repository.Salas> Rooms { get; set; }
        public List<Domain.Repository.Empresas> Customers { get;set; }
    }
}