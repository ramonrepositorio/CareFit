using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Machine
{
    public class ListVM
    {
        public List<Domain.Repository.Equipamentos> Machines { get; set; }
        public List<Domain.Repository.EquipamentoTipos> MachineTypes { get; set; }
        public string GetMachineTypeDescription(int machineTypeId)
        {
            return MachineTypes.Where(mt => mt.ID == machineTypeId).FirstOrDefault().Descricao;
        }
    }
}