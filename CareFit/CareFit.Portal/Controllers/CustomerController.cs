using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareFit.Portal.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            var model = new Models.Customer.IndexVM();
            return View();
        }

        public ActionResult Edit()
        {
            var model = new Models.Customer.EditVM();
            return View(model);
        }

        public ActionResult Financial()
        {
            var model = new Models.Customer.FinancialVM();
            return View(model);
        }
        public ActionResult Pricing() {
            var model = new Models.Customer.PricingVM();
            return View(model);
        }

    }
}
