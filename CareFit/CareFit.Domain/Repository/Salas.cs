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
    
    public partial class Salas
    {
        public Salas()
        {
            this.Equipamentos = new HashSet<Equipamentos>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public int EmpresaId { get; set; }
    
        public virtual Empresas Empresas { get; set; }
        public virtual ICollection<Equipamentos> Equipamentos { get; set; }
    }
}
