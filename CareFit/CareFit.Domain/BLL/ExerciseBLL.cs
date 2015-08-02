using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class ExerciseBLL : BaseBLL
    {
        public List<Repository.ExercicioTipos> GetExerciseTypes()
        {
            return _ctx.ExercicioTipos.ToList();
        }

        public List<Repository.GrupoMuscular> GetMuscleGroups()
        {
            return _ctx.GrupoMuscular.ToList();
        }
        public Repository.Exercicios Get(int exerciseId)
        {
            return _ctx.Exercicios.Where(e => e.ID == exerciseId).FirstOrDefault();
        }

        public List<Repository.Exercicios> GetExercises(ICollection<Repository.PessoaEmpresas> customerPeoples, int? exerciseMuscleGroupId, int? exerciseTypeId, string exerciseName)
        {
            var customerIds = customerPeoples.Where(cp => cp.PessoaTipoId >= 3).Select(cp => cp.EmpresaId).ToList();
            var query = (from e in _ctx.Exercicios
                         where customerIds.Contains(e.EmpresaId)
                         select e);

            if (exerciseMuscleGroupId.HasValue)
            {
                query = query.Where(ex => ex.GrupoMuscularId == exerciseMuscleGroupId.Value);
            }
            if (exerciseTypeId.HasValue)
            {
                query = query.Where(ext => ext.ExercicioTipoId == exerciseTypeId);
            }
            if (!string.IsNullOrEmpty(exerciseName))
            {
                query = query.Where(ex => ex.Nome.Contains(exerciseName));
            }
            return query.ToList();
        }
        public Repository.Exercicios Save(Repository.Exercicios exercise)
        {
            if (exercise.EquipamentoId <= 0)
            {
                exercise.EquipamentoId = null;
            }
            if (exercise.ID == 0)
            {
                _ctx.Exercicios.Add(exercise);
            }
            else
            {

                if (exercise.ExercicioEquipamentos != null)
                {
                    List<Repository.ExercicioEquipamentos> loRemove = new List<Repository.ExercicioEquipamentos>();
                    foreach (var equipamento in exercise.ExercicioEquipamentos)
                    {
                        var equipamentoAdded = _ctx.ExercicioEquipamentos.Where(ee => ee.EquipamentoID == equipamento.EquipamentoID && ee.ExercicioId == equipamento.ExercicioId).FirstOrDefault();
                        if (equipamentoAdded != null)
                        {
                            equipamento.ID = equipamentoAdded.ID;
                            _ctx.Entry(equipamentoAdded).State = System.Data.EntityState.Detached;
                            _ctx.Entry(equipamento).State = System.Data.EntityState.Modified;
                        }
                        else
                        {
                            _ctx.Entry(equipamento).State = System.Data.EntityState.Added;
                        }
                    }


                    var equipamentos = _ctx.ExercicioEquipamentos.Where(ee => ee.ExercicioId == exercise.ID).ToList();
                    if (equipamentos != null)
                    {
                        foreach (var equipamentoBase in equipamentos)
                        {
                            var equipamentoRemove = exercise.ExercicioEquipamentos.Where(ee => ee.EquipamentoID == equipamentoBase.EquipamentoID).FirstOrDefault();
                            if (equipamentoRemove == null)
                            {
                                _ctx.ExercicioEquipamentos.Remove(equipamentoBase);
                            }
                        }
                    }
                    equipamentos = null;
                }


                _ctx.Exercicios.Attach(exercise);
                _ctx.Entry(exercise).State = System.Data.EntityState.Modified;
            }
            _ctx.SaveChanges();
            return exercise;
        }

        public List<Repository.ExercicioEquipamentos> GetExerciseEquipamentos(int exerciseId)
        {
            return _ctx.ExercicioEquipamentos.Where(ee => ee.ExercicioId == exerciseId).ToList();
        }

        public List<Repository.Exercicios> GetExercisesByFilter(ICollection<Repository.PessoaEmpresas> customerPeoples, string filter)
        {
            var customerIds = customerPeoples.Where(cp => cp.PessoaTipoId >= 2).Select(cp => cp.EmpresaId).ToList();
            return (from ex in _ctx.Exercicios.Include("Equipamentos")
                    join eq in _ctx.Equipamentos
                        on ex.EquipamentoId equals eq.ID
                    where (ex.Nome.Contains(filter)
                    || eq.Nome.Contains(filter))
                    && customerIds.Contains(ex.EmpresaId)
                    select ex).ToList();
        }
    }
}
