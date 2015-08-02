using CareFit.Domain.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareFit.Portal.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {

        
        public ActionResult Index()
        {
            var model = new Models.People.IndexVM();
            var peopleBll = new Domain.BLL.PeopleBLL();
            model.PeopleTypes = peopleBll.GetPeopleTypes();
            model.LoggedUser = Session.GetLoggedUser();
            return View(model);
        }
        public ActionResult List(int peopleTypeId, string peopleName, string peopleCpf)
        {
            var model = new Models.People.ListVM();
            var peopleBll = new Domain.BLL.PeopleBLL();
            model.Peoples = peopleBll.GetPeoples(Session.GetLoggedUser().ID, peopleTypeId, peopleName, peopleCpf);
            return View(model);
        }
        public bool VerifeMail(string mail)
        {
            var peopleBll = new Domain.BLL.PeopleBLL();
            var people = peopleBll.GetPeople(mail);
            var success = false;
            if (people == null)
            {
                success = true;
            }

            return success;
        }
        [HttpGet]
        public JsonResult GetPeopleRequestPanel(bool firstCall)
        {
            var peopleRequestBll = new Domain.BLL.PeopleRequest.PeopleRequestBLL();
            var loggedUser = Session.GetLoggedUser();
            DateTime? lastUpdate = null;
            if (!firstCall)
            {
                lastUpdate = DateTime.Now.AddSeconds(-10);
            }
            
            var peopleRequests = peopleRequestBll.GetPessoaSolicitacoes(loggedUser.ID, lastUpdate);
            var result = peopleRequests.Select(pr => new
            {                
                ID = pr.ID,
                Title = pr.Titulo,
                Description = pr.Descricao,
                RequestDate = pr.DataSolicitacao.ToString("dd/MM/yyyy hh:mm:ss"),
                ResponseDate = (pr.DataResposta.HasValue ? pr.DataResposta.Value.ToString("dd/MM/yyyy hh:mm:ss") : null),
                RequestId = pr.ID,
                ImageUrl = peopleRequestBll.GetRequestImage(pr.ID)

            }).ToList();
           

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public bool RespondRequest(long requestId, bool answer)
        {
            var peopleRequestBll = new Domain.BLL.PeopleRequest.PeopleRequestBLL();
            var loggedUser = Session.GetLoggedUser();
            return peopleRequestBll.RespondRequest(requestId, answer, loggedUser.ID);
        }

        public JsonResult GetlayoutInfo()
        {
            var loggedUser = Session.GetLoggedUser();
            var UrlAvatarImage = new Domain.BLL.ImagesBLL().GetNoImage().Url;
            if (loggedUser.ImagemId.HasValue)
            {
                var avatarImage = new Domain.BLL.ImagesBLL().Get(loggedUser.ImagemId.Value);
                if (avatarImage != null)
                {
                    if (!string.IsNullOrEmpty(avatarImage.Url))
                    {
                        UrlAvatarImage = avatarImage.Url;
                    }
                }
            }


            var result = new { UserName = loggedUser.Nome, UserLastName = loggedUser.Sobrenome, UrlAvatarImage = UrlAvatarImage };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public long SaveCustomerRequest(int customerId, string email)
        {
            var loggedUser = Session.GetLoggedUser();
            if (loggedUser != null)
            {
                var peopleBll = new Domain.BLL.PeopleBLL();
                var people = peopleBll.GetPeople(email);
                if (people == null)
                {
                    throw new Exception("Email não encontrado");
                }
                var customer = loggedUser.PessoaEmpresas.Where(pe => pe.EmpresaId == customerId).FirstOrDefault();
                if (customer == null)
                {
                    throw new Exception("Usuario logado nao tem acesso a solicitar vinculação para essa empresa");
                }
                var peopleRequestBll = new Domain.BLL.PeopleRequest.PeopleRequestBLL();
                var customerRequest = peopleRequestBll.GetPendingPeopleCustomerRequest(people.ID, customerId);
                if (customerRequest == null)
                {
                    customerRequest = new Domain.Repository.PessoaSolicitacoes();
                    customerRequest.DataSolicitacao = DateTime.Now;
                    customerRequest.Descricao = "A Empresa " + customer.Empresas.Nome + " esta solicitando acesso ao seus dados cadastrais, acesso para habilitar o seu cadastro como aluno";
                    customerRequest.Titulo = "Solicitacao de acesso";
                    customerRequest.PessoaId = people.ID;
                    customerRequest.PessoaSolicitacaoTipoId = (int)Domain.BLL.PeopleRequest.PeopleRequestTypes.CustomerRequest;
                    customerRequest.PessoaSolicitacaoEmpresa = new List<Domain.Repository.PessoaSolicitacaoEmpresa>();
                    customerRequest.PessoaSolicitacaoEmpresa.Add(new Domain.Repository.PessoaSolicitacaoEmpresa { EmpresaId = customerId });
                }
                else
                {
                    throw new Exception("Já existe uma solicitação pendente para essa pessoa");
                }

                return peopleBll.RequestSave(customerRequest).ID;

            }
            throw new Exception("Usuario não identificado");

        }

        [HttpPost]
        public long Save(string jsonPeople)
        {
            var format = "dd/MM/yyyy"; // your datetime format
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var people = JsonConvert.DeserializeObject<Domain.Repository.Pessoas>(jsonPeople, dateTimeConverter);
            if (people.ImagemId <= 0)
            {
                people.ImagemId = null;
            }
            people = new Domain.BLL.PeopleBLL().Save(people);
            if (people.ImagemId.HasValue)
            {
                var loggedUser = Session.GetLoggedUser();
                if (people.ID == loggedUser.ID)
                {
                    //var image = new Domain.BLL.ImagesBLL().Get(people.ImagemId.Value);
                    loggedUser.ImagemId = people.ImagemId;
                }
            }
            return people.ID;
        }

        public ActionResult EditPerfil()
        {
            var loggedUser = Session.GetLoggedUser();
            var peopleId = loggedUser.ID;
            var mail = loggedUser.Email;

            var model = new Models.People.EditVM();
            model.States = new Utils.Cep.Estados().GetAll();

            var peopleBll = new Domain.BLL.PeopleBLL();
            model.Image = new Domain.Repository.Imagens { Url = "/Uploads/Images/no-image.png" };
            model.PeopleCustomers = new List<Domain.Repository.PessoaEmpresas>();
            foreach (var peopleCustomerUser in loggedUser.PessoaEmpresas.ToList())
            {
                if (peopleCustomerUser.PessoaTipoId > 2)
                {
                    var peopleCustomerEdit = peopleBll.GetPeopleCustomer(peopleId, peopleCustomerUser.EmpresaId);
                    if (peopleCustomerEdit == null)
                    {
                        peopleCustomerEdit = new Domain.Repository.PessoaEmpresas();
                        peopleCustomerEdit.EmpresaId = peopleCustomerUser.EmpresaId;
                        peopleCustomerEdit.Empresas = peopleCustomerUser.Empresas;

                    }
                    else
                    {
                        peopleCustomerEdit.Empresas = Session.GetLoggedUser().PessoaEmpresas.ToList().Where(pe => pe.EmpresaId == peopleCustomerEdit.EmpresaId).FirstOrDefault().Empresas;

                    }
                    model.PeopleCustomers.Add(peopleCustomerEdit);
                }
            }


            if (peopleId == 0)
            {
                model.People = new Domain.Repository.Pessoas();
                if (!string.IsNullOrEmpty(mail))
                {
                    model.People.Email = mail;
                }
            }
            else
            {
                model.People = peopleBll.GetPeople(peopleId);
                if (model.People.ImagemId.HasValue)
                {
                    model.Image = new Domain.BLL.ImagesBLL().Get(model.People.ImagemId.Value);
                }
            }
            model.PeopleTypes = peopleBll.GetPeopleTypes();
            return View("Edit", model);
        }

        public ActionResult Edit(int peopleId = 0, string mail = null)
        {
            var model = new Models.People.EditVM();
            model.States = new Utils.Cep.Estados().GetAll();

            var peopleBll = new Domain.BLL.PeopleBLL();

            model.PeopleCustomers = new List<Domain.Repository.PessoaEmpresas>();
            model.Image = new Domain.Repository.Imagens { Url = "/Uploads/Images/no-image.png" };

            foreach (var peopleCustomerUser in Session.GetLoggedUser().PessoaEmpresas.ToList())
            {
                if (peopleCustomerUser.PessoaTipoId > 2)
                {
                    var peopleCustomerEdit = peopleBll.GetPeopleCustomer(peopleId, peopleCustomerUser.EmpresaId);
                    if (peopleCustomerEdit == null)
                    {
                        peopleCustomerEdit = new Domain.Repository.PessoaEmpresas();
                        peopleCustomerEdit.EmpresaId = peopleCustomerUser.EmpresaId;
                        peopleCustomerEdit.Empresas = peopleCustomerUser.Empresas;

                    }
                    else
                    {
                        peopleCustomerEdit.Empresas = Session.GetLoggedUser().PessoaEmpresas.ToList().Where(pe => pe.EmpresaId == peopleCustomerEdit.EmpresaId).FirstOrDefault().Empresas;

                    }
                    model.PeopleCustomers.Add(peopleCustomerEdit);
                }

            }


            if (peopleId == 0)
            {
                model.People = new Domain.Repository.Pessoas();
                if (!string.IsNullOrEmpty(mail))
                {
                    model.People.Email = mail;
                }
            }
            else
            {
                model.People = peopleBll.GetPeople(peopleId);
                if (model.People.ImagemId.HasValue)
                {
                    model.Image = new Domain.BLL.ImagesBLL().Get(model.People.ImagemId.Value);
                }

            }
            model.PeopleTypes = peopleBll.GetPeopleTypes();
            return View(model);
        }
        public ActionResult GetPeopleAheadAjax(string search)
        {
            var exerciseBll = new Domain.BLL.ExerciseBLL();
            var loggedUser = Session.GetLoggedUser();

            var peoples = new Domain.BLL.PeopleBLL().GetPeopleByFilter(search).Where(p => p.ID != loggedUser.ID).ToList();
            var response = peoples.Select(p => new
            {
                description = p.Nome + " " + p.Sobrenome,
                ID = p.ID
            }).ToList();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPeopleDetail(long peopleId)
        {
            var peopleBll = new Domain.BLL.PeopleBLL();
            var customerBll = new Domain.BLL.CustomerBLL();
            var people = peopleBll.Get(peopleId);

            var peopleCustomers = peopleBll.GetPeopleCustomers(peopleId).Select(pe => new { peopleType = peopleBll.GetPeopleType(pe.PessoaTipoId).Descricao, customer = customerBll.GetCustomer(pe.EmpresaId).Nome }).ToList();
            var picture = new Domain.BLL.ImagesBLL().GetNoImage().Url;
            if (people.ImagemId.HasValue)
            {
                picture = new ImagesBLL().Get(people.ImagemId.Value).Url;
            }
            var result = new
            {
                customers = peopleCustomers,
                picture = picture
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SearchFriend()
        {
            return View();
        }
        [HttpPost]
        public long AddFriend(long peopleId)
        {
            var loggedUser = Session.GetLoggedUser();
            var peopleBll = new Domain.BLL.PeopleBLL();
            var peopleFriends = peopleBll.AddPeopleFriend(loggedUser.ID, peopleId);
            return peopleFriends.ID;
        }
    }
}
