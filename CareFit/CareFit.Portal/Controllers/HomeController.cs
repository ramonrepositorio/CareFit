using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareFit.Portal.Models.Authentication
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var loggedUser = Session.GetLoggedUser();
            if (loggedUser == null)
            {
                return RedirectToAction("Index", "Authentication");
            }
            var trainningBll = new Domain.BLL.TrainningBLL();
            var model = new Models.Menu.IndexVM();
            model.LoggedUser = loggedUser;
            model.PepleTrainnings = trainningBll.GetPeopleTrainnings(model.LoggedUser.ID);
            return View(model);
        }
        public ActionResult TopItens() {
            var loggedUser = Session.GetLoggedUser();
            var model = new Models.Home.TopItensVM();
            var trainningBll = new Domain.BLL.TrainningBLL();
            var openTrainnings = trainningBll.GetTrainnings(loggedUser.ID).Where(t => t.Termino.HasValue == false) ;
            var openTrainningIds = openTrainnings.Select( ot => ot.ID).ToList();
            model.TotalTrainningsSessions = openTrainnings.Sum(ot => ot.Treinos.Repeticoes);
            model.DoneTrainningsSessions = trainningBll.GetDoneTrainings(loggedUser.ID).Where(dt => openTrainningIds.Contains(dt.PessoaTreinoId)).Count();
            model.OpenTrainnings = openTrainnings.Count();
            return View(model);
        }

    }
}
