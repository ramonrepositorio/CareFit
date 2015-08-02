using CareFit.Domain.BLL.PeopleRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFit.Domain.BLL
{

    public class PeopleBLL : BaseBLL
    {
        public List<Repository.Pessoas> GetPeoples()
        {
            return _ctx.Pessoas.ToList();
        }
        public List<Repository.PessoaTipos> GetPeopleTypes()
        {
            return _ctx.PessoaTipos.ToList();
        }

        public Repository.Pessoas GetPeople(long peopleId)
        {
            return _ctx.Pessoas.Where(p => p.ID == peopleId).FirstOrDefault();
        }
        public Repository.Pessoas Save(Repository.Pessoas people)
        {
            if (people.ID == 0)
            {
                people.Cadastro = DateTime.Now;
                people.Senha = new Utils.Cryptography.EncryptMd5().GetHash("mudar123");
                _ctx.Pessoas.Add(people);
            }
            else
            {
                var oldPeple = GetPeople(people.ID);

                if (string.IsNullOrEmpty(people.Senha))
                {
                    people.Senha = oldPeple.Senha;
                }
                if (people.ProfessorPessoaId.HasValue == false)
                {
                    people.ProfessorPessoaId = oldPeple.ProfessorPessoaId;
                }
                if (people.Cadastro == DateTime.MinValue)
                {
                    people.Cadastro = oldPeple.Cadastro;
                }
                if (string.IsNullOrEmpty(people.Email))
                {
                    people.Email = oldPeple.Email;
                }
                //Manobra para conseguir utilizar dois arquivos de mesmo id na memoria e persistir apenas um!!
                _ctx.Entry(people).State = System.Data.EntityState.Detached;
                _ctx.Entry(oldPeple).State = System.Data.EntityState.Detached;


                _ctx.Pessoas.Attach(people);
                _ctx.Entry(people).State = System.Data.EntityState.Modified;
                if (people.PessoaEmpresas != null)
                {
                    if (people.PessoaEmpresas.Count > 0)
                    {
                        foreach (var peopleCustomer in people.PessoaEmpresas)
                        {
                            if (peopleCustomer.ID == 0)
                            {
                                //_ctx.PessoaEmpresas.Add(peopleCustomer);
                            }
                            else
                            {
                                _ctx.PessoaEmpresas.Attach(peopleCustomer);
                                _ctx.Entry(peopleCustomer).State = System.Data.EntityState.Modified;
                            }
                        }
                    }
                }

            }
            try
            {
                _ctx.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return people;
        }
        public List<Repository.PessoaEmpresas> GetPeopleCustomers(long peopleId)
        {
            return _ctx.PessoaEmpresas.Where(pe => pe.PessoaId == peopleId && pe.Ativo == true).ToList();
        }

        public Repository.PessoaEmpresas GetPeopleCustomer(long peopleId, int customerId)
        {
            return _ctx.PessoaEmpresas.Where(pe => pe.PessoaId == peopleId && pe.EmpresaId == customerId).FirstOrDefault();
        }

        public List<Repository.Pessoas> GetPeoples(long userId, int peopleTypeId, string peopleName, string peopleCpf)
        {
            var query = (from peU in _ctx.PessoaEmpresas
                         join peP in _ctx.PessoaEmpresas
                         on peU.EmpresaId equals peP.EmpresaId
                         join p in _ctx.Pessoas
                         on peP.PessoaId equals p.ID
                         where peU.PessoaId == userId
                         && peU.PessoaTipoId > 2
                         && peU.Ativo == true
                         select p);
            if (peopleTypeId > 0)
            {
                //query = query.Where(p => p);
            }
            if (!string.IsNullOrEmpty(peopleCpf))
            {
                query = query.Where(p => p.Cpf == peopleCpf);
            }
            if (!string.IsNullOrEmpty(peopleName))
            {
                query = query.Where(p => (p.Nome + " " + p.Sobrenome).Contains(peopleName));
            }
            return query.ToList();
        }

        public Domain.Repository.Pessoas GetPeople(string mail)
        {
            return _ctx.Pessoas.Where(p => p.Email == mail).FirstOrDefault();
        }

        public Repository.PessoaSolicitacoes RequestSave(Repository.PessoaSolicitacoes customerRequest)
        {
            if (customerRequest.ID == 0)
            {
                _ctx.PessoaSolicitacoes.Add(customerRequest);
            }
            else
            {
                _ctx.PessoaSolicitacoes.Attach(customerRequest);
                _ctx.Entry(customerRequest).State = System.Data.EntityState.Modified;
            }
            _ctx.SaveChanges();
            return customerRequest;
        }

        public List<Repository.Pessoas> GetStudentPeople(ICollection<Repository.PessoaEmpresas> customerPeoples, string name, string cpf)
        {
            var students = new List<Repository.Pessoas>();

            // Pegando alunos caso a pessoa logada seja cordenador de alguma empresa
            var customerIds = customerPeoples.Where(cp => cp.PessoaTipoId >= 3).Select(cp => cp.EmpresaId).ToList();
            if (customerIds != null && customerIds.Count > 0)
            {
                var studentByCustomer = (from pe in _ctx.PessoaEmpresas
                                         join p in _ctx.Pessoas
                                             on pe.PessoaId equals p.ID
                                         where customerIds.Contains(pe.EmpresaId)
                                         select p
                             ).ToList();
                if (studentByCustomer != null && studentByCustomer.Count > 0)
                {
                    students.AddRange(studentByCustomer);
                }
            }

            //pegando os alunos do professor logado    
            var professorId = customerPeoples.Where(cp => cp.PessoaTipoId == 2).Select(cp => cp.PessoaId).FirstOrDefault();
            if (professorId > 0)
            {
                var studentsByProfessor = _ctx.Pessoas.Where(p => p.ProfessorPessoaId == professorId).ToList();
                if (studentsByProfessor != null && studentsByProfessor.Count > 0)
                {
                    students.AddRange(studentsByProfessor);
                }

                //pegando alunos que estejam sem professor 
                if (customerIds == null)
                {
                    customerIds = customerPeoples.Where(cp => cp.PessoaTipoId >= 2).Select(cp => cp.EmpresaId).ToList();
                    var studentWithOutProfessor = (from pe in _ctx.PessoaEmpresas
                                                   join p in _ctx.Pessoas
                                                       on pe.PessoaId equals p.ID
                                                   where customerIds.Contains(pe.EmpresaId)
                                                      && p.ProfessorPessoaId.HasValue == false
                                                   select p).ToList();

                    if (studentWithOutProfessor != null && studentWithOutProfessor.Count > 0)
                    {
                        students.AddRange(studentWithOutProfessor);
                    }

                }
            }
            return students;
        }



        public List<Repository.Pessoas> GetProfessors(List<long> professorIds)
        {
            List<Repository.Pessoas> professors = null;
            if (professorIds != null && professorIds.Count > 0)
            {
                professors = _ctx.Pessoas.Where(p => professorIds.Contains(p.ID)).ToList();
            }
            return professors;
        }

        public Repository.Pessoas Get(long peopleId)
        {
            return _ctx.Pessoas.Where(p => p.ID == peopleId).FirstOrDefault();
        }
        public Repository.Pessoas Get(string mail, string token)
        {
            return (from p in _ctx.Pessoas
                    join pt in _ctx.PessoaToken
                        on p.ID equals pt.PessoaId
                    where p.Email == mail
                    && pt.Token == token
                    && pt.Cadastro < DateTime.Now
                    && pt.Vencimento > DateTime.Now
                    select p).FirstOrDefault();
        }

        public List<Repository.Pessoas> GetPeopleByFilter(string search)
        {
            return _ctx.Pessoas.Where(p => (p.Nome + "" + p.Sobrenome).Contains(search) || p.Email.Contains(search)).ToList();
        }

        public Repository.PessoaTipos GetPeopleType(int peopleTypeId)
        {
            return _ctx.PessoaTipos.Where(pt => pt.ID == peopleTypeId).FirstOrDefault();
        }

        public Repository.PessoaSolicitacoes AddPeopleFriend(long peopleId, long peopleFriendId)
        {
            Repository.PessoaSolicitacoes peopleRequest = null;
            var people = this.Get(peopleId);
            var peopleFriend = _ctx.PessoaAmigos.Where(pa => pa.PessoaId == peopleId && pa.PessoaAmigoId == peopleFriendId).FirstOrDefault();
            if (peopleFriend == null)
            {
                peopleRequest = (from pra in _ctx.PessoaSolicitacaoAmizades
                                 join pr in _ctx.PessoaSolicitacoes
                                 on pra.PessoaSolicitacaoId equals pr.ID
                                 where pra.PessoaAmigoId == peopleId
                                 && pr.PessoaId == peopleFriendId
                                 && pr.DataResposta.HasValue == false
                                 select pr).FirstOrDefault();
                if (peopleRequest == null)
                {
                    peopleRequest = new Repository.PessoaSolicitacoes();
                    peopleRequest.PessoaSolicitacaoTipoId = (int)PeopleRequestTypes.FriendRequest;
                    peopleRequest.DataSolicitacao = DateTime.Now;
                    peopleRequest.Titulo = "Solicitação de Amizade";
                    peopleRequest.Descricao = string.Format("{0} {1} ", people.Nome, people.Sobrenome);
                    peopleRequest.PessoaId = peopleFriendId;
                    peopleRequest.PessoaSolicitacaoAmizades.Add(new Repository.PessoaSolicitacaoAmizades
                    {
                        PessoaAmigoId = peopleId
                    });
                    _ctx.Entry(peopleRequest).State = System.Data.EntityState.Added;
                    _ctx.SaveChanges();
                }
                else
                {
                    throw new Exception("Já existe uma solicitação de amizade pendente para " + string.Format("{0} {1} !", people.Nome, people.Sobrenome));
                }
            }
            else
            {
                throw new Exception("Você já é amigo de " + string.Format("{0} {1} !", people.Nome, people.Sobrenome));
            }
            return peopleRequest;
        }

        public List<Repository.Pessoas> GetPeopleFriends(long peopleId)
        {
            var friends = (from pa in _ctx.PessoaAmigos
                           join p in _ctx.Pessoas
                           on pa.PessoaAmigoId equals p.ID
                           where pa.PessoaId == peopleId
                           select p).ToList();
            
            foreach (var friend in friends)
            {
                _ctx.Entry(friend).Reference("Imagens").Load();
            }
            
            return friends;
        }
    }
}
