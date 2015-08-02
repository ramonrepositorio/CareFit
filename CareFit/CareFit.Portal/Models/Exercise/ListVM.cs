using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Exercise
{
    public class ListVM
    {
        public List<Domain.Repository.ExercicioTipos> ExerciseTypes { get; set; }
        public List<Domain.Repository.GrupoMuscular> ExerciseMuscleGroups { get; set; }
        public List<Domain.Repository.Exercicios> Exercises { get; set; }

        public string GetExerciseTypeDescription(int exerciseTypeId)
        {
            return ExerciseTypes.Where(et => et.ID == exerciseTypeId).FirstOrDefault().Descricao;
        }
        public string GetMuscleGroupDescription(int mucleGroupId)
        {
            return ExerciseMuscleGroups.Where(emg => emg.ID == mucleGroupId).FirstOrDefault().Descricao;
        }
        
    }
}