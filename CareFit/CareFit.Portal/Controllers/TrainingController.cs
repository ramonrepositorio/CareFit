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
    public class TrainingController : Controller
    {

        public ActionResult Peoples()
        {
            var model = new Models.Trainig.PeoplesVM();
            return View(model);
        }
        public JsonResult DoneTrainings()
        {
            var loggedUser = Session.GetLoggedUser();
            var trainningBll = new Domain.BLL.TrainningBLL();
            var doneTrainnings = trainningBll.GetDoneTrainings(loggedUser.ID);

            if (doneTrainnings != null)
            {

                var response = doneTrainnings.Select(dt => new
                {
                    title = dt.PessoaTreino.Treinos.Titulo,
                    start = DateTimeToUnixTimestamp(dt.Marcacao),
                    color = (dt.PessoaTreino.Termino.HasValue ? "#808080" : (string.IsNullOrEmpty(dt.PessoaTreino.Treinos.Cor) ? "#3a87ad" : "#" + dt.PessoaTreino.Treinos.Cor)),
                    className = "trainning-calendar-item"
                }).ToList();
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewTrainning(long trainningId)
        {
            var model = new Models.Trainig.ViewTrainningVM();
            var loggedUser = Session.GetLoggedUser();
            model.People = loggedUser;
            var trainningBll = new Domain.BLL.TrainningBLL();
            model.PeopleTrainning = trainningBll.GetPeopleTrainning(trainningId);
            model.Trainning = trainningBll.GetTrainningToView(model.PeopleTrainning.TreinoId);
            model.Professor = new Domain.BLL.PeopleBLL().GetPeople(model.Trainning.PessoaCadastroTreino);
            return View(model);

        }
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }

        public ActionResult PeoplesList(string name, string cpf)
        {
            var model = new Models.Trainig.PeoplesListVM();
            var loggedUser = Session.GetLoggedUser();
            var peopleBll = new Domain.BLL.PeopleBLL();
            model.Peoples = peopleBll.GetStudentPeople(loggedUser.PessoaEmpresas, name, cpf);
            var professorIds = model.Peoples.Where(p => p.ProfessorPessoaId.HasValue).GroupBy(p => p.ProfessorPessoaId).Select(p => p.First().ProfessorPessoaId.Value).ToList();

            model.Professors = peopleBll.GetProfessors(professorIds);
            return View(model);
        }
        public ActionResult Edit(long trainningId, long? peopleId)
        {
            var model = new Models.Trainig.EditVM();
            var trainningBll = new Domain.BLL.TrainningBLL();
            var loggedUser = Session.GetLoggedUser();
            if (peopleId.HasValue)
            {
                model.PeopleId = peopleId.Value;
            }
            if (trainningId != 0)
            {
                model.Trainning = trainningBll.Get(trainningId);
                model.Trainning.TreinoExercicios = trainningBll.GetTrainningExercises(trainningId);

            }
            else
            {
                model.Trainning = new Domain.Repository.Treinos();
            }


            if (peopleId.HasValue == false)
            {
                model.DefaultTrainnings = new Models.Trainig.DefaultTrainningREQ();
                model.DefaultTrainnings.Professor = trainningBll.VerifyProfessorTrainning(trainningId, loggedUser.PessoaEmpresas.ToList());
                model.DefaultTrainnings.Customers = trainningBll.VerifyCustomerTrainnings(trainningId, loggedUser.PessoaEmpresas.ToList());
                var professorCustomerIds = loggedUser.PessoaEmpresas.Where(cp => cp.PessoaTipoId == 2).Select(cp => cp.EmpresaId).ToList();
                if (professorCustomerIds != null && professorCustomerIds.Count > 0)
                {
                    model.Professor = true;
                }
                var cordenatorCustomers = loggedUser.PessoaEmpresas.Where(cp => cp.PessoaTipoId > 2).Select(cp => cp.Empresas).ToList();
                if (cordenatorCustomers != null && cordenatorCustomers.Count > 0)
                {
                    model.Coordinator = cordenatorCustomers;
                }

            }

            model.TrainnigTypes = trainningBll.GetTrainningTypes();
            return View(model);
        }



        public long Save(string jsonTrainning, string jsonDefaultTrainningExercises, string jsonDefaultTrainning, long? peopleId)
        {
            var format = "dd/MM/yyyy"; // your datetime format
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var trainning = JsonConvert.DeserializeObject<Domain.Repository.Treinos>(jsonTrainning, dateTimeConverter);
            var defaultTrainning = JsonConvert.DeserializeObject<Models.Trainig.DefaultTrainningREQ>(jsonDefaultTrainning, dateTimeConverter);
            var defaultTrainningExercises = JsonConvert.DeserializeObject<Models.Trainig.DefaultTrainningExerciseREQ>(jsonDefaultTrainningExercises, dateTimeConverter);
            if (defaultTrainningExercises != null)
            {
                foreach (var exercises in trainning.TreinoExercicios)
                {
                    if (exercises.ID < 0)
                    {
                        exercises.ID = 0;
                    }
                    if (trainning.TreinoExercicios != null)
                    {
                        if (defaultTrainningExercises.DefaultTrainningCiclos > 0 && defaultTrainningExercises.DefaultTrainningInterval > 0 && defaultTrainningExercises.DefaultTrainningTimes > 0)
                        {
                            exercises.Ciclos = defaultTrainningExercises.DefaultTrainningCiclos;
                            exercises.Repeticoes = defaultTrainningExercises.DefaultTrainningTimes;
                            exercises.Descanso = defaultTrainningExercises.DefaultTrainningInterval;
                        }
                    }
                }
            }
            if (trainning.ID == 0 && peopleId.HasValue)
            {
                if (peopleId.Value > 0)
                {
                    var peopleTrainning = new Domain.Repository.PessoaTreino();
                    peopleTrainning.Inicio = DateTime.Now;
                    peopleTrainning.PessoaId = peopleId.Value;
                    trainning.PessoaTreino.Add(peopleTrainning);
                }
            }
            var trainningBll = new Domain.BLL.TrainningBLL();



            var loggedUser = Session.GetLoggedUser();
            trainning.PessoaCadastroTreino = loggedUser.ID;
            trainning = trainningBll.Save(trainning);


            if (peopleId.Value == 0 && defaultTrainning != null)
            {
                trainningBll.BindProfessorDefaultTrainning(defaultTrainning.Professor, loggedUser.ID, trainning.ID);
                if (defaultTrainning.Customers == null)
                {
                    defaultTrainning.Customers = new List<int>();
                }
                trainningBll.BindCustomerDefaultTrainning(trainning.ID, defaultTrainning.Customers, loggedUser.PessoaEmpresas.ToList());
            }

            return trainning.ID;
        }


        public ActionResult PeopleDetails(long peopleId)
        {
            var model = new Models.Trainig.PeopleDetailsVM();
            var peopleBll = new Domain.BLL.PeopleBLL();
            var trainningBll = new Domain.BLL.TrainningBLL();
            model.People = peopleBll.GetPeople(peopleId);
            model.Professor = peopleBll.GetPeople(model.People.ProfessorPessoaId.Value);
            model.Trainnings = trainningBll.GetTrainnings(peopleId);
            if (model.People.ImagemId.HasValue)
            {
                model.People.Imagens = new Domain.BLL.ImagesBLL().Get(model.People.ImagemId.Value);    
            }
            
            if (model.People.Imagens == null)
            {
                model.People.Imagens = new Domain.Repository.Imagens { Url = "/Uploads/Images/no-image.png" };
            }            

            return View(model);
        }

        [HttpPost]
        public long BindProfessor(long peopleId)
        {
            var loggedUser = Session.GetLoggedUser();
            var trainnignBll = new Domain.BLL.TrainningBLL();

            return trainnignBll.BindProfessor(loggedUser.ID, peopleId).ID;
        }
        public ActionResult Defaults()
        {
            return View();
        }
        public ActionResult CheckTrainning(long peopleTrainningId)
        {
            var model = new Models.Trainig.CheckTrainningVM();
            var trainningBll = new Domain.BLL.TrainningBLL();
            model.PeopleTrainning = trainningBll.GetPeopleTrainning(peopleTrainningId);
            model.Trainning = trainningBll.Get(model.PeopleTrainning.TreinoId);
            model.LastTrainnigDone = trainningBll.GetLastPeopleTrainningDone(peopleTrainningId);
            return View(model);
        }
        public int ConfirmCheckTrainning(long peopleTrainningId)
        {
            var trainningBll = new Domain.BLL.TrainningBLL();
            return trainningBll.CheckTrainning(peopleTrainningId);

        }
        public ActionResult PrintTrainning(long peopleTrainningId)
        {
            var model = new Models.Trainig.PrintTrainningVM();
            var trainningBll = new Domain.BLL.TrainningBLL();
            model.PeopleTrainning = trainningBll.GetPeopleTrainning(peopleTrainningId);
            model.Trainning = trainningBll.Get(model.PeopleTrainning.TreinoId);
            //model.LastTrainnigDone = trainningBll.GetLastPeopleTrainningDone(peopleTrainningId);
            return View(model);
        }

        public ActionResult GetDefaultTrainnings(long? peopleId = null)
        {
            var model = new Models.Trainig.GetDefaultTrainningsVM();
            model.PeopleId = peopleId;
            var trainningBLL = new Domain.BLL.TrainningBLL();
            var loggedUser = Session.GetLoggedUser();
            model.Professors = trainningBLL.GetProfessorDefaultTrainnings(loggedUser.PessoaEmpresas.ToList());
            model.Customers = trainningBLL.GetCustomersDefaultTrainnings(loggedUser.PessoaEmpresas.ToList());
            return View(model);
        }
        public ActionResult ListDefaultTrainnings(long? professorId, int? customerId, long? peopleId)
        {
            var model = new Models.Trainig.ListDefaultTrainningsVM();
            var trainningBll = new Domain.BLL.TrainningBLL();
            if (peopleId <= 0)
            {
                peopleId = null;
            }
            model.PeopleId = peopleId;
            var loggedUser = Session.GetLoggedUser();
            model.Trainnings = trainningBll.GetDefaultTrainnings(professorId, customerId, loggedUser.PessoaEmpresas.ToList());
            return View(model);
        }

        [HttpPost]
        public bool UseDefaultTrainning(long peopleId, long trainningId)
        {
            var loggedUser = Session.GetLoggedUser();
            var trainningBll = new Domain.BLL.TrainningBLL();
            trainningBll.UseDefaultTrainning(peopleId, trainningId, loggedUser.ID);
            return true;
        }
    }
}
