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
    
    public partial class ExercicioEquipamentos
    {
        public int ID { get; set; }
        public int EquipamentoID { get; set; }
        public int ExercicioId { get; set; }
    
        public virtual Equipamentos Equipamentos { get; set; }
        public virtual Exercicios Exercicios { get; set; }
    }
}