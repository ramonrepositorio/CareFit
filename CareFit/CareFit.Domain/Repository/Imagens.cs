//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareFit.Domain.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Imagens
    {
        public Imagens()
        {
            this.Empresas = new HashSet<Empresas>();
            this.Pessoas = new HashSet<Pessoas>();
        }
    
        public long ID { get; set; }
        public string Url { get; set; }
        public System.DateTime Cadastro { get; set; }
    
        public virtual ICollection<Empresas> Empresas { get; set; }
        public virtual ICollection<Pessoas> Pessoas { get; set; }
    }
}
