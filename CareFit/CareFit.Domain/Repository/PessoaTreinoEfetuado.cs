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
    
    public partial class PessoaTreinoEfetuado
    {
        public long ID { get; set; }
        public long PessoaTreinoId { get; set; }
        public System.DateTime Marcacao { get; set; }
    
        public virtual PessoaTreino PessoaTreino { get; set; }
    }
}