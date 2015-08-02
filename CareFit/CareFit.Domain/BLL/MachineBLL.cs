using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class MachineBLL : BaseBLL
    {
        public List<Repository.EquipamentoTipos> GetMachineTypes()
        {
            return _ctx.EquipamentoTipos.Where(et => et.Ativo == true).ToList();
        }

        public List<Repository.Equipamentos> GetMachines(ICollection<Repository.PessoaEmpresas> customerPeoples)
        {
            var customerIds = customerPeoples.Where(cp => cp.PessoaTipoId >= 3).Select(cp => cp.EmpresaId).ToList();

            return (from e in _ctx.Equipamentos
                    where customerIds.Contains(e.EmpresaId)
                    select e).ToList();
        }

        public List<Repository.Equipamentos> GetMachines(ICollection<Repository.PessoaEmpresas> customerPeoples, int? roomId, int? machineTypeId, string machineName)
        {
            var customerIds = customerPeoples.Where(cp => cp.PessoaTipoId >= 3).Select(cp => cp.EmpresaId).ToList();
            var query = (from e in _ctx.Equipamentos
                         where customerIds.Contains(e.EmpresaId)
                         select e);

            if (roomId.HasValue )
            {
                query = query.Where(e => e.SalaId == roomId);
            }
            if (machineTypeId.HasValue)
            {
                query = query.Where(e => e.EquipamentoTipoId == machineTypeId);
            }
            if (!string.IsNullOrEmpty(machineName))
            {
                query = query.Where(e => e.Nome.Contains(machineName));
            }
            return query.ToList();
        }

        public Repository.Equipamentos Get(int machineId)
        {
            return _ctx.Equipamentos.Where(e => e.ID == machineId).FirstOrDefault();
        }

        public List<Repository.Equipamentos> GetMachines(ICollection<Repository.PessoaEmpresas> customerPeoples, string filterName)
        {
            var customerIds = customerPeoples.Where(cp => cp.PessoaTipoId >= 3).Select(cp => cp.EmpresaId).ToList();
            var query = (from e in _ctx.Equipamentos
                         where customerIds.Contains(e.EmpresaId)
                         select e);

            if (!string.IsNullOrEmpty(filterName))
            {
                query = query.Where(e => filterName.Contains(e.Nome));
            }
            return query.ToList();
        }
    }
}
