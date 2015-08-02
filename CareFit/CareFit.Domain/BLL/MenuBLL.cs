using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class MenuBLL : BaseBLL
    {
        public List<Repository.Menus> GetAutorizedMenus(long peopleId)
        {
            return GetHierarquicalMenus(peopleId, null);
        }
        public List<Repository.Menus> GetHierarquicalMenus(long peopleId, int? menuID)
        {
            var query = (from p in _ctx.Pessoas
                         join pe in _ctx.PessoaEmpresas
                         on p.ID equals pe.PessoaId
                         join ptp in _ctx.PessoaTipoPermissoes
                             on pe.PessoaTipoId equals ptp.PessoaTipoID
                         join m in _ctx.Menus
                             on ptp.PermissaoID equals m.PermisaoId
                         where p.ID == peopleId
                         && pe.Ativo == true
                         select m);

            ///testando valores nulos
            if (menuID.HasValue)
            {
                query = query.Where(m => m.MenuId == menuID);
            }
            else
            {
                query = query.Where(m => m.MenuId.HasValue == false);
            }
            var menus = query.Distinct().ToList();
            foreach (var menu in menus)
            {
                menu.Menus1 = GetHierarquicalMenus(peopleId, menu.ID);
            }
            return menus;
            
        }
    }
}
