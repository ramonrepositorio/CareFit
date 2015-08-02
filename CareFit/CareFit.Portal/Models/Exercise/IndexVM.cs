using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareFit.Portal.Models.Exercise
{
    public class IndexVM
    {
        public List<Domain.Repository.ExercicioTipos> ExerciseTypes { get; set; }
        public List<Domain.Repository.GrupoMuscular> MuscleGroups { get; set; }

    }
}