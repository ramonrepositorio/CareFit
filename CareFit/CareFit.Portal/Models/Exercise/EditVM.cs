using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Exercise
{
    public class EditVM
    {
        public List<Domain.Repository.ExercicioTipos> ExerciseTypes { get; set; }
        public List<Domain.Repository.GrupoMuscular> ExerciseMuscleGroups { get; set; }
        public Domain.Repository.Exercicios Exercise { get; set; }
        public List<Domain.Repository.Equipamentos> Machines { get; set; }
        public List<Domain.Repository.EquipamentoTipos> MachineTypes { get; set; }
        public List<Domain.Repository.Empresas> Customers { get; set; }
        public string GetMachineTypeDescription(int machineTypeId)
        {
            return MachineTypes.Where(mt => mt.ID == machineTypeId).FirstOrDefault().Descricao;
        }
    }
}