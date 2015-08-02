using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CareFit.Domain.BLL.PeopleRequest
{
    public enum PeopleRequestTypes
    {
        CustomerRequest = 1,
        FriendRequest = 2
    }
    public class PeopleRequestBLL : BaseBLL
    {
        public Repository.PessoaSolicitacoes GetPendingPeopleCustomerRequest(long peopleId, int customerId)
        {
            return (from ps in _ctx.PessoaSolicitacoes.Include("PessoaSolicitacaoEmpresa")
                    join pse in _ctx.PessoaSolicitacaoEmpresa
                    on ps.ID equals pse.PessoaSolicitacaoId
                    where ps.PessoaId == peopleId
                    && pse.EmpresaId == customerId
                    && ps.DataResposta == null
                    select ps).FirstOrDefault();
        }
        public List<Repository.PessoaSolicitacoes> GetPessoaSolicitacoes(long peopleId, DateTime? dateFilter)
        {
            var query = (from ps in _ctx.PessoaSolicitacoes
                         where ps.PessoaId == peopleId
                         select ps
                    );
            if (dateFilter.HasValue)
            {
                query = query.Where(ps => ps.DataSolicitacao >= dateFilter);
            }
            var requests = query.ToList();
            foreach (var req in requests)
            {

            }
            return requests;
        }

        public bool RespondRequest(long requestId, bool answer, long peopleId)
        {
            var peopleRequest = _ctx.PessoaSolicitacoes.Where(ps => ps.ID == requestId && ps.PessoaId == peopleId && ps.DataResposta.HasValue == false).FirstOrDefault();
            if (peopleRequest != null)
            {
                peopleRequest.DataResposta = DateTime.Now;
                using (TransactionScope ts = new TransactionScope())
                {
                    
                    if (peopleRequest.PessoaSolicitacaoTipoId == (int)PeopleRequestTypes.CustomerRequest)
                    {
                        var peopleRequestCustomer = _ctx.PessoaSolicitacaoEmpresa.Where(pse => pse.PessoaSolicitacaoId == peopleRequest.ID).FirstOrDefault();
                        peopleRequestCustomer.Resposta = answer;
                        if (answer)
                        {
                            var peopleCustomer = _ctx.PessoaEmpresas.Where(pe => pe.PessoaId == peopleId && pe.EmpresaId == peopleRequestCustomer.EmpresaId).FirstOrDefault();
                            if (peopleCustomer == null)
                            {
                                new Domain.Repository.PessoaEmpresas();
                            }
                            peopleCustomer.Ativo = true;
                            peopleCustomer.EmpresaId = peopleRequestCustomer.EmpresaId;
                            peopleCustomer.PessoaId = peopleId;
                            peopleCustomer.PessoaTipoId = 1; //aluno
                            if (peopleCustomer.ID == 0)
                            {
                                _ctx.PessoaEmpresas.Add(peopleCustomer);
                            }
                            else
                            {
                                _ctx.PessoaEmpresas.Attach(peopleCustomer);
                                _ctx.Entry(peopleCustomer).State = System.Data.EntityState.Modified;
                            }

                        }
                        _ctx.PessoaSolicitacaoEmpresa.Attach(peopleRequestCustomer);
                        _ctx.Entry(peopleRequestCustomer).State = System.Data.EntityState.Modified;
                    }
                    else if (peopleRequest.PessoaSolicitacaoTipoId == (int)PeopleRequestTypes.FriendRequest)
                    {
                        var peopleRequestFriend = _ctx.PessoaSolicitacaoAmizades.Where(pse => pse.PessoaSolicitacaoId == requestId).FirstOrDefault();
                        peopleRequestFriend.Aceito = answer;
                        if (answer)
                        {
                            var peopleFriend1 = new Repository.PessoaAmigos();
                            var peopleFriend2 = new Repository.PessoaAmigos();
                            peopleFriend1.PessoaId = peopleRequest.PessoaId;
                            peopleFriend1.PessoaAmigoId = peopleRequestFriend.PessoaAmigoId;
                            peopleFriend1.Cadastro = DateTime.Now;
                            peopleFriend2.PessoaId = peopleRequestFriend.PessoaAmigoId;
                            peopleFriend2.PessoaAmigoId = peopleRequest.PessoaId; 
                            peopleFriend2.Cadastro = DateTime.Now;
                            _ctx.PessoaAmigos.Add(peopleFriend1);
                            _ctx.PessoaAmigos.Add(peopleFriend2);
                        }
                        _ctx.PessoaSolicitacaoAmizades.Attach(peopleRequestFriend);
                        _ctx.Entry(peopleRequestFriend).State = System.Data.EntityState.Modified;
                        
                    }
                    _ctx.PessoaSolicitacoes.Attach(peopleRequest);
                    _ctx.Entry(peopleRequest).State = System.Data.EntityState.Modified;
                    _ctx.SaveChanges();
                    ts.Complete();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public Repository.PessoaSolicitacoes Get(long peopleRequestId)
        {
            return _ctx.PessoaSolicitacoes.Where(ps => ps.ID == peopleRequestId).FirstOrDefault();
        }

        public string GetRequestImage(long requestId)
        {
            Repository.Imagens image = null;
            var request = Get(requestId);
            switch (request.PessoaSolicitacaoTipoId)
            {
                case (int)PeopleRequestTypes.FriendRequest:
                    image = GetRequestFriendImage(requestId);
                    break;
                case (int)PeopleRequestTypes.CustomerRequest:
                    image = GetRequestCustomerImage(requestId);
                    break;
            }
            if (image != null)
            {
                return image.Url;
            }
            return null;
        }

        private Repository.Imagens GetRequestCustomerImage(long requestId)
        {
            return (from pse in _ctx.PessoaSolicitacaoEmpresa
                    join e in _ctx.Empresas
                    on pse.EmpresaId equals e.ID
                    join i in _ctx.Imagens
                    on e.ImagemID equals i.ID
                    select i).FirstOrDefault();
        }

        private Repository.Imagens GetRequestFriendImage(long requestId)
        {
            return (from psa in _ctx.PessoaSolicitacaoAmizades
                    join p in _ctx.Pessoas
                    on psa.PessoaAmigoId equals p.ID
                    join i in _ctx.Imagens
                    on p.ImagemId equals i.ID
                    where psa.PessoaSolicitacaoId == requestId
                    select i).FirstOrDefault();
        }
    }
}
