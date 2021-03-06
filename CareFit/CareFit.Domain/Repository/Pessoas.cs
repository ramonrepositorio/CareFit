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
    
    public partial class Pessoas
    {
        public Pessoas()
        {
            this.PessoaAmigos = new HashSet<PessoaAmigos>();
            this.PessoaAmigos1 = new HashSet<PessoaAmigos>();
            this.PessoaEmpresas = new HashSet<PessoaEmpresas>();
            this.PessoaMensagens = new HashSet<PessoaMensagens>();
            this.PessoaMensagens1 = new HashSet<PessoaMensagens>();
            this.PessoaPosts = new HashSet<PessoaPosts>();
            this.PessoaProfessor = new HashSet<PessoaProfessor>();
            this.PessoaProfessor1 = new HashSet<PessoaProfessor>();
            this.Pessoas1 = new HashSet<Pessoas>();
            this.PessoaSolicitacaoAmizades = new HashSet<PessoaSolicitacaoAmizades>();
            this.PessoaSolicitacoes = new HashSet<PessoaSolicitacoes>();
            this.PessoaToken = new HashSet<PessoaToken>();
            this.PessoaTreino = new HashSet<PessoaTreino>();
            this.TreinoProfessor = new HashSet<TreinoProfessor>();
            this.Treinos = new HashSet<Treinos>();
        }
    
        public long ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public System.DateTime Cadastro { get; set; }
        public string Cpf { get; set; }
        public string RG { get; set; }
        public System.DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoComplemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public Nullable<long> ProfessorPessoaId { get; set; }
        public Nullable<long> ImagemId { get; set; }
    
        public virtual Imagens Imagens { get; set; }
        public virtual ICollection<PessoaAmigos> PessoaAmigos { get; set; }
        public virtual ICollection<PessoaAmigos> PessoaAmigos1 { get; set; }
        public virtual ICollection<PessoaEmpresas> PessoaEmpresas { get; set; }
        public virtual ICollection<PessoaMensagens> PessoaMensagens { get; set; }
        public virtual ICollection<PessoaMensagens> PessoaMensagens1 { get; set; }
        public virtual ICollection<PessoaPosts> PessoaPosts { get; set; }
        public virtual ICollection<PessoaProfessor> PessoaProfessor { get; set; }
        public virtual ICollection<PessoaProfessor> PessoaProfessor1 { get; set; }
        public virtual ICollection<Pessoas> Pessoas1 { get; set; }
        public virtual Pessoas Pessoas2 { get; set; }
        public virtual ICollection<PessoaSolicitacaoAmizades> PessoaSolicitacaoAmizades { get; set; }
        public virtual ICollection<PessoaSolicitacoes> PessoaSolicitacoes { get; set; }
        public virtual ICollection<PessoaToken> PessoaToken { get; set; }
        public virtual ICollection<PessoaTreino> PessoaTreino { get; set; }
        public virtual ICollection<TreinoProfessor> TreinoProfessor { get; set; }
        public virtual ICollection<Treinos> Treinos { get; set; }
    }
}
