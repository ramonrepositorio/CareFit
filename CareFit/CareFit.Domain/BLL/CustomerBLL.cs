using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class CustomerBLL : BaseBLL
    {
        public Repository.Empresas GetCustomer(int customerId)
        {
            return _ctx.Empresas.Where(e => e.ID == customerId).FirstOrDefault();
        }

        public Repository.Imagens GetImageByKey(string customerKey)
        {
            return (from e in _ctx.Empresas
                    join im in _ctx.Imagens
                    on e.ImagemID equals im.ID
                    where e.Nome == customerKey
                    select im).FirstOrDefault();

        }

        public Domain.Repository.Empresas GetCustomerByKey(string customerKey)
        {
            return _ctx.Empresas.Where(e => e.Nome == customerKey).FirstOrDefault();
        }
    }
}
