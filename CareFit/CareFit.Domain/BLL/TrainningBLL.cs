using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{
    public class TrainningBLL : BaseBLL
    {
        public Repository.PessoaProfessor BindProfessor(long professorId, long peopleId)
        {
            var newBind = new Repository.PessoaProfessor();

            //atualizando historicos de professores
            var oldBind = _ctx.PessoaProfessor.Where(pp => pp.PessoaId == peopleId && pp.ProfessorPeopleId == professorId && pp.Termino.HasValue == false).FirstOrDefault();
            if (oldBind != null)
            {
                oldBind.Termino = DateTime.Now;
                _ctx.PessoaProfessor.Attach(oldBind);
                _ctx.Entry(oldBind).State = System.Data.EntityState.Modified;
            }

            // atualizando professor do aluno
            var people = _ctx.Pessoas.Where(p => p.ID == peopleId).FirstOrDefault();
            people.ProfessorPessoaId = professorId;
            _ctx.Pessoas.Attach(people);
            _ctx.Entry(people).State = System.Data.EntityState.Modified;

            newBind.Inicio = DateTime.Now;
            newBind.PessoaId = peopleId;
            newBind.ProfessorPeopleId = professorId;
            _ctx.PessoaProfessor.Add(newBind);

            _ctx.SaveChanges();

            return newBind;
        }

        public List<Repository.PessoaTreino> GetTrainnings(long peopleId)
        {
            return (from pt in _ctx.PessoaTreino.Include("Treinos")
                    where pt.PessoaId == peopleId
                    select pt).ToList();
        }

        public Repository.Treinos Get(long trainningID)
        {
            return _ctx.Treinos.Where(t => t.ID == trainningID).FirstOrDefault();
        }

        public List<Repository.TreinoTipos> GetTrainningTypes()
        {
            return _ctx.TreinoTipos.ToList();
        }

        public Repository.Treinos Save(Repository.Treinos trainning)
        {
            if (trainning.ID == 0)
            {
                _ctx.Treinos.Add(trainning);
            }
            else
            {
                if (trainning.TreinoExercicios != null)
                {
                    foreach (var exercise in trainning.TreinoExercicios)
                    {
                        if (exercise.ID <= 0)
                        {
                            _ctx.Entry(exercise).State = System.Data.EntityState.Added;
                        }
                    }
                }
                _ctx.Treinos.Attach(trainning);
                _ctx.Entry(trainning).State = System.Data.EntityState.Modified;
            }
            _ctx.SaveChanges();
            return trainning;
        }

        public List<Repository.TreinoExercicios> GetTrainningExercises(long trainningId)
        {
            return (from te in _ctx.TreinoExercicios.Include("Exercicios")
                    where te.TreinoId == trainningId
                    select te).ToList();
        }

        public List<Domain.Repository.PessoaTreinoEfetuado> GetDoneTrainings(long peopleId)
        {
            var doneTrainings = (from pt in _ctx.PessoaTreino
                                 join pte in _ctx.PessoaTreinoEfetuado
                                     on pt.ID equals pte.PessoaTreinoId
                                 where pt.PessoaId == peopleId
                                 select pte).ToList();
            doneTrainings.ForEach(delegate(Domain.Repository.PessoaTreinoEfetuado pte)
            {
                pte.PessoaTreino = _ctx.PessoaTreino.Where(pt => pt.ID == pte.PessoaTreinoId).FirstOrDefault();
                if (pte.PessoaTreino != null)
                {
                    pte.PessoaTreino.Treinos = _ctx.Treinos.Where(t => t.ID == pte.PessoaTreino.TreinoId).FirstOrDefault();
                }
            });
            return doneTrainings;
        }

        public List<Repository.PessoaTreino> GetPeopleTrainnings(long peopleId)
        {
            var trainnings = (from pt in _ctx.PessoaTreino.Include("Treinos")
                              where pt.PessoaId == peopleId
                              select pt).ToList();
            return trainnings;
        }

        public Repository.Treinos GetTrainningToView(long trainningId)
        {
            var trainning = _ctx.Treinos.Include("TreinoExercicios").Where(t => t.ID == trainningId).FirstOrDefault();
            if (trainning.TreinoExercicios != null)
            {
                foreach (var exercises in trainning.TreinoExercicios)
                {

                    exercises.Exercicios = _ctx.Exercicios.Where(t => t.ID == exercises.ExercicioId).FirstOrDefault();
                }
            }

            return trainning;
        }

        public Repository.PessoaTreino GetPeopleTrainning(long trainningId)
        {
            return _ctx.PessoaTreino.Where(pt => pt.ID == trainningId).FirstOrDefault();
        }

        public int CheckTrainning(long peopleTrainningId)
        {
            var checkTrainning = new Repository.PessoaTreinoEfetuado();
            checkTrainning.Marcacao = DateTime.Now;
            checkTrainning.PessoaTreinoId = peopleTrainningId;

            _ctx.Entry(checkTrainning).State = System.Data.EntityState.Added;
            _ctx.SaveChanges();

            return _ctx.PessoaTreinoEfetuado.Where(pte => pte.PessoaTreinoId == peopleTrainningId).Count();
        }



        public Repository.PessoaTreinoEfetuado GetLastPeopleTrainningDone(long peopleTrainningId)
        {
            return _ctx.PessoaTreinoEfetuado.Where(pte => pte.PessoaTreinoId == peopleTrainningId).OrderByDescending(pte => pte.Marcacao).FirstOrDefault();
        }

        public List<Repository.Pessoas> GetProfessorDefaultTrainnings(List<Repository.PessoaEmpresas> peopleCustomers)
        {
            var professors = new List<Repository.Pessoas>();

            var professorIds = peopleCustomers.Where(pc => pc.PessoaTipoId == 2).Select(pc => pc.PessoaId).ToList();
            professors = _ctx.Pessoas.Where(p => professorIds.Contains(p.ID)).ToList();

            var customerIds = peopleCustomers.Where(pc => pc.PessoaTipoId >= 3).Select(pc => pc.EmpresaId).ToList();
            if (customerIds != null && customerIds.Count > 0)
            {
                var professorsList = (from pe in _ctx.PessoaEmpresas
                                      join p in _ctx.Pessoas
                                      on pe.PessoaId equals p.ID
                                      where customerIds.Contains(pe.EmpresaId)
                                      && pe.PessoaTipoId == 2
                                      select p).ToList();
                if (professors == null)
                {
                    professors = new List<Repository.Pessoas>();
                }
                professors.AddRange(professorsList);
            }

            return professors.Distinct().ToList();
        }

        public List<Repository.Empresas> GetCustomersDefaultTrainnings(List<Repository.PessoaEmpresas> peopleCustomers)
        {
            var customerIds = peopleCustomers.Where(pc => pc.PessoaTipoId >= 3).Select(pc => pc.EmpresaId).ToList();
            return _ctx.Empresas.Where(e => customerIds.Contains(e.ID)).ToList();
        }

        public List<Repository.Treinos> GetDefaultTrainnings(long? professorId, int? customerId, List<Repository.PessoaEmpresas> peopleCustomers)
        {
            List<Repository.Treinos> defaultTrainnings = null;

            if (professorId == -1)
                professorId = null;

            if (customerId == -1)
                customerId = null;

            if (professorId.HasValue == false && customerId.HasValue == false)
            {
                var professorIds = peopleCustomers.Where(pc => pc.PessoaTipoId == 2).Select(pc => pc.PessoaId).ToList();
                var customerIds = peopleCustomers.Where(pc => pc.PessoaTipoId >= 3).Select(pc => pc.EmpresaId).ToList();


                if (customerIds != null && customerIds.Count > 0)
                {
                    professorIds = (from pe in _ctx.PessoaEmpresas
                                    join p in _ctx.PessoaEmpresas
                                        on pe.PessoaId equals p.ID
                                    where customerIds.Contains(pe.EmpresaId)
                                    && pe.PessoaTipoId == 2
                                    select p.ID).ToList();

                    defaultTrainnings = (from te in _ctx.TreinoEmpresa
                                         join t in _ctx.Treinos
                                             on te.TreinoId equals t.ID
                                         where customerIds.Contains(te.EmpresaId)
                                         select t).ToList();


                }

                var defaultProfessorsTrainnings = (from tp in _ctx.TreinoProfessor
                                                   join t in _ctx.Treinos
                                                       on tp.TreinoId equals t.ID
                                                   where professorIds.Contains(tp.PessoaId)
                                                   select t).ToList();
                if (defaultProfessorsTrainnings != null && defaultProfessorsTrainnings.Count > 0)
                {
                    if (defaultTrainnings == null)
                    {
                        defaultTrainnings = defaultProfessorsTrainnings;
                    }
                    else
                    {
                        defaultTrainnings.AddRange(defaultProfessorsTrainnings);
                    }
                }
            }
            else
            {
                if (professorId.HasValue)
                {
                    defaultTrainnings = (from tp in _ctx.TreinoProfessor
                                         join t in _ctx.Treinos
                                         on tp.TreinoId equals t.ID
                                         where tp.PessoaId == professorId.Value
                                         select t).ToList();
                }
                if (customerId.HasValue)
                {
                    var defaultCustomersTrainnings = (from te in _ctx.TreinoEmpresa
                                                      join t in _ctx.Treinos
                                                      on te.TreinoId equals t.ID
                                                      where te.EmpresaId == customerId.Value
                                                      select t).ToList();

                    if (defaultCustomersTrainnings != null && defaultCustomersTrainnings.Count > 0)
                    {
                        if (defaultTrainnings == null)
                        {
                            defaultTrainnings = defaultCustomersTrainnings;
                        }
                        else
                        {
                            defaultTrainnings.AddRange(defaultCustomersTrainnings);
                        }
                    }
                }
            }

            foreach (var trainning in defaultTrainnings)
            {
                trainning.TreinoTipos = _ctx.TreinoTipos.Where(tt => tt.ID == trainning.TreinoTipoId).FirstOrDefault();
            }

            return defaultTrainnings;
        }

        public void BindProfessorDefaultTrainning(bool added, long professorId, long trainningId)
        {
            var defaultTrainning = _ctx.TreinoProfessor.Where(tp => tp.PessoaId == professorId && tp.TreinoId == trainningId).FirstOrDefault();
            if (added)
            {
                if (defaultTrainning == null)
                {
                    defaultTrainning = new Repository.TreinoProfessor();
                    defaultTrainning.TreinoId = trainningId;
                    defaultTrainning.PessoaId = professorId;
                    defaultTrainning.Cadastro = DateTime.Now;
                    _ctx.Entry(defaultTrainning).State = System.Data.EntityState.Added;
                    _ctx.SaveChanges();
                }
            }
            else
            {
                if (defaultTrainning != null)
                {
                    _ctx.TreinoProfessor.Remove(defaultTrainning);
                }
            }
        }

        public void BindCustomerDefaultTrainning(long trainningId, List<int> customers, List<Repository.PessoaEmpresas> peopleCustommers)
        {
            var customerGranted = peopleCustommers.Where(pe => pe.PessoaTipoId > 2).Select(pe => pe.EmpresaId).ToList();
            if (customerGranted != null && customerGranted.Count > 0)
            {
                foreach (var customerId in customerGranted)
                {
                    var defaultTrainning = _ctx.TreinoEmpresa.Where(te => te.EmpresaId == customerId && te.TreinoId == trainningId).FirstOrDefault();
                    if (!customers.Contains(customerId))
                    {
                        if (defaultTrainning != null)
                        {
                            _ctx.TreinoEmpresa.Remove(defaultTrainning);
                        }
                    }
                    else
                    {
                        if (defaultTrainning == null)
                        {
                            defaultTrainning = new Repository.TreinoEmpresa();
                            defaultTrainning.EmpresaId = customerId;
                            defaultTrainning.TreinoId = trainningId;
                            defaultTrainning.Cadastro = DateTime.Now;
                            _ctx.Entry(defaultTrainning).State = System.Data.EntityState.Added;
                        }
                    }
                    _ctx.SaveChanges();
                }
            }
        }

        public bool VerifyProfessorTrainning(long trainningId, List<Repository.PessoaEmpresas> peopleCustomer)
        {
            var professorId = peopleCustomer.Where(pc => pc.PessoaTipoId == 2).Select(pc => pc.PessoaId).FirstOrDefault();
            if (professorId != null && professorId > 0)
            {
                var trainning = _ctx.TreinoProfessor.Where(tp => tp.PessoaId == professorId && tp.TreinoId == trainningId).Select(tp => true).FirstOrDefault();

            }
            return false;
        }

        public List<int> VerifyCustomerTrainnings(long trainningId, List<Repository.PessoaEmpresas> peopleCustomer)
        {
            var customerIds = peopleCustomer.Where(pc => pc.PessoaTipoId > 2).Select(pc => pc.EmpresaId).ToList();
            if (customerIds != null && customerIds.Count > 0)
            {
                return (from te in _ctx.TreinoEmpresa
                        where customerIds.Contains(te.EmpresaId)
                        && te.TreinoId == trainningId
                        select te.EmpresaId).ToList();
            }
            return null;
        }

        public void UseDefaultTrainning(long peopleId, long trainningId, long userId)
        {
            var defaultTrainning = _ctx.Treinos.Include("TreinoExercicios").Where(t => t.ID == trainningId).FirstOrDefault();
            _ctx.Entry(defaultTrainning).State = System.Data.EntityState.Detached;
            defaultTrainning.ID = 0;
            defaultTrainning.PessoaTreino.Add(new Repository.PessoaTreino
                                                    {
                                                        Inicio = DateTime.Now,
                                                        PessoaId = peopleId
                                                    });
            defaultTrainning.TreinoExercicios = _ctx.TreinoExercicios.Where(te => te.TreinoId == trainningId).ToList();
            foreach (var exercise in defaultTrainning.TreinoExercicios)
            {
                _ctx.Entry(exercise).State = System.Data.EntityState.Detached;
                exercise.ID = 0;
                exercise.TreinoId = 0;
                _ctx.Entry(exercise).State = System.Data.EntityState.Added;                
            }
            _ctx.Entry(defaultTrainning).State = System.Data.EntityState.Added;
            _ctx.SaveChanges();
        }
    }
}
