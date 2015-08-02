using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Utils.Cep
{
    public class Estados
    {

        public string UF { get; set; }
        public string Estado { get; set; }


        public List<Estados> GetAll()
        {
            var _ufs = new List<Estados>();
            _ufs.Add(new Estados { Estado = "Acre", UF = "AC" });
            _ufs.Add(new Estados { Estado = "Alagoas", UF = "AL" });
            _ufs.Add(new Estados { Estado = "Amapá", UF = "AP" });
            _ufs.Add(new Estados { Estado = "Amazonas", UF = "AM" });
            _ufs.Add(new Estados { Estado = "Bahia", UF = "BA" });
            _ufs.Add(new Estados { Estado = "Ceará", UF = "CE" });
            _ufs.Add(new Estados { Estado = "Distrito Federal", UF = "DF" });
            _ufs.Add(new Estados { Estado = "Espírito Santo", UF = "ES" });
            _ufs.Add(new Estados { Estado = "Goiás", UF = "GO" });
            _ufs.Add(new Estados { Estado = "Maranhão", UF = "MA" });
            _ufs.Add(new Estados { Estado = "Mato Grosso", UF = "MT" });
            _ufs.Add(new Estados { Estado = "Mato Grosso do Sul", UF = "MS" });
            _ufs.Add(new Estados { Estado = "Minas Gerais", UF = "MG" });
            _ufs.Add(new Estados { Estado = "Pará", UF = "PA" });
            _ufs.Add(new Estados { Estado = "Paraíba", UF = "PB" });
            _ufs.Add(new Estados { Estado = "Paraná", UF = "PR" });
            _ufs.Add(new Estados { Estado = "Pernambuco", UF = "	PE	" });
            _ufs.Add(new Estados { Estado = "Piauí", UF = "PI" });
            _ufs.Add(new Estados { Estado = "Rio de Janeiro	", UF = "RJ" });
            _ufs.Add(new Estados { Estado = "Rio Grande do Norte", UF = "RN" });
            _ufs.Add(new Estados { Estado = "Rio Grande do Sul	", UF = "RS" });
            _ufs.Add(new Estados { Estado = "Rondônia	", UF = "RO" });
            _ufs.Add(new Estados { Estado = "Roraima", UF = "RR" });
            _ufs.Add(new Estados { Estado = "Santa Catarina", UF = "SC" });
            _ufs.Add(new Estados { Estado = "São Paulo", UF = "SP" });
            _ufs.Add(new Estados { Estado = "Sergipe	", UF = "SE" });
            _ufs.Add(new Estados { Estado = "Tocantins", UF = "TO" });
            return _ufs;
        }
    }
}
