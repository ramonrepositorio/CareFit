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
    
    public partial class PessoaEmpresas
    {
        public long ID { get; set; }
        public long PessoaId { get; set; }
        public int EmpresaId { get; set; }
        public int PessoaTipoId { get; set; }
        public bool Ativo { get; set; }
    
        public virtual Empresas Empresas { get; set; }
        public virtual Pessoas Pessoas { get; set; }
        public virtual PessoaTipos PessoaTipos { get; set; }
    }
}
