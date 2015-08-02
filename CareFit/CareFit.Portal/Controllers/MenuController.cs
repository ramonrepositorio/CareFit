using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareFit.Portal.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        public ActionResult GetAutorizedMenu()
        {
            var menuBll = new Domain.BLL.MenuBLL();
            var model = new Models.Menu.GetAutorizedMenuVM();

            model.Menus = menuBll.GetAutorizedMenus(Session.GetLoggedUser().ID);
            return View(model);
            
        }
    }
}
