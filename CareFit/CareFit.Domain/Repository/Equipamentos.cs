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
    
    public partial class Equipamentos
    {
        public Equipamentos()
        {
            this.ExercicioEquipamentos = new HashSet<ExercicioEquipamentos>();
            this.Exercicios = new HashSet<Exercicios>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int EmpresaId { get; set; }
        public Nullable<int> SalaId { get; set; }
        public bool Primario { get; set; }
        public bool Ativo { get; set; }
        public bool Secundario { get; set; }
        public int EquipamentoTipoId { get; set; }
        public string Identificacao { get; set; }
    
        public virtual Empresas Empresas { get; set; }
        public virtual EquipamentoTipos EquipamentoTipos { get; set; }
        public virtual Salas Salas { get; set; }
        public virtual ICollection<ExercicioEquipamentos> ExercicioEquipamentos { get; set; }
        public virtual ICollection<Exercicios> Exercicios { get; set; }
    }
}
