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
    
    public partial class Empresas
    {
        public Empresas()
        {
            this.Equipamentos = new HashSet<Equipamentos>();
            this.Exercicios = new HashSet<Exercicios>();
            this.PessoaEmpresas = new HashSet<PessoaEmpresas>();
            this.PessoaSolicitacaoEmpresa = new HashSet<PessoaSolicitacaoEmpresa>();
            this.Salas = new HashSet<Salas>();
            this.TreinoEmpresa = new HashSet<TreinoEmpresa>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public Nullable<long> ImagemID { get; set; }
    
        public virtual Imagens Imagens { get; set; }
        public virtual ICollection<Equipamentos> Equipamentos { get; set; }
        public virtual ICollection<Exercicios> Exercicios { get; set; }
        public virtual ICollection<PessoaEmpresas> PessoaEmpresas { get; set; }
        public virtual ICollection<PessoaSolicitacaoEmpresa> PessoaSolicitacaoEmpresa { get; set; }
        public virtual ICollection<Salas> Salas { get; set; }
        public virtual ICollection<TreinoEmpresa> TreinoEmpresa { get; set; }
    }
}
