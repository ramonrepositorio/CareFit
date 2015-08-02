using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class RoomBLL:BaseBLL
    {
        public List<Repository.Salas> GetRooms(ICollection<Repository.PessoaEmpresas> customerPeoples)
        {
            var customerIds = customerPeoples.Where(cp => cp.PessoaTipoId >= 3).Select(cp => cp.EmpresaId).ToList();
            return _ctx.Salas.Where(s => customerIds.Contains(s.EmpresaId)).ToList();
        }
    }
}
