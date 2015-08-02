using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareFit.Portal.Controllers
{
    public class CepController : Controller
    {
        //
        // GET: /Cep/

        public ActionResult GetCep(string cep)
        {
            var cepResult =  new Utils.Cep.CEP(cep);
            return Json(cepResult, JsonRequestBehavior.AllowGet);
        }
    }
}
